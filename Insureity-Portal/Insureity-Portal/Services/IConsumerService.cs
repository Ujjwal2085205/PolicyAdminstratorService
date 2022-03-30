using Insureity_Portal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Insureity_Portal.Services
{
    public interface IConsumerService
    {
        Task<HttpResponseMessage> UpdateConsumerBusiness(ConsumerBusiness consumerBusiness);
        Task<HttpResponseMessage> CreateConsumerBusinessRequest(ConsumerBusiness consumerBusiness);
        Task<HttpResponseMessage> GetConsumerBusinessDetails(string ConsumerId, string BusinessId);
        Task<HttpResponseMessage> UpdateBusinessProperty(BusinessProperty businessProperty);
        Task<HttpResponseMessage> CreateBusinessPropertyRequest(BusinessProperty businessProperty);
        Task<HttpResponseMessage> GetBusinessProperty(string ConsumerId, string PropertyId);
    }
}
