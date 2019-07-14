using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ChemAnalyst.Models
{
    public class SA_Job
    {
        public int id { get; set; }

        [StringLength(50)]
        public string JobName { get; set; }

        [StringLength(500)]
        public string JobDiscription { get; set; }

        [StringLength(50)]
        public string Meta { get; set; }

        [StringLength(500)]
        public string MetaDiscription { get; set; }

        public int? status { get; set; }

        public DateTime? CreatedTime { get; set; }

 

    }
}