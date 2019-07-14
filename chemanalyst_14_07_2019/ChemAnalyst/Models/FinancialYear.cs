using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ChemAnalyst.Models
{
    [Table("SA_FinancialYear")]
    public class FinancialYear
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Financial Year")]
        public string FinYear { get; set; }
    }
}