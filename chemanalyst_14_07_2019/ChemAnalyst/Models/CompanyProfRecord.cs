using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ChemAnalyst.Models
{
    [Table("SA_CompanyProfRecord")]
    public class CompanyProfRecord
    {
        public int Id { get; set; }

      
        public string Revenues { get; set; }
        public string Growth { get; set; }

        public FinancialYear FinancialYear { get; set; }

        [Required]
        [Display(Name = "Financial Year")]
        public int FinancialYearId { get; set; }

        public SA_Company SA_Company { get; set; }

        [Required]
        [Display(Name = "Company")]
        public int SA_CompanyId { get; set; }
    }
}