
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QuotesMicroservice.Models;

namespace QuotesMicroservice
{
    public class QuotesMasterStaticData
    {
        public static List<QuotesMaster> QuotesLists = new List<QuotesMaster>()
        {
            new QuotesMaster { MinPropertyValue = 0, MaxPropertyValue = 3, MinBusinessValue = 0,MaxBusinessValue = 3,PropertyType = "Factory Equipment",Quotes = "80000" },
            new QuotesMaster { MinPropertyValue = 4, MaxPropertyValue = 7, MinBusinessValue = 4,MaxBusinessValue = 7,PropertyType = "Factory Equipment",Quotes = "50000" },
            new QuotesMaster { MinPropertyValue = 8, MaxPropertyValue = 10, MinBusinessValue =8,MaxBusinessValue = 10,PropertyType = "Factory Equipment",Quotes ="30000" },

            new QuotesMaster { MinPropertyValue = 0, MaxPropertyValue = 3, MinBusinessValue = 0,MaxBusinessValue = 3,PropertyType = "Building",Quotes = "80000" },
            new QuotesMaster { MinPropertyValue = 4, MaxPropertyValue = 7, MinBusinessValue = 4,MaxBusinessValue = 7,PropertyType = "Building",Quotes = "50000" },
            new QuotesMaster { MinPropertyValue = 8, MaxPropertyValue = 10, MinBusinessValue =8,MaxBusinessValue = 10,PropertyType = "Building",Quotes ="30000" },

            new QuotesMaster { MinPropertyValue = 0, MaxPropertyValue = 3, MinBusinessValue = 0,MaxBusinessValue = 3,PropertyType = "Property In Transit",Quotes = "80000" },
            new QuotesMaster { MinPropertyValue = 4, MaxPropertyValue = 7, MinBusinessValue = 4,MaxBusinessValue = 7,PropertyType = "Property In Transit",Quotes = "50000" },
            new QuotesMaster { MinPropertyValue = 8, MaxPropertyValue = 10, MinBusinessValue =8,MaxBusinessValue = 10,PropertyType = "Property In Transit",Quotes ="30000" },



        };
    }
}