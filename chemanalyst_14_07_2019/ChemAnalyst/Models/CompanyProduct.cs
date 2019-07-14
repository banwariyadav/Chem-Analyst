using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ChemAnalyst.Models
{
    [Table("SA_CompanyProduct")]
    public class CompanyProduct
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Product Name")]
        public string ProductName { get; set; }

        public string Segment { get; set; }

        public bool IsSelected { get; set; }
    }
}