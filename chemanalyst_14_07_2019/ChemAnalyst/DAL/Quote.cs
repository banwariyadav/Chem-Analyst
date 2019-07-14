using ChemAnalyst.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ChemAnalyst.DAL
{
    public class QuoteDataStore
    {
            private ChemAnalystContext _context = new ChemAnalystContext();

            public List<SA_Quote> GetQuoteList()
            {
                return _context.SA_Quote.ToList();

            }

            public bool EditQuote(SA_Quote News)
            {
                //  News.CreatedDate = DateTime.Now;
                SA_Quote EditNews = _context.SA_Quote.Where(Cat => Cat.id == News.id).FirstOrDefault();
                EditNews.QuoteName = News.QuoteName;
                EditNews.QuoteDiscription = News.QuoteDiscription;
                EditNews.QuoteBy = News.QuoteBy;
                EditNews.QuoteDes = News.QuoteDes;
                EditNews.Meta = News.Meta;
                EditNews.MetaDiscription = News.MetaDiscription;
                _context.Entry(EditNews).State = EntityState.Modified;
                int x = _context.SaveChanges();
                return x == 0 ? false : true;
            }
            public bool DeleteQuote(int NewsId)
            {
                //  News.CreatedDate = DateTime.Now;
                SA_Quote EditNews = _context.SA_Quote.Where(News => News.id == NewsId).FirstOrDefault();
                _context.Entry(EditNews).State = EntityState.Deleted;
                int x = _context.SaveChanges();
                return x == 0 ? false : true;
            }
            public async Task<bool> AddQuote(SA_Quote News)
            {
                //  News.CreatedDate = DateTime.Now;
                _context.SA_Quote.Add(News);
                int x = await _context.SaveChangesAsync();
                return x == 0 ? false : true;
            }

            public async Task<bool> UpdateQuote(SA_Quote News)
            {
                _context.Entry(News).State = EntityState.Modified;
                //  News.ModeifiedDate = DateTime.Now;
                int x = await _context.SaveChangesAsync();
                return x == 0 ? false : true;
            }

            internal SA_Quote GetQuoteByid(int id)
            {
                return _context.SA_Quote.Where(x => x.id == id).SingleOrDefault();
            }


        }
    }
