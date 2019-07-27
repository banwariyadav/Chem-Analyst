using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChemAnalyst.Models
{
    public class SA_Industry
    {
        public int id { get; set; }

        [StringLength(255)]
        public string Title { get; set; }

        [StringLength(50000)]
        public string Description { get; set; }

        [StringLength(50000)]
        public string Tableoc { get; set; }

        [StringLength(50000)]
        public string Figot { get; set; }

        [StringLength(50000)]
        public string RelatedRep { get; set; }

        public string format { get; set; }

        public string Pages { get; set; }
       
        public string Industry { get; set; }
        [StringLength(255)]
        public string Meta { get; set; }
        [StringLength(255)]
        public string MetaDescription { get; set; }

        public DateTime? CreatedTime { get; set; }

        public int Product { get; set; }
        public int CountryID { get; set; }
        public int CategoryID { get; set; }
        //public List<SelectListItem> ProductList { get; set; }


    }
}