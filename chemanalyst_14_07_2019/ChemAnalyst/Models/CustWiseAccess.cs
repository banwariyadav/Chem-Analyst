using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChemAnalyst.Models
{
    public class CustWiseAccess
    {
        public int id { get; set; }
        public int CustId { get; set; }
        public int Pageid { get; set; }
        public string PageDiscription { get; set; }
        public bool access { get; set; }
        public DateTime CreatedTime { get; set; }
    }
}