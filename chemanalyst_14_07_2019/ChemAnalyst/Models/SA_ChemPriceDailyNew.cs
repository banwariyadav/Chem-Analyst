namespace ChemAnalyst.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SA_ChemPriceDailyNew
    {
        [Key]
        public int id { get; set; }

        [StringLength(50)]
        public string Date { get; set; }
        public int Product { get; set; }

        [StringLength(50)]
        public string Commodity { get; set; }

        [StringLength(500)]
        public string Type { get; set; }

        [StringLength(500)]
        public string Term { get; set; }

        [StringLength(100)]
        public string Location { get; set; }

        [StringLength(100)]
        public string Price { get; set; }

        [StringLength(50)]
        public string MidValue { get; set; }

        [StringLength(50)]
        public string Difference4WeekAgo { get; set; }

        [StringLength(500)]
        public string ContractDetails { get; set; }

        [StringLength(50)]
        public string FileName { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
