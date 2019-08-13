using ChemAnalyst.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.SqlServer;
using System.Globalization;
using System.Linq;
using System.Web;

namespace ChemAnalyst.DAL
{
    public class ChemicalPricing
    {

        private ChemAnalystContext _context = new ChemAnalystContext();
        public List<SA_Chem1PriceWeekly> GetChem1WeekWise(string product, string year)
        {

            int id = int.Parse(product);


            var data = (_context.SA_Chem1PriceWeekly.Where(Year => Year.Product == id && Year.year
            == year)).ToList()
                .Select(x => new
                {
                    ProductVariant = x.ProductVariant,
                    //Week = x.Week + " ("+ Convert.ToDateTime( x.Date).ToString("dd MMM yy")+")",
                    Week = "(" + Convert.ToDateTime(x.Date).ToString("dd MMM yy") + ")",
                    count = x.count,
                    Discription = x.Type,
                    Product = x.Product

                });

            var query = from d in data
                            //where d.Product == id && d.year == DateTime.Now.Year.ToString() && d.Month.ToUpper() == monthname

                        group d by new { d.Week, d.ProductVariant } into g
                        from SalesHeaderAndDetail in g.DefaultIfEmpty()
                        group SalesHeaderAndDetail by new
                        {
                            // SalesOrderId=SalesHeaderAndDetail.SalesOrderId,
                            Week = SalesHeaderAndDetail.Week,
                            ProductVariant = SalesHeaderAndDetail.ProductVariant,
                            Product = SalesHeaderAndDetail.Product
                        }
                        into grouped
                        select new SA_Chem1PriceWeekly
                        {
                            Week = grouped.Key.Week.ToString(),
                            count = grouped.Sum(x => x.count),

                            Product = grouped.Key.Product,
                            ProductVariant = grouped.Key.ProductVariant.ToString(),
                        };


            var sp = query.ToList();
            return query.ToList();



        }

        public List<SA_Chem2PriceWeekly> GetChem2WeekWise(string currentYear, string currentMonth, string currentWeek)
        {

            try
            {
                if (currentWeek == "1")
                {
                    return _context.SA_Chem2PriceWeekly.ToList().Where(w => w.year == currentYear && w.Month.ToLower() == currentMonth.ToLower() && Convert.ToInt32(w.day) <= 7).ToList();
                }
                else if (currentWeek == "2")
                {
                    return _context.SA_Chem2PriceWeekly.ToList().Where(w => w.year == currentYear && w.Month.ToLower() == currentMonth.ToLower() && (Convert.ToInt32(w.day) > 7 && Convert.ToInt32(w.day) <= 14)).ToList();
                }
                else if (currentWeek == "3")
                {
                    return _context.SA_Chem2PriceWeekly.ToList().Where(w => w.year == currentYear && w.Month.ToLower() == currentMonth.ToLower() && (Convert.ToInt32(w.day) > 14 && Convert.ToInt32(w.day) <= 21)).ToList();
                }
                else if (currentWeek == "4")
                {
                    return _context.SA_Chem2PriceWeekly.ToList().Where(w => w.year == currentYear && w.Month.ToLower() == currentMonth.ToLower() && (Convert.ToInt32(w.day) > 21 && Convert.ToInt32(w.day) <= 28)).ToList();
                }
                else
                {
                    return _context.SA_Chem2PriceWeekly.ToList().Where(w => w.year == currentYear && w.Month.ToLower() == currentMonth.ToLower() && Convert.ToInt32(w.day) > 28).ToList();
                }

            }
            catch (Exception ex)
            {

                throw;
            }



        }

        public List<SA_Chem3PriceWeekly> GetChem3WeekWise(string currentYear, string currentMonth, string currentWeek)
        {

            try
            {
                if (currentWeek == "1")
                {
                    return _context.SA_Chem3PriceWeekly.ToList().Where(w => w.year == currentYear && w.Month.ToLower() == currentMonth.ToLower() && Convert.ToInt32(w.day) <= 7).ToList();
                }
                else if (currentWeek == "2")
                {
                    return _context.SA_Chem3PriceWeekly.ToList().Where(w => w.year == currentYear && w.Month.ToLower() == currentMonth.ToLower() && (Convert.ToInt32(w.day) > 7 && Convert.ToInt32(w.day) <= 14)).ToList();
                }
                else if (currentWeek == "3")
                {
                    return _context.SA_Chem3PriceWeekly.ToList().Where(w => w.year == currentYear && w.Month.ToLower() == currentMonth.ToLower() && (Convert.ToInt32(w.day) > 14 && Convert.ToInt32(w.day) <= 21)).ToList();
                }
                else if (currentWeek == "4")
                {
                    return _context.SA_Chem3PriceWeekly.ToList().Where(w => w.year == currentYear && w.Month.ToLower() == currentMonth.ToLower() && (Convert.ToInt32(w.day) > 21 && Convert.ToInt32(w.day) <= 28)).ToList();
                }
                else
                {
                    return _context.SA_Chem3PriceWeekly.ToList().Where(w => w.year == currentYear && w.Month.ToLower() == currentMonth.ToLower() && Convert.ToInt32(w.day) > 28).ToList();
                }

            }
            catch (Exception ex)
            {

                throw;
            }



        }

