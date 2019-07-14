using ChemAnalyst.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ChemAnalyst.ViewModel
{
    public class IndustryViewModel
    {
        public IEnumerable<SA_Industry> Industry { get; set; }
        public IEnumerable<SA_Deals> DealsList { get; set; }

        public IEnumerable<SA_News> NewsList { get; set; }

    }

    public class IndustryVM
    {
        public int id { get; set; }
        public string Title { get; set; }
        public string Product { get; set; }

        public string CreateTime { get; set; }
    }



    }
