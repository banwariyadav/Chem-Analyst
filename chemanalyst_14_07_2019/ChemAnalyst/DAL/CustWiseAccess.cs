using ChemAnalyst.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ChemAnalyst.DAL
{
    public class CustWiseAccessDataStore
    {
        ChemAnalystContext _context = new ChemAnalystContext();
        public async Task<bool> AddCustWiseAccess(string id,int Custid)
        {
            try
            {
                int x = 0;
               
                string[] items = id.Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (var i in items)
                {

                    if (Convert.ToInt32(i) == 1)
                    {
                        CustWiseAccess access = new Models.CustWiseAccess();
                        access.CustId = Custid;
                        access.Pageid = 1;
                        access.access = true;
                        access.PageDiscription = "Chemical Pricing";
                        access.CreatedTime = DateTime.Now;
                        _context.CustWiseAccess.Add(access);
                        x = _context.SaveChanges();
                    }
                    if (Convert.ToInt32(i) == 2)
                    {
                        CustWiseAccess access = new Models.CustWiseAccess();
                        access.CustId = Custid;
                        access.Pageid = 2;
                        access.access = true;
                        access.PageDiscription = "Market Analysis";
                        access.CreatedTime = DateTime.Now;
                        _context.CustWiseAccess.Add(access);
                        x = _context.SaveChanges();
                    }
                    if (Convert.ToInt32(i) == 3)
                    {
                        CustWiseAccess access = new Models.CustWiseAccess();
                        access.CustId = Custid;
                        access.Pageid = 3;
                        access.access = true;
                        access.PageDiscription = "Company Profile";
                        access.CreatedTime = DateTime.Now;
                        _context.CustWiseAccess.Add(access);
                        x = _context.SaveChanges();
                    }
                    if (Convert.ToInt32(i) == 4)
                    {
                        CustWiseAccess access = new Models.CustWiseAccess();
                        access.CustId = Custid;
                        access.Pageid = 4;
                        access.access = true;
                        access.PageDiscription = "Industry Reports";
                        access.CreatedTime = DateTime.Now;
                        _context.CustWiseAccess.Add(access);
                        x = _context.SaveChanges();
                    }
                    if (Convert.ToInt32(i) == 5)
                    {
                        CustWiseAccess access = new Models.CustWiseAccess();
                        access.CustId = Custid;
                        access.Pageid = 5;
                        access.access = true;
                        access.PageDiscription = "News";
                        access.CreatedTime = DateTime.Now;
                        _context.CustWiseAccess.Add(access);
                        x = _context.SaveChanges();
                    }
                    if (Convert.ToInt32(i) == 6)
                    {
                        CustWiseAccess access = new Models.CustWiseAccess();
                        access.CustId = Custid;
                        access.Pageid = 6;
                        access.access = true;
                        access.PageDiscription = "Deals";
                        access.CreatedTime = DateTime.Now;
                        _context.CustWiseAccess.Add(access);
                        x = _context.SaveChanges();
                    }
                    if (Convert.ToInt32(i) == 7)
                    {
                        CustWiseAccess access = new Models.CustWiseAccess();
                        access.CustId = Custid;
                        access.Pageid = 7;
                        access.access = true;
                        access.PageDiscription = "Subscription Management";
                        access.CreatedTime = DateTime.Now;
                        _context.CustWiseAccess.Add(access);
                        x = await _context.SaveChangesAsync();

                    }
                }
                return x == 0 ? false : true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        internal List<CustWiseAccess> GetCustpage(int CustId)
        {
            
            var RoleDetails = _context.CustWiseAccess.Where(Role => Role.CustId == CustId).ToList();
            return RoleDetails;

            // return x == 0 ? false : true;
        }
        internal bool AddCustProduct(string ProdId,int CustId)
        {
            int x = 0;
            CustProduct access = new Models.CustProduct();
            
            string[] items = ProdId.Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var i in items)
            {
                access.CustId = CustId;
                access.ProdId = Convert.ToInt32(i);

                _context.CustProduct.Add(access);
                x = _context.SaveChanges();
            }
            return x == 0 ? false : true;
        }
    }
}