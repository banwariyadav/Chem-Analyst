using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ChemAnalyst.Models
{
    public class SA_Slider
    {
        public int id { get; set; }

        [StringLength(50)]
        public string Title { get; set; }

        [StringLength(500)]
        public string Discription { get; set; }

        [StringLength(500)]
        public string Category { get; set; }

        [StringLength(50)]
        public string Meta { get; set; }

        [StringLength(500)]
        public string MetaDiscription { get; set; }

        public int? status { get; set; }

        public DateTime? CreatedTime { get; set; }

        [StringLength(50)]
        public string Img { get; set; }
    }
}