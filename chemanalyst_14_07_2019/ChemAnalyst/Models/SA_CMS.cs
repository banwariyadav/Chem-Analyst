namespace ChemAnalyst.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SA_CMS
    {
        public int id { get; set; }

        [StringLength(50)]
        public string CMSName { get; set; }

        [StringLength(500)]
        public string CMSDiscription { get; set; }

        [StringLength(50)]
        public string Meta { get; set; }

        [StringLength(500)]
        public string MetaDiscription { get; set; }

        public int? status { get; set; }

        public DateTime? CreatedTime { get; set; }

        [StringLength(50)]
        public string CMSImg { get; set; }

        public int? Product { get; set; }
    }
}
