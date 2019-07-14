using ChemAnalyst.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ChemAnalyst.DAL
{
    public class WorldDataStore
    {
     
            private ChemAnalystContext _context = new ChemAnalystContext();

            public List<SA_World> GetWorldList()
            {
                return _context.SA_World.ToList();

            }

            public bool EditWorld(SA_World News)
            {

                SA_World EditNews = _context.SA_World.Where(Cat => Cat.id == News.id).FirstOrDefault();
                EditNews.Title = News.Title;
                EditNews.Description = News.Description;
                EditNews.Image = News.Image;
             
               

                _context.Entry(EditNews).State = EntityState.Modified;
                int x = _context.SaveChanges();
                return x == 0 ? false : true;
            }
            public bool DeleteWorld(int NewsId)
            {
                //  News.CreatedDate = DateTime.Now;
                SA_World EditNews = _context.SA_World.Where(News => News.id == NewsId).FirstOrDefault();
                _context.Entry(EditNews).State = EntityState.Deleted;
                int x = _context.SaveChanges();
                return x == 0 ? false : true;
            }
            public async Task<bool> AddWorld(SA_World News)
            {
                //  News.CreatedDate = DateTime.Now;
                _context.SA_World.Add(News);
                int x = await _context.SaveChangesAsync();
                return x == 0 ? false : true;
            }

            public async Task<bool> UpdateWorld(SA_World News)
            {
                _context.Entry(News).State = EntityState.Modified;
                //  News.ModeifiedDate = DateTime.Now;
                int x = await _context.SaveChangesAsync();
                return x == 0 ? false : true;
            }

            internal SA_World GetWorldByid(int id)
            {
                var data = _context.SA_World.Where(x => x.id == id).SingleOrDefault();
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



