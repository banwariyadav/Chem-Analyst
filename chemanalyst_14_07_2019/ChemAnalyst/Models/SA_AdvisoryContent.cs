using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ChemAnalyst.Models
{
    public partial class SA_AdvisoryContent
    {

        [Key]
        public int Id { get; set; }

        public int AdsId { get; set; }
       
        public string ADVISORY1 { get; set; }

        public string ADVISORY2 { get; set; }
    
        public string ADVISORY3 { get; set; }
       
        public string ADVISORY4 { get; set; }

        public string ADVISORY5 { get; set; }

        public string ADVISORY6 { get; set; }

        public DateTime? CreatedTime { get; set; }


    }
}