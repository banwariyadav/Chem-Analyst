using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ChemAnalyst.Models
{
    public class SA_Quote
    {
        public int id { get; set; }

        [StringLength(50)]
        public string QuoteName { get; set; }

        [StringLength(500)]
        public string QuoteDiscription { get; set; }

        [StringLength(50)]
        public string QuoteBy { get; set; }

        [StringLength(50)]
        public string QuoteDes { get; set; }

        [StringLength(50)]
        public string Meta { get; set; }

        [StringLength(500)]
        public string MetaDiscription { get; set; }

        public int? status { get; set; }

        public DateTime? CreatedTime { get; set; }

        [StringLength(50)]
        public string QuoteImg { get; set; }

    }
}