using ChemAnalyst.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChemAnalyst.ViewModel
{
    public class CustomerProductFormViewModel
    {
        public Lead_Master Lead_Master { get; set; }
        public List<SA_Product> SA_Product { get; set; }
        public List<CustomerAndProducRelation> CustomerAndProducRelation { get; set; }
    }
}