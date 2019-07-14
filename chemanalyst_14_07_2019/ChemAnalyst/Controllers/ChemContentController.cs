using ChemAnalyst.DAL;
using ChemAnalyst.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChemAnalyst.Controllers
{
    public class ChemContentController : Controller
    {
        ChemContentDataStore Obj = new ChemContentDataStore();
        // GET: ChemContent
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AddChemContent()
        {
            //NewsDataStore ObjDal = new NewsDataStore();
            //SA_NewsViewModel objCatViewModel = new SA_NewsViewModel();
            //objCatViewModel.ProductList = ObjDal.GetProductList();
            //return View("AddIndustry", objCatViewModel);

            SA_ChemContent obj = Obj.GetChemContentByid(1);
            if (obj == null)
            {
                obj = new SA_ChemContent();
            }
            return View(obj);

        }
        [ValidateInput(false)]
        public ActionResult SaveChemContent(SA_ChemContent UserNews)
        {
            //for (int i = 0; i < Request.Files.Count; i++)
            //{
            //    var file = Request.Files[i];

            //    if (file != null && file.ContentLength > 0)
            //    {
            //        var fileName = Path.GetFileName(file.FileName);

            //        var path = Path.Combine(Server.MapPath("~/ProductImages"), fileName);
            //        file.SaveAs(path);
            //        UserNews.Image = fileName;
            //    }
            //}

            if (UserNews.id == 0)
            {
                Obj.AddChemContent(UserNews);
            }
            else if (UserNews.id == 1)
            {
                Obj.EditChemContent(UserNews);
            }
            return RedirectToAction("AddChemContent");
        }
    }
}