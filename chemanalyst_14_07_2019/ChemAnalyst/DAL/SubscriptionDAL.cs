using ChemAnalyst.Models;
using SpeedUpCoreAPIExample.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ChemAnalyst.DAL
{

    public class SubscriptionDAL
    {
        private ChemAnalystContext _context = new ChemAnalystContext();

        public async Task<bool> AddSalesPackageTrial(SalesPackageSubscription subs)
        {
            int x = 0;
            try
            {
                subs.Status = "Active";
                _context.SalesPackageSubscription.Add(subs);
                x = await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
            }
            return x == 0 ? false : true;
        }

        public static bool SendMail(string FromName, string FromEmail, string ToEmail, string Title, string Content, string cc = "")
        {
            bool retVal = false;
            SmtpClient smtpClient = new SmtpClient();
            MailMessage message = new MailMessage();
            var smtpDetails = "";

            string SmtpUser = System.Configuration.ConfigurationManager.AppSettings["UserName"].ToString(); ;
            string SmtpPassword = System.Configuration.ConfigurationManager.AppSettings["Password"].ToString(); ;
            string SmtpHost = System.Configuration.ConfigurationManager.AppSettings["HostName"].ToString(); ;


            try
            {
                MailAddress fromAddres = new MailAddress(SmtpUser, "ChemAnalyest");
                smtpClient.Host = SmtpHost;
                smtpClient.EnableSsl = true;
                smtpClient.UseDefaultCredentials = true;
                smtpClient.Credentials = new System.Net.NetworkCredential(SmtpUser, SmtpPassword);
                smtpClient.Port = 587;
                message.From = fromAddres;
                message.To.Add(ToEmail);
                message.CC.Add(cc);
                message.Subject = Title;
                message.IsBodyHtml = true;
                message.Body = Content;
                smtpClient.Send(message);
                retVal = true;
            }
            catch (Exception ex)
            {
                throw;
            }

            return retVal;
        }

        public static string GetHtml(string argTemplateDocument)
        {
            StreamReader sr = default(StreamReader);
            string Data = null;
            string _path = HttpContext.Current.Server.MapPath("~/Templates/") + argTemplateDocument;
            sr = File.OpenText(_path);
            Data = sr.ReadToEnd();
            return Data;
        }
    }
}