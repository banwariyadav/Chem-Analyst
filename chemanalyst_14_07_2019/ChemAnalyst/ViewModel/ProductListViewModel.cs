using ChemAnalyst.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChemAnalyst.ViewModel
{
    public class ProductListViewModel
    {
        public string id { get; set; }
        public string search { get; set; }
        public IEnumerable<SA_Industry> Industry { get; set; }
        public IEnumerable<SA_Deals> DealsList { get; set; }

        public IEnumerable<SA_News> NewsList { get; set; }

        public IEnumerable<SA_Product> ProductList { get; set; }
    }
}