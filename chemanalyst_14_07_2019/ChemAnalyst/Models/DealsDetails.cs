using ChemAnalyst.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChemAnalyst.ViewModel
{
    public class DealsDetailsViewModel
    {
        public SA_Deals Deals { get; set; }

        public IList<SA_News> NewsList { get; set; }

        public IList<SA_Deals> DealList { get; set; }

        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string Year { get; internal set; }
    }
}