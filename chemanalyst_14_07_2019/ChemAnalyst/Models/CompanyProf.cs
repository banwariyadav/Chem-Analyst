using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ChemAnalyst.Models
{
    [Table("SA_CompanyProf")]
    public class CompanyProf
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Company Name")]
        public string CompanyName { get; set; }

        [Required]
        [Display(Name = "Registration Date")]
        public DateTime RegistrationDate { get; set; }
        public string Cin { get; set; }
        public string Category { get; set; }
        public string Address { get; set; }
        public string Contact { get; set; }

        [Required]
        [Display(Name = "Employee Number")]
        public int NumberOfEmployee { get; set; }

        [Required]
        [Display(Name = "Managing Director")]
        public string ManagingDirector { get; set; }
        public string Strength { get; set; }
        public string Weakness { get; set; }
        public string Oppertunity { get; set; }
        public string Threat { get; set; }

        [Display(Name = "Expansion Plans")]
        public string ExpansionPlans { get; set; }
    }
}