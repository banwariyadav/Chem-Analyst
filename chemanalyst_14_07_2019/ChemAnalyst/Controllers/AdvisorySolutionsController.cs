using ChemAnalyst.DAL;
using ChemAnalyst.Models;
using ChemAnalyst.ViewModel;
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
        private ChemAnalystContext _context = new ChemAnalystContext();
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

        [ValidateInput(false)]
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

        public ActionResult AdvsoryContent()
        {
            JobDataStore Obj = new JobDataStore();
            return View("AdvsoryContent");
        }

        public JsonResult AdvsoryContentList()
        {

            List<AdvisoryContentVM> NewsList = _context.SA_AdvisoryContent.ToList().Select(w => new AdvisoryContentVM
            {
                Id = w.Id,
                AdsId = w.AdsId,
                Advisory = _context.SA_Advisory.Where(x => x.id == w.AdsId).FirstOrDefault()!=null? _context.SA_Advisory.Where(x => x.id == w.AdsId).FirstOrDefault().AdvisoryName : ""
            }).ToList();

            return Json(new { data = NewsList }, JsonRequestBehavior.AllowGet);

        }

       
        public ActionResult AddAdvisoryContent(int id = 0)
        {
            

            SA_AdvisoryContent obj = new SA_AdvisoryContent();
            if (id > 0)
            {
                obj = _context.SA_AdvisoryContent.Where(w => w.Id == id).FirstOrDefault();
            }

            if (obj == null)
            {
                obj = new SA_AdvisoryContent();

            }
            //obj.ProductList = ObjDal.GetProductList();
            //SA_Industry obj = new SA_Industry();
            return View(obj);

        }

        [ValidateInput(false)]
        public ActionResult SaveAdvisoryContent(SA_AdvisoryContent UserNews)
        {
            if (UserNews.Id == 0)
            {
                Obj.AddAdvisoryConetnt(UserNews);
            }
            else
            {
                Obj.EditAdvisoryConetnt(UserNews);
            }
            return RedirectToAction("AdvsoryContent");
        }


        public ActionResult AdvisoryDetails(int id)
        {
            var data = _context.SA_Advisory.Where(w => w.id == id).FirstOrDefault();
            return View(data);
        }

    }


}

