using ConsumerMicroservice.Repository;
using ConsumerMicroservice.Models;
using ConsumerMicroservice.Controllers;
using ConsumerMicroservice.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConsumerMicroserviceTest
{
    [TestClass]
    public class RepositoryTest
    {
        [TestMethod]
        public void CreateConsumerBusiness()
        {
            bool output = true;
            ConsumerRepository ConsumerRepository_obj = new ConsumerRepository();
            ConsumerBusiness consumerBusiness = new ConsumerBusiness()
            {

                ConsumerId = "C01",
                ConsumerName = "Apoorva",
                Email = "apoorva@gmail.com",
                Pan = "ABCD12345",
                BusinessOverview = "Retailer",
                ValidityofConsumer = 1,
                AgentId = 1,
                AgentName = "Ujjwal",
                BusinessId = "B01",
                CapitalInvested = 1000000,
                BusinessType = "Rent",
                AnnualTurnOver = 200,
                TotalEmployees = 2

            };
            Assert.AreEqual(output, ConsumerRepository_obj.CreateConsumerBusiness(consumerBusiness));
        }
        [TestMethod]
        public void UpdateConsumerBusiness()
        {
            bool output = true;
            ConsumerRepository ConsumerRepository_obj = new ConsumerRepository();
            ConsumerBusiness consumerBusiness = new ConsumerBusiness()
            {
                ConsumerId = "C01",
                ConsumerName = "Apoorva",
                Email = "apoorva@gmail.com",
                Pan = "ABCD12345",
                BusinessOverview = "Retailer",
                ValidityofConsumer = 1,
                AgentId = 1,
                AgentName = "Ujjwal",
                BusinessId = "B01",
                CapitalInvested = 1000000,
                BusinessType = "Rent",
                AnnualTurnOver = 200,
                TotalEmployees = 2
            };
            Assert.AreEqual(output, ConsumerRepository_obj.UpdateConsumerBusiness(consumerBusiness));
        }

        [TestMethod]
        public void CreateBusinessProperty()
        {
            bool output = true;

            ConsumerRepository ConsumerRepository_obj = new ConsumerRepository();
            BusinessProperty Property_obj = new BusinessProperty()
            {
                PropertyId = "P01",
                BuildingSqft = 2000,
                BuildingType = "Owner",
                BuildingStoreys = 5,
                BuildingAge = 2,
                CostOfTheAsset = 9,
                SalvageValue = 3,
                UsefulLifeOfTheAsset = 3

            };

            Assert.AreEqual(output, ConsumerRepository_obj.CreateBusinessProperty(Property_obj));
        }

        [TestMethod]
        public void UpdateBusinessProperty()
        {
            bool output = true;
            ConsumerRepository ConsumerRepository_obj = new ConsumerRepository();
            BusinessProperty Property_obj = new BusinessProperty()
            {
                PropertyId = "P01",
                BuildingSqft = 2000,
                BuildingType = "Owner",
                BuildingStoreys = 5,
                BuildingAge = 2,
                CostOfTheAsset = 9,
                SalvageValue = 3,
                UsefulLifeOfTheAsset = 3
            };
            Assert.AreEqual(output, ConsumerRepository_obj.UpdateBusinessProperty(Property_obj));
        }

    }
}



