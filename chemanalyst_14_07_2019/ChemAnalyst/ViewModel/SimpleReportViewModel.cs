using ChemAnalyst.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ChemAnalyst.ViewModel
{
    public class SimpleReportViewModel
    {
        public string DimensionOne { get; set; }
        public decimal Quantity { get; set; }

        public string MDimensionOne { get; set; }

       
    }
}