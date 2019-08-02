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
        public SA_Company_SWOT GetSWOTByCompany(int id)
        {
            return _context.SA_Company_SWOT.FirstOrDefault(x=>x.CompanyId == id);

        }
        public List<SA_Company> GetCompanyList(string category, string products, string revsize, string empsize)
        {

         //   var ss = _context.SA_CompanyAndProductRelation.Where(x=>x.SA_ProductId == )

            //var q = _context.SA_Company.ToList().AsEnumerable();
            var q = from c in _context.SA_Company
                        join p in _context.CompanyAndProductRelations on c.id equals p.SA_CompanyId into gj
                        join r in  _context.CompanyProfRecords on c.id equals r.SA_CompanyId
                        select new  {
                            id = c.id,
                            Name = c.Name,
                            Description = c.Description,
                            Category = c.Category,
                            NOE = c.NOE,
                            Logo= c.Logo,
                            RegDate = c.RegDate,
                            CreatedTime = c.CreatedTime,
                            Product = gj.FirstOrDefault().SA_ProductId,
                            Revenu = r.Revenues
                        };
            // from subpet in gj.DefaultIfEmpty()
            // select new { person.FirstName, PetName = subpet?.Name ?? String.Empty };
            var sq = q.ToList().AsEnumerable();
            if (category != "")
            {
                sq = sq.Where(x => x.Category == category);
            }
            if (empsize != "")
            {
                int min = Convert.ToInt16(empsize.Split('-')[0]);
                int max = empsize.Split('-').Length<=1?50000: Convert.ToInt16(empsize.Split('-')[1]);
                sq = sq.Where(x =>Convert.ToInt16( x.NOE)>min && Convert.ToInt16( x.NOE)<=max);
            }
            if (revsize != "")
            {
                int min = Convert.ToInt16(revsize.Split('-')[0]);
                int max = revsize.Split('-').Length<=1 ? 5000000 : Convert.ToInt16(revsize.Split('-')[1]);

                if (revsize.Split('-').Length > 1)
                {
                    sq = sq.Where(x => Convert.ToDouble(x.Revenu.Replace("US$", "").Replace("billion", "").Trim()) > min && Convert.ToDouble(x.Revenu.Replace("US$", "").Replace("billion", "").Trim()) <= max);
                }
                else {
                    sq = sq.Where(x => Convert.ToDouble(x.Revenu.Replace("US$", "").Replace("billion", "").Trim()) > min );
                }
            }
            if (products != "")
            {
                sq = sq.Where(x => x.Product == Convert.ToInt16( products));
            }
         
            return sq.ToList().Select(c=> new SA_Company
            {
                id = c.id,
                Name = c.Name,
                Description = c.Description,
                Category = c.Category,
                NOE = c.NOE,
                RegDate = c.RegDate,
                CreatedTime = c.CreatedTime,
                Logo= c.Logo
            }).ToList();

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

        public bool EditCompanySWOT(SA_Company_SWOT News)
        {
            //  News.CreatedDate = DateTime.Now;
            SA_Company_SWOT EditNews = _context.SA_Company_SWOT.Where(Cat => Cat.Id == News.Id).FirstOrDefault();
            EditNews.CompanyId = News.CompanyId;
            EditNews.Opportunity = News.Opportunity;
            EditNews.CompanyExpansionBlock = News.CompanyExpansionBlock;
            EditNews.Perspective = News.Perspective;
            EditNews.Strategy = News.Strategy;
            EditNews.Weakness = News.Weakness;
            EditNews.Threat = News.Threat;
            EditNews.Strength = News.Strength;
          
            _context.Entry(EditNews).State = EntityState.Modified;
            int x = _context.SaveChanges();
            return x == 0 ? false : true;
        }

        internal dynamic GetUniqueCategory()
        {
            return _context.SA_Company.Select(x=>x.Category).Distinct().ToList();
           // return _context.SA_Category.Where(w=>w.status==1).ToList();
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
     
        public async Task<bool> AddCompanySWOT(SA_Company_SWOT News)
        {
            //  News.CreatedDate = DateTime.Now;
            _context.SA_Company_SWOT.Add(News);
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

        internal dynamic GetCompanyProducts()
        {
            //return _context.CompanyProducts.ToList();
            return _context.SA_Product.Where(w=>w.status==1).ToList();
        }

        internal SA_Company GetCompanyByid(int id)
        {
            return _context.SA_Company.Where(x => x.id == id).SingleOrDefault();
        }


    }
}
