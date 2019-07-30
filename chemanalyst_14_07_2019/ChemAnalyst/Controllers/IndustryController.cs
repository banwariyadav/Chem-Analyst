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
    public class IndustryController : Controller
    {
        // GET: Industry
        // GET: Quote
        IndustryDataStore Obj = new IndustryDataStore();
        // GET: AdvisorySolutions
        private ChemAnalystContext _context = new ChemAnalystContext();
        public ActionResult Industry()
        {
            return View("Industry");
        }

        // GET: NewsAndDeals
        public ActionResult GetIndustryList()
        {
            return View("Industry");
        }
        public JsonResult IndustryList()
        {

            List<SA_Industry> NewsList = Obj.GetIndustryList().OrderByDescending(w => w.id).ToList();

            return Json(new { data = NewsList }, JsonRequestBehavior.AllowGet);

        }
        public ActionResult AddIndustry(int id = 0)
        {
            //NewsDataStore ObjDal = new NewsDataStore();
            //SA_NewsViewModel objCatViewModel = new SA_NewsViewModel();
            //objCatViewModel.ProductList = ObjDal.GetProductList();
            //return View("AddIndustry", objCatViewModel);

            SA_Industry obj = new SA_Industry();
            if (id > 0)
            {
                obj = Obj.GetIndustryByid(id);
            }

            if (obj == null)
            {
                obj = new SA_Industry();

            }
            //obj.ProductList = ObjDal.GetProductList();
            //SA_Industry obj = new SA_Industry();
            return View(obj);

        }
        [ValidateInput(false)]
        public ActionResult SaveIndustry(SA_Industry UserNews)
        {

            if (UserNews.id == 0)
            {
                var Category = _context.SA_Product.Where(w => w.id == UserNews.Product).FirstOrDefault().Category;
                UserNews.CategoryID = Category;
                Obj.AddIndustry(UserNews);
            }
            else
            {
                var Category = _context.SA_Product.Where(w => w.id == UserNews.Product).FirstOrDefault().Category;
                UserNews.CategoryID = Category;
                UserNews.CountryID = UserNews.CountryID;
                Obj.EditIndustry(UserNews);
            }
            return RedirectToAction("ShowIndustryList", "Admin");
        }


        public ActionResult EditIndustry(int id)
        {
            SA_Industry obj = Obj.GetIndustryByid(id);
            return View("AddIndustry", obj);
        }

        public ActionResult DeleteIndustry(int id)
        {
            if (Obj.DeleteIndustry(id) == true)
            {
                return RedirectToAction("ShowIndustryList", "Admin");
            }
            else
            {
                return View("ErrorEventArgs");
            }
        }

        public ActionResult IndustryReport(int id)
        {
            NewsDataStore n = new NewsDataStore();
            DealsDataStore d = new DealsDataStore();
            IndustryViewModel model = new IndustryViewModel();
            List<SA_Industry> IndustryList = Obj.GetIndustryList().Where(w => w.id == id).OrderBy(w => w.id).ToList(); ;
            model.Industry = IndustryList;
            List<SA_News> NewsList = n.GetNewsList();
            model.NewsList = NewsList;
            List<SA_Deals> DealList = d.GetDealsList();
            model.DealsList = DealList;
            return View(model);

        }

        public ActionResult Reportsection()
        {

            string cate = Request.Form["categoryname"] != null ? Request.Form["categoryname"].ToString() : "";
            string country = Request.Form["countryname"] != null ? Request.Form["countryname"].ToString() : "";
            ViewBag.Cat = cate;
            ViewBag.Cou = country;
            CategoryDataStore d = new CategoryDataStore();
            IndustryViewModel model = new IndustryViewModel();
            List<SA_Industry> IndustryList = Obj.GetIndustryList().Where(x => (cate == "" || cate.Contains(x.CategoryID.ToString() + ",")) && (country == "" || country.Contains(x.CountryID.ToString() + ","))).OrderBy(w => w.id).OrderByDescending(w=>w.id).ToList(); 
            model.Industry = IndustryList;
            List<SelectListItem> lstCategory = d.CategoryList();
            model.lstCategory = lstCategory;

            List<SelectListItem> lstCountry = d.CountryList();
            model.lstCountry = lstCountry;

            return View("report-section", model);

        }

        public ActionResult IndustryReports(int id)
        {
            NewsDataStore n = new NewsDataStore();
            DealsDataStore d = new DealsDataStore();
            IndustryViewModel model = new IndustryViewModel();
            //List<SA_Industry> IndustryList = Obj.GetIndustryList();
            List<SA_Industry> IndustryList = Obj.GetCustIndustryList(id);
            model.Industry = IndustryList;
            List<SA_News> NewsList = n.GetNewsList();
            model.NewsList = NewsList;
            List<SA_Deals> DealList = d.GetDealsList();
            model.DealsList = DealList;
            return View(model);

        }
    }
}


