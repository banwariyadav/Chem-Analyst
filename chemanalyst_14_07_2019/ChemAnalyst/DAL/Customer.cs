using ChemAnalyst.Models;
using ChemAnalyst.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ChemAnalyst.DAL
{
    public class CustomerDataStore
    {

        private ChemAnalystContext _context = new ChemAnalystContext();
        public SA_Customer CheckCustomer(SA_Customer Login)
        {
            return _context.SA_Customers.Where(x => x.Email == Login.Email && x.UserPassword == Login.UserPassword).SingleOrDefault();
        }

        public bool CheckCustomerPackage(SA_Customer Login)
        {
            var query = from sales in _context.SalesPackageSubscription
                        join sub in _context.SubscriptionType on sales.SubscriptionType equals sub.id
                        //join mod in _context.Module on sales.MenuId equals mod.id
                        join lead in _context.Lead_Master on sales.LeadId equals lead.Id
                        where lead.CorpEmail.Equals(Login.Email)
                        select new SubscriptionViewModel
                        {
                            SId = sales.Id,
                            Status = sales.Status,
                            Name = lead.Name,
                            Organisation = lead.Organisation,
                            Phone = lead.Phone,
                            CorpEmail = lead.CorpEmail,
                            Designation = lead.Designation,
                            Subscribe = sales.MenuId,
                            ExpiryDate = sales.ToDate,
                            Package = sub.Name,
                            LeadId = lead.Id,

                        };

           
            if (query.Count() > 0)
            {
             var data = query.ToList().Where(x => x.ExpiryDate.Value.Date >= DateTime.Now.Date).FirstOrDefault();

                if (data != null)
                    return false;
                else
                    return true;
            }
            else
            {
                return false;
            }
        }
        public int CheckCustomerCount(string Email, string Password)
        {
            return _context.SA_Customers.Where(x => x.Email == Email && x.UserPassword == Password).Count();
        }
        public List<SA_Customer> GetCustomerList()
        {

            ;
            return _context.SA_Customers.ToList();

        }

        public async Task<bool> AddCustomer(SA_Customer User)
        {
            //  User.CreatedDate = DateTime.Now;
            _context.SA_Customers.Add(User);
            int x = _context.SaveChanges();
            return x == 0 ? false : true;
        }

        public async Task<bool> UpdateCustomer(SA_Customer User)
        {

            //  Category.CreatedDate = DateTime.Now;
            SA_Customer Objuser = _context.SA_Customers.Where(user => user.id == User.id).FirstOrDefault();
            Objuser.Fname = User.Fname;
            Objuser.Lname = User.Lname;
            Objuser.Phone = User.Phone;
            Objuser.Role = User.Role;
            Objuser.Email = User.Email;
            Objuser.Gender = User.Gender;
            Objuser.UserPassword = User.UserPassword;
            if (Objuser.ProfileImage != null)
                Objuser.ProfileImage = User.ProfileImage;
            _context.Entry(Objuser).State = EntityState.Modified;
            int x = _context.SaveChanges();
            return x == 0 ? false : true;
        }

        internal int UpdatePassword(string newPassword)
        {
            throw new NotImplementedException();
        }

        internal bool DeleteCustomer(int id)
        {
            SA_Customer User = _context.SA_Customers.Where(user => user.id == id).FirstOrDefault();
            _context.Entry(User).State = EntityState.Deleted;
            int x = _context.SaveChanges();
            return x == 0 ? false : true;
        }

        internal SA_Role UpdateCustomer(string id)
        {
            throw new NotImplementedException();
        }


        internal SA_Customer GetCustomerByid(int id)
        {
            return _context.SA_Customers.Where(user => user.id == id).FirstOrDefault();
        }
        internal int UpdatePassword(SA_Customer ObjPassChange)
        {
            SA_Customer UpdatedPass = _context.SA_Customers.Where(user => user.id == ObjPassChange.id).FirstOrDefault();
            UpdatedPass.UserPassword = ObjPassChange.UserPassword;
            _context.Entry(UpdatedPass).State = EntityState.Modified;
            int x = _context.SaveChanges();
            return x;
        }

    }
}

