using ChemAnalyst.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ChemAnalyst.DAL
{

    public class UserDataStore
    {
        private ChemAnalystContext _context = new ChemAnalystContext();

        public List<SA_User> GetUserList()
        {

            ;
            return _context.SA_User.ToList();

        }

        public async Task<bool> AddUser(SA_User User)
        {
            //  User.CreatedDate = DateTime.Now;
            _context.SA_User.Add(User);
            int x = _context.SaveChanges();
            return x == 0 ? false : true;
        }

        public async Task<bool> UpdateUser(SA_User User)
        {
            try
            {

          
            //  Category.CreatedDate = DateTime.Now;
            SA_User Objuser = _context.SA_User.Where(user => user.id == User.id).FirstOrDefault();
            Objuser.Fname = User.Fname;
            Objuser.Lname = User.Lname;
            Objuser.Phone = User.Phone;
            Objuser.Role = User.Role;
            Objuser.Email = User.Email;
            Objuser.Gender = User.Gender;
            Objuser.UserPassword = User.UserPassword;
                if(User.ProfileImage!=null)
                    Objuser.ProfileImage = User.ProfileImage;
                //if (Objuser.ProfileImage != null)
                //    Objuser.ProfileImage = User.ProfileImage;
                _context.Entry(Objuser).State = EntityState.Modified;
            int x = _context.SaveChanges();
            return x == 0 ? false : true;
            }
            catch (Exception ex)
            {
                return false;
                throw;
            }
        }

        public bool UpdateUserStatus(int userId)
        {
            SA_User Objuser = _context.SA_User.Where(user => user.id == userId).FirstOrDefault();
            if (Objuser.Status)
            {
                Objuser.Status = false;
            }
            else
            {
                Objuser.Status = true;
            }
            _context.Entry(Objuser).State = EntityState.Modified;
            int x = _context.SaveChanges();
            return x == 0 ? false : true;
        }

        internal int UpdatePassword(string newPassword)
        {
            throw new NotImplementedException();
        }

        internal bool DeleteUser(int id)
        {
            SA_User User = _context.SA_User.Where(user => user.id == id).FirstOrDefault();
            _context.Entry(User).State = EntityState.Deleted;
            int x = _context.SaveChanges();
            return x == 0 ? false : true;
        }

        internal SA_Role UpdateUser(string id)
        {
            throw new NotImplementedException();
        }


        internal SA_User GetUserByid(int id)
        {
            return _context.SA_User.Where(user => user.id == id).FirstOrDefault();
        }

        internal SA_Customer GetCustomerByid(int id)
        {
            return _context.SA_Customers.Where(user => user.id == id).FirstOrDefault();
        }
        internal int UpdatePassword(SA_User ObjPassChange)
        {
            SA_User UpdatedPass = _context.SA_User.Where(user => user.id == ObjPassChange.id).FirstOrDefault();
            UpdatedPass.UserPassword = ObjPassChange.UserPassword;
            _context.Entry(UpdatedPass).State = EntityState.Modified;
            int x = _context.SaveChanges();
            return x;
        }

    }
}