        public List<SA_Chem4PriceWeekly> GetChem4WeekWise(string currentYear, string currentMonth, string currentWeek)
        {

            try
            {
                if (currentWeek == "1")
                {
                    return _context.SA_Chem4PriceWeekly.ToList().Where(w => w.year == currentYear && w.Month.ToLower() == currentMonth.ToLower() && Convert.ToInt32(w.day) <= 7).ToList();
                }
                else if (currentWeek == "2")
                {
                    return _context.SA_Chem4PriceWeekly.ToList().Where(w => w.year == currentYear && w.Month.ToLower() == currentMonth.ToLower() && (Convert.ToInt32(w.day) > 7 && Convert.ToInt32(w.day) <= 14)).ToList();
                }
                else if (currentWeek == "3")
                {
                    return _context.SA_Chem4PriceWeekly.ToList().Where(w => w.year == currentYear && w.Month.ToLower() == currentMonth.ToLower() && (Convert.ToInt32(w.day) > 14 && Convert.ToInt32(w.day) <= 21)).ToList();
                }
                else if (currentWeek == "4")
                {
                    return _context.SA_Chem4PriceWeekly.ToList().Where(w => w.year == currentYear && w.Month.ToLower() == currentMonth.ToLower() && (Convert.ToInt32(w.day) > 21 && Convert.ToInt32(w.day) <= 28)).ToList();
                }
                else
                {
                    return _context.SA_Chem4PriceWeekly.ToList().Where(w => w.year == currentYear && w.Month.ToLower() == currentMonth.ToLower() && Convert.ToInt32(w.day) > 28).ToList();
                }

            }
            catch (Exception ex)
            {

                throw;
            }



        }

        public List<SA_Chem5PriceWeekly> GetChem5WeekWise(string currentYear, string currentMonth, string currentWeek)
        {

            try
            {
                if (currentWeek == "1")
                {
                    return _context.SA_Chem5PriceWeekly.ToList().Where(w => w.year == currentYear && w.Month.ToLower() == currentMonth.ToLower() && Convert.ToInt32(w.day) <= 7).ToList();
                }
                else if (currentWeek == "2")
                {
                    return _context.SA_Chem5PriceWeekly.ToList().Where(w => w.year == currentYear && w.Month.ToLower() == currentMonth.ToLower() && (Convert.ToInt32(w.day) > 7 && Convert.ToInt32(w.day) <= 14)).ToList();
                }
                else if (currentWeek == "3")
                {
                    return _context.SA_Chem5PriceWeekly.ToList().Where(w => w.year == currentYear && w.Month.ToLower() == currentMonth.ToLower() && (Convert.ToInt32(w.day) > 14 && Convert.ToInt32(w.day) <= 21)).ToList();
                }
                else if (currentWeek == "4")
                {
                    return _context.SA_Chem5PriceWeekly.ToList().Where(w => w.year == currentYear && w.Month.ToLower() == currentMonth.ToLower() && (Convert.ToInt32(w.day) > 21 && Convert.ToInt32(w.day) <= 28)).ToList();
                }
                else
                {
                    return _context.SA_Chem5PriceWeekly.ToList().Where(w => w.year == currentYear && w.Month.ToLower() == currentMonth.ToLower() && Convert.ToInt32(w.day) > 28).ToList();
                }

            }
            catch (Exception ex)
            {

                throw;
            }



        }

        public List<SA_Chem6PriceWeekly> GetChem6WeekWise(string currentYear, string currentMonth, string currentWeek)
        {

            try
            {
                if (currentWeek == "1")
                {
                    return _context.SA_Chem6PriceWeekly.ToList().Where(w => w.year == currentYear && w.Month.ToLower() == currentMonth.ToLower() && Convert.ToInt32(w.day) <= 7).ToList();
                }
                else if (currentWeek == "2")
                {
                    return _context.SA_Chem6PriceWeekly.ToList().Where(w => w.year == currentYear && w.Month.ToLower() == currentMonth.ToLower() && (Convert.ToInt32(w.day) > 7 && Convert.ToInt32(w.day) <= 14)).ToList();
                }
                else if (currentWeek == "3")
                {
                    return _context.SA_Chem6PriceWeekly.ToList().Where(w => w.year == currentYear && w.Month.ToLower() == currentMonth.ToLower() && (Convert.ToInt32(w.day) > 14 && Convert.ToInt32(w.day) <= 21)).ToList();
                }
                else if (currentWeek == "4")
                {
                    return _context.SA_Chem6PriceWeekly.ToList().Where(w => w.year == currentYear && w.Month.ToLower() == currentMonth.ToLower() && (Convert.ToInt32(w.day) > 21 && Convert.ToInt32(w.day) <= 28)).ToList();
                }
                else
                {
                    return _context.SA_Chem6PriceWeekly.ToList().Where(w => w.year == currentYear && w.Month.ToLower() == currentMonth.ToLower() && Convert.ToInt32(w.day) > 28).ToList();
                }

            }
            catch (Exception ex)
            {

                throw;
            }



        }

