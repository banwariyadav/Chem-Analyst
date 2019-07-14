using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ChemAnalyst.Models
{
    public class Lead_Master
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please Enter Name")]
        [StringLength(50)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please Enter Email")]
        [StringLength(70)]
        public string CorpEmail { get; set; }

        [StringLength(50)]
        public string Organisation { get; set; }

        [StringLength(50)]
        public string Country { get; set; }

        [StringLength(50)]
        public string State { get; set; }

        [StringLength(12)]
        public string Phone { get; set; }

        [StringLength(50)]
        public string InterestArea { get; set; }

        [StringLength(100)]
        public string Subject { get; set; }

        [StringLength(500)]
        public string Query { get; set; }

        [StringLength(50)]
        public string UserType { get; set; }

        public string Status { get; set; }

        public DateTime? CreatedDate { get; set; }
        public string AssignTo { get; set; }
        public string Designation { get; set; }

        public DateTime? AssignDate { get; set; }

        public string IPAddress { get; set; }
    }
}