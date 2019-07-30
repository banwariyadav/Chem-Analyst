using ChemAnalyst.DAL;
using ChemAnalyst.Models;
using ChemAnalyst.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChemAnalyst.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        private ChemAnalystContext _context = new ChemAnalystContext();
        public ActionResult Index()
        {
            return View("Login");
        }
        /// <summary>
        /// get user data
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        public ActionResult UserLogin(FormCollection collection)
        {
            SA_User login = new Models.SA_User();
            login.Email = Request["Username"];
            LoginDataStore LoginStore = new LoginDataStore();
            login.UserPassword = Request["Password"];
            if ((login.Email == "customer" && login.UserPassword == "Customer"))
            {
                string product = null;
                string ChartType = null;
                string Range = null;
                string CompareProject = null;
                bool Customer = true;
                return RedirectToAction("ChecmPriceYearlyChart", "ChemicalPricing", new
                {
                    product,
                    ChartType,
                    Range,
                    CompareProject,
                    Customer
                });

                // return this.RedirectToAction("ChecmPriceYearlyChart", "ChemicalPricing");
            }
            if ((LoginStore.CheckUser(login) != null) || (login.Email == "admin" && login.UserPassword == "admin"))
            {
                SA_User objectuser = LoginStore.CheckUser(login);
                if (objectuser.Status == false)
                {
                    TempData["ErrorMessage"] = "You don’t have access to the account. Kindly contact Administrator.";
                    return View("Login");
                }

                if ((objectuser != null))
                {
                    Session["LoginUser"] = objectuser.id;
                    Session["User"] = objectuser.Fname + " " + objectuser.Lname;
                    Session["UserImg"] = "images /" + objectuser.ProfileImage; ;
                    Session["UserRole"] = objectuser.Role;
                    List<SA_RoleWiseAccess> Access = LoginStore.Getpage(objectuser.Role);
                    Session["Access"] = Access;
                    if (objectuser.Role == "Sales")
                    {


                        return this.RedirectToAction("ShowSubscriptionListForSales", "SubsManagement");
                    }
                    if (objectuser.Role.ToUpper() != "ADMIN")
                        return this.RedirectToAction("Index", "User");
                }
                else
                {
                    objectuser = new SA_User();
                    Session["LoginUser"] = 100001;
                    objectuser.Role = "Admin";
                    Session["UserRole"] = objectuser.Role;
                    List<SA_RoleWiseAccess> Access = LoginStore.Getpage(objectuser.Role);
                    Session["Access"] = Access;
                    Session["User"] = "Admin";
                    Session["UserImg"] = "images/" + "user.jpg";

                }
                return RedirectToAction("ShowUserList");
            }
            else
            {
                return View("Login");

            }

        }
        public ActionResult LoadUserData()
        {
            try
            {
                UserDataStore Obj = new UserDataStore();
                List<SA_User> UserList = Obj.GetUserList().Where(w => w.Email != "admin@techsci.com").ToList();
                return Json(new { data = UserList }, JsonRequestBehavior.AllowGet);

            }
            catch (Exception)
            {
                throw;
            }

        }

        public ActionResult LoadCountryData()
        {
            try
            {
              
                List<SA_Country> CountryList =_context.SA_Country.ToList();
                return Json(new { data = CountryList }, JsonRequestBehavior.AllowGet);

            }
            catch (Exception)
            {
                throw;
            }

        }

        public ActionResult LoadIndustryData()
        {
            try
            {
                ProductDataStore ObjProduct = new ProductDataStore();
                IndustryDataStore Obj = new IndustryDataStore();
                var IndustryList = Obj.GetIndustryList().Select(w => new IndustryVM
                {
                    id = w.id,
                    Title = w.Title,
                    CreateTime = w.CreatedTime != null ? w.CreatedTime.Value.ToString("dd/MM/yyyy") : "",
                    Product = w.Product != null ? ObjProduct.GetProductByid(w.Product).ProductName : "",
                });
                return Json(new { data = IndustryList }, JsonRequestBehavior.AllowGet);

            }
            catch (Exception)
            {
                throw;
            }

        }



        public ActionResult GetUserList()
        {
            return View("grid");
        }

        public ActionResult UserList()
        {
            return View("user-list");
        }

        public ActionResult AddUser()
        {
            ChemAnalystContext _context = new ChemAnalystContext();
            var customerData = (from User in _context.SA_Role
                                    //  select  { Fname = User.Fname+" "+User.Lname , Phone = User.Phone, Role=User.Role,Email=User.Email,UserPassword=User.Password});
                                select new SelectListItem { Text = User.Role, Value = User.Role }).Where(w => w.Value != "Admin").ToList();
            SA_UserViewModel obj = new SA_UserViewModel();
            obj.UserRoleList = customerData;
            return View("add-user", obj);

        }

        public ActionResult AddCountry()
        {
           
            return View("add-country");

        }
        public ActionResult SaveUser(SA_User User)
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
            UserDataStore Obj = new UserDataStore();
            if (User.id == 0)
            {
                Obj.AddUser(User);
            }
            else
            {
                Obj.UpdateUser(User);
                if ((User.Role).ToUpper() != "ADMIN")
                {
                    return View("UserView");
                }
            }
            return RedirectToAction("ShowUserList");
        }

        public ActionResult SaveCountry(SA_Country Country)
        {
            if (Country.id == 0)
            {
                SA_Country Obj = new SA_Country();
                Obj.CountryName = Country.CountryName;
                Obj.Active = true;
                _context.SA_Country.Add(Obj);
                _context.SaveChanges();
            }
            else
            {
                var Obj = _context.SA_Country.Where(w => w.id == Country.id).FirstOrDefault();
                Obj.CountryName = Country.CountryName;
                _context.SaveChanges();
              return RedirectToAction("ShowCountryList");

            }
            return RedirectToAction("ShowCountryList");
        }
        public ActionResult ShowUserList()
        {
            UserDataStore Obj = new UserDataStore();
            List<SA_User> UserList = Obj.GetUserList();
            return View("user-list", UserList);
        }


        public ActionResult ShowCountryList()
        {
            UserDataStore Obj = new UserDataStore();
            List<SA_Country> CountryList = _context.SA_Country.ToList();
            return View("country-list", CountryList);
        }

        public ActionResult ShowIndustryList()
        {
            IndustryDataStore Obj = new IndustryDataStore();
            List<SA_Industry> IndustryList = Obj.GetIndustryList();
            return View("industry-list", IndustryList);
        }


        [HttpPost]
        public ActionResult UpdateStatus(int userId)
        {
            UserDataStore Obj = new UserDataStore();
            Obj.UpdateUserStatus(userId);
            return RedirectToAction("ShowUserList");
        }


        public ActionResult EditUser(int id)
        {
            ChemAnalystContext _context = new ChemAnalystContext();
            UserDataStore Obj = new UserDataStore();
            SA_User obj = Obj.GetUserByid(id);
            SA_UserViewModel Objuser = new SA_UserViewModel();
            Objuser.id = obj.id;
            Objuser.Fname = obj.Fname;
            Objuser.Lname = obj.Lname;
            Objuser.Phone = obj.Phone;
            Objuser.ProfileImage = obj.ProfileImage;
            Objuser.Role = obj.Role;
            Objuser.Email = obj.Email;
            Objuser.UserPassword = obj.UserPassword;
            Objuser.Gender = obj.Gender;
            var customerData = (from User in _context.SA_Role
                                    //  select  { Fname = User.Fname+" "+User.Lname , Phone = User.Phone, Role=User.Role,Email=User.Email,UserPassword=User.Password});
                                select new SelectListItem { Text = User.Role, Value = User.Role }).ToList();
            Objuser.UserRoleList = customerData;
            return View("add-user", Objuser);
        }

        public ActionResult EditCountry(int id)
        {
            ChemAnalystContext _context = new ChemAnalystContext();

            SA_Country obj = _context.SA_Country.Where(w => w.id == id).FirstOrDefault();
           
            return View("add-country", obj);
        }
        public ActionResult Deleteuser(int id)
        {

            UserDataStore Obj = new UserDataStore();
            if (Obj.DeleteUser(id) == true)
            {
                return RedirectToAction("ShowUserList");
            }
            else
            {
                return View("ErrorEventArgs");
            }

        }


        public ActionResult Deletecountry(int id)
        {
            try
            {
                SA_Country country = _context.SA_Country.Where(c => c.id == id).FirstOrDefault();
                _context.Entry(country).State = EntityState.Deleted;
                int x = _context.SaveChanges();

                return RedirectToAction("ShowCountryList");
            }
            catch (Exception ex)
            {

                return View("ErrorEventArgs");
            }
        }
        /// <summary>
        /// Get Role data
        /// </summary>
        /// <returns></returns>

        public ActionResult GetRoleList()
        {
            return View("role");
        }
        public JsonResult RoleList()
        {
            RoleDataStore Obj = new RoleDataStore();
            List<SA_RoleViewModel> RoleList = Obj.GetRoleList();
            return Json(new { data = RoleList }, JsonRequestBehavior.AllowGet);

        }
        public ActionResult AddRole()
        {
            SA_RoleViewModel obj = new SA_RoleViewModel();

            return View("add-role", obj);

        }
        public ActionResult SaveRole(SA_RoleViewModel UserRole)
        {
            UserRole.CreatedTime = DateTime.Now;
            RoleDataStore Obj = new RoleDataStore();
            if (UserRole.id == 0)
            {
                Obj.AddRole(UserRole);
            }
            else
            {
                Obj.EditRole(UserRole);
            }
            return RedirectToAction("Role");
        }

        public ActionResult Role()
        {
            RoleDataStore Obj = new RoleDataStore();
            // List<SA_Role> RoleList = Obj.GetRoleList();
            return View("Role");
        }
        public ActionResult EditRole(int id)
        {

            RoleDataStore Obj = new RoleDataStore();
            SA_RoleViewModel obj = Obj.GetRoleByid(id);
            return View("add-role", obj);
        }
        public ActionResult DeleteRole(int id)
        {

            RoleDataStore Obj = new RoleDataStore();
            if (Obj.DeleteRole(id) == true)
            {
                return View("role");
            }
            else
            {
                return View("ErrorEventArgs");
            }
        }

        #region Commentary Management
        public ActionResult LoadCommentaryData()
        {
            try
            {
                ProductDataStore ObjProduct = new ProductDataStore();
                CommentaryDataStore Obj = new CommentaryDataStore();
                var CommentaryList = Obj.GetCommentaryList().Select(w => new IndustryVM
                {
                    id = w.id,
                    Title = w.Title,
                    CreateTime = w.CreatedTime != null ? w.CreatedTime.ToString("dd/MM/yyyy") : "",
                    Product = w.Product != null ? ObjProduct.GetProductByid(w.Product).ProductName : "",
                });
                return Json(new { data = CommentaryList }, JsonRequestBehavior.AllowGet);

            }
            catch (Exception)
            {
                throw;
            }

        }
        public ActionResult ShowCommentaryList()
        {
            CommentaryDataStore Obj = new CommentaryDataStore();
            List<SA_Commentary> IndustryList = Obj.GetCommentaryList();
            return View("commentary-list", IndustryList);
        }


        public ActionResult AddCommentary(int id = 0)
        {
            CommentaryDataStore Obj = new CommentaryDataStore();
            SA_Commentary obj = new SA_Commentary();
            if (id > 0)
            {
                obj = Obj.GetCommentaryByid(id);
            }

            if (obj == null)
            {
                obj = new SA_Commentary();

            }
            return View(obj);

        }
        [ValidateInput(false)]
        public ActionResult SaveCommentary(SA_Commentary UserNews)
        {
            CommentaryDataStore Obj = new CommentaryDataStore();
            if (UserNews.id == 0)
            {
                Obj.AddCommentary(UserNews);
            }
            else
            {
                Obj.EditCommentary(UserNews);
            }
            return RedirectToAction("ShowCommentaryList", "Admin");
        }


        public ActionResult EditCommentary(int id)
        {
            CommentaryDataStore Obj = new CommentaryDataStore();
            SA_Commentary obj = Obj.GetCommentaryByid(id);
            return View("AddIndustry", obj);
        }

        public ActionResult DeleteCommentary(int id)
        {
            CommentaryDataStore Obj = new CommentaryDataStore();
            if (Obj.DeleteCommentary(id) == true)
            {
                return RedirectToAction("ShowCommentaryList", "Admin");
            }
            else
            {
                return View("ErrorEventArgs");
            }
        }
        #endregion

    }
}