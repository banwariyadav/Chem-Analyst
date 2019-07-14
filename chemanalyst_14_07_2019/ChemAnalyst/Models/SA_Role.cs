namespace ChemAnalyst.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SA_Role
    {
        public int id { get; set; }

        [StringLength(50)]
        public string Role { get; set; }

        [StringLength(500)]
        public string RoleDiscription { get; set; }

        public DateTime? CreatedTime { get; set; }
    }
}
