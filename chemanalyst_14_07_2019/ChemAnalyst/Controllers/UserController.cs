using ChemAnalyst.DAL;
using ChemAnalyst.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ChemAnalyst.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View("UserView");
        }
        public ActionResult ChangePassword()
        {
            return View("changePassword");
        }
        public ActionResult UpdatePassword(FormCollection ChangePassword)
        {
            int LoginUser = int.Parse(ChangePassword["LoginUser"]);
            string CurPassword = ChangePassword["CurPassword"];
            string newPassword = ChangePassword["newPassword"];
            string confirmpasswd = ChangePassword["confirmpasswd"];
            UserDataStore ObjUser = new UserDataStore();
          SA_User loginUser=  ObjUser.GetUserByid(LoginUser);
            if ((loginUser != null))
            {
                if (loginUser.UserPassword == CurPassword)
                {
                    loginUser.id = LoginUser;
                    loginUser.UserPassword = newPassword;
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
            return View("changePassword");
        }
        public ActionResult UpdateProfile()
        {
          int id= int.Parse(Session["LoginUser"].ToString()); 
            ChemAnalystContext _context = new ChemAnalystContext();
            UserDataStore Obj = new UserDataStore();
            SA_User obj = Obj.GetUserByid(id);
            SA_UserViewModel Objuser = new SA_UserViewModel();
            Objuser.id = obj.id;
            Objuser.Fname = obj.Fname;
            Objuser.Lname = obj.Lname;
            Objuser.Phone = obj.Phone;
            Objuser.Role = obj.Role;
            Objuser.Email = obj.Email;
            Objuser.Gender = obj.Gender;
            var customerData = (from User in _context.SA_Role
                                    //  select  { Fname = User.Fname+" "+User.Lname , Phone = User.Phone, Role=User.Role,Email=User.Email,UserPassword=User.Password});
                                select new SelectListItem { Text = User.Role, Value = User.Role }).ToList();
            Objuser.UserRoleList = customerData;
            return View("update-profile", Objuser);
        }
        public ActionResult SaveProfile(SA_User User)
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
           
                Obj.UpdateUser(User);
                if ((User.Role).ToUpper() != "ADMIN")
                {
                    return View("UserView");
                }
            

            return RedirectToAction("ShowUserList","Admin");

        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Clear();
            return RedirectToAction("index", "ChemAnalyst");
        }
    }
}