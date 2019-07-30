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

            int index = 0;
            foreach (var i in items)
            {
                int proid = Convert.ToInt32(i);
                int pagid = 0;
                if (pages.Length == 1)
                    pagid = Convert.ToInt32(pages[0]);
                else
                    pagid = Convert.ToInt32(pages[index]);

                var data = _context.CustProduct.Where(w => w.CustId == CustId && w.ProdId == proid && w.PageId == pagid).OrderByDescending(w => w.id).FirstOrDefault();
                if (data == null)
                {
                    access.CustId = CustId;
                    access.ProdId = Convert.ToInt32(i);
                    access.PageId = pagid;

                    _context.CustProduct.Add(access);
                    x = _context.SaveChanges();
                }
                index++;

            }


            int index1 = 0;
            foreach (var i in pages)
            {
                int pgId = Convert.ToInt32(i);
                int ProId = 0;

                if (items.Length == 1)
                    ProId = Convert.ToInt32(items[0]);
                else
                    ProId = Convert.ToInt32(items[index1]);

                var data = _context.CustProduct.Where(w => w.CustId == CustId && w.PageId == pgId && w.ProdId == ProId).OrderByDescending(w => w.id).FirstOrDefault();
                if (data == null)
                {
                    access.CustId = CustId;
                    access.PageId = Convert.ToInt32(i);
                    access.ProdId = ProId;

                    _context.CustProduct.Add(access);
                    x = _context.SaveChanges();
                }
                index1++;
            }


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