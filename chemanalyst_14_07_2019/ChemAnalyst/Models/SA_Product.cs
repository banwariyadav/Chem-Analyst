namespace ChemAnalyst.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SA_Product
    {
        public int id { get; set; }

        [StringLength(50)]
        public string ProductName { get; set; }

        [StringLength(500)]
        public string ProductDiscription { get; set; }

        [StringLength(50)]
        public string Meta { get; set; }

        [StringLength(500)]
        public string MetaDiscription { get; set; }

        public int? status { get; set; }

        public DateTime? CreatedTime { get; set; }

        [StringLength(50)]
        public string ProductImg { get; set; }
        public int Category { get; set; }

        public bool IsSelected { get; set; }

    }
}
