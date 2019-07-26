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

                List<SA_Industry> NewsList = Obj.GetIndustryList();

                return Json(new { data = NewsList }, JsonRequestBehavior.AllowGet);

            }
        public ActionResult AddIndustry(int id =0)
        {
            //NewsDataStore ObjDal = new NewsDataStore();
            //SA_NewsViewModel objCatViewModel = new SA_NewsViewModel();
            //objCatViewModel.ProductList = ObjDal.GetProductList();
            //return View("AddIndustry", objCatViewModel);

            SA_Industry obj = new SA_Industry();
            if (id > 0)
            {
                obj= Obj.GetIndustryByid(id);
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
                    Obj.AddIndustry(UserNews);
                }
                else
                {
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
            List<SA_Industry> IndustryList = Obj.GetIndustryList().Where(w=>w.id==id).OrderBy(w => w.id).ToList(); ;
            model.Industry = IndustryList;
            List<SA_News> NewsList = n.GetNewsList();
            model.NewsList = NewsList;
            List<SA_Deals> DealList = d.GetDealsList();
            model.DealsList = DealList;
            return View(model);

        }

        public ActionResult Reportsection()
        {
            CategoryDataStore d = new CategoryDataStore();
            IndustryViewModel model = new IndustryViewModel();
            List<SA_Industry> IndustryList = Obj.GetIndustryList().OrderBy(w => w.id).ToList(); ;
            model.Industry = IndustryList;
            List<SelectListItem> lstCategory = d.CategoryList();
            model.lstCategory = lstCategory;
           


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
            List <SA_Deals> DealList = d.GetDealsList();
            model.DealsList = DealList;
            return View(model);
            
         }
    }
    }


      