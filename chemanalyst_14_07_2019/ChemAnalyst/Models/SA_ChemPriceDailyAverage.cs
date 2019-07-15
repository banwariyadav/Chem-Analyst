namespace ChemAnalyst.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SA_ChemPriceDailyAverage
    {
        public int id { get; set; }


        public int Product { get; set; }

        [StringLength(500)]
        public string ProductVariant { get; set; }

        [StringLength(500)]
        public string ModeOfDistrubution { get; set; }

        [StringLength(100)]
        public string Location { get; set; }

        [StringLength(50)]
        public string year { get; set; }
        [StringLength(50)]
        public string Month { get; set; }
        [StringLength(50)]
        public string day { get; set; }
        public decimal count { get; set; }
        [StringLength(500)]
        public string Discription { get; set; }
        [StringLength(500)]
        public string FileName { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
