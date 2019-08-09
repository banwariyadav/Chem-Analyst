using ChemAnalyst.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChemAnalyst.ViewModel
{
    public class MA_StackViewModel
    {

        public string MStackedDimensionOne { get; set; }
        public string MRange { get; set; }

        public List<SimpleReportViewModel> LstData { get; set; }
        public List<SelectListItem> ProductList { get; set; }
        public string Product { get; set; }
        public string MChartType { get; set; }
        public List<string> Discription { get; set; }

        public int category { get; set; }
        public string Compare { get; set; }

        public string CommentaryTitle { get; set; }

        public string CommentaryDescription { get; set; }

        public DealsDetailsViewModel NewsDetailsViewModel { get; set; }

        public string FromYear { get; set; }
        public string ToYear { get; set; }
    }
        public enum MRange
        {
            Company,
            Location,
            Process
            
        }
        public enum MChartType
        {
            line,
            bar,
            pie
        }
    
}