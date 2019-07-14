using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ChemAnalyst.Models
{
    [Table("SA_CustomerAndProducRelation")]
    public class CustomerAndProducRelation
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Customer")]
        public int Lead_MasterId { get; set; }

        [Required]
        [Display(Name = "Product")]
        public int SA_ProductId { get; set; }




        //OLD PROPERTY
        //public int Id { get; set; }

        //public SA_Company SA_Company { get; set; }

        //[Required]
        //[Display(Name = "Company")]
        //public int SA_CompanyId { get; set; }

        //public SA_Product SA_Product { get; set; }

        //[Required]
        //[Display(Name = "Product")]
        //public int SA_ProductId { get; set; }
    }
}