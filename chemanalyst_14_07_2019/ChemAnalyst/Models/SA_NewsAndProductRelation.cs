using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ChemAnalyst.Models
{
     
    public class SA_NewsAndProductRelation
    {
        public int Id { get; set; }

        [Required]
         
        public int SA_NewsId { get; set; }

        [Required]
        
        public int SA_ProductId { get; set; }



         
    }
}