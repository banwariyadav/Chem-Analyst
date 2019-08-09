using ChemAnalyst.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Web;

namespace ChemAnalyst.DAL
{
    public class MarketAnalysis
    {
        private ChemAnalystContext _context = new ChemAnalystContext();
        public List<SA_MarketbyComp> GetYearWiseProductList(string ProductId)
        {
            if (ProductId != null)
            {
                int id = int.Parse(ProductId);
                return _context.SA_MarketbyComp.Where(Year => Year.Product == id).ToList();
            }
            else
                return _context.SA_MarketbyComp.ToList();

            

        }
        public int GetctegotyBYproduct(int ProductId)
        {

            SA_Product obj = _context.SA_Product.Where(product => product.id == ProductId).FirstOrDefault();
            if (ProductId > 0)
                return (int)obj.Category;
            else
                return 0;



        }

        internal List<SA_MarketbyLoc> GetLocWiseProductList(string ProductId)
        {
            if (ProductId != null)
            {
                int id = int.Parse(ProductId);
                return _context.SA_MarketbyLoc.Where(Year => Year.Product == id).ToList();
            }
            else
                return _context.SA_MarketbyLoc.ToList();
        }
        internal int CheckExistingdata(string Filename, string ImportType)
        {
            int x = 0;
            if (ImportType == "Company")
            {

                List<SA_MarketbyComp> obj = _context.SA_MarketbyComp.Where(Year => Year.FileName == Filename).ToList();
                foreach (SA_MarketbyComp PriceYearly in obj)
                {
                    _context.Entry(PriceYearly).State = EntityState.Deleted;
                    x = _context.SaveChanges();

                }
            }
            else if (ImportType == "Location")
            {
                List<SA_MarketbyLoc> obj = _context.SA_MarketbyLoc.Where(Year => Year.FileName == Filename).ToList();
                foreach (SA_MarketbyLoc PriceYearly in obj)
                {
                    _context.Entry(PriceYearly).State = EntityState.Deleted;
                    x = _context.SaveChanges();

                }
            }
            //else if (ImportType == "Quarterly")
            //{
            //    List<SA_ChemPriceQuarterly> obj = _context.SA_ChemPriceQuarterly.Where(Year => Year.FileName == Filename).ToList();
            //    foreach (SA_ChemPriceQuarterly PriceYearly in obj)
            //    {
            //        _context.Entry(PriceYearly).State = EntityState.Deleted;
            //        x = _context.SaveChanges();

            //    }
            //}
            //else if (ImportType == "Daily basis")
            //{
            //    List<SA_ChemPriceDaily> obj = _context.SA_ChemPriceDaily.Where(Year => Year.FileName == Filename).ToList();
            //    foreach (SA_ChemPriceDaily PriceYearly in obj)
            //    {
            //        _context.Entry(PriceYearly).State = EntityState.Deleted;
            //        x = _context.SaveChanges();

            //    }
            //}
            //else if (ImportType == "Daily Bulk")
            //{
            //    List<SA_ChemPriceDailyAverage> obj = _context.SA_ChemPriceDailyAverage.Where(Year => Year.FileName == Filename).ToList();
            //    foreach (SA_ChemPriceDailyAverage PriceYearly in obj)
            //    {
            //        _context.Entry(PriceYearly).State = EntityState.Deleted;
            //        x = _context.SaveChanges();

            //    }
            //}



            return x;

        }
        internal int CheckFileuploadStatus(string Filename, string ImportType)
        {
            int x = 0;

            if (ImportType == "Company")
            {

                List<SA_MarketbyComp> obj = _context.SA_MarketbyComp.Where(Year => Year.FileName == Filename).ToList();
                if (obj.Count() > 0)
                {
                    return 1;
                }
                else
                    return 0;
            }
            else if (ImportType == "Location")
            {
                List<SA_MarketbyLoc> obj = _context.SA_MarketbyLoc.Where(Year => Year.FileName == Filename).ToList();
                if (obj.Count() > 0)
                {
                    return 1;
                }
                else
                    return 0;
            }

            //else if (ImportType == "Quarterly")
            //{
            //    List<SA_ChemPriceQuarterly> obj = _context.SA_ChemPriceQuarterly.Where(Year => Year.FileName == Filename).ToList();
            //    if (obj.Count() > 0)
            //    {
            //        return 1;
            //    }
            //    else
            //        return 0;
            //}
            //else if (ImportType == "Daily basis")
            //{
            //    List<SA_ChemPriceDaily> obj = _context.SA_ChemPriceDaily.Where(Year => Year.FileName == Filename).ToList();
            //    if (obj.Count() > 0)
            //    {
            //        return 1;
            //    }
            //    else
            //        return 0;
            //}
            //else if (ImportType == "Daily Bulk")
            //{
            //    List<SA_ChemPriceDailyAverage> obj = _context.SA_ChemPriceDailyAverage.Where(Year => Year.FileName == Filename).ToList();
            //    if (obj.Count() > 0)
            //    {
            //        return 1;
            //    }
            //    else
            //        return 0;
            //}
            return 0;
        }

