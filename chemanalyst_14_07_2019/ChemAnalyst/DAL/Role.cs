using ChemAnalyst.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ChemAnalyst.DAL
{

    public class RoleDataStore
    {
        private ChemAnalystContext _context = new ChemAnalystContext();

        public List<SA_RoleViewModel> GetRoleList()
        {
            //return  _context.SA_Role.ToList();
            return _context.SA_Role.ToList().Select(item => new SA_RoleViewModel
            {
                id = item.id,
                Role = item.Role,
                RoleDiscription = item.RoleDiscription,
                CreatedTime = item.CreatedTime != null ? item.CreatedTime.Value.ToString("dd/MM/yyy") : DateTime.Now.ToString("dd/MM/yyyy")
            }
        ).ToList();

        }

        public bool EditRole(SA_RoleViewModel RoleViewModel)
        {
            //  Role.CreatedDate = DateTime.Now;
            SA_Role Role = _context.SA_Role.Where(role => role.id == RoleViewModel.id).FirstOrDefault();
            Role.RoleDiscription = RoleViewModel.RoleDiscription;
            Role.Role = RoleViewModel.Role;
            _context.Entry(Role).State = EntityState.Modified;

            int x = _context.SaveChanges();
            List<SA_RoleWiseAccess> Editrole = _context.SA_RoleWiseAccess.Where(role => role.RoleId == RoleViewModel.id).ToList();
            foreach (var item in Editrole)
            {
                _context.Entry(item).State = EntityState.Deleted;
                _context.SaveChanges();
            }

            if (RoleViewModel.ChemicalPricing == true)
            {
                SA_RoleWiseAccess access = new Models.SA_RoleWiseAccess();
                access.RoleId = Role.id;
                access.Pageid = 1;
                access.access = true;
                access.PageDiscription = "Chemical Pricing";
                access.CreatedTime = DateTime.Now;
                _context.SA_RoleWiseAccess.Add(access);
                _context.SaveChanges();
            }
            if (RoleViewModel.MarketAnalysis == true)
            {
                SA_RoleWiseAccess access = new Models.SA_RoleWiseAccess();
                access.RoleId = Role.id;
                access.Pageid = 2;
                access.access = true;
                access.PageDiscription = "Market Analysis";
                access.CreatedTime = DateTime.Now;
                _context.SA_RoleWiseAccess.Add(access);
                _context.SaveChanges();
            }
            if (RoleViewModel.CompanyProfile == true)
            {
                SA_RoleWiseAccess access = new Models.SA_RoleWiseAccess();
                access.RoleId = Role.id;
                access.Pageid = 3;
                access.access = true;
                access.PageDiscription = "Company Profile";
                access.CreatedTime = DateTime.Now;
                _context.SA_RoleWiseAccess.Add(access);
                _context.SaveChanges();
            }
            if (RoleViewModel.IndustryReports == true)
            {
                SA_RoleWiseAccess access = new Models.SA_RoleWiseAccess();
                access.RoleId = Role.id;
                access.Pageid = 4;
                access.access = true;
                access.PageDiscription = "Industry Reports";
                access.CreatedTime = DateTime.Now;
                _context.SA_RoleWiseAccess.Add(access);
                _context.SaveChanges();
            }
            if (RoleViewModel.News == true)
            {
                SA_RoleWiseAccess access = new Models.SA_RoleWiseAccess();
                access.RoleId = Role.id;
                access.Pageid = 5;
                access.access = true;
                access.PageDiscription = "News";
                access.CreatedTime = DateTime.Now;
                _context.SA_RoleWiseAccess.Add(access);
                _context.SaveChanges();
            }
            if (RoleViewModel.Deals == true)
            {
                SA_RoleWiseAccess access = new Models.SA_RoleWiseAccess();
                access.RoleId = Role.id;
                access.Pageid = 6;
                access.access = true;
                access.PageDiscription = "Deals";
                access.CreatedTime = DateTime.Now;
                _context.SA_RoleWiseAccess.Add(access);
                _context.SaveChanges();
            }
            if (RoleViewModel.SubscriptionManagement == true)
            {
                SA_RoleWiseAccess access = new Models.SA_RoleWiseAccess();
                access.RoleId = Role.id;
                access.Pageid = 7;
                access.access = true;
                access.PageDiscription = "Subscription Management";
                access.CreatedTime = DateTime.Now;
                _context.SA_RoleWiseAccess.Add(access);
                _context.SaveChanges();

            }
            return x == 0 ? false : true;
        }
        public bool DeleteRole(int RoleId)
        {
            //  Role.CreatedDate = DateTime.Now;
            SA_Role Editrole = _context.SA_Role.Where(role => role.id == RoleId).FirstOrDefault();
            _context.Entry(Editrole).State = EntityState.Deleted;
            int x = _context.SaveChanges();
            List<SA_RoleWiseAccess> deleteroleaceess = _context.SA_RoleWiseAccess.Where(role => role.RoleId == RoleId).ToList();
            foreach (var item in deleteroleaceess)
            {
                _context.Entry(item).State = EntityState.Deleted;
                _context.SaveChanges();
            }
            return x == 0 ? false : true;
        }
        public async Task<bool> AddRole(SA_RoleViewModel RoleViewModel)
        {
            try
            {
                int x = 0;
                SA_Role Role = new Models.SA_Role();
                Role.Role = RoleViewModel.Role;
                Role.CreatedTime = DateTime.Now;
                Role.RoleDiscription = RoleViewModel.RoleDiscription;
                _context.SA_Role.Add(Role);
                _context.SaveChanges();



                if (RoleViewModel.ChemicalPricing == true)
                {
                    SA_RoleWiseAccess access = new Models.SA_RoleWiseAccess();
                    access.RoleId = Role.id;
                    access.Pageid = 1;
                    access.access = true;
                    access.PageDiscription = "Chemical Pricing";
                    access.CreatedTime = DateTime.Now;
                    _context.SA_RoleWiseAccess.Add(access);
                    _context.SaveChanges();
                }
                if (RoleViewModel.MarketAnalysis == true)
                {
                    SA_RoleWiseAccess access = new Models.SA_RoleWiseAccess();
                    access.RoleId = Role.id;
                    access.Pageid = 2;
                    access.access = true;
                    access.PageDiscription = "Market Analysis";
                    access.CreatedTime = DateTime.Now;
                    _context.SA_RoleWiseAccess.Add(access);
                    _context.SaveChanges();
                }
                if (RoleViewModel.CompanyProfile == true)
                {
                    SA_RoleWiseAccess access = new Models.SA_RoleWiseAccess();
                    access.RoleId = Role.id;
                    access.Pageid = 3;
                    access.access = true;
                    access.PageDiscription = "Company Profile";
                    access.CreatedTime = DateTime.Now;
                    _context.SA_RoleWiseAccess.Add(access);
                    _context.SaveChanges();
                }
                if (RoleViewModel.IndustryReports == true)
                {
                    SA_RoleWiseAccess access = new Models.SA_RoleWiseAccess();
                    access.RoleId = Role.id;
                    access.Pageid = 4;
                    access.access = true;
                    access.PageDiscription = "Industry Reports";
                    access.CreatedTime = DateTime.Now;
                    _context.SA_RoleWiseAccess.Add(access);
                    _context.SaveChanges();
                }
                if (RoleViewModel.News == true)
                {
                    SA_RoleWiseAccess access = new Models.SA_RoleWiseAccess();
                    access.RoleId = Role.id;
                    access.Pageid = 5;
                    access.access = true;
                    access.PageDiscription = "News";
                    access.CreatedTime = DateTime.Now;
                    _context.SA_RoleWiseAccess.Add(access);
                    _context.SaveChanges();
                }
                if (RoleViewModel.Deals == true)
                {
                    SA_RoleWiseAccess access = new Models.SA_RoleWiseAccess();
                    access.RoleId = Role.id;
                    access.Pageid = 6;
                    access.access = true;
                    access.PageDiscription = "Deals";
                    access.CreatedTime = DateTime.Now;
                    _context.SA_RoleWiseAccess.Add(access);
                    _context.SaveChanges();
                }
                if (RoleViewModel.SubscriptionManagement == true)
                {
                    SA_RoleWiseAccess access = new Models.SA_RoleWiseAccess();
                    access.RoleId = Role.id;
                    access.Pageid = 7;
                    access.access = true;
                    access.PageDiscription = "Subscription Management";
                    access.CreatedTime = DateTime.Now;
                    _context.SA_RoleWiseAccess.Add(access);
                    x = await _context.SaveChangesAsync();

                }
                return x == 0 ? false : true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }










        public async Task<bool> UpdateRole(SA_Role Role)
        {
            _context.Entry(Role).State = EntityState.Modified;
            //  Role.ModeifiedDate = DateTime.Now;
            int x = await _context.SaveChangesAsync();
            return x == 0 ? false : true;
        }

        internal SA_RoleViewModel GetRoleByid(int id)
        {
            SA_RoleViewModel model = new Models.SA_RoleViewModel();
            SA_Role editrole = _context.SA_Role.Where(x => x.id == id).SingleOrDefault();
            model.id = editrole.id;
            model.CreatedTime = editrole.CreatedTime!=null? editrole.CreatedTime.Value.ToString("dd/MM/yyyy"):DateTime.Now.ToString("dd/MM/yyyy");
            model.Role = editrole.Role;
            model.RoleDiscription = editrole.RoleDiscription;
            var editaccess = _context.SA_RoleWiseAccess.Where(x => x.RoleId == id).ToList();
            foreach (var item in editaccess)
            {
                if (item.Pageid == 1)
                {
                    model.ChemicalPricing = true;
                }
                if (item.Pageid == 2)
                {
                    model.MarketAnalysis = true;
                }
                if (item.Pageid == 3)
                {
                    model.CompanyProfile = true;
                }
                if (item.Pageid == 4)
                {
                    model.IndustryReports = true;
                }
                if (item.Pageid == 5)
                {
                    model.News = true;
                }
                if (item.Pageid == 6)
                {
                    model.Deals = true;
                }
                if (item.Pageid == 7)
                {
                    model.SubscriptionManagement = true;


                }
            }
            return model;

        }
    }
}