using ChemAnalyst.DAL;
using ChemAnalyst.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChemAnalyst.Controllers
{
    public class ContactUSController : Controller
    {
        ContactDataStore obj = new ContactDataStore();
        // GET: ContactUS
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Contact()
        {

            return View("Contact");
        }

        // GET: NewsAndDeals
        public ActionResult GetContactList()
        {
            return View("Contact");
        }
        public JsonResult ContactList()
        {

            List<SA_Contact> NewsList = obj.GetContactList();

            return Json(new { data = NewsList }, JsonRequestBehavior.AllowGet);

        }
        public ActionResult AddContact(SA_Contact model)
        {
            if (model.id == 0)
            {
                obj.AddContact(model);
            }
            return View("Contact");
        }
    }
}