        public List<SA_ChemPriceYearly> GetYearWiseProductList(string ProductId, string MaxValue, string fromdate, string todate)
        {


            var q = _context.SA_ChemPriceYearly.ToList().AsQueryable();


            if (ProductId != null)
            {
                int id = int.Parse(ProductId);
                q = q.Where(Year => Year.Product == id);
            }
            else
            {
                int uniqueCategories = (from m in _context.SA_ChemPriceYearly
                                        join n in _context.SA_Product on
                                        m.Product equals n.id
                                        select (n.id)).FirstOrDefault();

                q = q.Where(Year => Year.Product == uniqueCategories);
            }

            if (!string.IsNullOrEmpty(fromdate) && !string.IsNullOrEmpty(todate))
            {

                int fromyear = Convert.ToDateTime(fromdate).Year;
                int toyear = Convert.ToDateTime(todate).Year;

                q = q.Where(Year => Convert.ToInt16(Year.year) >= fromyear
                        && Convert.ToInt16(Year.year) <= toyear);
            }
            if (MaxValue != null)
            {
                int MaxYear = Convert.ToInt32(MaxValue);
                q = q.Where(Year => Convert.ToInt32(Year.year) <= MaxYear);
            }
            return q.ToList();
            //if (ProductId != null)
            //{
            //    int id = int.Parse(ProductId);
            //    if (MaxValue != null)
            //    {
            //        int MaxYear = Convert.ToInt32(MaxValue);
            //        return _context.SA_ChemPriceYearly.ToList().
            //            Where(Year => Year.Product == id && Convert.ToInt32(Year.year) <= MaxYear
            //            && Convert.ToInt16(Year.year) >= fromyear
            //            && Convert.ToInt16(Year.year) <= toyear
            //            ).ToList();
            //    }
            //    else
            //    {
            //        return _context.SA_ChemPriceYearly.Where(Year => Year.Product == id

            //            ).ToList().Where(x => Convert.ToInt16(x.year) >= fromyear
            //           && Convert.ToInt16(x.year) <= toyear).ToList(); ;
            //    }

            //}
            //else
            //{
            //    //var uniqueCategories = _context.SA_ChemPriceYearly
            //    //                  .Select(p => p.Product)
            //    //                  .Distinct().FirstOrDefault();
            //    int uniqueCategories = (from m in _context.SA_ChemPriceYearly
            //                            join n in _context.SA_Product on
            //                            m.Product equals n.id
            //                            select (n.id)).FirstOrDefault();

            //    return _context.SA_ChemPriceYearly.Where(Year => Year.Product == uniqueCategories


            //            ).ToList().Where(x => Convert.ToInt16(x.year) >= fromyear
            //           && Convert.ToInt16(x.year) <= toyear).ToList();
            //    // return _context.SA_ChemPriceYearly.ToList();
            //}


        }

        public List<SA_ChemPriceYearly> GetYearWiseProductListFirstLastValues(string ProductId)
        {
            if (ProductId != null)
            {
                int id = int.Parse(ProductId);

                return _context.SA_ChemPriceYearly.Where(Year => Year.Product == id).ToList();
            }
            else
            {
                int uniqueCategories = (from m in _context.SA_ChemPriceYearly
                                        join n in _context.SA_Product on
                                        m.Product equals n.id
                                        select (n.id)).FirstOrDefault();

                return _context.SA_ChemPriceYearly.Where(Year => Year.Product == uniqueCategories).ToList();
            }


        }


        public int GetctegotyBYproduct(int ProductId)
        {

            SA_Product obj = _context.SA_Product.Where(product => product.id == ProductId).FirstOrDefault();
            if (ProductId > 0)
                return (int)obj.Category;
            else
                return 0;



        }

        internal List<SA_ChemPriceMonthly> GetMonthlyWiseProductList(string ProductId)
        {
            if (ProductId != null)
            {
                int id = int.Parse(ProductId);
                return _context.SA_ChemPriceMonthly.Where(month => month.Product == id).ToList();
            }
            return _context.SA_ChemPriceMonthly.ToList();
        }

        internal List<SA_ChemPriceMonthly> GetMonthlyWiseProductList1(string ProductId, string fromdate, string todate)
        {
            //if (ProductId != null)
            //{
            //    int id = int.Parse(ProductId);
            //    return _context.SA_ChemPriceMonthly.Where(month => month.Product == id).ToList();
            //}
            //return _context.SA_ChemPriceMonthly.ToList();
            var data = _context.SA_ChemPriceMonthly.ToList()
                .Select(x => new
                {
                    Product = x.Product,
                    ProductVariant = x.ProductVariant,
                    year = x.year,
                    Month = x.Month,
                    count = x.count,
                    Date = x.Month + " 01 " + x.year,
                    Discription = x.Discription,
                }).AsEnumerable();

            data = data.Where(month => Convert.ToDateTime(month.Date) >= Convert.ToDateTime(fromdate));
            data = data.Where(month => Convert.ToDateTime(month.Date) <= Convert.ToDateTime(todate));
            if (!string.IsNullOrEmpty(ProductId))
            {
                int id = int.Parse(ProductId);
                data = data.Where(month => month.Product == id).ToList();
            }

            var query = from d in data
                            //where d.Product == id && d.year == DateTime.Now.Year.ToString() && d.Month.ToUpper() == monthname

                        group d by new { d.year, d.Month } into g
                        from SalesHeaderAndDetail in g.DefaultIfEmpty()
                        group SalesHeaderAndDetail by new
                        {
                            // SalesOrderId=SalesHeaderAndDetail.SalesOrderId,
                            year = SalesHeaderAndDetail.year,
                            Month = SalesHeaderAndDetail.Month,
                            Product = SalesHeaderAndDetail.Product,
                            ProductVariant = SalesHeaderAndDetail.ProductVariant


                        }
                         into grouped
                        select new SA_ChemPriceMonthly
                        {
                            Product = grouped.Key.Product,
                            ProductVariant = grouped.Key.ProductVariant.ToString(),
                            year = grouped.Key.year.ToString(),
                            Month = grouped.Key.Month.ToString(),
                            count = grouped.Sum(x => x.count),
                            Discription = grouped.FirstOrDefault().Discription.ToString(),


                        };



            var ss = query.ToList();
            //return query.OrderByDescending(x => Convert.ToDateTime("01 " + x.Month + " " + x.year)).ToList();
            return query.OrderBy(x => Convert.ToDateTime("01 " + x.Month + " " + x.year)).ToList();





        }

