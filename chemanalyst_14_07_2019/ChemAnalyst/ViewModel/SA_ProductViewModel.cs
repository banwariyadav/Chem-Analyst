namespace ChemAnalyst.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web.Mvc;

    public partial class SA_ProductViewModel
    {
        [Key]
        public int id { get; set; }

        [StringLength(50)]
        public string ProductName { get; set; }

        [StringLength(500)]
        public string ProductDiscription { get; set; }
        [StringLength(50)]
        public string Meta { get; set; }

        [StringLength(500)]
        public string MetaDiscription { get; set; }

        [StringLength(500)]
        public string ProductImg { get; set; }
        public int status { get; set; }

        public string Category { get; set; }
        public DateTime? CreatedTime { get; set; }
        public List<SelectListItem> CategoryList { get; set; }



    }
}
