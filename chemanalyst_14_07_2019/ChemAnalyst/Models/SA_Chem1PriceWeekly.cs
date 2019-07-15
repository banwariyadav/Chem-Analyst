namespace ChemAnalyst.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SA_Chem1PriceWeekly
    {
        [Key]
        public int id { get; set; }


        public Int32? Product { get; set; }

        [StringLength(500)]
        public string ProductVariant { get; set; }

        [StringLength(50)]
        public string year { get; set; }
        [StringLength(50)]
        public string Month { get; set; }

        [StringLength(50)]
        public string Week { get; set; }

        [StringLength(50)]
        public string day { get; set; }
        public decimal? count { get; set; }
        [StringLength(5000)]
        public string Discription { get; set; }
        [StringLength(500)]
        public string FileName { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
