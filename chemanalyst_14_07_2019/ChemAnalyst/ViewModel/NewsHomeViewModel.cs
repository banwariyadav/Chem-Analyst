using ChemAnalyst.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChemAnalyst.ViewModel
{
    public class NewsHomeViewModel
    {
        public string id { get; set; }
        public DateTime search { get; set; }

        public IPagedList<SA_News> NewsList { get; set; }
    }
}