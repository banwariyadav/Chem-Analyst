using ChemAnalyst.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ChemAnalyst.DAL
{
    public class CompanyDataStore
    {

        private ChemAnalystContext _context = new ChemAnalystContext();

        public List<SA_Company> GetCompanyList()
        {
            return _context.SA_Company.ToList();

        }

        public bool EditCompany(SA_Company News)
        {
            //  News.CreatedDate = DateTime.Now;
            SA_Company EditNews = _context.SA_Company.Where(Cat => Cat.id == News.id).FirstOrDefault();
            EditNews.Address = News.Address;
            EditNews.Category = News.Category;
            EditNews.CEO = News.CEO;
            EditNews.CIN = News.CIN;
            EditNews.Meta = News.Meta;
            EditNews.MetaDescription = News.MetaDescription;
            EditNews.Description = News.Description;
            EditNews.Logo = News.Logo;
            EditNews.Name = News.Name;
            EditNews.NOE = News.NOE;
            EditNews.phoneNo = News.phoneNo;
            EditNews.website = News.website;
            EditNews.EmailId = News.EmailId;
            EditNews.fax = News.fax;
            EditNews.RegDate = News.RegDate;
            _context.Entry(EditNews).State = EntityState.Modified;
            int x = _context.SaveChanges();
            return x == 0 ? false : true;
        }
        public bool DeleteCompany(int NewsId)
        {
            //  News.CreatedDate = DateTime.Now;
            SA_Company EditNews = _context.SA_Company.Where(News => News.id == NewsId).FirstOrDefault();
            _context.Entry(EditNews).State = EntityState.Deleted;
            int x = _context.SaveChanges();
            return x == 0 ? false : true;
        }
        public async Task<bool> AddCompany(SA_Company News)
        {
            //  News.CreatedDate = DateTime.Now;
            _context.SA_Company.Add(News);
            int x = await _context.SaveChangesAsync();
            return x == 0 ? false : true;
        }

        public async Task<bool> UpdateCompany(SA_Company News)
        {
            _context.Entry(News).State = EntityState.Modified;
            //  News.ModeifiedDate = DateTime.Now;
            int x = await _context.SaveChangesAsync();
            return x == 0 ? false : true;
        }

        internal SA_Company GetCompanyByid(int id)
        {
            return _context.SA_Company.Where(x => x.id == id).SingleOrDefault();
        }


    }
}
