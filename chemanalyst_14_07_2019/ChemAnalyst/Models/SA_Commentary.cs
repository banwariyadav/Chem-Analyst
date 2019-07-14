using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChemAnalyst.Models
{
    public class SA_Commentary
    {
        [Key]
        public int id { get; set; }

        [StringLength(255)]
        public string Title { get; set; }

        [StringLength(50000)]
        public string Description { get; set; }

        public string Meta { get; set; }
        [StringLength(255)]
        public string MetaDescription { get; set; }

        public DateTime CreatedTime { get; set; }

        public int Product { get; set; }

        public bool IsActive { get; set; }

        public bool IsDelete { get; set; }

        //public List<SelectListItem> ProductList { get; set; }


    }
}