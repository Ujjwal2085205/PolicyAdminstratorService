using ConsumerMicroservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsumerMicroservice
{
    public class ConsumerData
    {
        public static List<Consumer> ConsumerList = new List<Consumer>()

        {
           new Consumer()
            {
                ConsumerId = "C01",
                ConsumerName = "Apoorva",
                Email = "apoorva@gmail.com",
                Pan = "ABC1234567",
                BusinessOverview = "Sole Proprietorships",
                ValidityofConsumer = 2 ,
                AgentId = 1,
                AgentName = "Ujjwal"
            },
            new Consumer()
            {
                ConsumerId = "C02",
                ConsumerName = "Aishwarya",
                Email = "aishwarya@gmail.com",
                Pan = "ABC1144567",
                BusinessOverview = "Corporations" ,
                ValidityofConsumer = 2 ,
                AgentId = 2,
                AgentName = "Anshika"
            },
            new Consumer()
            {
                ConsumerId = "C03",
                ConsumerName = "Anshika",
                Email = "anshika@gmail.com",
                Pan = "XYZ1234567",
                BusinessOverview = "entrepreneurs",
                ValidityofConsumer = 3 ,
                AgentId = 3,
                AgentName = "Manvita"
            },
            new Consumer()
            {
                ConsumerId = "C04",
                ConsumerName = "Aishwarya",
                Email = "aishwarya@gmail.com",
                Pan = "ABC1156472",
                BusinessOverview = "Sole Proprietorships" ,
                ValidityofConsumer = 1 ,
                AgentId = 4,
                AgentName = "Ujjwal1"
            },
            
        };
    }
}
