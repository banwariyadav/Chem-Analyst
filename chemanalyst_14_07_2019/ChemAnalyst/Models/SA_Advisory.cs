using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ChemAnalyst.Models
{
    public partial class SA_Advisory
    {
       
            public int id { get; set; }

            [StringLength(50)]
            public string AdvisoryName { get; set; }

            [StringLength(500)]
            public string AdvisoryDiscription { get; set; }

            [StringLength(50)]
            public string Meta { get; set; }

            [StringLength(500)]
            public string MetaDiscription { get; set; }

            public int? status { get; set; }

            public DateTime? CreatedTime { get; set; }

            [StringLength(50)]
            public string AdvisoryImg { get; set; }

        
    

}
}