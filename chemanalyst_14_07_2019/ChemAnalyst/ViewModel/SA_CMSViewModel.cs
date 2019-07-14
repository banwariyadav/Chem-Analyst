namespace ChemAnalyst.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web.Mvc;

    public partial class SA_CMSViewModel
    {
        [Key]
        public int id { get; set; }

        [StringLength(50)]
        public string CMSName { get; set; }

        [StringLength(500)]
        public string CMSDiscription { get; set; }
        [StringLength(50)]
        public string Meta { get; set; }

        [StringLength(500)]
        public string MetaDiscription { get; set; }

        [StringLength(500)]
        public string CMSImg { get; set; }
        public int status { get; set; }

        public string Product { get; set; }
        public DateTime? CreatedTime { get; set; }
        public List<SelectListItem> ProductList { get; set; }

    }
}
