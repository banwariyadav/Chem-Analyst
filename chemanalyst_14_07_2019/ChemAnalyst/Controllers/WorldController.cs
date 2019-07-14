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
    public class WorldController : Controller
    {
        WorldDataStore Obj = new WorldDataStore();
        // GET: World
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AddWorld()
        {
            //NewsDataStore ObjDal = new NewsDataStore();
            //SA_NewsViewModel objCatViewModel = new SA_NewsViewModel();
            //objCatViewModel.ProductList = ObjDal.GetProductList();
            //return View("AddIndustry", objCatViewModel);

            SA_World obj = Obj.GetWorldByid(1);
            if (obj == null)
            {
                obj = new SA_World();
            }
            return View(obj);

        }
        [ValidateInput(false)]
        public ActionResult SaveWorld(SA_World UserNews)
        {
            for (int i = 0; i < Request.Files.Count; i++)
            {
                var file = Request.Files[i];

                if (file != null && file.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(file.FileName);

                    var path = Path.Combine(Server.MapPath("~/ProductImages"), fileName);
                    file.SaveAs(path);
                    UserNews.Image = fileName;
                }
            }

            if (UserNews.id == 0)
            {
                Obj.AddWorld(UserNews);
            }
            else if (UserNews.id == 1)
            {
                Obj.EditWorld(UserNews);
            }
            return RedirectToAction("AddWorld");
        }
    }
}