        internal List<SA_MarketFileList> GetallUploadFile()
        {
            List<SA_MarketFileList> xyz = ((from cust in _context.SA_MarketbyComp
                                            select new SA_MarketFileList { FileName = cust.FileName, CreatedDate = cust.CreatedDate.ToString(), Product = _context.SA_Product.Where(x => x.id == cust.Product).Select(y => y.ProductName).FirstOrDefault() })
        .Union
          (from cust in _context.SA_MarketbyLoc
           select new SA_MarketFileList { FileName = cust.FileName, CreatedDate = cust.CreatedDate.ToString(), Product = _context.SA_Product.Where(x => x.id == cust.Product).Select(y => y.ProductName).FirstOrDefault() })
           .Union
          (from cust in _context.SA_MarketbyProcess
           select new SA_MarketFileList { FileName = cust.FileName, CreatedDate = cust.CreatedDate.ToString(), Product = _context.SA_Product.Where(x => x.id == cust.Product).Select(y => y.ProductName).FirstOrDefault() })
           .Union
           (from cust in _context.SA_MarketbyProducer
            select new SA_MarketFileList { FileName = cust.FileName, CreatedDate = cust.CreatedDate.ToString(), Product = _context.SA_Product.Where(x => x.id == cust.Product).Select(y => y.ProductName).FirstOrDefault() })
           .Union
           (from cust in _context.SA_MarketbyEfficiency
            select new SA_MarketFileList { FileName = cust.FileName, CreatedDate = cust.CreatedDate.ToString(), Product = _context.SA_Product.Where(x => x.id == cust.Product).Select(y => y.ProductName).FirstOrDefault() })
             .Union
           (from cust in _context.SA_MarketbyEndUsetonnes
            select new SA_MarketFileList { FileName = cust.FileName, CreatedDate = cust.CreatedDate.ToString(), Product = _context.SA_Product.Where(x => x.id == cust.Product).Select(y => y.ProductName).FirstOrDefault() })
              .Union
           (from cust in _context.SA_MarketbyGradetonnes
            select new SA_MarketFileList { FileName = cust.FileName, CreatedDate = cust.CreatedDate.ToString(), Product = _context.SA_Product.Where(x => x.id == cust.Product).Select(y => y.ProductName).FirstOrDefault() })
              .Union
           (from cust in _context.SA_MarketbySalestonnes
            select new SA_MarketFileList { FileName = cust.FileName, CreatedDate = cust.CreatedDate.ToString(), Product = _context.SA_Product.Where(x => x.id == cust.Product).Select(y => y.ProductName).FirstOrDefault() })
              .Union
           (from cust in _context.SA_MarketbyRegiontonnes
            select new SA_MarketFileList { FileName = cust.FileName, CreatedDate = cust.CreatedDate.ToString(), Product = _context.SA_Product.Where(x => x.id == cust.Product).Select(y => y.ProductName).FirstOrDefault() })
              .Union
           (from cust in _context.SA_MarketbyDemandsupply
            select new SA_MarketFileList { FileName = cust.FileName, CreatedDate = cust.CreatedDate.ToString(), Product = _context.SA_Product.Where(x => x.id == cust.Product).Select(y => y.ProductName).FirstOrDefault() })
              .Union
           (from cust in _context.SA_MarketbyCompanySharetonnes
            select new SA_MarketFileList { FileName = cust.FileName, CreatedDate = cust.CreatedDate.ToString(), Product = _context.SA_Product.Where(x => x.id == cust.Product).Select(y => y.ProductName).FirstOrDefault() })
              .Union
           (from cust in _context.SA_MarketbyTradeExport
            select new SA_MarketFileList { FileName = cust.FileName, CreatedDate = cust.CreatedDate.ToString(), Product = _context.SA_Product.Where(x => x.id == cust.Product).Select(y => y.ProductName).FirstOrDefault() })
               .Union
           (from cust in _context.SA_MarketbyTradeImport
            select new SA_MarketFileList { FileName = cust.FileName, CreatedDate = cust.CreatedDate.ToString(), Product = _context.SA_Product.Where(x => x.id == cust.Product).Select(y => y.ProductName).FirstOrDefault() })
              .Union
           (from cust in _context.SA_MarketbyTech
            select new SA_MarketFileList { FileName = cust.FileName, CreatedDate = cust.CreatedDate.ToString(), Product = _context.SA_Product.Where(x => x.id == cust.Product).Select(y => y.ProductName).FirstOrDefault() })).ToList();
            return xyz;


        }

        internal List<SA_MarketbyComp> GetCompanyWiseProductListwithCompare(string[] values)
        {
            var query = (from SA_MarketbyComp in _context.SA_MarketbyComp
                         where values.Contains(SA_MarketbyComp.Product.ToString())
                         select new { SA_MarketbyComp });

            List<SA_MarketbyComp> returnpro = new List<SA_MarketbyComp>();
            foreach (var item in query)
            {
                returnpro.Add(item.SA_MarketbyComp);
            }
            return returnpro;
        }

        public List<SA_MarketbyComp> GetCompanyWiseProductList(string ProductId)
        {
            if (ProductId != null)
            {
                int id = int.Parse(ProductId);

                return _context.SA_MarketbyComp.Where(Year => Year.Product == id).ToList();
            }
            else
            {
                
                int uniqueCategories = (from m in _context.SA_MarketbyComp
                                        join n in _context.SA_Product on
                                        m.Product equals n.id
                                        select (n.id)).FirstOrDefault();

                return _context.SA_MarketbyComp.Where(Year => Year.Product == uniqueCategories).ToList();
            }


        }

