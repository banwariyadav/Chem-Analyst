using ChemAnalyst.Common;
using ChemAnalyst.DAL;
using ChemAnalyst.Models;
using ChemAnalyst.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChemAnalyst.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Custlogin(FormCollection collection)
        {
          

            CustWiseAccessDataStore Obj = new CustWiseAccessDataStore();
            SA_Customer login = new SA_Customer();
            login.Email = Request["Username"];

            login.UserPassword = Request["Password"];

            string strEncrypted = (Helpers.Encrypt(login.UserPassword));
            string strDecrypted = (Helpers.Decrypt(strEncrypted));

            login.UserPassword = strEncrypted;

            CustomerDataStore LoginStore = new CustomerDataStore();
            SA_Customer objectuser = LoginStore.CheckCustomer(login);
            if (objectuser != null)
            {
                if (LoginStore.CheckCustomerPackage(login))
                {
                    TempData["ErrorMessage"] = "Your subscription expired.";
                    return RedirectToAction("Index");
                }
                else
                {
                   
                    Session["LoginUser"] = objectuser.id;
                    Session["User"] = objectuser.Fname + " " + objectuser.Lname;
                    Session["UserImg"] = "images/" + "user.jpg";
                    Session["UserRole"] = objectuser.Role;
                    List<CustWiseAccess> Access = Obj.GetCustpage(objectuser.id);
                    Session["Access"] = Access;
                    return View();
                }
            }
            else
            {
                TempData["ErrorMessage"] = "Invalid credentials.";
                return RedirectToAction("Index");
            }
            return View();
        }
        public ActionResult ChemicalPricing()
        {
            return View("chemicalpricingUser");
        }

        public ActionResult CustIndustryList()
        {
            return View("CustIndustry");
        }
        public JsonResult GetCustIndustryList()
        {
            var LoginUser = Convert.ToInt32(Session["LoginUser"]);
            ProductDataStore ObjProduct = new ProductDataStore();

            //var custProduct = ObjProduct.GetCustProductList(LoginUser);
            List<string> custProduct = ObjProduct.GetCustProductList(LoginUser);

            IndustryDataStore Obj = new IndustryDataStore();
            var IndustryList = Obj.GetCustIndustryList(custProduct).Select(w => new IndustryVM
            {
                id = w.id,
                Title = w.Title,
                CreateTime = w.CreatedTime != null ? w.CreatedTime.Value.ToString("dd/MM/yyyy") : "",
                Product = w.Product != null ? ObjProduct.GetProductByid(w.Product).ProductName : "",
            }); ;
            return Json(new { data = IndustryList }, JsonRequestBehavior.AllowGet);
        }


        public ActionResult CustCompaniesList()
        {
            return View("CustCompanies");
        }
        public JsonResult GetCustcompaniesList()
        {
            var LoginUser = Convert.ToInt32(Session["LoginUser"]);

            LeadDAL leadObj = new LeadDAL();
            List<CustCompanyVM> lstCompanies = new List<CustCompanyVM>();
            lstCompanies = leadObj.GetCompanies(LoginUser);

            return Json(new { data = lstCompanies }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult CompanyDetail(int id)
        {
           
            ChemAnalystContext db = new ChemAnalystContext();
            
            CompanyDataStore obj = new CompanyDataStore();
            CustCompanyVM model = new CustCompanyVM();
            var data = obj.GetCompanyByid(id);
            model.Name = data.Name;
            model.Description = data.Description;
            model.Logo = data.Logo;

            model.EmailId = data.EmailId;
            model.Address = data.Address;
            model.phoneNo = data.phoneNo;
            model.fax = data.fax;
            model.website = data.website;
            model.RegDate = data.RegDate.Date.ToString("dd/MM/yyyy");
            model.CreatedTime = data.RegDate.Date.Year.ToString();
            model.NOE = data.NOE;
            model.CEO = data.CEO;
            model.CIN = data.CIN;
            model.Category = data.Category;
            model.id = data.id;
            model.Meta = data.Meta;
            model.MetaDescription = data.MetaDescription;
            model.lstFinacialData = db.CompanyProfRecords.Where(w => w.SA_CompanyId == data.id).Select(x => new CompanyFinacialData
            {
                FinacialYear = db.FinancialYears.Where(f => f.Id == x.FinancialYearId).FirstOrDefault().FinYear,
                Growth=x.Growth,
                Revenue=x.Revenues
            }).ToList();

            return View(model);

        }
    }
}