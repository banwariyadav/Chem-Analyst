using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChemAnalyst.Models
{
    public class LeadViewModel
    {
        public Lead_Master LeadMaster { get; set; }
        public string hdId { get; set; }
        public List<SelectListItem> StatusList { get; set; }
        public List<SelectListItem> UserList { get; set; }
    }
}