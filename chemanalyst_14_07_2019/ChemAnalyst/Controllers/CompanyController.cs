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
    public class CompanyController : Controller
    {
        private ChemAnalystContext _context = new ChemAnalystContext();
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

        public ActionResult CompanySWOT()
        {
            JobDataStore Obj = new JobDataStore();
            return View("CompanySWOT");
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

        public JsonResult CompanyListSWOT()
        {

            List<CompanySWOT> NewsList = _context.SA_Company_SWOT.ToList().Select(w=>new CompanySWOT {
                Id=w.Id,
                CompanyId=w.CompanyId,
                Company=_context.SA_Company.Where(x=>x.id == w.CompanyId).FirstOrDefault().Name
            }).ToList();

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


        public ActionResult AddCompanySWOT(int id = 0)
        {
            //NewsDataStore ObjDal = new NewsDataStore();
            //SA_NewsViewModel objCatViewModel = new SA_NewsViewModel();
            //objCatViewModel.ProductList = ObjDal.GetProductList();
            //return View("AddIndustry", objCatViewModel);

            SA_Company_SWOT obj = new SA_Company_SWOT();
            if (id > 0)
            {
                obj = _context.SA_Company_SWOT.Where(w => w.Id == id).FirstOrDefault();
            }

            if (obj == null)
            {
                obj = new SA_Company_SWOT();

            }
            //obj.ProductList = ObjDal.GetProductList();
            //SA_Industry obj = new SA_Industry();
            return View(obj);

        }

        public ActionResult SaveCompanySWOT(SA_Company_SWOT UserNews)
        {
            if (UserNews.Id == 0)
            {
                Obj.AddCompanySWOT(UserNews);
            }
            else
            {
                Obj.EditCompanySWOT(UserNews);
            }
            return RedirectToAction("CompanySWOT");
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
            ViewBag.Product = Obj.GetCompanyProducts();
            ViewBag.Category = Obj.GetUniqueCategory();
            ViewBag.Cat = "";
            ViewBag.Prod = "";
            ViewBag.RevS = "";
            ViewBag.EmpSiz = "";
            NewsDataStore n = new NewsDataStore();
            ViewBag.f = n.GetFirstProduct();
            return View(Obj.GetCompanyList().OrderBy(x => x.CreatedTime));

        }

        public ActionResult CompanyProfileDetails(int id)
        {
            List<SA_Company> NewsList = Obj.GetCompanyList().Where(w=>w.id==id).OrderBy(w => w.id).ToList();
            NewsList.OrderBy(x => x.CreatedTime).Take(1);
            ViewBag.S = Obj.GetSWOTByCompany(id);

            return View(NewsList);

        }

        [HttpPost]
        public ActionResult CompanyProfile(string category,string products,string revsize,string empsize)
        {
            NewsDataStore n = new NewsDataStore();
            ViewBag.f = n.GetFirstProduct();
            ViewBag.Cat = category;
            ViewBag.Prod = products;
            ViewBag.RevS = revsize;
            ViewBag.EmpSiz = empsize;
            ViewBag.Product = Obj.GetCompanyProducts();
            ViewBag.Category = Obj.GetUniqueCategory();
            return View(Obj.GetCompanyList(category, products,revsize,empsize).OrderBy(x => x.CreatedTime));

        }


        [HttpPost]
        public JsonResult CheckAccess(string ProductId)
        {
            int custid = int.Parse(Session["LoginUser"].ToString());
            if (!string.IsNullOrEmpty(ProductId))
            {
                int PId = int.Parse(ProductId);

                try
                {

                    var IsAccess = _context.CustProduct.Where(w => w.CustId == custid && w.ProdId == PId).OrderByDescending(w => w.id).FirstOrDefault();

                    if (IsAccess == null)
                    {
                        return Json("NoAcesss");
                    }
                    else
                    {
                        return Json("Access");
                    }
                }
                catch (Exception ex)
                {

                    throw;
                }
            }
            else
            {
                //var Commentaries = ObjCommentary.GetCommentaryList().Select(w => new SelectListItem { Text = w.Title, Value = w.Description }).ToList();
                return Json("ProductNotFound");
            }
        }

    }
}
