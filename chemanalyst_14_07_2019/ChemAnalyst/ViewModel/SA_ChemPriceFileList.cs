namespace ChemAnalyst.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SA_ChemPriceFileList
    {


        public string Product { get; set; }


        public string year { get; set; }
        public string Month { get; set; }
        public string day { get; set; }
        public decimal count { get; set; }
        public string Discription { get; set; }
        public string FileName { get; set; }
        public string Range { get; set; }
        public string CreatedDate { get; set; }

        public string CreatedBy { get; set; }
    }
}
