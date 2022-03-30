using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Insureity_Portal.Models
{
    public class BusinessPropertyDetails
    {
        [Display(Name = "BusinessProperty")]
        public virtual string ConsumerId { get; set; }

        [ForeignKey("DepartmentId")]
        public virtual BusinessProperty BusinessPropertys { get; set; }
    
        public string PropertyId { get; set; }
        public int BuildingSqft { get; set; }
        public string BuildingType { get; set; }
        public int BuildingStoreys { get; set; }
        public int BuildingAge { get; set; }
        public int CostOfTheAsset { get; set; }
        public int SalvageValue { get; set; }
        public int UsefulLifeOfTheAsset { get; set; }
        public int PropertyValue { get; set; }
    }
}
