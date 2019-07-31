using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ChemAnalyst.Models
{
     
    public class SA_DealsAndProductRelation
    {
        public int Id { get; set; }

        [Required]
         
        public int SA_DealID { get; set; }

        [Required]
        
        public int SA_ProductId { get; set; }



         
    }
}