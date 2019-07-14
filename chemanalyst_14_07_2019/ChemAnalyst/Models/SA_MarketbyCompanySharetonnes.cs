using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace ChemAnalyst.Models
{
    public class SA_MarketbyCompanySharetonnes
    {
        public int id { get; set; }


        public int Product { get; set; }

        [StringLength(500)]
        public string Company { get; set; }

        [StringLength(50)]
        public string year { get; set; }

        public decimal count { get; set; }

        [StringLength(5000)]
        public string Discription { get; set; }

        public string FileName { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}