        internal List<SA_MarketbyLoc> GetLocationWiseProductListwithCompare(string[] values)
        {
            var query = (from SA_MarketbyLoc in _context.SA_MarketbyLoc
                         where values.Contains(SA_MarketbyLoc.Product.ToString())
                         select new { SA_MarketbyLoc });

            List<SA_MarketbyLoc> returnpro = new List<SA_MarketbyLoc>();
            foreach (var item in query)
            {
                returnpro.Add(item.SA_MarketbyLoc);
            }
            return returnpro;
        }

        public List<SA_MarketbyLoc> GetLocationWiseProductList(string ProductId, string FromYear, string ToYear)
        {
            int id = 0;
            int fyear = Convert.ToInt16(FromYear);
            int tyear = Convert.ToInt16(ToYear);
            if (ProductId != null)
            {
                id = int.Parse(ProductId);


            }
            else
            {

                id = (from m in _context.SA_MarketbyLoc
                      join n in _context.SA_Product on
                      m.Product equals n.id
                      select (n.id)).FirstOrDefault();


            }
            var results = (from ssi in _context.SA_MarketbyLoc.AsEnumerable()
                           where ssi.Product == id
                             &&(fyear == 0 ||(int.Parse(ssi.year)) >= fyear)
                            &&(tyear == 0 ||(int.Parse(ssi.year)) <= tyear)
                           group ssi by new { ssi.States, ssi.year } into g
                           select new SA_MarketbyLoc
                           {
                               Location = g.Key.States,
                               year = g.Key.year,
                               Discription = g.FirstOrDefault().Discription,
                               Product = g.FirstOrDefault().Product,
                               count = g.Sum(c => c.count)


                           }
).ToList();
            return results;
            //return _context.SA_MarketbyLoc.Where(Year => Year.Product == id).ToList().GroupBy(x=> new { x.States,x.year,x.Company }).Select(x=> new SA_MarketbyLoc {
            //    Location = x.FirstOrDefault().States,
            //    year = x.FirstOrDefault().year,
            //    Discription = x.FirstOrDefault().Discription,
            //    Product = x.FirstOrDefault().Product,
            //    count = x.Sum(c=>c.count) 



            //}).ToList();


        }

        public List<SA_MarketbyLoc> GetLocationWiseProductListReport(string ProductId, string FromYear, string ToYear)
        {
            if (ProductId != null)
            {
                int id = int.Parse(ProductId);
                return _context.SA_MarketbyLoc.ToList().Where(Year => Year.Product == id
                 && (Convert.ToInt16(FromYear) == 0 || Convert.ToInt16(Year.year) >= Convert.ToInt16(FromYear))
                && (Convert.ToInt16(ToYear) == 0 || Convert.ToInt16(Year.year) <= Convert.ToInt16(ToYear))
                ).ToList();
            }
            else
            {
                int uniqueCategories = (from m in _context.SA_MarketbyLoc
                                        join n in _context.SA_Product on
                                        m.Product equals n.id
                                        select (n.id)).FirstOrDefault();
                return _context.SA_MarketbyLoc.ToList().Where(Year => Year.Product == uniqueCategories
                 && (Convert.ToInt16(FromYear) ==0 ||Convert.ToInt16(Year.year) >= Convert.ToInt16(FromYear))
                && (Convert.ToInt16(ToYear) == 0 || Convert.ToInt16(Year.year) <= Convert.ToInt16(ToYear))
                ).ToList();
            }
        }

        public List<SA_MarketbyTech> GetTechnologyWiseProductListReport(string ProductId, string FromYear, string ToYear)
        {
            if (ProductId != null)
            {
                int id = int.Parse(ProductId);
                return _context.SA_MarketbyTech.ToList().Where(Year => Year.Product == id
                 && (Convert.ToInt16(FromYear) == 0 || Convert.ToInt16(Year.year) >= Convert.ToInt16(FromYear))
                && (Convert.ToInt16(ToYear) == 0 || Convert.ToInt16(Year.year) <= Convert.ToInt16(ToYear))
                ).ToList();
            }
            else
            {
                int uniqueCategories = (from m in _context.SA_MarketbyLoc
                                        join n in _context.SA_Product on
                                        m.Product equals n.id
                                        select (n.id)).FirstOrDefault();
                return _context.SA_MarketbyTech.ToList().Where(Year => Year.Product == uniqueCategories
                 && (Convert.ToInt16(FromYear) == 0 || Convert.ToInt16(Year.year) >= Convert.ToInt16(FromYear))
                && (Convert.ToInt16(ToYear) == 0 || Convert.ToInt16(Year.year) <= Convert.ToInt16(ToYear))
                ).ToList();
            }
        }

        internal List<SA_MarketbyTech> GetTechnologyWiseProductListwithCompare(string[] values)
        {
            var query = (from SA_MarketbyTech in _context.SA_MarketbyTech
                         where values.Contains(SA_MarketbyTech.Product.ToString())
                         select new { SA_MarketbyTech });

            List<SA_MarketbyTech> returnpro = new List<SA_MarketbyTech>();
            foreach (var item in query)
            {
                returnpro.Add(item.SA_MarketbyTech);
            }
            return returnpro;
        }

