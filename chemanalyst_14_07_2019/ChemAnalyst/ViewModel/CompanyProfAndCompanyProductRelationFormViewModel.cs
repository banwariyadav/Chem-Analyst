using ChemAnalyst.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ChemAnalyst.ViewModel
{
    public class CompanyProfAndCompanyProductRelationFormViewModel
    {
        public IEnumerable<SA_Company> CompanyProf { get; set; }

        //[Display(Name = "Company Profile")]
        public int CompanyProfId { get; set; }

        //[Display(Name = "Company Product")]
        public List<SA_Product> CompanyProduct { get; set; }
    }
}