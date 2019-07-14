using ChemAnalyst.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChemAnalyst.ViewModel
{
    public class NewsDetailsViewModel
    {
        public SA_News News { get; set; }

        public IList<SA_News> NewsList { get; set; }

        public IList<SA_Deals> DealList { get; set; }
    }
}