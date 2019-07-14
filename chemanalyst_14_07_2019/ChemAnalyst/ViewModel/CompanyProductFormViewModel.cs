using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ChemAnalyst.ViewModel
{
    public class CompanyProductFormViewModel
    {
        //[Display(Name = "Select Excel File")]
        public HttpPostedFileBase excelFile { get; set; }
    }
}