        public List<SA_MarketbyTech> GetTechnologyWiseProductList(string ProductId, string FromYear, string ToYear)
        {

           
            List<SA_MarketbyTech> results = new List<SA_MarketbyTech>();
            //int id = 0;
            if (ProductId != null)
            {
                int id = int.Parse(ProductId);
                return _context.SA_MarketbyTech.ToList().Where(Year => Year.Product == id
                 && (Convert.ToInt16(FromYear) == 0 || Convert.ToInt16(Year.year) >= Convert.ToInt16(FromYear))
                && (Convert.ToInt16(ToYear) == 0 || Convert.ToInt16(Year.year) <= Convert.ToInt16(ToYear))
                ).ToList();
            }
            else
            {
                int uniqueCategories = (from m in _context.SA_MarketbyLoc
                                        join n in _context.SA_Product on
                                        m.Product equals n.id
                                        select (n.id)).FirstOrDefault();
                return _context.SA_MarketbyTech.ToList().Where(Year => Year.Product == uniqueCategories
                 && (Convert.ToInt16(FromYear) == 0 || Convert.ToInt16(Year.year) >= Convert.ToInt16(FromYear))
                && (Convert.ToInt16(ToYear) == 0 || Convert.ToInt16(Year.year) <= Convert.ToInt16(ToYear))
                ).ToList();
            }


        }

        internal List<SA_MarketbyProcess> GetProcessWiseProductListwithCompare(string[] values)
        {
            var query = (from SA_MarketbyProcess in _context.SA_MarketbyProcess
                         where values.Contains(SA_MarketbyProcess.Product.ToString())
                         select new { SA_MarketbyProcess });

            List<SA_MarketbyProcess> returnpro = new List<SA_MarketbyProcess>();
            foreach (var item in query)
            {
                returnpro.Add(item.SA_MarketbyProcess);
            }
            return returnpro;
        }

        public List<SA_MarketbyProcess> GetProcessWiseProductList(string ProductId, string FromYear, string ToYear)
        {
            List<SA_MarketbyTech> results = new List<SA_MarketbyTech>();
            //int id = 0;
            if (ProductId != null)
            {
                int id = int.Parse(ProductId);
                return _context.SA_MarketbyProcess.ToList().Where(Year => Year.Product == id
                 && (Convert.ToInt16(FromYear) == 0 || Convert.ToInt16(Year.year) >= Convert.ToInt16(FromYear))
                && (Convert.ToInt16(ToYear) == 0 || Convert.ToInt16(Year.year) <= Convert.ToInt16(ToYear))
                ).ToList();
            }
            else
            {
                int uniqueCategories = (from m in _context.SA_MarketbyLoc
                                        join n in _context.SA_Product on
                                        m.Product equals n.id
                                        select (n.id)).FirstOrDefault();
                return _context.SA_MarketbyProcess.ToList().Where(Year => Year.Product == uniqueCategories
                 && (Convert.ToInt16(FromYear) == 0 || Convert.ToInt16(Year.year) >= Convert.ToInt16(FromYear))
                && (Convert.ToInt16(ToYear) == 0 || Convert.ToInt16(Year.year) <= Convert.ToInt16(ToYear))
                ).ToList();
            }



        }

        public List<SA_MarketbyProcess> GetProcessWiseProductListReport(string ProductId, string FromYear, string ToYear)
        {
            if (ProductId != null)
            {
                int id = int.Parse(ProductId);
                return _context.SA_MarketbyProcess.ToList().Where(Year => Year.Product == id
                 && (Convert.ToInt16(FromYear) == 0 || Convert.ToInt16(Year.year) >= Convert.ToInt16(FromYear))
                && (Convert.ToInt16(ToYear) == 0 || Convert.ToInt16(Year.year) <= Convert.ToInt16(ToYear))
                ).ToList();
            }
            else
            {
                int uniqueCategories = (from m in _context.SA_MarketbyLoc
                                        join n in _context.SA_Product on
                                        m.Product equals n.id
                                        select (n.id)).FirstOrDefault();
                return _context.SA_MarketbyProcess.ToList().Where(Year => Year.Product == uniqueCategories
                 && (Convert.ToInt16(FromYear) == 0 || Convert.ToInt16(Year.year) >= Convert.ToInt16(FromYear))
                && (Convert.ToInt16(ToYear) == 0 || Convert.ToInt16(Year.year) <= Convert.ToInt16(ToYear))
                ).ToList();
            }
        }

        internal List<SA_MarketbyProducer> GetProducerWiseProductListwithCompare(string[] values)
        {
            var query = (from SA_MarketbyProducer in _context.SA_MarketbyProducer
                         where values.Contains(SA_MarketbyProducer.Product.ToString())
                         select new { SA_MarketbyProducer });

            List<SA_MarketbyProducer> returnpro = new List<SA_MarketbyProducer>();
            foreach (var item in query)
            {
                returnpro.Add(item.SA_MarketbyProducer);
            }
            return returnpro;
        }

        public List<SA_MarketbyProducer> GetProducerWiseProductList(string ProductId)
        {
            if (ProductId != null)
            {
                int id = int.Parse(ProductId);

                return _context.SA_MarketbyProducer.Where(Year => Year.Product == id).ToList();
            }
            else
            {
                int uniqueCategories = (from m in _context.SA_MarketbyProducer
                                        join n in _context.SA_Product on
                                        m.Product equals n.id
                                        select (n.id)).FirstOrDefault();

                return _context.SA_MarketbyProducer.Where(Year => Year.Product == uniqueCategories).ToList();
            }


        }

