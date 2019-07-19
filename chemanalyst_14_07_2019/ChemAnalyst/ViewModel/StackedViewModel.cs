using ChemAnalyst.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChemAnalyst.ViewModel
{
    public class StackedViewModel
    {
        //public IEnumerable<SA_Deals> DealsList { get; set; }

        //public IEnumerable<SA_News> NewsList { get; set; }
        public string FirstValue { get; set; }
        public string LastValues { get; set; }

        public string SelectedValues { get; set; }

        public DealsDetailsViewModel NewsDetailsViewModel { get; set; }

        public string StackedDimensionOne { get; set; }
        public string range { get; set; }

        public List<SimpleReportViewModel> LstData { get; set; }
        public List<SelectListItem> ProductList { get; set; }
        public string Product { get; set; }

        public string ProductName { get; set; }

        public string selectedLegends { get; set; }
        public string ChartType { get; set; }
        public List<string> Discription { get; set; }
        public int category { get; set; }
        public string Compare { get; set; }

        public string FromDate { get; set; }
        public string ToDate { get; set; }

        public string CommentaryTitle { get; set; }

        public string CommentaryDescription { get; set; }


    }
    public enum Range
    {
        Yearly,
        Monthly,
        Quaterly,
        DailyBasis
    }
    public enum ChartType
    {
        line,
        bar,
        pie
    }

   
}