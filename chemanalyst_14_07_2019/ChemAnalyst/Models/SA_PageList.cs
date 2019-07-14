namespace ChemAnalyst.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SA_PageList
    {
        public int id { get; set; }

       

        [StringLength(500)]
        public string PageDiscription { get; set; }

    
    }
}
