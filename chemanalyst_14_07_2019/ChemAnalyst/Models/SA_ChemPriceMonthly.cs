
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;
namespace ChemAnalyst.Models
{
    public partial class SA_ChemPriceMonthly
    {
        public int id { get; set; }


        public int Product { get; set; }

        [StringLength(500)]
        public string ProductVariant { get; set; }

        [StringLength(50)]
        public string year { get; set; }

        [StringLength(50)]
        public string Month { get; set; }
        public decimal count { get; set; }
        [StringLength(5000)]
        public string Discription { get; set; }
        [StringLength(500)]
        public string FileName { get; set; }
        public DateTime? CreatedDate { get; set; }


        public string CreatedBy { get; set; }
    }
}
