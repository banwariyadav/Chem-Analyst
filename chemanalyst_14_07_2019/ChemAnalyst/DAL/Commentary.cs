using ChemAnalyst.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ChemAnalyst.DAL
{
    public class CommentaryDataStore
    {
        private ChemAnalystContext _context = new ChemAnalystContext();

        public List<SA_Commentary> GetCommentaryList()
        {
            return _context.SA_Commentary.ToList();

        }

        public List<SA_Commentary> GetCommentaryList(List<string> lst)
        {
            var query = (from SA_Commentary in _context.SA_Commentary
                         where lst.Contains(SA_Commentary.Product.ToString())
                         select new { SA_Commentary });

            List<SA_Commentary> returnpro = new List<SA_Commentary>();
            foreach (var item in query)
            {
                returnpro.Add(item.SA_Commentary);
            }
            return returnpro;

        }

        public bool EditCommentary(SA_Commentary News)
        {

            SA_Commentary EditNews = _context.SA_Commentary.Where(Cat => Cat.id == News.id).FirstOrDefault();
            EditNews.Title = News.Title;
            EditNews.Description = News.Description;
            EditNews.Meta = News.Meta;
            EditNews.MetaDescription = News.MetaDescription;
            EditNews.IsActive = News.IsActive;
            EditNews.IsDelete = News.IsDelete;
            EditNews.Product = News.Product;

            _context.Entry(EditNews).State = EntityState.Modified;
            int x = _context.SaveChanges();
            return x == 0 ? false : true;
        }
        public bool DeleteCommentary(int NewsId)
        {
            //  News.CreatedDate = DateTime.Now;
            SA_Commentary EditNews = _context.SA_Commentary.Where(News => News.id == NewsId).FirstOrDefault();
            _context.Entry(EditNews).State = EntityState.Deleted;
            int x = _context.SaveChanges();
            return x == 0 ? false : true;
        }
        public async Task<bool> AddCommentary(SA_Commentary News)
        {
            News.IsActive = true;
            News.IsDelete = false;
            News.CreatedTime = DateTime.Now;

            _context.SA_Commentary.Add(News);
            int x = await _context.SaveChangesAsync();
            return x == 0 ? false : true;
        }

        public async Task<bool> UpdateCommentary(SA_Commentary News)
        {
            _context.Entry(News).State = EntityState.Modified;
            //  News.ModeifiedDate = DateTime.Now;
            int x = await _context.SaveChangesAsync();
            return x == 0 ? false : true;
        }

        internal SA_Commentary GetCommentaryByid(int id)
        {
            var data = _context.SA_Commentary.Where(x => x.id == id).SingleOrDefault();
            if (data != null)
            {
                return data;
            }
            else
            {
                return null;
            }
        }

        public List<SA_Commentary> GetCommentaryList(int id)
        {
            return _context.SA_Commentary.Where(w=>w.id==id).ToList();

        }

    }
}


