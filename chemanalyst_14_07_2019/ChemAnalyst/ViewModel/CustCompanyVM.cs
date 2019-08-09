using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChemAnalyst.ViewModel
{
    public class CustCompanyVM
    {

        public int id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Logo { get; set; }
        public string RegDate { get; set; }
        public string CIN { get; set; }
        public string Category { get; set; }
        public string Address { get; set; }
        public string NOE { get; set; }
        public string CEO { get; set; }
        public string Meta { get; set; }

        public string MetaDescription { get; set; }
        public string website { get; set; }
        public string phoneNo { get; set; }
        public string fax { get; set; }
        public string EmailId { get; set; }
        public string CreatedTime { get; set; }

        public List<CompanyFinacialData> lstFinacialData { get; set; }

    }

    public class CompanyFinacialData
    {
        public string FinacialYear { get; set; }
        public decimal Revenue { get; set; }
        public decimal Growth { get; set; }

        public int PBT { get; set; }
        public decimal Margin { get; set; }
        public decimal Pat { get; set; }
        public decimal Liablities { get; set; }
    }

    public class CompanySWOT
    {
        public string Company { get; set; }
        public int CompanyId { get; set; }
        public int Id { get; set; }
    }

    public class AdvisoryContentVM
    {
        public string Advisory { get; set; }
        public int AdsId { get; set; }
        public int Id { get; set; }
    }

}