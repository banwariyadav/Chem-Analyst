using ChemAnalyst.DAL;
using ChemAnalyst.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChemAnalyst.Controllers
{
    public class SliderController : Controller
    {
        SliderDataStore Obj = new SliderDataStore();
        // GET: SLider
        private ChemAnalystContext _context = new ChemAnalystContext();
        public ActionResult Index()
        {
            return View();
        }

        // GET: Quote

        // GET: AdvisorySolutions
        public ActionResult Slider()
        {

            return View("Slider");
        }

        // GET: NewsAndDeals
        public ActionResult GetSliderList()
        {
            return View("Slider");
        }
        public JsonResult SliderList()
        {

            List<SA_Slider> NewsList = Obj.GetSliderList();

            return Json(new { data = NewsList }, JsonRequestBehavior.AllowGet);

        }
        public ActionResult AddSlider()
        {
            var Model = new SA_Slider();
            return View(Model);

        }
        public ActionResult SaveSlider(SA_Slider UserNews)
        {
            for (int i = 0; i < Request.Files.Count; i++)
            {
                var file = Request.Files[i];

                if (file != null && file.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(file.FileName);

                    var path = Path.Combine(Server.MapPath("~/ProductImages"), fileName);
                    file.SaveAs(path);
                    UserNews.Img = fileName;
                }
            }
            UserNews.CreatedTime = DateTime.Now;
            //AdvisoryDataStore Obj = new AdvisoryDataStore();
            if (UserNews.id == 0)
            {
                Obj.AddSlider(UserNews);
            }
            else
            {
                Obj.EditSlider(UserNews);
            }
            return RedirectToAction("Slider");
        }


        public ActionResult EditSlider(int id)
        {
            SA_Slider obj = Obj.GetSliderByid(id);
            return View("AddSlider", obj);
        }
        public ActionResult DeleteSlider(int id)
        {
            if (Obj.DeleteSlider(id) == true)
            {
                return RedirectToAction("Slider");
            }
            else
            {
                return View("ErrorEventArgs");
            }
        }


        public ActionResult HeaderContent()
        {
            JobDataStore Obj = new JobDataStore();
            return View("HeaderContent");
        }

        public JsonResult HeaderContentList()
        {

            var lstData = _context.SA_HomeHeader.ToList();

            return Json(new { data = lstData }, JsonRequestBehavior.AllowGet);

        }


        public ActionResult AddHeaderContent(int id = 0)
        {


            SA_HomeHeader obj = new SA_HomeHeader();
            if (id > 0)
            {
                obj = _context.SA_HomeHeader.Where(w => w.Id == id).FirstOrDefault();
            }

            if (obj == null)
            {
                obj = new SA_HomeHeader();

            }
            //obj.ProductList = ObjDal.GetProductList();
            //SA_Industry obj = new SA_Industry();
            return View(obj);

        }

        [ValidateInput(false)]
        public ActionResult SaveHeaderContent(SA_HomeHeader UserNews)
        {
            if (UserNews.Id == 0)
            {
                UserNews.CreatedTime = DateTime.Now;
                _context.SA_HomeHeader.Add(UserNews);
                _context.SaveChangesAsync();
            }
            else
            {
                SA_HomeHeader EditNews = _context.SA_HomeHeader.Where(Cat => Cat.Id == UserNews.Id).FirstOrDefault();
                EditNews.EmailAddress = UserNews.EmailAddress;
                EditNews.OfficeAddress = UserNews.OfficeAddress;
                EditNews.PhoneNumber = UserNews.PhoneNumber;
            
                EditNews.CreatedTime = UserNews.CreatedTime;
                _context.Entry(EditNews).State = EntityState.Modified;
                int x = _context.SaveChanges();
            }
            return RedirectToAction("HeaderContent");
        }

    }
}
