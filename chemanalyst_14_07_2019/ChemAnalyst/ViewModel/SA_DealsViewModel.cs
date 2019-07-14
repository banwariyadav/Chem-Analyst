namespace ChemAnalyst.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web.Mvc;

    public partial class SA_DealsViewModel
    {
        [Key]
        public int id { get; set; }

        [StringLength(50)]
        public string DealsName { get; set; }

        [StringLength(500)]
        public string DealsDiscription { get; set; }
        [StringLength(50)]
        public string URL { get; set; }

        [StringLength(500)]
        public string MetaDiscription { get; set; }

        [StringLength(500)]
        public string DealsImg { get; set; }

        [StringLength(1000)]
        public string Keywords { get; set; }
        public int status { get; set; }

        public string Product { get; set; }
        public DateTime? CreatedTime { get; set; }
        public List<SelectListItem> ProductList { get; set; }

    }
}
