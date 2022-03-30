using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuotesMicroservice.Models
{
    public class QuotesMaster
    {
        public int Id { get; set; }

        public int MinBusinessValue { get; set; }
        public int MaxBusinessValue { get; set; }

        public int MinPropertyValue { get; set; }
        public int MaxPropertyValue { get; set; }

        public string PropertyType { get; set; }

        public string Quotes { get; set; }

    }
}
