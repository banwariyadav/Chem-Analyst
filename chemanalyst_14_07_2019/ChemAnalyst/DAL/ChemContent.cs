using ChemAnalyst.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ChemAnalyst.DAL
{
    public class ChemContentDataStore
    {
        private ChemAnalystContext _context = new ChemAnalystContext();

        public List<SA_ChemContent> GetChemContentList()
        {
            return _context.SA_ChemContent.ToList();

        }

        public bool EditChemContent(SA_ChemContent News)
        {

            SA_ChemContent EditNews = _context.SA_ChemContent.Where(Cat => Cat.id == News.id).FirstOrDefault();
            EditNews.Title = News.Title;
            EditNews.Description = News.Description;
         



            _context.Entry(EditNews).State = EntityState.Modified;
            int x = _context.SaveChanges();
            return x == 0 ? false : true;
        }
        public bool DeleteChemContent(int NewsId)
        {
            //  News.CreatedDate = DateTime.Now;
            SA_ChemContent EditNews = _context.SA_ChemContent.Where(News => News.id == NewsId).FirstOrDefault();
            _context.Entry(EditNews).State = EntityState.Deleted;
            int x = _context.SaveChanges();
            return x == 0 ? false : true;
        }
        public async Task<bool> AddChemContent(SA_ChemContent News)
        {
            //  News.CreatedDate = DateTime.Now;
            _context.SA_ChemContent.Add(News);
            int x = await _context.SaveChangesAsync();
            return x == 0 ? false : true;
        }

        public async Task<bool> UpdateChemContent(SA_ChemContent News)
        {
            _context.Entry(News).State = EntityState.Modified;
            //  News.ModeifiedDate = DateTime.Now;
            int x = await _context.SaveChangesAsync();
            return x == 0 ? false : true;
        }

        internal SA_ChemContent GetChemContentByid(int id)
        {
            var data = _context.SA_ChemContent.Where(x => x.id == id).SingleOrDefault();
            if (data != null)
            {
                return data;
            }
            else
            {
                return null;
            }
        }
    }
}