        internal List<SA_ChemPriceQuarterly> GetQuarterWiseProductList(string ProductId, string year)
        {
            if (ProductId != null)
            {
                int id = int.Parse(ProductId);
                return _context.SA_ChemPriceQuarterly.Where(quater => quater.Product == id && quater.year == year).ToList();
            }
            return _context.SA_ChemPriceQuarterly.ToList();
        }

        internal int CheckExistingdata(string Filename, string ImportType)
        {
            int x = 0;
            if (ImportType == "Yearly")
            {

                List<SA_ChemPriceYearly> obj = _context.SA_ChemPriceYearly.Where(Year => Year.FileName == Filename).ToList();
                foreach (SA_ChemPriceYearly PriceYearly in obj)
                {
                    _context.Entry(PriceYearly).State = EntityState.Deleted;
                    x = _context.SaveChanges();

                }
            }
            else if (ImportType == "Monthly")
            {
                List<SA_ChemPriceMonthly> obj = _context.SA_ChemPriceMonthly.Where(Year => Year.FileName == Filename).ToList();
                foreach (SA_ChemPriceMonthly PriceYearly in obj)
                {
                    _context.Entry(PriceYearly).State = EntityState.Deleted;
                    x = _context.SaveChanges();

                }
            }
            else if (ImportType == "Quarterly")
            {
                List<SA_ChemPriceQuarterly> obj = _context.SA_ChemPriceQuarterly.Where(Year => Year.FileName == Filename).ToList();
                foreach (SA_ChemPriceQuarterly PriceYearly in obj)
                {
                    _context.Entry(PriceYearly).State = EntityState.Deleted;
                    x = _context.SaveChanges();

                }
            }
            else if (ImportType == "Daily Retail")
            {
                List<SA_ChemPriceDaily> obj = _context.SA_ChemPriceDaily.Where(Year => Year.FileName == Filename).ToList();
                foreach (SA_ChemPriceDaily PriceYearly in obj)
                {
                    _context.Entry(PriceYearly).State = EntityState.Deleted;
                    x = _context.SaveChanges();

                }
            }
            else if (ImportType == "Daily Bulk")
            {
                List<SA_ChemPriceDailyAverage> obj = _context.SA_ChemPriceDailyAverage.Where(Year => Year.FileName == Filename).ToList();
                foreach (SA_ChemPriceDailyAverage PriceYearly in obj)
                {
                    _context.Entry(PriceYearly).State = EntityState.Deleted;
                    x = _context.SaveChanges();

                }
            }
            else if (ImportType == "Chemical 1")
            {
                List<SA_Chem1PriceWeekly> obj = _context.SA_Chem1PriceWeekly.ToList();
                foreach (SA_Chem1PriceWeekly PriceYearly in obj)
                {
                    _context.Entry(PriceYearly).State = EntityState.Deleted;
                    x = _context.SaveChanges();

                }
            }
            else if (ImportType == "Chemical 2")
            {
                List<SA_Chem2PriceWeekly> obj = _context.SA_Chem2PriceWeekly.ToList();
                foreach (SA_Chem2PriceWeekly PriceYearly in obj)
                {
                    _context.Entry(PriceYearly).State = EntityState.Deleted;
                    x = _context.SaveChanges();

                }
            }
            else if (ImportType == "Chemical 3")
            {
                List<SA_Chem3PriceWeekly> obj = _context.SA_Chem3PriceWeekly.ToList();
                foreach (SA_Chem3PriceWeekly PriceYearly in obj)
                {
                    _context.Entry(PriceYearly).State = EntityState.Deleted;
                    x = _context.SaveChanges();

                }
            }
            else if (ImportType == "Chemical 4")
            {
                List<SA_Chem4PriceWeekly> obj = _context.SA_Chem4PriceWeekly.ToList();
                foreach (SA_Chem4PriceWeekly PriceYearly in obj)
                {
                    _context.Entry(PriceYearly).State = EntityState.Deleted;
                    x = _context.SaveChanges();

                }
            }
            else if (ImportType == "Chemical 5")
            {
                List<SA_Chem5PriceWeekly> obj = _context.SA_Chem5PriceWeekly.ToList();
                foreach (SA_Chem5PriceWeekly PriceYearly in obj)
                {
                    _context.Entry(PriceYearly).State = EntityState.Deleted;
                    x = _context.SaveChanges();

                }
            }
            else if (ImportType == "Chemical 6")
            {
                List<SA_Chem6PriceWeekly> obj = _context.SA_Chem6PriceWeekly.ToList();
                foreach (SA_Chem6PriceWeekly PriceYearly in obj)
                {
                    _context.Entry(PriceYearly).State = EntityState.Deleted;
                    x = _context.SaveChanges();

                }
            }



            return x;

        }
        internal int CheckFileuploadStatus(string Filename, string ImportType)
        {
            int x = 0;

            if (ImportType == "Yearly")
            {

                List<SA_ChemPriceYearly> obj = _context.SA_ChemPriceYearly.Where(Year => Year.FileName == Filename).ToList();
                if (obj.Count() > 0)
                {
                    return 1;
                }
                else
                    return 0;
            }
            else if (ImportType == "Monthly")
            {
                List<SA_ChemPriceMonthly> obj = _context.SA_ChemPriceMonthly.Where(Year => Year.FileName == Filename).ToList();
                if (obj.Count() > 0)
                {
                    return 1;
                }
                else
                    return 0;
            }
            else if (ImportType == "Quarterly")
            {
                List<SA_ChemPriceQuarterly> obj = _context.SA_ChemPriceQuarterly.Where(Year => Year.FileName == Filename).ToList();
                if (obj.Count() > 0)
                {
                    return 1;
                }
                else
                    return 0;
            }
            else if (ImportType == "Daily Retail")
            {
                List<SA_ChemPriceDaily> obj = _context.SA_ChemPriceDaily.Where(Year => Year.FileName == Filename).ToList();
                if (obj.Count() > 0)
                {
                    return 1;
                }
                else
                    return 0;
            }
            else if (ImportType == "Daily Bulk")
            {
                List<SA_ChemPriceDailyAverage> obj = _context.SA_ChemPriceDailyAverage.Where(Year => Year.FileName == Filename).ToList();
                if (obj.Count() > 0)
                {
                    return 1;
                }
                else
                    return 0;
            }
            else if (ImportType == "Chemical 1")
            {
                List<SA_Chem1PriceWeekly> obj = _context.SA_Chem1PriceWeekly.Where(Year => Year.FileName == Filename).ToList();
                if (obj.Count() > 0)
                {
                    return 1;
                }
                else
                    return 0;
            }
            else if (ImportType == "Chemical 2")
            {
                List<SA_Chem2PriceWeekly> obj = _context.SA_Chem2PriceWeekly.Where(Year => Year.FileName == Filename).ToList();
                if (obj.Count() > 0)
                {
                    return 1;
                }
                else
                    return 0;
            }
            else if (ImportType == "Chemical 3")
            {
                List<SA_Chem3PriceWeekly> obj = _context.SA_Chem3PriceWeekly.Where(Year => Year.FileName == Filename).ToList();
                if (obj.Count() > 0)
                {
                    return 1;
                }
                else
                    return 0;
            }
            else if (ImportType == "Chemical 4")
            {
                List<SA_Chem4PriceWeekly> obj = _context.SA_Chem4PriceWeekly.Where(Year => Year.FileName == Filename).ToList();
                if (obj.Count() > 0)
                {
                    return 1;
                }
                else
                    return 0;
            }
            else if (ImportType == "Chemical 5")
            {
                List<SA_Chem5PriceWeekly> obj = _context.SA_Chem5PriceWeekly.Where(Year => Year.FileName == Filename).ToList();
                if (obj.Count() > 0)
                {
                    return 1;
                }
                else
                    return 0;
            }
            else if (ImportType == "Chemical 6")
            {
                List<SA_Chem6PriceWeekly> obj = _context.SA_Chem6PriceWeekly.Where(Year => Year.FileName == Filename).ToList();
                if (obj.Count() > 0)
                {
                    return 1;
                }
                else
                    return 0;
            }
            return 0;
        }
        internal List<SA_ChemPriceDaily> GetDailyWiseProductList(string product, string fromdate, string todate)
        {
            int id = int.Parse(product);
            // string monthname = DateTime.Now.ToMonthName().ToUpper();

            var result = (_context.SA_ChemPriceDaily.Where(Year => Year.Product == id)).ToList().Where(x =>
            Convert.ToDateTime(x.Month + " " + x.day + " " + x.year) >= Convert.ToDateTime(fromdate)
            && Convert.ToDateTime(x.Month + " " + x.day + " " + x.year) <= Convert.ToDateTime(todate)

            ).OrderBy(x => Convert.ToDateTime(x.Month + " " + x.day + " " + x.year)).ToList();

            return (result);


        }

