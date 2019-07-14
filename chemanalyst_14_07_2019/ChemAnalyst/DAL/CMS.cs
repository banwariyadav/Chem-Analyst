using ChemAnalyst.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ChemAnalyst.DAL
{

    public class CMSDataStore
    {
        private ChemAnalystContext _context = new ChemAnalystContext();

        public List<SA_CMS> GetCMSList()
        {
            return _context.SA_CMS.ToList();

        }

        public bool EditCMS(SA_CMS CMS)
        {
            //  CMS.CreatedDate = DateTime.Now;
            SA_CMS EditCMS = _context.SA_CMS.Where(Cat => Cat.id == CMS.id).FirstOrDefault();
            EditCMS.CMSName = CMS.CMSName;
            EditCMS.CMSDiscription = CMS.CMSDiscription;
            EditCMS.Meta = CMS.Meta;
            EditCMS.MetaDiscription = CMS.MetaDiscription;
            EditCMS.Product = CMS.Product;
            _context.Entry(EditCMS).State = EntityState.Modified;
            int x = _context.SaveChanges();
            return x == 0 ? false : true;
        }
        public bool DeleteCMS(int CMSId)
        {
            //  CMS.CreatedDate = DateTime.Now;
            SA_CMS EditCMS = _context.SA_CMS.Where(CMS => CMS.id == CMSId).FirstOrDefault();
            _context.Entry(EditCMS).State = EntityState.Deleted;
            int x = _context.SaveChanges();
            return x == 0 ? false : true;
        }
        public async Task<bool> AddCMS(SA_CMS CMS)
        {
            //  CMS.CreatedDate = DateTime.Now;
            _context.SA_CMS.Add(CMS);
            int x = await _context.SaveChangesAsync();
            return x == 0 ? false : true;
        }

        public async Task<bool> UpdateCMS(SA_CMS CMS)
        {
            _context.Entry(CMS).State = EntityState.Modified;
            //  CMS.ModeifiedDate = DateTime.Now;
            int x = await _context.SaveChangesAsync();
            return x == 0 ? false : true;
        }

        internal SA_CMS GetCMSByid(int id)
        {
            return _context.SA_CMS.Where(x => x.id == id).SingleOrDefault();
        }

        internal List<SelectListItem> GetProductList()
        {
            return (from product in _context.SA_Product
                        //  select  { Fname = User.Fname+" "+User.Lname , Phone = User.Phone, Role=User.Role,Email=User.Email,UserPassword=User.Password});
                    select new SelectListItem { Text = product.ProductName, Value = product.id.ToString() }).ToList();
        }
    }
}