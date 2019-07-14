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
    public class AdvisorySolutionsController : Controller
    {
        AdvisoryDataStore Obj = new AdvisoryDataStore();
        // GET: AdvisorySolutions
        public ActionResult Advisory()
        {
            AdvisoryDataStore Obj = new AdvisoryDataStore();
            return View("Advisory");
        }
     
            // GET: NewsAndDeals
            public ActionResult GetAdvisoryList()
            {
                return View("Advisory");
            }
            public JsonResult AdvisoryList()
            {
             
                List<SA_Advisory> NewsList = Obj.GetAdvisoryList();

                return Json(new { data = NewsList }, JsonRequestBehavior.AllowGet);

            }
            public ActionResult AddAdvisory()
            {
            var Model = new SA_Advisory();
                return View(Model);

            }
            public ActionResult SaveAdvisory(SA_Advisory UserNews)
            {
                for (int i = 0; i < Request.Files.Count; i++)
                {
                    var file = Request.Files[i];

                    if (file != null && file.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(file.FileName);

                        var path = Path.Combine(Server.MapPath("~/ProductImages"), fileName);
                        file.SaveAs(path);
                        UserNews.AdvisoryImg = fileName;
                    }
                }
                UserNews.CreatedTime = DateTime.Now;
                AdvisoryDataStore Obj = new AdvisoryDataStore();
                if (UserNews.id == 0)
                {
                    Obj.AddAdvisory(UserNews);
                }
                else
                {
                    Obj.EditAdvisory(UserNews);
                }
                return RedirectToAction("Advisory");
            }


            public ActionResult EditAdvisory(int id)
            {         
                SA_Advisory obj = Obj.GetAdvisoryByid(id);  
                return View("AddAdvisory", obj);
            }
        public ActionResult DeleteAdvisory(int id)
        {
            if (Obj.DeleteAdvisory(id) == true)
            {
                return RedirectToAction("Advisory");
            }
            else
            {
                return View("ErrorEventArgs");
            }
        }
        }

      
}

