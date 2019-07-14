using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChemAnalyst.Models
{
    public class CustProduct
    {
        public int id { get; set; }
        public int CustId { get; set; }
        public int ProdId { get; set; }
    }
}