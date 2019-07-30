using ChemAnalyst.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ChemAnalyst.DAL
{
    public class IndustryDataStore
    {
        private ChemAnalystContext _context = new ChemAnalystContext();

        public List<SA_Industry> GetIndustryList()
        {
            return _context.SA_Industry.ToList();

        }

        public List<SA_Industry> GetCustIndustryList(List<string> lst)
        {
            var query = (from SA_Industry in _context.SA_Industry
                         where lst.Contains(SA_Industry.Product.ToString())
                         select new { SA_Industry });

            List<SA_Industry> returnpro = new List<SA_Industry>();
            foreach (var item in query)
            {
                returnpro.Add(item.SA_Industry);
            }
            return returnpro;

        }

        public bool EditIndustry(SA_Industry News)
        {

            SA_Industry EditNews = _context.SA_Industry.Where(Cat => Cat.id == News.id).FirstOrDefault();
            EditNews.Title = News.Title;
            EditNews.Description = News.Description;
            EditNews.Meta = News.Meta;
            EditNews.MetaDescription = News.MetaDescription;
            EditNews.Figot = News.Figot;
            EditNews.Industry = News.Industry;
            EditNews.format = News.format;
            EditNews.Pages = News.Pages;
            EditNews.RelatedRep = News.RelatedRep;
            EditNews.Tableoc = News.Tableoc;
            EditNews.Product = News.Product;
            EditNews.CategoryID = News.CategoryID;
            EditNews.CountryID = News.CountryID;

            _context.Entry(EditNews).State = EntityState.Modified;
            int x = _context.SaveChanges();
            return x == 0 ? false : true;
        }
        public bool DeleteIndustry(int NewsId)
        {
            //  News.CreatedDate = DateTime.Now;
            SA_Industry EditNews = _context.SA_Industry.Where(News => News.id == NewsId).FirstOrDefault();
            _context.Entry(EditNews).State = EntityState.Deleted;
            int x = _context.SaveChanges();
            return x == 0 ? false : true;
        }
        public async Task<bool> AddIndustry(SA_Industry News)
        {
            News.CreatedTime = DateTime.Now;

            _context.SA_Industry.Add(News);
            int x = await _context.SaveChangesAsync();
            return x == 0 ? false : true;
        }

        public async Task<bool> UpdateIndustry(SA_Industry News)
        {
            _context.Entry(News).State = EntityState.Modified;
            //  News.ModeifiedDate = DateTime.Now;
            int x = await _context.SaveChangesAsync();
            return x == 0 ? false : true;
        }

        internal SA_Industry GetIndustryByid(int id)
        {
            var data = _context.SA_Industry.Where(x => x.id == id).FirstOrDefault();
            if (data != null)
            {
                return data;
            }
            else
            {
                return null;
            }
        }

        public List<SA_Industry> GetCustIndustryList(int id)
        {
            return _context.SA_Industry.Where(w=>w.id==id).ToList();

        }

    }
}


