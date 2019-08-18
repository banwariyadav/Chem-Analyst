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

    public class NewsDataStore
    {
        private ChemAnalystContext _context = new ChemAnalystContext();

        public List<SA_News> GetNewsListAdmin()
        {
            return _context.SA_News.ToList();
        }
        public List<SA_News> GetNewsList()
        {


            return _context.SA_News.Where(x=>x.status==1).ToList();

        }
        public IQueryable<SA_News> GetNewsBySearch(string id, DateTime? from,DateTime? to ,string keyword)
        {

            DateTime search = from == null ? new DateTime(1990, 01, 01) : from.Value;
            DateTime searchto = to == null ? new DateTime(2100, 01, 01) : to.Value;
            if (id == null) { id = ""; }
            IQueryable<SA_News> lst;
            if (id != "" && search != DateTime.MinValue)
            {
                var ids = Convert.ToInt32(id);
                lst = from r in _context.SA_News
                      join p in _context.SA_Product on r.Product equals ids
                      where p.status==1 && r.status==1 && 
                       r.NewsDiscription.Contains(keyword) &&
                      DbFunctions.TruncateTime(r.CreatedTime) >= DbFunctions.TruncateTime(search)
                      && DbFunctions.TruncateTime(r.CreatedTime) <= DbFunctions.TruncateTime(searchto)
                      select r;
            }
            else if (id == "" && search != DateTime.MinValue)
            {

                lst = from r in _context.SA_News
                      where r.status == 1 &&
                       r.NewsDiscription.Contains(keyword)  
                      && DbFunctions.TruncateTime(r.CreatedTime) >= DbFunctions.TruncateTime(search)
                      && DbFunctions.TruncateTime(r.CreatedTime) <= DbFunctions.TruncateTime(searchto)
                      select r;
            }
            else if (id != "" && search == DateTime.MinValue)
            {
                var ids = Convert.ToInt32(id);
                lst = from r in _context.SA_News
                      join p in _context.SA_Product on r.Product equals ids where p.status == 1 && r.NewsDiscription.Contains(keyword) && r.status == 1 
                      select r;

            }
            else
            {
                lst = from r in _context.SA_News
                      where r.NewsDiscription.Contains(keyword) && r.status == 1 
                      select r;
            }
            return lst.Distinct();
        }
        public List<SA_News> GetCustNewsList(int id)
        {

            var result = (from n in _context.SA_News
                           join r in _context.SA_NewsAndProductRelation on
                          n.id equals r.SA_NewsId into np
                           from npresult in np.DefaultIfEmpty()

                           join p in _context.CustProduct
                           on npresult.SA_ProductId equals p.ProdId
                           where p.CustId == id && n.status == 1

                           select (n)).Distinct().ToList();

            //var result = (from m in _context.SA_News
            //              join n in _context.CustProduct on
            //              m.Product equals n.ProdId
            //              join r in _context.SA_NewsAndProductRelation
            //              on m.id equals r.SA_NewsId 
            //              where n.CustId == id && m.status == 1

            //              select (m)).Distinct().ToList();

            //var result = from Np in _context.SA_NewsAndProductRelation
            //             group Np by Np.SA_ProductId into pg
            //             // join *after* group
            //             join m in _context.SA_News on pg.FirstOrDefault().SA_NewsId equals m.id 
            //             join bp in _context.CustProduct on pg.FirstOrDefault().SA_ProductId equals bp.ProdId

            //             select new SA_News
            //             {
            //                 //SomeId = pg.FirstOrDefault().SomeId,
            //                 //CountryCode = pg.FirstOrDefault().CountryCode,
            //                 //MinPrice = pg.Min(m => m.Price),
            //                 //MaxPrice = pg.Max(m => m.Price),
            //                 //BaseProductName = bp.Name  // now there is a 'bp' in scope
            //                 id=m.id,
            //                 CreatedBy=m.CreatedBy,
            //                 CreatedTime=m.CreatedTime,




            //             };

            return result;

        }

        public bool EditNews(SA_News News)
        {
            //  News.CreatedDate = DateTime.Now;
            SA_News EditNews = _context.SA_News.Where(Cat => Cat.id == News.id).FirstOrDefault();
            EditNews.NewsName = News.NewsName;
            EditNews.NewsDiscription = News.NewsDiscription;
            EditNews.URL = News.URL;
            EditNews.MetaDiscription = News.MetaDiscription;
            EditNews.Keywords = News.Keywords;
            EditNews.MetaTitle = News.MetaTitle;
            EditNews.Product = News.Product;
            EditNews.CreatedTime = News.CreatedTime;
            if (News.NewsImg != null)
            {
                EditNews.NewsImg = News.NewsImg;
            }
            _context.Entry(EditNews).State = EntityState.Modified;
            int x = _context.SaveChanges();
            return x == 0 ? false : true;
        }

        public bool UpdateNewsStatus(int newsId)
        {
            //  News.CreatedDate = DateTime.Now;
            SA_News EditNews = _context.SA_News.Where(Cat => Cat.id == newsId).FirstOrDefault();
            if (EditNews.status.HasValue)
            {
                if (EditNews.status.Value == 1)
                {
                    EditNews.status = 2;
                }
                else
                {
                    EditNews.status = 1;
                }
            }
            else
            {
                EditNews.status = 1;
            }


            _context.Entry(EditNews).State = EntityState.Modified;
            int x = _context.SaveChanges();
            return x == 0 ? false : true;
        }

        internal List<SA_NewsAndProductRelation> GetNewsProduct(int id)
        {
            return _context.SA_NewsAndProductRelation.Where(x => x.SA_NewsId == id).ToList();
        }

        public bool DeleteNews(int NewsId)
        {
            //  News.CreatedDate = DateTime.Now;
            SA_News EditNews = _context.SA_News.Where(News => News.id == NewsId).FirstOrDefault();
            _context.Entry(EditNews).State = EntityState.Deleted;
            int x = _context.SaveChanges();
            return x == 0 ? false : true;
        }
        public bool AddNews(SA_News News)
        {
            //  News.CreatedDate = DateTime.Now;
            _context.SA_News.Add(News);
            int x =   _context.SaveChanges();
            return x == 0 ? false : true;
        }
        public bool AddNewsProduct(SA_NewsAndProductRelation np)
        {
            //  News.CreatedDate = DateTime.Now;
            _context.SA_NewsAndProductRelation.Add(np);
            int x =  _context.SaveChanges();
            return x == 0 ? false : true;
        }
        public async Task<bool> UpdateNews(SA_News News)
        {
            _context.Entry(News).State = EntityState.Modified;
            //  News.ModeifiedDate = DateTime.Now;
            int x = await _context.SaveChangesAsync();
            return x == 0 ? false : true;
        }

        internal SA_News GetNewsByid(int id)
        {
            return _context.SA_News.Where(x => x.id == id && x.status==1).SingleOrDefault();
        }

        public bool DeleteNewsProduct(int DealsId)
        {
            //  Deals.CreatedDate = DateTime.Now;

            _context.Database.ExecuteSqlCommand("delete from SA_NewsAndProductRelation where SA_NewsId = " + DealsId);

            return true;
        }
        internal List<SelectListItem> GetProductList()
        {
            return (from product in _context.SA_Product where product.status==1
                        //  select  { Fname = User.Fname+" "+User.Lname , Phone = User.Phone, Role=User.Role,Email=User.Email,UserPassword=User.Password});
                    select new SelectListItem { Text = product.ProductName, Value = product.id.ToString() }).ToList();
        }

        internal int GetFirstProduct()
        {
            //var id= _context.SA_Product.OrderBy(x => new { x.Category, x.id }).FirstOrDefault().id;
            var catId= _context.SA_Category.OrderBy(x => x.id ).FirstOrDefault().id;

            
            return _context.SA_Product.Where(w=>w.Category== catId).OrderBy(x =>x.id).FirstOrDefault().id;
        }
    }



}