        internal List<SA_ChemPriceYearly> GetYearWiseProductListwithCompare(string[] values)
        {
            //return _context.SA_ChemPriceYearly.Where(Year => Year.Product;
            var query = (from ChemPriceYearly in _context.SA_ChemPriceYearly
                         where values.Contains(ChemPriceYearly.Product.ToString())
                         select new { ChemPriceYearly });

            List<SA_ChemPriceYearly> returnpro = new List<SA_ChemPriceYearly>();
            foreach (var item in query)
            {
                returnpro.Add(item.ChemPriceYearly);
            }
            return returnpro;
        }

        internal List<SA_ChemPriceYearly> GetYearWiseProductListwithCompareUser(string[] values, int CustId)
        {
            //return _context.SA_ChemPriceYearly.Where(Year => Year.Product;
            var query = (from ChemPriceYearly in _context.SA_ChemPriceYearly
                         join cust in _context.CustProduct on ChemPriceYearly.id equals cust.ProdId
                         where values.Contains(ChemPriceYearly.Product.ToString()) && cust.id == CustId
                         select new { ChemPriceYearly });

            List<SA_ChemPriceYearly> returnpro = new List<SA_ChemPriceYearly>();
            foreach (var item in query)
            {
                returnpro.Add(item.ChemPriceYearly);
            }
            return returnpro;
        }

        internal List<SA_ChemPriceMonthly> GetMonthWiseProductListwithCompare(string[] values)
        {
            var query = (from ChemPricemonthly in _context.SA_ChemPriceMonthly
                         where values.Contains(ChemPricemonthly.Product.ToString())
                         select new { ChemPricemonthly });

            List<SA_ChemPriceMonthly> returnpro = new List<SA_ChemPriceMonthly>();
            foreach (var item in query)
            {
                returnpro.Add(item.ChemPricemonthly);
            }
            return returnpro;
        }
        internal List<SA_ChemPriceMonthly> GetMonthWiseProductListwithCompareUser(string[] values, int CustId)
        {
            var query = (from ChemPricemonthly in _context.SA_ChemPriceMonthly
                         join cust in _context.CustProduct on ChemPricemonthly.id equals cust.ProdId
                         where cust.id == CustId && values.Contains(ChemPricemonthly.Product.ToString())
                         select new { ChemPricemonthly });

            List<SA_ChemPriceMonthly> returnpro = new List<SA_ChemPriceMonthly>();
            foreach (var item in query)
            {
                returnpro.Add(item.ChemPricemonthly);
            }
            return returnpro;
        }

