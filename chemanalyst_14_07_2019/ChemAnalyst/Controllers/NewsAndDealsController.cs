using ChemAnalyst.Authorize;
using ChemAnalyst.DAL;
using ChemAnalyst.Models;
using ChemAnalyst.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using System.Collections;

namespace ChemAnalyst.Controllers
{
    public class NewsAndDealsController : Controller
    {
        // GET: NewsAndDeals
        public ActionResult News()
        {
            NewsDataStore Obj = new NewsDataStore();
            //List<SA_News> NewsList = Obj.GetNewsList();
            return View("News");
        }

        public ActionResult GetNewsList()
        {
            return View("News");
        }
        public JsonResult NewsList()
        {
            NewsDataStore Obj = new NewsDataStore();
            List<SA_News> NewsList = Obj.GetNewsListAdmin();

            return Json(new { data = NewsList }, JsonRequestBehavior.AllowGet);

        }
        public ActionResult AddNews()
        {
            NewsDataStore ObjDal = new NewsDataStore();
            SA_NewsViewModel objCatViewModel = new SA_NewsViewModel();
            objCatViewModel.ProductList = ObjDal.GetProductList();

            return View("add-News", objCatViewModel);

        }
        public ActionResult SaveNews(SA_News UserNews)
        {
            for (int i = 0; i < Request.Files.Count; i++)
            {
                var file = Request.Files[i];

                if (file != null && file.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(file.FileName);

                    var path = Path.Combine(Server.MapPath("~/ProductImages"), fileName);
                    file.SaveAs(path);
                    UserNews.NewsImg = fileName;



                }
            }
            UserNews.CreatedTime = DateTime.Now;
            NewsDataStore Obj = new NewsDataStore();
            if (UserNews.id == 0)
            {
                Obj.AddNews(UserNews);
            }
            else
            {
                Obj.EditNews(UserNews);
            }
            return RedirectToAction("News");
        }


        public ActionResult EditNews(int id)
        {

            NewsDataStore Obj = new NewsDataStore();
            SA_News obj = Obj.GetNewsByid(id);
            List<SelectListItem> productList = Obj.GetProductList();
            SA_NewsViewModel objSaCatV = new SA_NewsViewModel();
            objSaCatV.id = obj.id;
            objSaCatV.NewsName = obj.NewsName;
            objSaCatV.NewsDiscription = obj.NewsDiscription;
            objSaCatV.URL = obj.URL;
            objSaCatV.MetaDiscription = obj.MetaDiscription;
            objSaCatV.Keywords = obj.Keywords;
            objSaCatV.ProductList = productList;
            objSaCatV.Product = obj.Product.ToString();



            return View("add-News", objSaCatV);
        }
        public ActionResult DeleteNews(int id)
        {

            NewsDataStore Obj = new NewsDataStore();
            if (Obj.DeleteNews(id) == true)
            {
                return RedirectToAction("News");
            }
            else
            {
                return View("ErrorEventArgs");
            }
        }

        public ActionResult Deals()
        {
            DealsDataStore Obj = new DealsDataStore();
            //List<SA_Deals> DealsList = Obj.GetDealsList();
            return View("Deals");
        }
        public ActionResult GetDealsList()
        {
            return View("Deals");
        }
        public JsonResult DealsList()
        {
            DealsDataStore Obj = new DealsDataStore();
            List<SA_Deals> DealsList = Obj.GetDealsListAdmin();

            return Json(new { data = DealsList }, JsonRequestBehavior.AllowGet);

        }
        public ActionResult AddDeals()
        {
            DealsDataStore ObjDal = new DealsDataStore();
            SA_DealsViewModel objCatViewModel = new SA_DealsViewModel();
            objCatViewModel.ProductList = ObjDal.GetProductList();

            return View("add-Deals", objCatViewModel);

        }
        public ActionResult SaveDeals(SA_Deals UserDeals)
        {
            for (int i = 0; i < Request.Files.Count; i++)
            {
                var file = Request.Files[i];

                if (file != null && file.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(file.FileName);

                    var path = Path.Combine(Server.MapPath("~/ProductImages"), fileName);
                    file.SaveAs(path);
                    UserDeals.DealsImg = fileName;



                }
            }
            UserDeals.CreatedTime = DateTime.Now;
            DealsDataStore Obj = new DealsDataStore();
            if (UserDeals.id == 0)
            {
                Obj.AddDeals(UserDeals);
            }
            else
            {
                Obj.EditDeals(UserDeals);
            }
            return RedirectToAction("Deals");
        }


