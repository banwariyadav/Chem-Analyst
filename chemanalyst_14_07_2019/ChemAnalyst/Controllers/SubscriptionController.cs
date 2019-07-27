using ChemAnalyst.Common;
using ChemAnalyst.DAL;
using ChemAnalyst.Models;
using SpeedUpCoreAPIExample.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ChemAnalyst.Controllers
{
    public class SubscriptionController : Controller
    {
        // GET: Subscription
        private LeadDAL ObjLead;
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Lead()
        {
            return View("lead");
        }

        public ActionResult AddPackage(int id)
        {
            ViewBag.LeadId = id;
            return View("AddPackage");
        }

        public ActionResult Viewlead()
        {
            return View("viewlead");
        }
        public ActionResult Subscriptionpackage()
        {
            return View("subscriptionpackage");
        }

        [HttpPost]
        public async Task<ActionResult> SaveSalesPackageSubscriptionAsync(SalesPackageSubscription subs)
        {
            bool result = false;
            LeadDAL l = new LeadDAL();
            CustomerDataStore c = new CustomerDataStore();
            var lst = l.GetLeadByid(subs.LeadId);

            //string strPassword = "LetMeIn99$";
            string strPassword = "1234";
            string strEncrypted = (Helpers.Encrypt(strPassword));
            string strDecrypted = (Helpers.Decrypt(strEncrypted));

            try
            {

                subs.CreatedDate = DateTime.Now;
                CustWiseAccessDataStore DAL = new CustWiseAccessDataStore();
                CustomerDataStore Check = new CustomerDataStore();
                SubscriptionDAL Obj = new SubscriptionDAL();
                if (ModelState.IsValid)
                {
                    if (Check.CheckCustomerCount(lst.CorpEmail, strEncrypted) == 0)
                    {
                        result = await Obj.AddSalesPackageTrial(subs);
                        SA_Customer Customer = new SA_Customer();
                        Customer.MenuId = subs.Id.ToString();
                        Customer.Email = lst.CorpEmail;
                        Customer.Phone = lst.Phone;
                        Customer.UserPassword = strEncrypted;
                        Customer.Role = "Customer";
                        Customer.ProfileImage = "";
                        Customer.Fname = lst.Name;
                        Customer.Lname = "";

                        c.AddCustomer(Customer);
                        DAL.AddCustWiseAccess(subs.MenuId, Customer.id);
                        DAL.AddCustProduct(subs.ProductId, Customer.id);

                        string EmailBody = SubscriptionDAL.GetHtml("PackageWelcome.html");
                        //EmailBody = EmailBody.Replace("@Name@", Customer.Fname + " " + Customer.Lname);
                        EmailBody = EmailBody.Replace("@Pass@", "1234");
                        EmailBody = EmailBody.Replace("@Email@", Customer.Email);
                        //EmailBody = EmailBody.Replace("@SiteRoot@", CommonUtility.SitePath);
                        //EmailBody = EmailBody.Replace("@URL@", CommonUtility.SitePath);

                        SubscriptionDAL.SendMail("Chem Analyst", "info@chemanalyst", Customer.Email, "Package Activation", EmailBody, "mrnickolasjames@gmail.com");

                        UpdateLeadStatus(subs.LeadId);

                    }
                    else
                    {
                        var custId = c.GetCustomerList().Where(w => w.Email == lst.CorpEmail).FirstOrDefault().id;
                        result = await Obj.AddSalesPackageTrial(subs);
                        DAL.AddCustWiseAccess(subs.MenuId, custId);
                        DAL.AddCustProduct(subs.ProductId, custId);

                        return Json(new { result = "This customer is already added and added one more package into that account.", JsonRequestBehavior.AllowGet });
                    }

                }
            }
            catch (Exception ex)
            {
            }

            return Json(new { result = "Data Added Successfully", JsonRequestBehavior.AllowGet });
        }



        private void UpdateLeadStatus(int leadId)
        {
            try
            {
                LeadDAL db = new LeadDAL();
                Lead_Master lm = new Lead_Master();
                lm = db.GetLeadList().Where(x => x.Id == leadId).FirstOrDefault();
                lm.Status = "Won";
                db.AddLeadDetails(lm);
            }
            catch (Exception ex)
            {
                throw;
            }
           
        }
    }



}


