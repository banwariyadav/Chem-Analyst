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
            EditNews.AdsContent = News.AdsContent;
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


        public bool EditAdvisoryConetnt(SA_AdvisoryContent News)
        {
            //  News.CreatedDate = DateTime.Now;
            SA_AdvisoryContent EditNews = _context.SA_AdvisoryContent.Where(Cat => Cat.Id == News.Id).FirstOrDefault();
            EditNews.AdsId = News.AdsId;
            EditNews.ADVISORY1 = News.ADVISORY1;
            EditNews.ADVISORY2 = News.ADVISORY2;
            EditNews.ADVISORY3 = News.ADVISORY3;
            EditNews.ADVISORY4 = News.ADVISORY4;
            EditNews.ADVISORY5 = News.ADVISORY5;
            EditNews.ADVISORY6 = News.ADVISORY6;
            EditNews.CreatedTime = News.CreatedTime;
            _context.Entry(EditNews).State = EntityState.Modified;
            int x = _context.SaveChanges();
            return x == 0 ? false : true;
        }

        public async Task<bool> AddAdvisoryConetnt(SA_AdvisoryContent News)
        {
            News.CreatedTime = DateTime.Now;
            _context.SA_AdvisoryContent.Add(News);
            int x = await _context.SaveChangesAsync();
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
