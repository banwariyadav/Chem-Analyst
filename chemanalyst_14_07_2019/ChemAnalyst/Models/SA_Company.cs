using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChemAnalyst.Models
{
    public class SA_Company
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Logo { get; set; }
        public DateTime RegDate { get; set; }
        public string CIN { get; set; }
        public string Category { get; set; }
        public string Address { get; set; }
        public string NOE { get; set; }
        public string CEO { get; set; }
        public string Meta { get; set; }

        public string MetaDescription { get; set; }
        public string website { get; set; }
        public string phoneNo { get; set; }
        public string fax { get; set; }
        public string EmailId { get; set; }
        public DateTime CreatedTime { get; set; }

    }
}