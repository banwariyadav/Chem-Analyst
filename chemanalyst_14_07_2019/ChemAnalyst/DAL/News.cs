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
        public IQueryable<SA_News> GetNewsBySearch(string id, DateTime search,DateTime searchto ,string keyword)
        {
            if (id == null) { id = ""; }
            IQueryable<SA_News> lst;
            if (id != "" && search != DateTime.MinValue)
            {
                var ids = Convert.ToInt32(id);
                lst = from r in _context.SA_News
                      join p in _context.SA_Product on r.Product equals ids
                      where p.status==1 && r.status==1 && 
                       r.Keywords.Contains(keyword) &&
                      DbFunctions.TruncateTime(r.CreatedTime) >= DbFunctions.TruncateTime(search)
                      && DbFunctions.TruncateTime(r.CreatedTime) <= DbFunctions.TruncateTime(searchto)
                      select r;
            }
            else if (id == "" && search != DateTime.MinValue)
            {

                lst = from r in _context.SA_News
                      where r.status == 1 &&
                       r.Keywords.Contains(keyword)  
                      && DbFunctions.TruncateTime(r.CreatedTime) >= DbFunctions.TruncateTime(search)
                      && DbFunctions.TruncateTime(r.CreatedTime) <= DbFunctions.TruncateTime(searchto)
                      select r;
            }
            else if (id != "" && search == DateTime.MinValue)
            {
                var ids = Convert.ToInt32(id);
                lst = from r in _context.SA_News
                      join p in _context.SA_Product on r.Product equals ids where p.status == 1 && r.Keywords.Contains(keyword) && r.status == 1 
                      select r;

            }
            else
            {
                lst = from r in _context.SA_News
                      where r.Keywords.Contains(keyword) && r.status == 1 
                      select r;
            }
            return lst.Distinct();
        }
        public List<SA_News> GetCustNewsList(int id)
        {

            var result = (from m in _context.SA_News
                          join n in _context.CustProduct on
                          m.Product equals n.ProdId
                          where n.CustId == id && m.status == 1 
                          select (m)).ToList();
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
            EditNews.Product = News.Product;
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


        public bool DeleteNews(int NewsId)
        {
            //  News.CreatedDate = DateTime.Now;
            SA_News EditNews = _context.SA_News.Where(News => News.id == NewsId).FirstOrDefault();
            _context.Entry(EditNews).State = EntityState.Deleted;
            int x = _context.SaveChanges();
            return x == 0 ? false : true;
        }
        public async Task<bool> AddNews(SA_News News)
        {
            //  News.CreatedDate = DateTime.Now;
            _context.SA_News.Add(News);
            int x = await _context.SaveChangesAsync();
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


        internal List<SelectListItem> GetProductList()
        {
            return (from product in _context.SA_Product where product.status==1
                        //  select  { Fname = User.Fname+" "+User.Lname , Phone = User.Phone, Role=User.Role,Email=User.Email,UserPassword=User.Password});
                    select new SelectListItem { Text = product.ProductName, Value = product.id.ToString() }).ToList();
        }


    }



}