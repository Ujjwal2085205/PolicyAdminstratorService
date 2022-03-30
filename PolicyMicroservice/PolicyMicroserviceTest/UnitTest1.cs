using PolicyMicroservice.Models;
using PolicyMicroservice.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PolicyMicroserviceTest
{
    [TestClass]
    public class Tests
    {
        [TestMethod]
        public void GetPolicyMethod()
        {
            ConsumerPolicyRepository consumerPolicyRepository = new ConsumerPolicyRepository();
            PolicyDetails policyDetails = new PolicyDetails()
            {
                ConsumerId = "C01",
                PolicyId = "P01",
                BusinessId = "B01",
                ConsumerName = "Apoorva",
                AgentId = 2,
                AgentName = "Ujjwal",
                AcceptedQuotes = "81000",
                PolicyStatus = "Initiated",
                PaymentDetails = "Success",
                AcceptanceStatus = "Accept",
            };
            Assert.AreEqual(policyDetails.PaymentDetails, consumerPolicyRepository.GetPolicy("C01", "P01").PaymentDetails);
        }

        [TestMethod]
        public void CreatePolicyMethod()
        {
            bool output = true;
            ConsumerPolicyRepository consumerPolicyRepository = new ConsumerPolicyRepository();
            CreatePolicyRequest createPolicyRequest = new CreatePolicyRequest()
            {
                ConsumerId = "C01",
                BusinessId = "B01",
                AcceptedQuotes = "Accepted",

            };
            Assert.AreEqual(output, consumerPolicyRepository.CreatePolicy(createPolicyRequest));

        }

        [TestMethod]
        public void IssuePolicyMethod()
        {
            bool output = true;
            ConsumerPolicyRepository consumerPolicyRepository = new ConsumerPolicyRepository();
            IssuePolicyRequest issuePolicyRequest = new IssuePolicyRequest()
            {
                ConsumerId = "C01",
                BusinessId = "B01",
                PolicyId = "P01",
                PaymentDetails = "Success",
                AcceptanceStatus = "Accepted",

            };
            Assert.AreEqual(output, consumerPolicyRepository.IssuePolicy(issuePolicyRequest));

        }


    }
}