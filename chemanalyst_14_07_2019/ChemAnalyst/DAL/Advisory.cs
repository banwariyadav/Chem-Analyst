using ChemAnalyst.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ChemAnalyst.DAL
{
    public class AdvisoryDataStore
    {
       
            private ChemAnalystContext _context = new ChemAnalystContext();

            public List<SA_Advisory> GetAdvisoryList()
            {
                return _context.SA_Advisory.ToList();

            }

            public bool EditAdvisory(SA_Advisory News)
            {
            //  News.CreatedDate = DateTime.Now;
                SA_Advisory EditNews = _context.SA_Advisory.Where(Cat => Cat.id == News.id).FirstOrDefault();
                EditNews.AdvisoryName = News.AdvisoryName;
                EditNews.AdvisoryDiscription = News.AdvisoryDiscription;
                EditNews.Meta = News.Meta;
                EditNews.MetaDiscription = News.MetaDiscription;
                _context.Entry(EditNews).State = EntityState.Modified;
                int x = _context.SaveChanges();
                return x == 0 ? false : true;
            }
            public bool DeleteAdvisory(int NewsId)
            {
            //  News.CreatedDate = DateTime.Now;
            SA_Advisory EditNews = _context.SA_Advisory.Where(News => News.id == NewsId).FirstOrDefault();
                _context.Entry(EditNews).State = EntityState.Deleted;
                int x = _context.SaveChanges();
                return x == 0 ? false : true;
            }
            public async Task<bool> AddAdvisory(SA_Advisory News)
            {
                //  News.CreatedDate = DateTime.Now;
                _context.SA_Advisory.Add(News);
                int x = await _context.SaveChangesAsync();
                return x == 0 ? false : true;
            }

            public async Task<bool> UpdateAdvisory(SA_Advisory News)
            {
                _context.Entry(News).State = EntityState.Modified;
                //  News.ModeifiedDate = DateTime.Now;
                int x = await _context.SaveChangesAsync();
                return x == 0 ? false : true;
            }

            internal SA_Advisory GetAdvisoryByid(int id)
            {
                return _context.SA_Advisory.Where(x => x.id == id).SingleOrDefault();
            }

           
        }
    }
