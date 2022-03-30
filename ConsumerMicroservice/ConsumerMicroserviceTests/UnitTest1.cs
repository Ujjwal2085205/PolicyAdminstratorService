using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using ConsumerMicroservice.Repository;
using ConsumerMicroservice.Models;
using Moq;
using ConsumerMicroservice.Controllers;
using Microsoft.AspNetCore.Mvc;
using FluentAssertions;
using ConsumerMicroservice.Service;
using System.Net;

namespace ConsumerMicroserviceTest
{
    [TestFixture]
    public class UnitTest1
    {
        private Mock<IConsumerService> _service;
        [SetUp]
        public void Setup()
        {
            _service = new Mock<IConsumerService>();

        }
        [Test]
        public void ViewBusinessByConsumerId_WhenConsumerExists_ReturnsTheBusinessDetail()
        {
            var expectedItem = new ConsumerBusinessDetails
            {
                ConsumerId = "C01",
                ConsumerName = "Charles Boyle",
                Email = "charlesBoyle@gmail.com",
                Pan = "QT1237FG21",
                AgentId = 1,
                AgentName = "Apoorva",
                BusinessId = "B01",
                ValidityofConsumer = 2,
                BusinessOverview = "Large Scale Contract Based Construction",
                BusinessType = "Pharmacy",
                AnnualTurnOver = 1000000,
                TotalEmployees = 5600,
                CapitalInvested = 2325567,
                BusinessValue = 8
            };

            _service.Setup(repo => repo.ViewConsumerBusiness("C01", "B01")).Returns(expectedItem);
            var controller = new ConsumerController(_service.Object);
            var response = controller.ViewConsumerBusiness("C01", "B01");
            var result = response as OkObjectResult;
            result.Value.Should().BeEquivalentTo(expectedItem,
                options => options.ComparingByMembers<ConsumerBusinessDetails>());
        }
        [Test]
        public void ViewAllProperties_ExistingProperties_ReturnsAllProperties()
        {
            var expectedResults = new BusinessPropertyDetails
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
            _service.Setup(repo => repo.ViewConsumerProperty("C01", "B01")).Returns(expectedResults);
            var controller = new ConsumerController(_service.Object);
            var response = controller.ViewConsumerProperty("C01", "B01");
            var result = response as OkObjectResult;
            result.Value.Should().BeEquivalentTo(expectedResults,
                options => options.ComparingByMembers<BusinessPropertyDetails>());
        }




    }


}