        internal List<SA_ChemPriceQuarterly> GetQuarterWiseProductListwithCompare(string[] values, int CustId)
        {
            var query = (from ChemPricemonthly in _context.SA_ChemPriceQuarterly
                         join cust in _context.CustProduct on ChemPricemonthly.id equals cust.ProdId
                         where cust.id == CustId && values.Contains(ChemPricemonthly.Product.ToString())
                         select new { ChemPricemonthly });

            List<SA_ChemPriceQuarterly> returnpro = new List<SA_ChemPriceQuarterly>();
            foreach (var item in query)
            {
                returnpro.Add(item.ChemPricemonthly);
            }
            return returnpro;
        }

        //internal List<SA_ChemPriceDaily> GetDailyWiseProductListwithCompare(string[] values)
        //{
        //    var query = (from SA_ChemPriceDaily in _context.SA_ChemPriceDaily
        //                 where values.Contains(SA_ChemPriceDaily.Product.ToString())
        //                 select new { SA_ChemPriceDaily });

        //    List<SA_ChemPriceDaily> returnpro = new List<SA_ChemPriceDaily>();
        //    foreach (var item in query)
        //    {
        //        returnpro.Add(item.SA_ChemPriceDaily);
        //    }
        //    return returnpro;
        //}

        internal List<SA_ChemPriceQuarterly> GetQuarterWiseProductListwithCompare(string[] values)
        {
            var query = (from ChemPricemonthly in _context.SA_ChemPriceQuarterly
                         where values.Contains(ChemPricemonthly.Product.ToString())
                         select new { ChemPricemonthly });

            List<SA_ChemPriceQuarterly> returnpro = new List<SA_ChemPriceQuarterly>();
            foreach (var item in query)
            {
                returnpro.Add(item.ChemPricemonthly);
            }
            return returnpro;
        }

        internal List<SA_ChemPriceDaily> GetDailyWiseProductListwithCompare(string[] values)
        {
            var query = (from SA_ChemPriceDaily in _context.SA_ChemPriceDaily
                         where values.Contains(SA_ChemPriceDaily.Product.ToString())
                         select new { SA_ChemPriceDaily });

            List<SA_ChemPriceDaily> returnpro = new List<SA_ChemPriceDaily>();
            foreach (var item in query)
            {
                returnpro.Add(item.SA_ChemPriceDaily);
            }
            return returnpro;
        }
        internal List<SA_ChemPriceDailyAverage> GetDailyAverageWiseProductListwithCompare(string[] values)
        {
            var query = (from SA_ChemPriceDailyAverage in _context.SA_ChemPriceDailyAverage
                         where values.Contains(SA_ChemPriceDailyAverage.Product.ToString())
                         select new { SA_ChemPriceDailyAverage });

            List<SA_ChemPriceDailyAverage> returnpro = new List<SA_ChemPriceDailyAverage>();
            foreach (var item in query)
            {
                returnpro.Add(item.SA_ChemPriceDailyAverage);
            }
            return returnpro;
        }

        internal List<SA_ChemPriceWeekly> GetWeeklyWiseProductList(string product, string year)
        {
            int id = int.Parse(product);


            var data = (_context.SA_ChemPriceWeeklyNew.Where(Year => Year.Product == id && Year.year
            == year)).ToList()
                .Select(x => new
                {
                    ProductVariant = x.ProductVariant,
                    //Week = x.Week + " ("+ Convert.ToDateTime( x.Date).ToString("dd MMM yy")+")",
                    Week = "(" + Convert.ToDateTime(x.Date).ToString("dd MMM yy") + ")",
                    count = x.count,
                    Discription = x.Type,
                    Product = x.Product

                });

            var query = from d in data
                            //where d.Product == id && d.year == DateTime.Now.Year.ToString() && d.Month.ToUpper() == monthname

                        group d by new { d.Week, d.ProductVariant } into g
                        from SalesHeaderAndDetail in g.DefaultIfEmpty()
                        group SalesHeaderAndDetail by new
                        {
                            // SalesOrderId=SalesHeaderAndDetail.SalesOrderId,
                            Week = SalesHeaderAndDetail.Week,
                            ProductVariant = SalesHeaderAndDetail.ProductVariant,
                            Product = SalesHeaderAndDetail.Product
                        }
                        into grouped
                        select new SA_ChemPriceWeekly
                        {
                            Week = grouped.Key.Week.ToString(),
                            count = grouped.Sum(x => x.count),
                            Discription = grouped.FirstOrDefault().Discription.ToString(),
                            Product = grouped.Key.Product,
                            ProductVariant = grouped.Key.ProductVariant.ToString(),
                        };


            var ss = query.ToList();
            return query.ToList();

        }



