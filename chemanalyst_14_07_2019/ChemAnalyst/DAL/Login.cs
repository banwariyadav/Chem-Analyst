using ChemAnalyst.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ChemAnalyst.DAL
{

    public class LoginDataStore
    {
        private ChemAnalystContext _context = new ChemAnalystContext();

        public SA_User CheckUser(SA_User Login)
        {
            //return _context.SA_User.Where(x => x.Email == Login.Email && x.UserPassword == Login.UserPassword && x.Status==true).SingleOrDefault();
            return _context.SA_User.Where(x => x.Email == Login.Email && x.UserPassword == Login.UserPassword).SingleOrDefault();
        }

        public async Task<bool> AddUser(SA_User User)
        {
            //  User.CreatedDate = DateTime.Now;
            _context.SA_User.Add(User);
            int x = await _context.SaveChangesAsync();
            return x == 0 ? false : true;
        }

        public async Task<bool> UpdateUser(SA_User User)
        {
            _context.Entry(User).State = EntityState.Modified;
            //  User.ModeifiedDate = DateTime.Now;
            int x = await _context.SaveChangesAsync();
            return x == 0 ? false : true;
        }
        internal List<SA_RoleWiseAccess> Getpage(string role)
        {
            if(role=="Admin")
            {
                return _context.SA_RoleWiseAccess.ToList();

            }
            SA_Role RoleDetails = _context.SA_Role.Where(Role => Role.Role == role).FirstOrDefault();
            return _context.SA_RoleWiseAccess.Where(x => x.RoleId == RoleDetails.id).ToList();

            // return x == 0 ? false : true;
        }

    }
}