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
    public class SliderController : Controller
    {
        SliderDataStore Obj = new SliderDataStore();
        // GET: SLider
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
        }
    }
