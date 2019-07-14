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

    public class DealsDataStore
    {
        private ChemAnalystContext _context = new ChemAnalystContext();

        public List<SA_Deals> GetDealsListAdmin()
        {
            return _context.SA_Deals.ToList();
        }


        public List<SA_Deals> GetDealsList()
        {
            return _context.SA_Deals.Where(x => x.status == 1).ToList();

        }

        public List<SA_Deals> GetCustDealsList(int id)
        {

            var result = (from m in _context.SA_Deals
                          join n in _context.CustProduct on
                          m.Product equals n.ProdId
                          where n.CustId == id && m.status == 1
                          select (m)).ToList();
            return result;

        }

        public IQueryable<SA_Deals> GetDealsBySearch(string id, DateTime search)
        {
            IQueryable<SA_Deals> lst;
            if (id != "" && search != DateTime.MinValue)
            {
                var ids = Convert.ToInt32(id);
                lst = from r in _context.SA_Deals
                      join p in _context.SA_Product on r.Product equals ids
                      where p.status == 1 && r.status == 1 && DbFunctions.TruncateTime(r.CreatedTime) <= DbFunctions.TruncateTime(search)
                      select r;
            }
            else if (id == "" && search != DateTime.MinValue)
            {

                lst = from r in _context.SA_Deals
                      where r.status == 1 && DbFunctions.TruncateTime(r.CreatedTime) <= DbFunctions.TruncateTime(search)

                      select r;
            }
            else if (id != "" && search == DateTime.MinValue)
            {
                var ids = Convert.ToInt32(id);
                lst = from r in _context.SA_Deals
                      join p in _context.SA_Product on r.Product equals ids
                      where p.status == 1 && r.status == 1
                      select r;

            }
            else
            {
                lst = from r in _context.SA_Deals
                      where r.status == 1
                      select r;
            }
            return lst.Distinct();
        }

        public bool EditDeals(SA_Deals Deals)
        {
            //  Deals.CreatedDate = DateTime.Now;
            SA_Deals EditDeals = _context.SA_Deals.Where(Cat => Cat.id == Deals.id).FirstOrDefault();
            EditDeals.DealsName = Deals.DealsName;
            EditDeals.DealsDiscription = Deals.DealsDiscription;
            EditDeals.URL = Deals.URL;
            EditDeals.MetaDiscription = Deals.MetaDiscription;
            EditDeals.Keywords = Deals.Keywords;
            EditDeals.Product = Deals.Product;
            if(Deals.DealsImg!=null)
            {
                EditDeals.DealsImg = Deals.DealsImg;
            }
            _context.Entry(EditDeals).State = EntityState.Modified;
            int x = _context.SaveChanges();
            return x == 0 ? false : true;
        }

        public bool UpdateDealStatus(int dealId)
        {
            //  Deals.CreatedDate = DateTime.Now;
            SA_Deals EditDeals = _context.SA_Deals.Where(Cat => Cat.id == dealId).FirstOrDefault();
            if (EditDeals.status.HasValue)
            {
                if (EditDeals.status.Value == 1)
                {
                    EditDeals.status = 2;
                }
                else
                {
                    EditDeals.status = 1;
                }
            }
            else
            {
                EditDeals.status = 1;
            }
           
            _context.Entry(EditDeals).State = EntityState.Modified;
            int x = _context.SaveChanges();
            return x == 0 ? false : true;
        }

        
        public bool DeleteDeals(int DealsId)
        {
            //  Deals.CreatedDate = DateTime.Now;
            SA_Deals EditDeals = _context.SA_Deals.Where(Deals => Deals.id == DealsId).FirstOrDefault();
            _context.Entry(EditDeals).State = EntityState.Deleted;
            int x = _context.SaveChanges();
            return x == 0 ? false : true;
        }
        public async Task<bool> AddDeals(SA_Deals Deals)
        {
            //  Deals.CreatedDate = DateTime.Now;
            _context.SA_Deals.Add(Deals);
            int x = await _context.SaveChangesAsync();
            return x == 0 ? false : true;
        }

        public async Task<bool> UpdateDeals(SA_Deals Deals)
        {
            _context.Entry(Deals).State = EntityState.Modified;
            //  Deals.ModeifiedDate = DateTime.Now;
            int x = await _context.SaveChangesAsync();
            return x == 0 ? false : true;
        }

        internal SA_Deals GetDealsByid(int id)
        {
            return _context.SA_Deals.Where(x => x.id == id && x.status==1).SingleOrDefault();
        }

        internal List<SelectListItem> GetProductList()
        {
            return (from product in _context.SA_Product where product.status==1
                        //  select  { Fname = User.Fname+" "+User.Lname , Phone = User.Phone, Role=User.Role,Email=User.Email,UserPassword=User.Password});
                    select new SelectListItem { Text = product.ProductName, Value = product.id.ToString() }).ToList();
        }
    }
}