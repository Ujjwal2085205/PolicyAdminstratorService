using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuotesMicroservice.Repository
{

    public class QuotesRepo : IQuotesRepo
    {
        private readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(QuotesRepo));
        public string QuotesForPolicy(int PropertyValue, int BusinessValue, string PropertyType)
        {
            _log4net.Info("Checking QuotesForPolicy with PropertyValue=" + PropertyValue + " BusinessValue=" + BusinessValue + " PropertyType=" + PropertyType);

            var quotes = (from q in QuotesMasterStaticData.QuotesLists
                          where q.MinPropertyValue <= PropertyValue && q.MaxPropertyValue >= PropertyValue &&
                          q.MinBusinessValue <= BusinessValue && q.MaxBusinessValue >= BusinessValue &&
                          q.PropertyType.ToLower() == PropertyType.ToLower()
                          select q).FirstOrDefault();
            if (quotes == null)
                return "No Quotes, Contact Insurance Provider";
            else
                return quotes.Quotes;

        }
    }
}