        internal List<SA_MarketbyEfficiency> GetEfficiencyWiseProductListwithCompare(string[] values)
        {
            var query = (from SA_MarketbyEfficiency in _context.SA_MarketbyEfficiency
                         where values.Contains(SA_MarketbyEfficiency.Product.ToString())
                         select new { SA_MarketbyEfficiency });

            List<SA_MarketbyEfficiency> returnpro = new List<SA_MarketbyEfficiency>();
            foreach (var item in query)
            {
                returnpro.Add(item.SA_MarketbyEfficiency);
            }
            return returnpro;
        }

        public List<SA_MarketbyEfficiency> GetEfficiencyWiseProductList(string ProductId)
        {
            if (ProductId != null)
            {
                int id = int.Parse(ProductId);

                return _context.SA_MarketbyEfficiency.Where(Year => Year.Product == id).ToList();
            }
            else
            {
                int uniqueCategories = (from m in _context.SA_MarketbyEfficiency
                                        join n in _context.SA_Product on
                                        m.Product equals n.id
                                        select (n.id)).FirstOrDefault();

                return _context.SA_MarketbyEfficiency.Where(Year => Year.Product == uniqueCategories).ToList();
            }


        }

        internal List<SA_MarketbyEndUsepercent> GetEndUsepercentWiseProductListwithCompare(string[] values)
        {
            var query = (from SA_MarketbyEndUsepercent in _context.SA_MarketbyEndUsepercent
                         where values.Contains(SA_MarketbyEndUsepercent.Product.ToString())
                         select new { SA_MarketbyEndUsepercent });

            List<SA_MarketbyEndUsepercent> returnpro = new List<SA_MarketbyEndUsepercent>();
            foreach (var item in query)
            {
                returnpro.Add(item.SA_MarketbyEndUsepercent);
            }
            return returnpro;
        }

        public List<SA_MarketbyEndUsepercent> GetEndUsepercentWiseProductList(string ProductId)
        {
            if (ProductId != null)
            {
                int id = int.Parse(ProductId);

                return _context.SA_MarketbyEndUsepercent.Where(Year => Year.Product == id).ToList();
            }
            else
            {
                int uniqueCategories = (from m in _context.SA_MarketbyEndUsepercent
                                        join n in _context.SA_Product on
                                        m.Product equals n.id
                                        select (n.id)).FirstOrDefault();

                return _context.SA_MarketbyEndUsepercent.Where(Year => Year.Product == uniqueCategories).ToList();
            }


        }

        internal List<SA_MarketbyEndUsetonnes> GetEndUsetonnesWiseProductListwithCompare(string[] values)
        {
            var query = (from SA_MarketbyEndUsetonnes in _context.SA_MarketbyEndUsetonnes
                         where values.Contains(SA_MarketbyEndUsetonnes.Product.ToString())
                         select new { SA_MarketbyEndUsetonnes });

            List<SA_MarketbyEndUsetonnes> returnpro = new List<SA_MarketbyEndUsetonnes>();
            foreach (var item in query)
            {
                returnpro.Add(item.SA_MarketbyEndUsetonnes);
            }
            return returnpro;
        }

        public List<SA_MarketbyEndUsetonnes> GetEndUsetonnesWiseProductList(string ProductId)
        {
            if (ProductId != null)
            {
                int id = int.Parse(ProductId);

                return _context.SA_MarketbyEndUsetonnes.Where(Year => Year.Product == id).ToList();
            }
            else
            {
                int uniqueCategories = (from m in _context.SA_MarketbyEndUsetonnes
                                        join n in _context.SA_Product on
                                        m.Product equals n.id
                                        select (n.id)).FirstOrDefault();

                return _context.SA_MarketbyEndUsetonnes.Where(Year => Year.Product == uniqueCategories).ToList();
            }


        }

        internal List<SA_MarketbyGradepercent> GetGradepercentWiseProductListwithCompare(string[] values)
        {
            var query = (from SA_MarketbyGradepercent in _context.SA_MarketbyGradepercent
                         where values.Contains(SA_MarketbyGradepercent.Product.ToString())
                         select new { SA_MarketbyGradepercent });

            List<SA_MarketbyGradepercent> returnpro = new List<SA_MarketbyGradepercent>();
            foreach (var item in query)
            {
                returnpro.Add(item.SA_MarketbyGradepercent);
            }
            return returnpro;
        }

        public List<SA_MarketbyGradepercent> GetGradepercentWiseProductList(string ProductId)
        {
            if (ProductId != null)
            {
                int id = int.Parse(ProductId);

                return _context.SA_MarketbyGradepercent.Where(Year => Year.Product == id).ToList();
            }
            else
            {
                int uniqueCategories = (from m in _context.SA_MarketbyGradepercent
                                        join n in _context.SA_Product on
                                        m.Product equals n.id
                                        select (n.id)).FirstOrDefault();

                return _context.SA_MarketbyGradepercent.Where(Year => Year.Product == uniqueCategories).ToList();
            }


        }

        internal List<SA_MarketbyGradetonnes> GetGradetonnesWiseProductListwithCompare(string[] values)
        {
            var query = (from SA_MarketbyGradetonnes in _context.SA_MarketbyGradetonnes
                         where values.Contains(SA_MarketbyGradetonnes.Product.ToString())
                         select new { SA_MarketbyGradetonnes });

            List<SA_MarketbyGradetonnes> returnpro = new List<SA_MarketbyGradetonnes>();
            foreach (var item in query)
            {
                returnpro.Add(item.SA_MarketbyGradetonnes);
            }
            return returnpro;
        }

