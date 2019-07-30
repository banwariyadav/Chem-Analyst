namespace ChemAnalyst.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web.Mvc;

    public partial class SA_NewsViewModel
    {
        [Key]
        public int id { get; set; }

        [StringLength(500)]
        public string NewsName { get; set; }

        [StringLength(5000)]
        public string NewsDiscription { get; set; }
        [StringLength(500)]
        public string URL { get; set; }

        [StringLength(1000)]
        public string MetaDiscription { get; set; }

        [StringLength(1000)]
        public string NewsImg { get; set; }
        [StringLength(1000)]
        public string Keywords { get; set; }
        public int status { get; set; }

        [StringLength(500)]
        public string MetaTitle { get; set; }
        public string Product { get; set; }
        public DateTime? CreatedTime { get; set; }
        public List<SelectListItem> ProductList { get; set; }

    }
}
