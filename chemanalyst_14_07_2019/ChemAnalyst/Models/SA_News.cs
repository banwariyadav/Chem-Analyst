namespace ChemAnalyst.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Text.RegularExpressions;
    using System.Web;
   

    public partial class SA_News
    {
        public int id { get; set; }

        [StringLength(500)]
        public string NewsName { get; set; }

        [StringLength(500)]
        public string MetaTitle { get; set; }

        [StringLength(5000)]
        public string NewsDiscription { get; set; }

        [StringLength(500)]
        public string URL { get; set; }

        [StringLength(1000)]
        public string MetaDiscription { get; set; }

        public int? status { get; set; }

        public DateTime CreatedTime { get; set; }

        [StringLength(1009)]
        public string NewsImg { get; set; }

        public int? Product { get; set; }

        [StringLength(1000)]
        public string Keywords { get; set; }

        public string CreatedBy { get; set; }

        public string GenerateItemNameAsParam()
        {
            string phrase = string.Format("{0}-{1}", id, URL);// Creates in the specific pattern  
            string str = GetByteArray(phrase).ToLower();
            str = Regex.Replace(str, @"[^a-z0-9\s-]", "");// Remove invalid characters for param  
            str = Regex.Replace(str, @"\s+", "-").Trim(); // convert multiple spaces into one hyphens   
            //str = str.Substring(0, str.Length <= 30 ? str.Length : 30).Trim(); //Trim to max 30 char  
            str = Regex.Replace(str, @"\s", "-"); // Replaces spaces with hyphens     
            return str;
        }

        private string GetByteArray(string text)
        {
            byte[] bytes = System.Text.Encoding.GetEncoding("Cyrillic").GetBytes(text);
            return System.Text.Encoding.ASCII.GetString(bytes);
        }

        //public static string UpdateMetaDetails(string pageUrl)
        //{
        //    //--- StringBuilder object to store MetaTags information.
        //    StringBuilder sbMetaTags = new StringBuilder();

        //    //--Step1 Get data from database.
        //    using (myEntities db = new myEntities())
        //    {
        //        var obj = db.PageMetaDetails.FirstOrDefault(a => a.PageUrl == pageUrl);

        //        //---- Step2 In this step we will add <title> tag to our StringBuilder Object.
        //        sbMetaTags.Append("<title>" + obj.Title + "</title>");
        //        sbMetaTags.Append(Environment.NewLine);

        //        //---- Step3 In this step we will add "Meta Description" to our StringBuilder Object.
        //        sbMetaTags.Append("<meta name="\"description\"" content = "\""" +="" obj.metadescription="" "\"="">");
        //        sbMetaTags.Append(Environment.NewLine);
        //        //---- Step4 In this step we will add "Meta Keywords" to our StringBuilder Object.
        //        sbMetaTags.Append("<meta name="\"keywords\"" content = "\""" +="" obj.metakeywords="" "\"="">");
        //    }
        //    return sbMetaTags.ToString();
        //}
    }
}