        public List<SA_MarketbyGradetonnes> GetGradetonnesWiseProductList(string ProductId)
        {
            if (ProductId != null)
            {
                int id = int.Parse(ProductId);

                return _context.SA_MarketbyGradetonnes.Where(Year => Year.Product == id).ToList();
            }
            else
            {
                int uniqueCategories = (from m in _context.SA_MarketbyGradetonnes
                                        join n in _context.SA_Product on
                                        m.Product equals n.id
                                        select (n.id)).FirstOrDefault();

                return _context.SA_MarketbyGradetonnes.Where(Year => Year.Product == uniqueCategories).ToList();
            }


        }

        internal List<SA_MarketbyTypepercent> GetTypepercentWiseProductListwithCompare(string[] values)
        {
            var query = (from SA_MarketbyTypepercent in _context.SA_MarketbyTypepercent
                         where values.Contains(SA_MarketbyTypepercent.Product.ToString())
                         select new { SA_MarketbyTypepercent });

            List<SA_MarketbyTypepercent> returnpro = new List<SA_MarketbyTypepercent>();
            foreach (var item in query)
            {
                returnpro.Add(item.SA_MarketbyTypepercent);
            }
            return returnpro;
        }

        public List<SA_MarketbyTypepercent> GetTypepercentWiseProductList(string ProductId)
        {
            if (ProductId != null)
            {
                int id = int.Parse(ProductId);

                return _context.SA_MarketbyTypepercent.Where(Year => Year.Product == id).ToList();
            }
            else
            {
                int uniqueCategories = (from m in _context.SA_MarketbyTypepercent
                                        join n in _context.SA_Product on
                                        m.Product equals n.id
                                        select (n.id)).FirstOrDefault();

                return _context.SA_MarketbyTypepercent.Where(Year => Year.Product == uniqueCategories).ToList();
            }


        }

        internal List<SA_MarketbyTypetonnes> GetTypetonnesWiseProductListwithCompare(string[] values)
        {
            var query = (from SA_MarketbyTypetonnes in _context.SA_MarketbyTypetonnes
                         where values.Contains(SA_MarketbyTypetonnes.Product.ToString())
                         select new { SA_MarketbyTypetonnes });

            List<SA_MarketbyTypetonnes> returnpro = new List<SA_MarketbyTypetonnes>();
            foreach (var item in query)
            {
                returnpro.Add(item.SA_MarketbyTypetonnes);
            }
            return returnpro;
        }

        public List<SA_MarketbyTypetonnes> GetTypetonnesWiseProductList(string ProductId)
        {
            if (ProductId != null)
            {
                int id = int.Parse(ProductId);

                return _context.SA_MarketbyTypetonnes.Where(Year => Year.Product == id).ToList();
            }
            else
            {
                int uniqueCategories = (from m in _context.SA_MarketbyTypetonnes
                                        join n in _context.SA_Product on
                                        m.Product equals n.id
                                        select (n.id)).FirstOrDefault();

                return _context.SA_MarketbyTypetonnes.Where(Year => Year.Product == uniqueCategories).ToList();
            }


        }

        internal List<SA_MarketbySalespercent> GetSalespercentWiseProductListwithCompare(string[] values)
        {
            var query = (from SA_MarketbySalespercent in _context.SA_MarketbySalespercent
                         where values.Contains(SA_MarketbySalespercent.Product.ToString())
                         select new { SA_MarketbySalespercent });

            List<SA_MarketbySalespercent> returnpro = new List<SA_MarketbySalespercent>();
            foreach (var item in query)
            {
                returnpro.Add(item.SA_MarketbySalespercent);
            }
            return returnpro;
        }

        public List<SA_MarketbySalespercent> GetSalespercentWiseProductList(string ProductId)

        {
            if (ProductId != null)
            {
                int id = int.Parse(ProductId);

                return _context.SA_MarketbySalespercent.Where(Year => Year.Product == id).ToList();
            }
            else
            {
                int uniqueCategories = (from m in _context.SA_MarketbySalespercent
                                        join n in _context.SA_Product on
                                        m.Product equals n.id
                                        select (n.id)).FirstOrDefault();

                return _context.SA_MarketbySalespercent.Where(Year => Year.Product == uniqueCategories).ToList();
            }


        }

        internal List<SA_MarketbySalestonnes> GetSalestonnesWiseProductListwithCompare(string[] values)
        {
            var query = (from SA_MarketbySalestonnes in _context.SA_MarketbySalestonnes
                         where values.Contains(SA_MarketbySalestonnes.Product.ToString())
                         select new { SA_MarketbySalestonnes });

            List<SA_MarketbySalestonnes> returnpro = new List<SA_MarketbySalestonnes>();
            foreach (var item in query)
            {
                returnpro.Add(item.SA_MarketbySalestonnes);
            }
            return returnpro;
        }

        public List<SA_MarketbySalestonnes> GetSalestonnesWiseProductList(string ProductId)
        {
            if (ProductId != null)
            {
                int id = int.Parse(ProductId);

                return _context.SA_MarketbySalestonnes.Where(Year => Year.Product == id).ToList();
            }
            else
            {
                int uniqueCategories = (from m in _context.SA_MarketbySalestonnes
                                        join n in _context.SA_Product on
                                        m.Product equals n.id
                                        select (n.id)).FirstOrDefault();

                return _context.SA_MarketbySalestonnes.Where(Year => Year.Product == uniqueCategories).ToList();
            }


        }

