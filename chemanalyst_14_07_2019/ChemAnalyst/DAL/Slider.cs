using ChemAnalyst.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ChemAnalyst.DAL
{
    public class SliderDataStore
    {

        private ChemAnalystContext _context = new ChemAnalystContext();

        public List<SA_Slider> GetSliderList()
        {
            return _context.SA_Slider.ToList();

        }

        public bool EditSlider(SA_Slider News)
        {
            //  News.CreatedDate = DateTime.Now;
            SA_Slider EditNews = _context.SA_Slider.Where(Cat => Cat.id == News.id).FirstOrDefault();
            EditNews.Title = News.Title;
            EditNews.Category = News.Category;
            EditNews.Discription = News.Discription;
            EditNews.Meta = News.Meta;
            EditNews.MetaDiscription = News.MetaDiscription;
            _context.Entry(EditNews).State = EntityState.Modified;
            int x = _context.SaveChanges();
            return x == 0 ? false : true;
        }
        public bool DeleteSlider(int NewsId)
        {
            //  News.CreatedDate = DateTime.Now;
            SA_Slider EditNews = _context.SA_Slider.Where(News => News.id == NewsId).FirstOrDefault();
            _context.Entry(EditNews).State = EntityState.Deleted;
            int x = _context.SaveChanges();
            return x == 0 ? false : true;
        }
        public async Task<bool> AddSlider(SA_Slider News)
        {
            //  News.CreatedDate = DateTime.Now;
            _context.SA_Slider.Add(News);
            int x = await _context.SaveChangesAsync();
            return x == 0 ? false : true;
        }

        public async Task<bool> UpdateSlider(SA_Slider News)
        {
            _context.Entry(News).State = EntityState.Modified;
            //  News.ModeifiedDate = DateTime.Now;
            int x = await _context.SaveChangesAsync();
            return x == 0 ? false : true;
        }

        internal SA_Slider GetSliderByid(int id)
        {
            return _context.SA_Slider.Where(x => x.id == id).SingleOrDefault();
        }


    }
}
  