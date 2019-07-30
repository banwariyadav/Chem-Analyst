using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ChemAnalyst.ViewModel
{
    public class SubscriptionViewModel
    {
        public int SId { get; set; }
        public int LeadId { get; set; }
        public string Subscribe { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public string Package { get; set; }
        public string Status { get; set; }
        public string AssignedUserId { get; set; }
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

        public string Query { get; set; }

        public string UserType { get; set; }

        public DateTime? CreatedDate { get; set; }
        public string AssignTo { get; set; }
        public string Designation { get; set; }

        public DateTime? AssignDate { get; set; }

        public string PackageStatus { get; set; }

        public int UserId { get; set; }
    }
}