namespace ChemAnalyst.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SA_RoleWiseAccess
    {
        public int id { get; set; }

       
        public int RoleId { get; set; }
        public int Pageid { get; set; }
        
        [StringLength(500)]
        public string PageDiscription { get; set; }

        public bool access { get; set; }
        public DateTime? CreatedTime { get; set; }
    }
}
