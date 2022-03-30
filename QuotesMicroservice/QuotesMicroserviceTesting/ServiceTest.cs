using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using QuotesMicroservice.Service;
using QuotesMicroservice.Repository;
using Moq;

namespace QuotesMicroServiceTesting
{
    public class ServiceTests
    {
        [SetUp]
        public void Setup()
        {

        }
        public QuotesService quotesService;
        Mock<IQuotesRepo> mock = new Mock<IQuotesRepo>();

        public ServiceTests()
        {
            quotesService = new QuotesService(mock.Object);
        }
        [TestCase(3, 4, "Factory Equipment")]
        [TestCase(6, 8, "Factory Equipment")]
        [TestCase(10, 10, "Property in Transit")]
        [TestCase(7, 6, "Property in Transit")]
        [TestCase(2, 1, "Building")]
        [TestCase(6, 7, "Building")]
        public void QuotesForService_ValidData_String_Pass(int PropertyValue, int BusinessValue, string PropertyType)
        {
            mock.Setup(s => s.QuotesForPolicy(3, 4, "Factory Equipment")).Returns("50000");
            mock.Setup(s => s.QuotesForPolicy(6, 8, "Factory Equipment")).Returns("15000");
            mock.Setup(s => s.QuotesForPolicy(10, 10, "Property in Transit")).Returns("120000");
            mock.Setup(s => s.QuotesForPolicy(7, 6, "Property in Transit")).Returns("80000");
            mock.Setup(s => s.QuotesForPolicy(2, 1, "Building")).Returns("40000");
            mock.Setup(s => s.QuotesForPolicy(6, 7, "Building")).Returns("79000");

            var quotes = quotesService.QuotesForPolicyService(PropertyValue, BusinessValue, PropertyType);

            int num;
            bool flag = int.TryParse(quotes, out num);
            Assert.IsNotNull(quotes);
            Assert.AreEqual(flag, true);
        }



        [TestCase(0, 5, "Factory Equipment")]
        [TestCase(1, 12, "Factory Equipment")]
        [TestCase(3, 499, "Property in Transit")]
        [TestCase(4, 9, "Property in Transit")]
        [TestCase(-1, 5, "Building")]
        [TestCase(99, 10, "Building")]
        [TestCase(1, 2, "Account")]
        [TestCase(-1, -2, "Clerk")]
        public void QuotesForService_ValidData_String_Fail(int PropertyValue, int BusinessValue, string PropertyType)
        {
            mock.Setup(s => s.QuotesForPolicy(PropertyValue, BusinessValue, PropertyType)).Returns("No Quotes, Contact Insurance Provider");

            var quotes = quotesService.QuotesForPolicyService(PropertyValue, BusinessValue, PropertyType);

            int num;
            bool flag = int.TryParse(quotes, out num);
            Assert.IsNotNull(quotes);
            Assert.AreEqual(flag, false);
        }
    }
}

