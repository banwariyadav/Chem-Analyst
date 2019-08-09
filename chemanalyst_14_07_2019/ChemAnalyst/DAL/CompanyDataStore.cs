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

        public List<SA_Company> GetCompaniesList(string category, string products, string revsize, string empsize, string fyear, string companyname)
        {

            //   var ss = _context.SA_CompanyAndProductRelation.Where(x=>x.SA_ProductId == )
            int fid = _context.FinancialYears.FirstOrDefault(x => x.FinYear == fyear).Id;
            //var q = _context.SA_Company.ToList().AsEnumerable();
            var q = from c in _context.SA_Company
                    join p in _context.CompanyAndProductRelations on c.id equals p.SA_CompanyId into gj
                    join r in _context.CompanyProfRecordNew on c.id equals r.SA_CompanyId
                    select new
                    {
                        id = c.id,
                        Name = c.Name,
                        Description = c.Description,
                        Category = c.Category,
                        NOE = c.NOE,
                        Logo = c.Logo,
                        RegDate = c.RegDate,
                        CreatedTime = c.CreatedTime,
                        Product = gj.FirstOrDefault().SA_ProductId,
                        Revenu = r.Revenue,
                        FId = r.FinancialYearId
                    };
            // from subpet in gj.DefaultIfEmpty()
            // select new { person.FirstName, PetName = subpet?.Name ?? String.Empty };
            var sq = q.ToList().AsEnumerable();
            // sq = sq.Where(x => x.FId == fid);

            if (category != "")
            {
                // sq = sq.Where(x => x.Category == category);
            }
            if (companyname != "")
            {
                sq = sq.Where(x => x.Name.ToLower().Contains(companyname.ToLower()));
            }
            if (empsize != "")
            {
                int min = Convert.ToInt16(empsize.Split('-')[0]);
                int max = empsize.Split('-').Length <= 1 ? 50000 : Convert.ToInt16(empsize.Split('-')[1]);
                sq = sq.Where(x => Convert.ToInt16(x.NOE) > min && Convert.ToInt16(x.NOE) <= max);
            }
            if (revsize != "")
            {
                int min = Convert.ToInt16(revsize.Split('-')[0]);
                int max = revsize.Split('-').Length <= 1 ? 5000000 : Convert.ToInt16(revsize.Split('-')[1]);

                if (revsize.Split('-').Length > 1)
                {
                    sq = sq.Where(x => x.Revenu >= min && x.Revenu <= max);
                }
                else
                {
                    sq = sq.Where(x => x.Revenu >= min);
                }
            }
            if (products != "")
            {
                sq = sq.Where(x => x.Product == Convert.ToInt16(products));
            }
            var sds = sq.ToList().Select(c => new SA_Company
            {
                id = c.id,
                Name = c.Name,
                Description = c.Description,
                Category = c.Category,
                NOE = c.NOE,
                RegDate = c.RegDate,
                CreatedTime = c.CreatedTime,
                Logo = c.Logo
            }).Distinct().ToList();
            return sq.ToList().GroupBy(x => new { x.id, x.Name }).Select(c => new SA_Company
            {
                id = c.FirstOrDefault().id,
                Name = c.FirstOrDefault().Name



            }).ToList().ToList();

        }


        public SA_Company_SWOT GetSWOTByCompany(int id)
        {
            return _context.SA_Company_SWOT.FirstOrDefault(x=>x.CompanyId == id);

        }
        public List<SA_Company> GetCompanyList(string category, string products, string revsize, string empsize,string fyear)
        {

            //   var ss = _context.SA_CompanyAndProductRelation.Where(x=>x.SA_ProductId == )
            int fid = _context.FinancialYears.FirstOrDefault(x => x.FinYear == fyear).Id;
            //var q = _context.SA_Company.ToList().AsEnumerable();
            var q = from c in _context.SA_Company
                        join p in _context.CompanyAndProductRelations on c.id equals p.SA_CompanyId into gj
                        join r in  _context.CompanyProfRecordNew on c.id equals r.SA_CompanyId
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
                            Revenu = r.Revenue,
                            FId= r.FinancialYearId
                        };
            // from subpet in gj.DefaultIfEmpty()
            // select new { person.FirstName, PetName = subpet?.Name ?? String.Empty };
            var sq = q.ToList().AsEnumerable();
            sq = sq.Where(x => x.FId == fid);
            
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
                    sq = sq.Where(x => x.Revenu >= min && x.Revenu <= max);
                }
                else {
                    sq = sq.Where(x => x.Revenu >= min );
                }
            }
            if (products != "")
            {
                sq = sq.Where(x => x.Product == Convert.ToInt16( products));
            }
            var sds = sq.ToList().Select(c => new SA_Company
            {
                id = c.id,
                Name = c.Name,
                Description = c.Description,
                Category = c.Category,
                NOE = c.NOE,
                RegDate = c.RegDate,
                CreatedTime = c.CreatedTime,
                Logo = c.Logo
            }).Distinct().ToList();
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
            }).Distinct().ToList();

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

        internal dynamic GetUniqueFyear()
        {
            return _context.FinancialYears.Select(x => x.FinYear).Distinct().ToList();
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
