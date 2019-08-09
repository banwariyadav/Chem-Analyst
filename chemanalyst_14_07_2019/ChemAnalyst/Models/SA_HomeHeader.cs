using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ChemAnalyst.Models
{
    public partial class SA_HomeHeader
    {

        [Key]
        public int Id { get; set; }

        public string PhoneNumber { get; set; }

        [StringLength(500)]
        public string EmailAddress { get; set; }

        [StringLength(500)]
        public string OfficeAddress { get; set; }

        public DateTime? CreatedTime { get; set; }


    }
    
}