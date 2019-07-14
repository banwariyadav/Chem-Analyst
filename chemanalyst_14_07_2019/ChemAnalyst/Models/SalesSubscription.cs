using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ChemAnalyst.Models
{
    public class SalesSubscription
    {
        [Key]
        public int SId { get; set; }
        public int LeadId { get; set; }
        public string Subscribe { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public string Package { get; set; }
        public string Status { get; set; }
        public string AssignedUserId { get; set; }
    }
}