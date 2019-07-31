using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ChemAnalyst.Models
{
    public class SA_Company_SWOT
    {
        [Key]
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public string Strength { get; set; }
        public string Weakness { get; set; }
        public string Opportunity { get; set; }
        public string Threat { get; set; }
        public string CompanyExpansionBlock { get; set; }
        public string Perspective { get; set; }
        public string Strategy { get; set; }
       

    }
}