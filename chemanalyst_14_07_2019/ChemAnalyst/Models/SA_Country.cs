using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ChemAnalyst.Models
{
    public class SA_Country
    {
        public int id { get; set; }

        [StringLength(200)]
        public string CountryName { get; set; }

        
        public bool Active { get; set; }

        

    }
}