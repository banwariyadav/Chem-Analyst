using ChemAnalyst.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ChemAnalyst.ViewModel
{
    public class CompanyProfRecordViewModel
    {
        public int Id { get; set; }
        public string Revenues { get; set; }
        public string Growth { get; set; }

        [Required]
        //[Display(Name = "Financial Year")]
        public int FinancialYearId { get; set; }

        [Required]
        //[Display(Name = "Company")]
        public int SA_CompanyId { get; set; }

        public IEnumerable<FinancialYear> FinancialYear { get; set; }
        public IEnumerable<SA_Company> SA_Company { get; set; }

        //[Display(Name = "Select Excel File")]
        public HttpPostedFileBase excelFile { get; set; }
    }
}