        internal List<SA_ChemPriceWeekly> SA_Chem1PriceWeekly(string product, string year)
        {
            int id = int.Parse(product);


            var data = (_context.SA_Chem1PriceWeekly.Where(Year => Year.Product == id && Year.year
            == year)).ToList()
                .Select(x => new
                {
                    ProductVariant = x.ProductVariant,
                    //Week = x.Week + " ("+ Convert.ToDateTime( x.Date).ToString("dd MMM yy")+")",
                    Week = "(" + Convert.ToDateTime(x.Date).ToString("dd MMM yy") + ")",
                    count = x.count,
                    Discription = x.Type,
                    Product = x.Product

                });

            var query = from d in data
                            //where d.Product == id && d.year == DateTime.Now.Year.ToString() && d.Month.ToUpper() == monthname

                        group d by new { d.Week, d.ProductVariant } into g
                        from SalesHeaderAndDetail in g.DefaultIfEmpty()
                        group SalesHeaderAndDetail by new
                        {
                            // SalesOrderId=SalesHeaderAndDetail.SalesOrderId,
                            Week = SalesHeaderAndDetail.Week,
                            ProductVariant = SalesHeaderAndDetail.ProductVariant,
                            Product = SalesHeaderAndDetail.Product
                        }
                        into grouped
                        select new SA_ChemPriceWeekly
                        {
                            Week = grouped.Key.Week.ToString(),
                            count = grouped.Sum(x => x.count),
                            Discription = grouped.FirstOrDefault().Discription.ToString(),
                            Product = grouped.Key.Product,
                            ProductVariant = grouped.Key.ProductVariant.ToString(),
                        };


            var ss = query.ToList();
            return query.ToList();

        }


        internal List<SA_ChemPriceWeekly> GetWeeklyWiseProductList_bak(string product, string fromdate, string todate)
        {
            int id = int.Parse(product);
            string monthname = DateTime.Now.ToMonthName().ToUpper();

            monthname = Convert.ToDateTime(fromdate).ToMonthName().ToString();

            var data = (_context.SA_ChemPriceWeekly.Where(Year => Year.Product == id && Year.year == DateTime.Now.Year.ToString() && Year.Month.ToUpper() == monthname)).ToList()
                .Select(x => new
                {
                    ProductVariant = x.ProductVariant,
                    Week = ((Convert.ToInt16(x.day) / 7) + 1),
                    count = x.count,
                    Discription = x.Discription,
                    Product = x.Product

                });

            var query = from d in data
                            //where d.Product == id && d.year == DateTime.Now.Year.ToString() && d.Month.ToUpper() == monthname

                        group d by new { d.Week, d.ProductVariant } into g
                        from SalesHeaderAndDetail in g.DefaultIfEmpty()
                        group SalesHeaderAndDetail by new
                        {
                            // SalesOrderId=SalesHeaderAndDetail.SalesOrderId,
                            Week = SalesHeaderAndDetail.Week,
                            ProductVariant = SalesHeaderAndDetail.ProductVariant
                        }
                        into grouped
                        select new SA_ChemPriceWeekly
                        {
                            Week = grouped.Key.Week.ToString(),
                            count = grouped.Sum(x => x.count),
                            Discription = grouped.FirstOrDefault().Discription.ToString(),
                            Product = grouped.FirstOrDefault().Product,
                            ProductVariant = grouped.Key.ProductVariant.ToString(),
                        };


            //var query =  ((_context.SA_ChemPriceWeekly.Where(Year => Year.Product == id && Year.year == DateTime.Now.Year.ToString() && Year.Month.ToUpper() == monthname)).ToList()
            //    .Select(x=> new {
            //        ProductVariant = x.ProductVariant,
            //        Week= ((Convert.ToInt16( x.day) / 7) + 1),
            //        count= x.count,
            //        Discription= x.Discription

            //    })
            //     .AsEnumerable());
            //var ss = query.GroupBy(x => x.Week).Select{
            //    s=> new SA_ChemPriceWeekly {
            //        ProductVariant = x.ProductVariant,
            //        Week = s.key
            //        count = x.count,
            //        Discription = x.Discription
            //    }
            //};
            var ss = query.ToList();
            return query.ToList();

        }

        internal List<SA_ChemPriceWeekly> GetWeeklyWiseProductListwithCompare(string[] values)
        {
            var query = (from SA_ChemPriceWeekly in _context.SA_ChemPriceWeekly
                         where values.Contains(SA_ChemPriceWeekly.Product.ToString())
                         select new { SA_ChemPriceWeekly });

            List<SA_ChemPriceWeekly> returnpro = new List<SA_ChemPriceWeekly>();
            foreach (var item in query)
            {
                returnpro.Add(item.SA_ChemPriceWeekly);
            }
            return returnpro;
        }


        internal List<SA_ChemPriceDailyAverage> GetDailyAverageWiseProductList(string product, string fromdate, string todate)
        {
            //  int id = int.Parse(product);
            //string monthname = DateTime.Now.ToMonthName().ToUpper();
            //return ((_context.SA_ChemPriceDailyAverage.Where(Year => Year.Product == id && Year.year == DateTime.Now.Year.ToString() && Year.Month.ToUpper() == monthname)).ToList());

            int id = int.Parse(product);
            // string monthname = DateTime.Now.ToMonthName().ToUpper();

            var result = (_context.SA_ChemPriceDailyAverage.Where(Year => Year.Product == id)).ToList().Where(x =>
            Convert.ToDateTime(x.Month + " " + x.day + " " + x.year) >= Convert.ToDateTime(fromdate)
            && Convert.ToDateTime(x.Month + " " + x.day + " " + x.year) <= Convert.ToDateTime(todate)

            ).OrderBy(x => Convert.ToDateTime(x.Month + " " + x.day + " " + x.year)).ToList();

            return (result);

        }
        //internal List<SA_ChemPriceDailyAverage> GetDailyAverageWiseProductList(string product)
        //{
        //    int id = int.Parse(product);
        //    string monthname = DateTime.Now.ToMonthName().ToUpper();
        //    return ((_context.SA_ChemPriceDailyAverage.Where(Year => Year.Product == id && Year.year == DateTime.Now.Year.ToString() && Year.Month.ToUpper() == monthname)).ToList());


