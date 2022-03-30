using NUnit.Framework;
using QuotesMicroservice.Repository;
using System;
using QuotesMicroservice.Models;

namespace QuotesMicroserviceTesting
{
    public class RepositoryTests
    {
        [SetUp]
        public void Setup()
        {

        }
        public QuotesRepo quotesRepo;
        public RepositoryTests()
        {
            quotesRepo = new QuotesRepo();
        }

        /// <summary>
        /// Pass test for quotes policy function.
        /// </summary>
        /// <param name="PropertyValue"></param>
        /// <param name="BusinessValue"></param>
        /// <param name="PropertyType"></param>
        [TestCase(3, 4, "Factory Equipment")]
        [TestCase(6, 8, "Factory Equipment")]
        [TestCase(10, 10, "Property in Transit")]
        [TestCase(7, 6, "Property in Transit")]
        [TestCase(2, 1, "Building")]
        [TestCase(6, 7, "Building")]
        public void QuotesForPolicy_ValidData_String_Pass(int PropertyValue, int BusinessValue, string PropertyType)
        {
            string quotes = quotesRepo.QuotesForPolicy(PropertyValue, BusinessValue, PropertyType);

            int num;
            bool flag = int.TryParse(quotes, out num);

            Assert.IsNotNull(quotes);
            Assert.AreEqual(flag, true);
        }


        /// <summary>
        /// Fail test for quotes policy function.
        /// </summary>
        /// <param name="PropertyValue"></param>
        /// <param name="BusinessValue"></param>
        /// <param name="PropertyType"></param>

        [TestCase(0, 5, "Factory Equipment")]
        [TestCase(1, 12, "Factory Equipment")]
        [TestCase(3, 499, "Property in Transit")]
        [TestCase(4, 9, "Property in Transit")]
        [TestCase(-1, 5, "Building")]
        [TestCase(99, 10, "Building")]
        [TestCase(1, 2, "Account")]
        [TestCase(-1, -2, "Clerk")]
        public void QuotesForPolicy_ValidData_String_Fail(int PropertyValue, int BusinessValue, string PropertyType)
        {
            string quotes = quotesRepo.QuotesForPolicy(PropertyValue, BusinessValue, PropertyType);

            int num;
            bool flag = int.TryParse(quotes, out num);

            Assert.IsNotNull(quotes);
            Assert.AreEqual(flag, false);

        }
    }
}
