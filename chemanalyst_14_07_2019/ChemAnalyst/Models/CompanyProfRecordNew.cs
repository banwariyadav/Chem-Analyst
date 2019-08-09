using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ChemAnalyst.Models
{
    [Table("SA_CompanyProfRecordNew")]
    public class CompanyProfRecordNew
    {
        public int Id { get; set; }
        public int SA_CompanyId { get; set; }
        public int FinancialYearId { get; set; }
        public decimal Revenue { get; set; }
        public int Growth { get; set; }
        public int PBT { get; set; }
        public decimal Margin { get; set; }
        public decimal Pat { get; set; }
        public decimal Liablities { get; set; }
        public DateTime CreateDate { get; set; }
        public SA_Company SA_Company { get; set; }
        public FinancialYear FinancialYear { get; set; }
    }
}