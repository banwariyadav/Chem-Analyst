using ChemAnalyst.DAL;
using ChemAnalyst.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChemAnalyst.Controllers
{
    public class CompanyController : Controller
    {
        CompanyDataStore Obj = new CompanyDataStore();
        // GET: Company
        public ActionResult Index()
        {
            return View();
        }


        // GET: AdvisorySolutions
        public ActionResult Company()
        {
            JobDataStore Obj = new JobDataStore();
            return View("Company");
        }

        // GET: NewsAndDeals
        public ActionResult GetCompanyList()
        {
            return View("Company");
        }
        public JsonResult CompanyList()
        {

            List<SA_Company> NewsList = Obj.GetCompanyList();

            return Json(new { data = NewsList }, JsonRequestBehavior.AllowGet);

        }
        public ActionResult AddCompany()
        {
            var Model = new SA_Company();
            return View(Model);

        }
        public ActionResult SaveCompany(SA_Company UserNews)
        {
            for (int i = 0; i < Request.Files.Count; i++)
            {
                var file = Request.Files[i];

                if (file != null && file.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(file.FileName);

                    var path = Path.Combine(Server.MapPath("~/ProductImages"), fileName);
                    file.SaveAs(path);
                    UserNews.Logo = fileName;



                }
            }
            UserNews.CreatedTime = DateTime.Now;

            if (UserNews.id == 0)
            {
                Obj.AddCompany(UserNews);
            }
            else
            {
                Obj.EditCompany(UserNews);
            }
            return RedirectToAction("Company");
        }


        public ActionResult EditCompany(int id)
        {
            SA_Company obj = Obj.GetCompanyByid(id);
            return View("AddCompany", obj);
        }
        public ActionResult DeleteCompany(int id)
        {
            if (Obj.DeleteCompany(id) == true)
            {
                return View("Company");
            }
            else
            {
                return View("ErrorEventArgs");
            }
        }
        public ActionResult CompanyProfile()
        {
            List<SA_Company> NewsList = Obj.GetCompanyList().OrderBy(w => w.id).Take(1).ToList();
            NewsList.OrderBy(x => x.CreatedTime).Take(1);
            return View(NewsList);

        }
    }
}