        internal List<SA_MarketbyGradepricing> GetGradepricingWiseProductListwithCompare(string[] values)
        {
            var query = (from SA_MarketbyGradepricing in _context.SA_MarketbyGradepricing
                         where values.Contains(SA_MarketbyGradepricing.Product.ToString())
                         select new { SA_MarketbyGradepricing });

            List<SA_MarketbyGradepricing> returnpro = new List<SA_MarketbyGradepricing>();
            foreach (var item in query)
            {
                returnpro.Add(item.SA_MarketbyGradepricing);
            }
            return returnpro;
        }

        public List<SA_MarketbyGradepricing> GetGradepricingWiseProductList(string ProductId)
        {
            if (ProductId != null)
            {
                int id = int.Parse(ProductId);

                return _context.SA_MarketbyGradepricing.Where(Year => Year.Product == id).ToList();
            }
            else
            {
                int uniqueCategories = (from m in _context.SA_MarketbyGradepricing
                                        join n in _context.SA_Product on
                                        m.Product equals n.id
                                        select (n.id)).FirstOrDefault();

                return _context.SA_MarketbyGradepricing.Where(Year => Year.Product == uniqueCategories).ToList();
            }


        }

        internal List<SA_MarketbyRegionpercent> GetRegionpercentWiseProductListwithCompare(string[] values)
        {
            var query = (from SA_MarketbyRegionpercent in _context.SA_MarketbyRegionpercent
                         where values.Contains(SA_MarketbyRegionpercent.Product.ToString())
                         select new { SA_MarketbyRegionpercent });

            List<SA_MarketbyRegionpercent> returnpro = new List<SA_MarketbyRegionpercent>();
            foreach (var item in query)
            {
                returnpro.Add(item.SA_MarketbyRegionpercent);
            }
            return returnpro;
        }

        public List<SA_MarketbyRegionpercent> GetRegionpercentWiseProductList(string ProductId)
        {
            if (ProductId != null)
            {
                int id = int.Parse(ProductId);

                return _context.SA_MarketbyRegionpercent.Where(Year => Year.Product == id).ToList();
            }
            else
            {
                int uniqueCategories = (from m in _context.SA_MarketbyRegionpercent
                                        join n in _context.SA_Product on
                                        m.Product equals n.id
                                        select (n.id)).FirstOrDefault();

                return _context.SA_MarketbyRegionpercent.Where(Year => Year.Product == uniqueCategories).ToList();
            }


        }

        internal List<SA_MarketbyRegiontonnes> GetRegiontonnesWiseProductListwithCompare(string[] values)
        {
            var query = (from SA_MarketbyRegiontonnes in _context.SA_MarketbyRegiontonnes
                         where values.Contains(SA_MarketbyRegiontonnes.Product.ToString())
                         select new { SA_MarketbyRegiontonnes });

            List<SA_MarketbyRegiontonnes> returnpro = new List<SA_MarketbyRegiontonnes>();
            foreach (var item in query)
            {
                returnpro.Add(item.SA_MarketbyRegiontonnes);
            }
            return returnpro;
        }

        public List<SA_MarketbyRegiontonnes> GetRegiontonnesWiseProductList(string ProductId)
        {
            if (ProductId != null)
            {
                int id = int.Parse(ProductId);

                return _context.SA_MarketbyRegiontonnes.Where(Year => Year.Product == id).ToList();
            }
            else
            {
                int uniqueCategories = (from m in _context.SA_MarketbyRegiontonnes
                                        join n in _context.SA_Product on
                                        m.Product equals n.id
                                        select (n.id)).FirstOrDefault();

                return _context.SA_MarketbyRegiontonnes.Where(Year => Year.Product == uniqueCategories).ToList();
            }


        }

        internal List<SA_MarketbyTradeExport> GetTradeExportWiseProductListwithCompare(string[] values)
        {
            var query = (from SA_MarketbyTradeExport in _context.SA_MarketbyTradeExport
                         where values.Contains(SA_MarketbyTradeExport.Product.ToString())
                         select new { SA_MarketbyTradeExport });

            List<SA_MarketbyTradeExport> returnpro = new List<SA_MarketbyTradeExport>();
            foreach (var item in query)
            {
                returnpro.Add(item.SA_MarketbyTradeExport);
            }
            return returnpro;
        }

        public List<SA_MarketbyTradeExport> GetTradeExportWiseProductList(string ProductId)
        {
            if (ProductId != null)
            {
                int id = int.Parse(ProductId);

                return _context.SA_MarketbyTradeExport.Where(Year => Year.Product == id).ToList();
            }
            else
            {
                int uniqueCategories = (from m in _context.SA_MarketbyTradeExport
                                        join n in _context.SA_Product on
                                        m.Product equals n.id
                                        select (n.id)).FirstOrDefault();

                return _context.SA_MarketbyTradeExport.Where(Year => Year.Product == uniqueCategories).ToList();
            }


        }

        internal List<SA_MarketbyTradeImport> GetTradeImportWiseProductListwithCompare(string[] values)
        {
            var query = (from SA_MarketbyTradeImport in _context.SA_MarketbyTradeImport
                         where values.Contains(SA_MarketbyTradeImport.Product.ToString())
                         select new { SA_MarketbyTradeImport });

            List<SA_MarketbyTradeImport> returnpro = new List<SA_MarketbyTradeImport>();
            foreach (var item in query)
            {
                returnpro.Add(item.SA_MarketbyTradeImport);
            }
            return returnpro;
        }

