namespace ChemAnalyst.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SA_RoleViewModel
    {
        [Key]
        public int id { get; set; }

        [StringLength(50)]
        public string Role { get; set; }

        [StringLength(500)]
        public string RoleDiscription { get; set; }

        //public DateTime? CreatedTime { get; set; }
        public string CreatedTime { get; set; }

        public bool ChemicalPricing { get; set; }
        public bool MarketAnalysis { get; set; }
        public bool CompanyProfile { get; set; }
        public bool IndustryReports { get; set; }
        public bool News { get; set; }
        public bool Deals { get; set; }
        public bool SubscriptionManagement { get; set; }
    }

}
