using System;
using System.Threading.Tasks;
using System.Net.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Insureity_Portal.Models;
using System.Text;
using Microsoft.AspNetCore.Http;

namespace Insureity_Portal.Services
{
    public class ConsumerService : IConsumerService
    {
        private IConfiguration _configuration;
        public ConsumerService(IConfiguration configuration)
        {
            _configuration = configuration;

        }

        public async Task<HttpResponseMessage> UpdateConsumerBusiness(ConsumerBusiness consumerBusiness)
        {
            string consumerBaseUri = _configuration.GetValue<string>("ServiceURIs:Consumer");

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(consumerBaseUri);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add("Accept", "application/json");
                client.DefaultRequestHeaders.Add("ContentType", "application/json");

                StringContent content = new StringContent(JsonConvert.SerializeObject(consumerBusiness), Encoding.UTF8, "application/json");

                var httpResponse = await client.PutAsync($"/api/Consumer/UpdateConsumerBusiness", content);
                return httpResponse;
            }
        }

        public async Task<HttpResponseMessage> CreateConsumerBusinessRequest(ConsumerBusiness consumerBusiness)
        {
            string consumerBaseUri = _configuration.GetValue<string>("ServiceURIs:Consumer");

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(consumerBaseUri);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add("Accept", "application/json");
                client.DefaultRequestHeaders.Add("ContentType", "application/json");
                StringContent content = new StringContent(JsonConvert.SerializeObject(consumerBusiness), Encoding.UTF8, "application/json");

                var httpResponse = await client.PostAsync($"/api/Consumer/CreateConsumerBusiness", content);
                return httpResponse;
            }
        }

        public async Task<HttpResponseMessage> GetConsumerBusinessDetails(string ConsumerId, string BusinessId)
        {
            string consumerBaseUri = _configuration.GetValue<string>("ServiceURIs:Consumer");
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(consumerBaseUri);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add("Accept", "application/json");
                client.DefaultRequestHeaders.Add("ContentType", "application/json");

                var httpResponse = await client.GetAsync($"/api/Consumer/viewConsumerBusiness/{ConsumerId}/{BusinessId}");
                return httpResponse;
            }
        }

        public async Task<HttpResponseMessage> UpdateBusinessProperty(BusinessProperty businessProperty)
        {
            string consumerBaseUri = _configuration.GetValue<string>("ServiceURIs:Consumer");

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(consumerBaseUri);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add("Accept", "application/json");
                client.DefaultRequestHeaders.Add("ContentType", "application/json");



                StringContent content = new StringContent(JsonConvert.SerializeObject(businessProperty), Encoding.UTF8, "application/json");

                var httpResponse = await client.PutAsync($"/api/Consumer/UpdateBusinessProperty", content);
                return httpResponse;
            }
        }

        public async Task<HttpResponseMessage> CreateBusinessPropertyRequest(BusinessProperty businessProperty)
        {
            string consumerBaseUri = _configuration.GetValue<string>("ServiceURIs:Consumer");
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(consumerBaseUri);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add("Accept", "application/json");
                client.DefaultRequestHeaders.Add("ContentType", "application/json");

                StringContent content = new StringContent(JsonConvert.SerializeObject(businessProperty), Encoding.UTF8, "application/json");

                var httpResponse = await client.PostAsync($"/api/Consumer/CreateBusinessProperty", content);

                return httpResponse;
            }
        }

        public async Task<HttpResponseMessage> GetBusinessProperty(string ConsumerId, string PropertyId)
        {
            string consumerBaseUri = _configuration.GetValue<string>("ServiceURIs:Consumer");
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(consumerBaseUri);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add("Accept", "application/json");
                client.DefaultRequestHeaders.Add("ContentType", "application/json");

                var httpResponse = await client.GetAsync($"/api/Consumer/viewConsumerProperty/{ConsumerId}/{PropertyId}");
                return httpResponse;

            }
        }
    }
}
