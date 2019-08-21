﻿using ChemAnalyst.DAL;
using ChemAnalyst.Models;
using ChemAnalyst.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChemAnalyst.Controllers
{
    public class SubsManagementController : Controller
    {
        // GET: SubsManagement

        private ChemAnalystContext _contextDb = new ChemAnalystContext();

        private LeadDAL ObjLead;
        UserDataStore ObjUser = new UserDataStore();
        public SubsManagementController()
        {

            ObjLead = new LeadDAL();
        }
        public ActionResult LeadManagement()
        {
            return View("LeadManagementList");
        }

        public JsonResult GetLeadManagementList()
        {
            List<Lead_Master> leadList;
            string loggeduser = Session["User"].ToString().Trim();
            string items = Session["LoginUser"].ToString();
            List<SubscriptionViewModel> SubscriptionList;
            if (Session["UserRole"].ToString() == "Admin")
            {
                leadList = ObjLead.GetLeadList();
            }
            else
            {
                leadList = ObjLead.GetLeadListforothers(items);
            }
            foreach (var item in leadList)
            {
                if (item.AssignTo == "NA" || item.AssignTo == null)
                {
                    item.AssignTo = "---";
                }
                else
                {
                    item.AssignTo = ObjUser.GetUserByid(Convert.ToInt32(item.AssignTo)) != null ? ObjUser.GetUserByid(Convert.ToInt32(item.AssignTo)).Fname : "NA";
                }
            }
            return Json(new { data = leadList }, JsonRequestBehavior.AllowGet);

        }

        public ActionResult ViewDetails(int Id)
        {
            LeadViewModel objLeadModel = new LeadViewModel();
            objLeadModel.StatusList = new List<SelectListItem>();
            objLeadModel.StatusList = new List<SelectListItem> {
        new SelectListItem { Value = "Pending", Text = "Pending" },
        new SelectListItem { Value = "Assign", Text = "Assign" },
        new SelectListItem { Value = "Lost", Text = "Lost" } };

            objLeadModel.UserList = ObjLead.GetUserList();

            objLeadModel.hdId = Convert.ToString(Id);

            objLeadModel.LeadMaster = new Lead_Master();
            objLeadModel.LeadMaster = ObjLead.GetLeadList().Where(x => x.Id == Id).FirstOrDefault();
            if (objLeadModel.LeadMaster.AssignTo == "NA" || objLeadModel.LeadMaster.AssignTo == null)
                objLeadModel.LeadMaster.AssignTo = "---";
            return View("ViewLeadDetails", objLeadModel);
        }

        public ActionResult ViewAllSubscriptions(int Id)
        {
            LeadViewModel objLeadModel = new LeadViewModel();
            objLeadModel.StatusList = new List<SelectListItem>();
            objLeadModel.StatusList = new List<SelectListItem> {
        new SelectListItem { Value = "Pending", Text = "Pending" },
        new SelectListItem { Value = "Assign", Text = "Assign" },
        new SelectListItem { Value = "Lost", Text = "Lost" } };

            objLeadModel.UserList = ObjLead.GetUserList();

            objLeadModel.hdId = Convert.ToString(Id);
            objLeadModel.LeadMaster = new Lead_Master();

            int leadId = _contextDb.SalesPackageSubscription.Where(w => w.UserId == Id).FirstOrDefault().LeadId;
            objLeadModel.LeadMaster = ObjLead.GetLeadList().Where(x => x.Id == leadId).FirstOrDefault();
            if (objLeadModel.LeadMaster.AssignTo == "NA" || objLeadModel.LeadMaster.AssignTo == null)
                objLeadModel.LeadMaster.AssignTo = "---";

            var lstSubscription = _contextDb.SalesPackageSubscription.Where(w => w.UserId == Id).ToList().OrderByDescending(w => w.CreatedDate);

            //foreach (var item in lstSubscription)
            //{
            //    string[] pages = item.ProductId.Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);

            //}



            objLeadModel.SubscriptionList = lstSubscription.ToList();



            return View("ViewAllSubscriptions", objLeadModel);
        }

        public ActionResult AssignLeadDetails(LeadViewModel model)
        {
            int id = Convert.ToInt32(model.hdId);
            Lead_Master lm = new Lead_Master();
            lm = ObjLead.GetLeadList().Where(x => x.Id == id).FirstOrDefault();
            lm.Status = model.LeadMaster.Status;
            lm.AssignTo = model.LeadMaster.AssignTo;
            lm.AssignDate = DateTime.Now.Date;
            ObjLead.AddLeadDetails(lm);
            //ObjLead.AddSubscrption(lm);
            return RedirectToAction("LeadManagement");
        }


        public ActionResult ShowSubscriptionListForSales()
        {
            return View("ShowSubscriptionListForSales");
        }

        public JsonResult ShowSubscriptionList()
        {
            string loggeduser = Session["User"].ToString().Trim();
            string item = Session["LoginUser"].ToString();
            List<SubscriptionViewModel> SubscriptionList;
            if (Session["UserRole"].ToString() == "Admin")
            {
                //SubscriptionList = ObjLead.SubscriptionListforadmin(loggeduser);
                SubscriptionList = ObjLead.SubscriptionListforAdminNew(loggeduser);
            }
            else
            {
                SubscriptionList = ObjLead.SubscriptionList(item);
            }
            // return View("Subscription-list", SubscriptionListList);
            return Json(new { data = SubscriptionList }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult SendNotification(int LeadId)
        {

            ChemAnalystContext _context = new ChemAnalystContext();

            var email = _context.Lead_Master.Where(w => w.Id == LeadId).FirstOrDefault().CorpEmail;

            string EmailBody = SubscriptionDAL.GetHtml("PackageExpiry.html");
            //EmailBody = EmailBody.Replace("@Name@", Customer.Fname + " " + Customer.Lname);
            //EmailBody = EmailBody.Replace("@Pass@", "1234");
            //EmailBody = EmailBody.Replace("@Email@", email);
            //EmailBody = EmailBody.Replace("@SiteRoot@", CommonUtility.SitePath);
            //EmailBody = EmailBody.Replace("@URL@", CommonUtility.SitePath);


            SubscriptionDAL.SendMail("Chem Analyst", "info@chemanalyst", email, "Package Expiry Notification", EmailBody, "mrnickolasjames@gmail.com");



            return Json(new { data = "Success" }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult RenewSubscription(int subId, DateTime fromDate, DateTime toDate)
        {

            ChemAnalystContext _context = new ChemAnalystContext();

            var subsData = _context.SalesPackageSubscription.Where(w => w.Id == subId).FirstOrDefault();
            subsData.FromDate = fromDate;
            subsData.ToDate = toDate;
            _context.SaveChanges();
            //string EmailBody = SubscriptionDAL.GetHtml("PackageExpiry.html");
            // SubscriptionDAL.SendMail("Chem Analyst", "info@chemanalyst", email, "Package Expiry Notification", EmailBody, "mrnickolasjames@gmail.com");

            return Json(new { data = "Success" }, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public JsonResult DeleteLead(int leadId)
        {
            bool result = false;
            try
            {
                Lead_Master lead = _contextDb.Lead_Master.Where(News => News.Id == leadId).FirstOrDefault();
                _contextDb.Entry(lead).State = EntityState.Deleted;
                _contextDb.SaveChanges();

                return Json(new { data = "Success" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { data = "fail" }, JsonRequestBehavior.AllowGet);
            }

            return Json(new { result = result, JsonRequestBehavior.AllowGet });
        }

    }
}