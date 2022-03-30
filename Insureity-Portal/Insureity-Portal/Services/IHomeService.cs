using Insureity_Portal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Insureity_Portal.Services
{
    public interface IHomeService
    {
        Task<HttpResponseMessage> GetQuotesRequest(GetQuotes getQuotes);
        Task<HttpResponseMessage> ViewPolicyRequest(ViewPolicy viewPolicy);
        Task<HttpResponseMessage> CreatePolicyRequest(CreatePolicy createPolicy);
        Task<HttpResponseMessage> IssuePolicyRequest(IssuePolicy issuePolicy);
    }
}
