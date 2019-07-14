using ChemAnalyst.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ChemAnalyst.DAL
{
    public class JobDataStore
    {
            private ChemAnalystContext _context = new ChemAnalystContext();

            public List<SA_Job> GetJobList()
            {
                return _context.SA_Job.ToList();

            }

            public bool EditJob(SA_Job News)
            {
                //  News.CreatedDate = DateTime.Now;
                SA_Job EditNews = _context.SA_Job.Where(Cat => Cat.id == News.id).FirstOrDefault();
                EditNews.JobName = News.JobName;
                EditNews.JobDiscription = News.JobDiscription;
                EditNews.Meta = News.Meta;
                EditNews.MetaDiscription = News.MetaDiscription;
                _context.Entry(EditNews).State = EntityState.Modified;
                int x = _context.SaveChanges();
                return x == 0 ? false : true;
            }
            public bool DeleteJob(int NewsId)
            {
                //  News.CreatedDate = DateTime.Now;
                SA_Job EditNews = _context.SA_Job.Where(News => News.id == NewsId).FirstOrDefault();
                _context.Entry(EditNews).State = EntityState.Deleted;
                int x = _context.SaveChanges();
                return x == 0 ? false : true;
            }
            public async Task<bool> AddJob(SA_Job News)
            {
                //  News.CreatedDate = DateTime.Now;
                _context.SA_Job.Add(News);
                int x = await _context.SaveChangesAsync();
                return x == 0 ? false : true;
            }

            public async Task<bool> UpdateJob(SA_Job News)
            {
                _context.Entry(News).State = EntityState.Modified;
                //  News.ModeifiedDate = DateTime.Now;
                int x = await _context.SaveChangesAsync();
                return x == 0 ? false : true;
            }

            internal SA_Job GetJobByid(int id)
            {
                return _context.SA_Job.Where(x => x.id == id).SingleOrDefault();
            }


        }
    }
