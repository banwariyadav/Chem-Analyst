using ChemAnalyst.Common;
using ChemAnalyst.DAL;
using ChemAnalyst.Models;
using ChemAnalyst.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

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
            IndustryDataStore Obj = new IndustryDataStore();
            string cate = Request.Form["categoryname"] != null ? Request.Form["categoryname"].ToString() : "";
            string country = Request.Form["countryname"] != null ? Request.Form["countryname"].ToString() : "";
            ViewBag.Cat = cate;
            ViewBag.Cou = country;
            CategoryDataStore d = new CategoryDataStore();
            IndustryViewModel model = new IndustryViewModel();
            List<SA_Industry> IndustryList = Obj.GetIndustryList().Where(x => (cate == "" || cate.Contains(x.CategoryID.ToString() + ",")) && (country == "" || country.Contains(x.CountryID.ToString() + ","))).OrderBy(w => w.id).OrderByDescending(w => w.id).ToList();
            model.Industry = IndustryList;
            List<SelectListItem> lstCategory = d.CategoryList();
            model.lstCategory = lstCategory;

            List<SelectListItem> lstCountry = d.CountryList();
            model.lstCountry = lstCountry;

            return View("CustIndustry", model);
            //return View("CustIndustry");
        }

        public ActionResult Reportsection()
        {
            IndustryDataStore Obj = new IndustryDataStore();
            string cate = Request.Form["categoryname"] != null ? Request.Form["categoryname"].ToString() : "";
            string country = Request.Form["countryname"] != null ? Request.Form["countryname"].ToString() : "";
            ViewBag.Cat = cate;
            ViewBag.Cou = country;
            CategoryDataStore d = new CategoryDataStore();
            IndustryViewModel model = new IndustryViewModel();
            List<SA_Industry> IndustryList = Obj.GetIndustryList().Where(x => (cate == "" || cate.Contains(x.CategoryID.ToString() + ",")) && (country == "" || country.Contains(x.CountryID.ToString() + ","))).OrderBy(w => w.id).OrderByDescending(w => w.id).ToList();
            model.Industry = IndustryList;
            List<SelectListItem> lstCategory = d.CategoryList();
            model.lstCategory = lstCategory;

            List<SelectListItem> lstCountry = d.CountryList();
            model.lstCountry = lstCountry;

            return View("CustIndustry", model);

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
            CompanyDataStore Obj = new CompanyDataStore();

            ViewBag.Product = Obj.GetCompanyProducts();
            ViewBag.Category = Obj.GetUniqueCategory();
            ViewBag.Cat = "";
            ViewBag.Prod = "";
            ViewBag.RevS = "";
            ViewBag.EmpSiz = "";
            NewsDataStore n = new NewsDataStore();
            ViewBag.f = n.GetFirstProduct();
            return View("CustCompanies", Obj.GetCompanyList().OrderBy(x => x.CreatedTime));
           // return View("CustCompanies");
        }

        [HttpPost]
        public ActionResult CompanyProfile(string category, string products, string revsize, string empsize)
        {
            CompanyDataStore Obj = new CompanyDataStore();

            NewsDataStore n = new NewsDataStore();
            ViewBag.f = n.GetFirstProduct();
            ViewBag.Cat = category;
            ViewBag.Prod = products;
            ViewBag.RevS = revsize;
            ViewBag.EmpSiz = empsize;
            ViewBag.Product = Obj.GetCompanyProducts();
            ViewBag.Category = Obj.GetUniqueCategory();
            return View("CustCompanies", Obj.GetCompanyList(category, products, revsize, empsize).OrderBy(x => x.CreatedTime));

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

            ViewBag.S = obj.GetSWOTByCompany(id);
            return View(model);

        }

        public ActionResult ChangePassword()
        {
            return View("custChangePassword");
        }
        public ActionResult UpdatePassword(FormCollection ChangePassword)
        {

            int LoginUser = int.Parse(ChangePassword["LoginUser"]);
            string CurPassword = ChangePassword["CurPassword"];
            string newPassword = ChangePassword["newPassword"];
            string confirmpasswd = ChangePassword["confirmpasswd"];

            //string strPassword = "1234";

            string strEncryptedCurr = (Helpers.Encrypt(CurPassword));
            string strDecryptedCurr = (Helpers.Decrypt(strEncryptedCurr));

            string strEncrypted = (Helpers.Encrypt(newPassword));
            string strDecrypted = (Helpers.Decrypt(strEncrypted));

            CustomerDataStore ObjUser = new CustomerDataStore();
            SA_Customer loginUser = ObjUser.GetCustomerByid(LoginUser);
            if ((loginUser != null))
            {
                if (loginUser.UserPassword == strEncryptedCurr)
                {
                    loginUser.id = LoginUser;
                    loginUser.UserPassword = strEncrypted;
                    int valid = ObjUser.UpdatePassword(loginUser);
                    if (valid > 0)
                    {
                        ViewBag.Message = "Password Updated Successfuly.";
                    }
                    else
                    {
                        ViewBag.Message = "Password not Updated Successfuly.";
                    }
                }
                else
                    ViewBag.Message = "Your current Password is not matched.";
            }
            return View("custChangePassword");
        }


        public ActionResult CustUpdateProfile()
        {
            int id = int.Parse(Session["LoginUser"].ToString());
            ChemAnalystContext _context = new ChemAnalystContext();
            CustomerDataStore Obj = new CustomerDataStore();
            SA_Customer obj = Obj.GetCustomerByid(id);
            SA_CustomerViewModel Objuser = new SA_CustomerViewModel();
            Objuser.id = obj.id;
            Objuser.Fname = obj.Fname;
            Objuser.Lname = obj.Lname;
            Objuser.Phone = obj.Phone;
            Objuser.Role = obj.Role;
            Objuser.Email = obj.Email;
            Objuser.Gender = obj.Gender;
            Objuser.UserPassword = obj.UserPassword;
            Objuser.ProfileImage = obj.ProfileImage;

            var customerData = (from User in _context.SA_Role
                                    //  select  { Fname = User.Fname+" "+User.Lname , Phone = User.Phone, Role=User.Role,Email=User.Email,UserPassword=User.Password});
                                select new SelectListItem { Text = User.Role, Value = User.Role }).ToList();
            Objuser.UserRoleList = customerData;
            return View("cust-update-profile", Objuser);
        }
        public ActionResult CustSaveProfile(SA_Customer User)
        {
            for (int i = 0; i < Request.Files.Count; i++)
            {
                var file = Request.Files[i];

                if (file != null && file.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(file.FileName);

                    var path = Path.Combine(Server.MapPath("~/images"), fileName);
                    file.SaveAs(path);
                    User.ProfileImage = fileName;
                }
            }
            CustomerDataStore Obj = new CustomerDataStore();

            Obj.UpdateCustomer(User);

            return RedirectToAction("CustUpdateProfile", "Login");

        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Clear();
            return RedirectToAction("index", "ChemAnalyst");
        }
    }
}