        public ActionResult EditDeals(int id)
        {

            DealsDataStore Obj = new DealsDataStore();
            SA_Deals obj = Obj.GetDealsByid(id);
            List<SelectListItem> productList = Obj.GetProductList();
            SA_DealsViewModel objSaCatV = new SA_DealsViewModel();
            objSaCatV.id = obj.id;
            objSaCatV.DealsName = obj.DealsName;
            objSaCatV.DealsDiscription = obj.DealsDiscription;
            objSaCatV.URL = obj.URL;
            objSaCatV.MetaDiscription = obj.MetaDiscription;
            objSaCatV.Keywords = obj.Keywords;
            objSaCatV.ProductList = productList;

            objSaCatV.Product = obj.Product.ToString();


            return View("add-Deals", objSaCatV);
        }
        public ActionResult DeleteDeals(int id)
        {

            DealsDataStore Obj = new DealsDataStore();
            if (Obj.DeleteDeals(id) == true)
            {
                return RedirectToAction("Deals");
            }
            else
            {
                return View("ErrorEventArgs");
            }
        }

        //CMS Management
        public ActionResult CMS()
        {
            CMSDataStore Obj = new CMSDataStore();
            //List<SA_CMS> CMSList = Obj.GetCMSList();
            return View("CMS");
        }
        public ActionResult GetCMSList()
        {
            return View("CMS");
        }
        public JsonResult CMSList()
        {
            CMSDataStore Obj = new CMSDataStore();
            List<SA_CMS> CMSList = Obj.GetCMSList();

            return Json(new { data = CMSList }, JsonRequestBehavior.AllowGet);

        }
        public ActionResult AddCMS()
        {
            CMSDataStore ObjDal = new CMSDataStore();
            SA_CMSViewModel objCatViewModel = new SA_CMSViewModel();
            objCatViewModel.ProductList = ObjDal.GetProductList();

            return View("add-CMS", objCatViewModel);

        }
        public ActionResult SaveCMS(SA_CMS UserCMS)
        {
            for (int i = 0; i < Request.Files.Count; i++)
            {
                var file = Request.Files[i];

                if (file != null && file.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(file.FileName);

                    var path = Path.Combine(Server.MapPath("~/ProductImages"), fileName);
                    file.SaveAs(path);
                    UserCMS.CMSImg = fileName;



                }
            }
            UserCMS.CreatedTime = DateTime.Now;
            CMSDataStore Obj = new CMSDataStore();
            if (UserCMS.id == 0)
            {
                Obj.AddCMS(UserCMS);
            }
            else
            {
                Obj.EditCMS(UserCMS);
            }
            return RedirectToAction("CMS");
        }


