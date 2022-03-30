using System;
using System.Threading.Tasks;
using System.Net.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Insureity_Portal.Models;
using System.Text;

namespace Insureity_Portal.Services
{
    public class HomeService : IHomeService
    {
        private IConfiguration _configuration;
        

        public HomeService(IConfiguration configuration)
        {
            _configuration = configuration;

        }

        public async Task<HttpResponseMessage> CreatePolicyRequest(CreatePolicy createPolicy)
        {
            string policyBaseUri = _configuration.GetValue<string>("ServiceURIs:Policy");

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(policyBaseUri);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add("Accept", "application/json");
                client.DefaultRequestHeaders.Add("ContentType", "application/json");
                StringContent content = new StringContent(JsonConvert.SerializeObject(createPolicy), Encoding.UTF8, "application/json");
                var httpResponse = await client.PostAsync($"/api/Policy/createPolicy", content);
                return httpResponse;
            }
        }

        public async Task<HttpResponseMessage> IssuePolicyRequest(IssuePolicy issuePolicy)
        {
            string policyBaseUri = _configuration.GetValue<string>("ServiceURIs:Policy");

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(policyBaseUri);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add("Accept", "application/json");
                client.DefaultRequestHeaders.Add("ContentType", "application/json");

                StringContent content = new StringContent(JsonConvert.SerializeObject(issuePolicy), Encoding.UTF8, "application/json");
                var httpResponse = await client.PostAsync($"/api/Policy/issuePolicy", content);
                return httpResponse;
            }


        }
        public async Task<HttpResponseMessage> GetQuotesRequest(GetQuotes getQuotes)
        {
            string policyBaseUri = _configuration.GetValue<string>("ServiceURIs:Policy");
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(policyBaseUri);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add("Accept", "application/json");
                client.DefaultRequestHeaders.Add("ContentType", "application/json");

                int PropertyValue = getQuotes.PropertyValue;
                int BusinessValue = getQuotes.BusinessValue;
                string PropertyType = getQuotes.PropertyType;

                var httpResponse = await client.GetAsync($"/getQuotes/{PropertyValue}/{BusinessValue}/{PropertyType}");
                return httpResponse;
            }
        }

        public async Task<HttpResponseMessage> ViewPolicyRequest(ViewPolicy viewPolicy)
        {
            string policyBaseUri = _configuration.GetValue<string>("ServiceURIs:Policy");

            string ConsumerId = viewPolicy.ConsumerId;
            string BusinessId = viewPolicy.BusinessId;
            string PolicyId = viewPolicy.PolicyId;
            

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(policyBaseUri);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add("Accept", "application/json");
                client.DefaultRequestHeaders.Add("ContentType", "application/json");
                
                var httpResponse = await client.GetAsync($"/api/Policy/viewPolicy/{ConsumerId}/{BusinessId}/{PolicyId}");
                return httpResponse;

            }
        }

    }
}