        //}
        internal List<SA_ChemPriceFileList> GetallUploadFile()
        {
            List<SA_ChemPriceFileList> xyz = ((from cust in _context.SA_ChemPriceYearly
                                               select new SA_ChemPriceFileList { FileName = cust.FileName, CreatedDate = cust.CreatedDate.ToString(), CreatedBy = cust.CreatedBy, Product = _context.SA_Product.Where(x => x.id == cust.Product).Select(y => y.ProductName).FirstOrDefault() })
        .Union
          (from cust in _context.SA_ChemPriceMonthly
           select new SA_ChemPriceFileList { FileName = cust.FileName, CreatedDate = cust.CreatedDate.ToString(), CreatedBy = cust.CreatedBy, Product = _context.SA_Product.Where(x => x.id == cust.Product).Select(y => y.ProductName).FirstOrDefault() })
           .Union
          (from cust in _context.SA_ChemPriceQuarterly
           select new SA_ChemPriceFileList { FileName = cust.FileName, CreatedDate = cust.CreatedDate.ToString(), CreatedBy = cust.CreatedBy, Product = _context.SA_Product.Where(x => x.id == cust.Product).Select(y => y.ProductName).FirstOrDefault() })
           .Union
           (from cust in _context.SA_ChemPriceDaily
            select new SA_ChemPriceFileList { FileName = cust.FileName, CreatedDate = cust.CreatedDate.ToString(), CreatedBy = cust.CreatedBy, Product = _context.SA_Product.Where(x => x.id == cust.Product).Select(y => y.ProductName).FirstOrDefault() })
            .Union
           (from cust in _context.SA_ChemPriceWeeklyNew
            select new SA_ChemPriceFileList { FileName = cust.FileName, CreatedDate = cust.CreatedDate.ToString(), CreatedBy = cust.CreatedBy, Product = _context.SA_Product.Where(x => x.id == cust.Product).Select(y => y.ProductName).FirstOrDefault() })
            .Union
           (from cust in _context.SA_ChemPriceDailyNew
            select new SA_ChemPriceFileList { FileName = cust.FileName, CreatedDate = cust.CreatedDate.ToString(), CreatedBy = cust.CreatedBy, Product = _context.SA_Product.Where(x => x.id == cust.Product).Select(y => y.ProductName).FirstOrDefault() })
            .Union
           (from cust in _context.SA_ChemPriceDailyAverage
            select new SA_ChemPriceFileList { FileName = cust.FileName, CreatedDate = cust.CreatedDate.ToString(), CreatedBy = cust.CreatedBy, Product = _context.SA_Product.Where(x => x.id == cust.Product).Select(y => y.ProductName).FirstOrDefault() })).ToList();
            return xyz;


        }
        public dynamic GetYear(string T)
        {
            if (T == "Q")
            {

                return _context.SA_ChemPriceQuarterly.Select(x => new YearModel { Year = x.year }).Distinct().ToList();
            }
            else
            {
                return _context.SA_ChemPriceWeeklyNew.Select(x => new YearModel { Year = x.year.Trim() }).Distinct().ToList();
            }
        }

        internal List<ProductVariantModel> GetAllProductVariant(string type, int productId)
        {
            if (type == "month")
            {
                return _context.SA_ChemPriceMonthly.Where(w => w.Product == productId).Select(x => new ProductVariantModel
                {
                    Name = x.ProductVariant
                }).Distinct().ToList();
            }
            else if (type == "year")
            {
                return _context.SA_ChemPriceYearly.Where(w => w.Product == productId).Select(x => new ProductVariantModel
                {
                    Name = x.ProductVariant
                }).Distinct().ToList();

            }
            else if (type == "week")
            {
                return _context.SA_ChemPriceWeeklyNew.Where(w => w.Product == productId).Select(x => new ProductVariantModel
                {
                    Name = x.ProductVariant
                }).Distinct().ToList();

            }
            else if (type == "quater")
            {
                return _context.SA_ChemPriceQuarterly.Where(w => w.Product == productId).Select(x => new ProductVariantModel
                {
                    Name = x.ProductVariant
                }).Distinct().ToList();

            }
            else if (type == "day")
            {
                return _context.SA_ChemPriceDaily.Where(w => w.Product == productId).Select(x => new ProductVariantModel
                {
                    Name = x.ProductVariant
                }).Distinct().ToList();

            }
            else
            {
                return _context.SA_ChemPriceDailyAverage.Where(w => w.Product == productId).Select(x => new ProductVariantModel
                {
                    Name = x.ProductVariant
                }).Distinct().ToList();

            }
            //else
            //{
            //    return _context.SA_ChemPriceMonthly.Where(w => w.Product == productId).Select(x => new ProductVariantModel
            //    {
            //        Name = x.ProductVariant
            //    }).Distinct().ToList();
            //}

        }
    }
    public class ProductVariantModel
    {
        public string Name { get; set; }
    }
    public class YearModel
    {
        public string Year { get; set; }
    }
    static class DateTimeExtensions
    {
        public static string ToMonthName(this DateTime dateTime)
        {
            return CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(dateTime.Month);
        }

        public static string ToShortMonthName(this DateTime dateTime)
        {
            return CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(dateTime.Month);
        }
    }
}