        public ActionResult EditCMS(int id)
        {

            CMSDataStore Obj = new CMSDataStore();
            SA_CMS obj = Obj.GetCMSByid(id);
            List<SelectListItem> productList = Obj.GetProductList();
            SA_CMSViewModel objSaCatV = new SA_CMSViewModel();
            objSaCatV.id = obj.id;
            objSaCatV.CMSName = obj.CMSName;
            objSaCatV.CMSDiscription = obj.CMSDiscription;
            objSaCatV.Meta = obj.Meta;
            objSaCatV.MetaDiscription = obj.MetaDiscription;
            objSaCatV.ProductList = productList;



            return View("add-CMS", objSaCatV);
        }
        public ActionResult DeleteCMS(int id)
        {

            CMSDataStore Obj = new CMSDataStore();
            if (Obj.DeleteCMS(id) == true)
            {
                return View("CMS");
            }
            else
            {
                return View("ErrorEventArgs");
            }
        }
        public ActionResult NewsHome(int? page)
        {

            int pageSize = 6;
            NewsDataStore n = new NewsDataStore();
            ProductDataStore p = new ProductDataStore();
            NewsHomeViewModel model=new NewsHomeViewModel();
            ViewBag.formdate = new DateTime(DateTime.Now.Year,DateTime.Now.Month,01).ToString("MM/dd/yyyy");
            ViewBag.todate = DateTime.Now.ToString("MM/dd/yyyy");
            if (Session["UserRole"] != null && Session["UserRole"].ToString().ToUpper() == "CUSTOMER")
                {
                    model.NewsList = n.GetCustNewsList(Convert.ToInt32(Session["LoginUser"])).ToPagedList(page ?? 1, pageSize);
                }
            
            else
            {
                model.NewsList = n.GetNewsList().ToPagedList(page ?? 1, pageSize);
            }
            ViewBag.category=p.ProductList();
            return View(model);
        }
        [HttpPost]
        public ActionResult NewsHome(int? page, string id, DateTime? search,DateTime? searchto,string keyword)
        { 
            ViewBag.formdate = search!= null? Convert.ToDateTime( search).ToString("MM/dd/yyyy"):"";
            ViewBag.todate = searchto != null?Convert.ToDateTime( searchto).ToString("MM/dd/yyyy"):"";
            int pageSize = 6;
            NewsDataStore n = new NewsDataStore();
            ProductDataStore p = new ProductDataStore();
            NewsHomeViewModel model = new NewsHomeViewModel();

            if (Session["UserRole"] != null && Session["UserRole"].ToString().ToUpper() == "CUSTOMER")
            {
                model.NewsList = n.GetCustNewsList(Convert.ToInt32(Session["LoginUser"])).ToPagedList(page ?? 1, pageSize);
            }

            else
            {
                
                model.NewsList = n.GetNewsBySearch(id,search,searchto,keyword).OrderByDescending(x=>x.CreatedTime).ToPagedList(page ?? 1, pageSize);
            }
            ViewBag.category = p.ProductList();
            return View(model);
        }
        public ActionResult DealsHome(int? page)
        {
            //int pageSize = 6;
            //DealsDataStore d = new DealsDataStore();
            //var model= d.GetDealsList().ToPagedList(page ?? 1, pageSize);
            //return View(model);

            int pageSize = 6;
            DealsDataStore n = new DealsDataStore();
            ProductDataStore p = new ProductDataStore();
            DealsHomeViewModel model = new DealsHomeViewModel();

            if (Session["UserRole"] != null && Session["UserRole"].ToString().ToUpper() == "CUSTOMER")
            {
                model.DealsList = n.GetCustDealsList(Convert.ToInt32(Session["LoginUser"])).ToPagedList(page ?? 1, pageSize);
            }

            else
            {
                model.DealsList = n.GetDealsList().ToPagedList(page ?? 1, pageSize);
            }
            ViewBag.category = p.ProductList();
            return View(model);
        }

        [HttpPost]
        public ActionResult DealsHome(int? page, string id, DateTime search, DateTime searchto, string keyword)
        {
            ViewBag.formdate = search.ToString("MM/dd/yyyy");
            ViewBag.todate = searchto.ToString("MM/dd/yyyy");
            int pageSize = 6;
            DealsDataStore n = new DealsDataStore();
            ProductDataStore p = new ProductDataStore();
            DealsHomeViewModel model = new DealsHomeViewModel();

            if (Session["UserRole"] != null && Session["UserRole"].ToString().ToUpper() == "CUSTOMER")
            {
                model.DealsList = n.GetCustDealsList(Convert.ToInt32(Session["LoginUser"])).ToPagedList(page ?? 1, pageSize);
            }

            else
            {

                model.DealsList = n.GetDealsBySearch(id, search, searchto,keyword).OrderByDescending(x => x.CreatedTime).ToPagedList(page ?? 1, pageSize);
            }
            ViewBag.category = p.ProductList();
            return View(model);
        }

        public ActionResult NewsDetails(int id)
        {
            NewsDataStore Obj = new NewsDataStore();
            DealsDataStore Obj2 = new DealsDataStore();
            NewsDetailsViewModel n = new NewsDetailsViewModel();
            n.News = Obj.GetNewsByid(id);
            n.NewsList = Obj.GetNewsList();
            n.DealList = Obj2.GetDealsList();
            return View(n);
        }
        public ActionResult DealsDetails(int id)
        {
            NewsDataStore Obj2 = new NewsDataStore();
            DealsDataStore Obj = new DealsDataStore();
            DealsDetailsViewModel d = new DealsDetailsViewModel();
            d.Deals = Obj.GetDealsByid(id);
            d.NewsList = Obj2.GetNewsList();
            d.DealList = Obj.GetDealsList();
            return View(d);
        }

        [HttpPost]
        public ActionResult UpdateStatus(int newsId)
        {
            NewsDataStore Obj = new NewsDataStore();
            Obj.UpdateNewsStatus(newsId);
            return RedirectToAction("GetNewsList");
        }

        [HttpPost]
        public ActionResult UpdateDealStatus(int dealId)
        {
           DealsDataStore Obj = new DealsDataStore();
            Obj.UpdateDealStatus(dealId);
            return RedirectToAction("GetDealsList");
        }

    }
}