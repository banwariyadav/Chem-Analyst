using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ChemAnalyst.Models
{
    public class SA_States
    {
        [Key]
        public int Id { get; set; }

        public int CountryId { get; set; }

        [StringLength(200)]
        public string State { get; set; }

        public DateTime CreatedTime { get; set; }

        

    }
}