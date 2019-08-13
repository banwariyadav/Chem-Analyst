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
        public async Task<bool> AddCustWiseAccess(string id, int Custid)
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
        internal bool AddCustProduct(string ProdId, int CustId, string PageId)
        {
            int x = 0;
            CustProduct access = new Models.CustProduct();

            string[] items = ProdId.Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);

            string[] pages = PageId.Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);

            for (int j = 0; j <= items.Length-1; j++)
            {
                int PrId = Convert.ToInt32(items[j]);
                foreach (var pg in pages)
                {
                    int pgId = Convert.ToInt32(pg);
                    var data = _context.CustProduct.Where(w => w.CustId == CustId && w.ProdId == PrId && w.PageId == pgId).OrderByDescending(w => w.id).FirstOrDefault();
                    if (data == null)
                    {
                        access.CustId = CustId;
                        access.ProdId = PrId;
                        access.PageId = pgId;

                        _context.CustProduct.Add(access);
                        x = _context.SaveChanges();
                    }
                }
            }


            //for (int i=0; i<= pages.Length;i++)
            //{
            //    int pgId = Convert.ToInt32(pages[i]);
            //    foreach (var p in items)
            //    {
            //       int ProId = Convert.ToInt32(p);

            //        var data = _context.CustProduct.Where(w => w.CustId == CustId && w.PageId == pgId && w.ProdId == ProId).OrderByDescending(w => w.id).FirstOrDefault();
            //        if (data == null)
            //        {
            //            access.CustId = CustId;
            //            access.PageId = pgId;
            //            access.ProdId = ProId;

            //            _context.CustProduct.Add(access);
            //            x = _context.SaveChanges();
            //        }
            //    }
            //}


            //int index = 0;
            //foreach (var i in items)
            //{

            //    int prodID = Convert.ToInt32(i);

            //    var data = _context.CustProduct.Where(w => w.CustId == CustId && w.ProdId == prodID && w.PageId==0).OrderByDescending(w=>w.id).FirstOrDefault();
            //    data.PageId = Convert.ToInt32(menus[index]);
            //    x = _context.SaveChanges();

            //    index++;
            //}

            return x == 0 ? false : true;
        }
    }
}