        public List<SA_MarketbyTradeImport> GetTradeImportWiseProductList(string ProductId)
        {
            if (ProductId != null)
            {
                int id = int.Parse(ProductId);

                return _context.SA_MarketbyTradeImport.Where(Year => Year.Product == id).ToList();
            }
            else
            {
                int uniqueCategories = (from m in _context.SA_MarketbyTradeImport
                                        join n in _context.SA_Product on
                                        m.Product equals n.id
                                        select (n.id)).FirstOrDefault();

                return _context.SA_MarketbyTradeImport.Where(Year => Year.Product == uniqueCategories).ToList();
            }


        }

        internal List<SA_MarketbyDemandsupplyGraph> GetDemandsupplyWiseProductListwithCompare(string[] values)
        {
            var query = (from SA_MarketbyDemandsupplyGraph in _context.SA_MarketbyDemandsupplyGraph
                         where values.Contains(SA_MarketbyDemandsupplyGraph.Product.ToString())
                         select new { SA_MarketbyDemandsupplyGraph });

            List<SA_MarketbyDemandsupplyGraph> returnpro = new List<SA_MarketbyDemandsupplyGraph>();
            foreach (var item in query)
            {
                returnpro.Add(item.SA_MarketbyDemandsupplyGraph);
            }
            return returnpro;
        }

        public List<SA_MarketbyDemandsupply> GetDemandsupplyWiseProductList(string ProductId)
        {
            if (ProductId != null)
            {
                int id = int.Parse(ProductId);

                return _context.SA_MarketbyDemandsupply.Where(Year => Year.Product == id).ToList();
            }
            else
            {
                int uniqueCategories = (from m in _context.SA_MarketbyDemandsupply
                                        join n in _context.SA_Product on
                                        m.Product equals n.id
                                        select (n.id)).FirstOrDefault();

                return _context.SA_MarketbyDemandsupply.Where(Year => Year.Product == uniqueCategories).ToList();
            }


        }

        public List<SA_MarketbyDemandsupplyGraph> GetDemandsupplyGraphWiseProductList(string ProductId)
        {
            if (ProductId != null)
            {
                int id = int.Parse(ProductId);

                return _context.SA_MarketbyDemandsupplyGraph.Where(Year => Year.Product == id).ToList();
            }
            else
            {
                int uniqueCategories = (from m in _context.SA_MarketbyDemandsupplyGraph
                                        join n in _context.SA_Product on
                                        m.Product equals n.id
                                        select (n.id)).FirstOrDefault();

                return _context.SA_MarketbyDemandsupplyGraph.Where(Year => Year.Product == uniqueCategories).ToList();
            }


        }

        internal List<SA_MarketbyCompanySharepercent> GetCompanySharepercentWiseProductListwithCompare(string[] values)
        {
            var query = (from SA_MarketbyCompanySharepercent in _context.SA_MarketbyCompanySharepercent
                         where values.Contains(SA_MarketbyCompanySharepercent.Product.ToString())
                         select new { SA_MarketbyCompanySharepercent });

            List<SA_MarketbyCompanySharepercent> returnpro = new List<SA_MarketbyCompanySharepercent>();
            foreach (var item in query)
            {
                returnpro.Add(item.SA_MarketbyCompanySharepercent);
            }
            return returnpro;
        }

        public List<SA_MarketbyCompanySharepercent> GetCompanySharepercentWiseProductList(string ProductId)
        {
            if (ProductId != null)
            {
                int id = int.Parse(ProductId);

                return _context.SA_MarketbyCompanySharepercent.Where(Year => Year.Product == id).ToList();
            }
            else
            {
                int uniqueCategories = (from m in _context.SA_MarketbyCompanySharepercent
                                        join n in _context.SA_Product on
                                        m.Product equals n.id
                                        select (n.id)).FirstOrDefault();

                return _context.SA_MarketbyCompanySharepercent.Where(Year => Year.Product == uniqueCategories).ToList();
            }


        }

        internal List<SA_MarketbyCompanySharetonnes> GetCompanySharetonnesWiseProductListwithCompare(string[] values)
        {
            var query = (from SA_MarketbyCompanySharetonnes in _context.SA_MarketbyCompanySharetonnes
                         where values.Contains(SA_MarketbyCompanySharetonnes.Product.ToString())
                         select new { SA_MarketbyCompanySharetonnes });

            List<SA_MarketbyCompanySharetonnes> returnpro = new List<SA_MarketbyCompanySharetonnes>();
            foreach (var item in query)
            {
                returnpro.Add(item.SA_MarketbyCompanySharetonnes);
            }
            return returnpro;
        }

        public List<SA_MarketbyCompanySharetonnes> GetCompanySharetonnesWiseProductList(string ProductId)
        {
            if (ProductId != null)
            {
                int id = int.Parse(ProductId);

                return _context.SA_MarketbyCompanySharetonnes.Where(Year => Year.Product == id).ToList();
            }
            else
            {
                int uniqueCategories = (from m in _context.SA_MarketbyCompanySharetonnes
                                        join n in _context.SA_Product on
                                        m.Product equals n.id
                                        select (n.id)).FirstOrDefault();

                return _context.SA_MarketbyCompanySharetonnes.Where(Year => Year.Product == uniqueCategories).ToList();
            }


        }
    }
}