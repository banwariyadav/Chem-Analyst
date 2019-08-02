using ChemAnalyst.DAL;
using ChemAnalyst.Models;
using ChemAnalyst.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ChemAnalyst.Controllers
{
    public class ChemAnalystController : Controller
    {
        // GET: Home
        ProductDataStore ObjProduct = new ProductDataStore();
        public ActionResult Index()
        {
            return View("ChemAnalyst");
        }
        public ActionResult Contact()
        {
            return View("Contact");
        }

        public ActionResult Products()
        {
            NewsDataStore Obj = new NewsDataStore();
            DealsDataStore d = new DealsDataStore();
            IndustryViewModel model = new IndustryViewModel();
            List<SA_News> NewsList = Obj.GetNewsList();
            model.NewsList = NewsList;
            List<SA_Deals> DealList = d.GetDealsList();
            model.DealsList = DealList;
            return View("products",model);
        }
        public ActionResult FreeTrail()
        {
            NewsDataStore Obj = new NewsDataStore();
            DealsDataStore d = new DealsDataStore();
            IndustryViewModel model = new IndustryViewModel();
            List<SA_News> NewsList = Obj.GetNewsList();
            model.NewsList = NewsList;
            List<SA_Deals> DealList = d.GetDealsList();
            model.DealsList = DealList;
            return View("FreeTrial", model);
        }

        [HttpPost]
        public async Task<ActionResult> SaveFreeTrialAsync(Lead_Master lead)
        {
            bool result = false;
            try
            {
               

                lead.IPAddress =   GetIPAddress() ;
                lead.CreatedDate = DateTime.Now;
                lead.Status = "New";
                FreeTrialDal Obj = new FreeTrialDal();
                if (ModelState.IsValid) //checking model is valid or not  
                {
                    result = await Obj.AddFreeTrial(lead);
                }
            }
            catch (Exception ex)
            {
            }

            return Json(new { result = result, JsonRequestBehavior.AllowGet });
        }

        public ActionResult AdvisoryList()
        {
            AdvisoryDataStore Obj = new AdvisoryDataStore();
            List<SA_Advisory> NewsList = Obj.GetAdvisoryList().OrderByDescending(w => w.id).Take(6).ToList();

            return PartialView("~/Views/PartialView/AdvisoryPartialView.cshtml", NewsList);

        }
        public ActionResult QuoteList()
        {
            QuoteDataStore Obj = new QuoteDataStore();
            List<SA_Quote> NewsList = Obj.GetQuoteList();

            return PartialView("~/Views/PartialView/QuotePartialView.cshtml", NewsList);

        }
        public ActionResult JobList()
        {
            JobDataStore Obj = new JobDataStore();
            List<SA_Job> NewsList = Obj.GetJobList();

            return PartialView("~/Views/PartialView/JobPartialView.cshtml", NewsList);

        }
        public ActionResult CategoryList()
        {
            CategoryDataStore Obj = new CategoryDataStore();
            List<SA_Category> NewsList = Obj.GetCategoryList().OrderByDescending(w => w.id).Take(6).ToList();

            return PartialView("~/Views/PartialView/CategoryPartialView.cshtml", NewsList);

        }
        public ActionResult NewsList()
        {
            NewsDataStore Obj = new NewsDataStore();
            List<SA_News> NewsList = Obj.GetNewsList();
            var model = NewsList.OrderByDescending(w => w.id).Take(3).ToList();
          
            return PartialView("~/Views/PartialView/NewPartialView.cshtml", model);

        }
        public ActionResult SliderList()
        {
            SliderDataStore Obj = new SliderDataStore();
            List<SA_Slider> NewsList = Obj.GetSliderList();
            return PartialView("~/Views/PartialView/SliderPartialView.cshtml", NewsList);

        }
        public ActionResult WorldList()
        {
            WorldDataStore Obj = new WorldDataStore();
            SA_World NewsList = Obj.GetWorldByid(1);
            return PartialView("~/Views/PartialView/WorldPartialView.cshtml", NewsList);

        }
        public ActionResult ChemContentList()
        {
            ChemContentDataStore Obj = new ChemContentDataStore();
            SA_ChemContent NewsList = Obj.GetChemContentByid(1);
            if(NewsList==null)
            {
                NewsList=new SA_ChemContent();
            }
            return PartialView("~/Views/PartialView/ChemContentPartialView.cshtml", NewsList);

        }
        public ActionResult ProductList()
        {
            NewsDataStore Obj = new NewsDataStore();
            DealsDataStore d = new DealsDataStore();
            ProductListViewModel model = new ProductListViewModel();
            List<SA_News> NewsList = Obj.GetNewsList();
            model.NewsList = NewsList;
            List<SA_Deals> DealList = d.GetDealsList();
            model.DealsList = DealList;
            ProductDataStore p = new ProductDataStore();
            List<SA_Product> ProductList = p.GetProductList();
            model.ProductList = ProductList;
            CategoryDataStore c = new CategoryDataStore();
            ViewBag.category=c.CategoryList();
            return View("~/Views/ChemAnalyst/products.cshtml", model);

        }
        [HttpPost]
        public ActionResult ProductList(string id,string search)
        {
            NewsDataStore Obj = new NewsDataStore();
            DealsDataStore d = new DealsDataStore();
            ProductListViewModel model = new ProductListViewModel();
            List<SA_News> NewsList = Obj.GetNewsList();
            model.NewsList = NewsList;
            List<SA_Deals> DealList = d.GetDealsList();
            model.DealsList = DealList;
            ProductDataStore p = new ProductDataStore();
            IQueryable<SA_Product> ProductList = p.GetProductListBySearch(id,search);
            model.ProductList = ProductList;
            CategoryDataStore c = new CategoryDataStore();
            if (id != "")
            {
                var categoryName = c.GetCategoryByid(Convert.ToInt32(id));
                ViewBag.CategoryName = categoryName.CategoryName;
            }
            else
            {
                ViewBag.CategoryName = "";
            }
           
            ViewBag.category = c.CategoryList();
            return View("~/Views/ChemAnalyst/products.cshtml", model);

        }

        private string GetIPAddress()
        {
            string hostName = Dns.GetHostName(); // Retrive the Name of HOST  
            Console.WriteLine(hostName);
            // Get the IP  
            return Dns.GetHostByName(hostName).AddressList[0].ToString();
        }
        public ActionResult Chem1WeekChart()
        {
            int PId = 0;
            ChemicalPricing Objdal = new DAL.ChemicalPricing();


            List<SA_Chem1PriceWeekly> obj = null;
            string compare = string.Empty;

            string currentYear = DateTime.Now.Year.ToString();
            string currentMonth = DateTime.Now.ToMonthName().ToUpper();
            string currentWeek = ((Convert.ToInt32(DateTime.Now.Day) / 7) + 1).ToString();

                //               Convert.ToInt32(DateTime.Now.Day / 7).ToString();
           

            obj = Objdal.GetChem1WeekWise(currentYear, currentMonth, currentWeek);
            List<string> Year = obj.Select(p => p.day).Distinct().ToList();
            List<string> Discription = obj.Select(p => p.Discription).Distinct().ToList();

            var lstModel = new List<StackedViewModel>();

            for (int i = 0; i < Year.Count; i++)
            {

                List<SA_Chem1PriceWeekly> Chartdata = obj.Where(Chart => Chart.day == Year[i]).ToList();

                PId = Chartdata.FirstOrDefault().Product.Value;
                //sales of product sales by quarter  
                StackedViewModel Report = new StackedViewModel();
                Report.StackedDimensionOne = Year[i];
                
                List<SimpleReportViewModel> Data = new List<SimpleReportViewModel>();
                List<SimpleReportViewModel> QuantityList = new List<ViewModel.SimpleReportViewModel>();


                foreach (var item in obj.Select(p => p.ProductVariant).Distinct().ToList())
                {
                    SimpleReportViewModel Quantity = new SimpleReportViewModel()
                    {
                        DimensionOne = item,// item.Month,
                        Quantity = Chartdata.Where(x => x.ProductVariant == item).Sum(x => x.count.Value),
                       // MDimensionOne = Chartdata.FirstOrDefault(w=>w.ProductVariant== item).day
                    };
                    QuantityList.Add(Quantity);
                }


                //foreach (var item in Chartdata)
                //{
                //    SimpleReportViewModel Quantity = new SimpleReportViewModel()
                //    {
                //        DimensionOne = item.ProductVariant,
                //        Quantity = item.count.HasValue? item.count.Value:0,
                //        MDimensionOne = item.day
                //};
                //    QuantityList.Add(Quantity);
                //}
                Report.LstData = QuantityList;

                lstModel.Add(Report);



                lstModel[0].ProductName = ObjProduct.GetProductByid(PId).ProductName;
            }


            if (lstModel.Count() > 0)
                return PartialView("~/Views/PartialView/YearlyChartChemical1.cshtml", lstModel);
            else
                return PartialView("~/Views/PartialView/YearlyChemical.cshtml", lstModel);


        }
        public ActionResult Chem2WeekChart()
        {
            ChemicalPricing Objdal = new DAL.ChemicalPricing();
            int PId = 0;

            List<SA_Chem2PriceWeekly> obj = null;
            string compare = string.Empty;

            string currentYear = DateTime.Now.Year.ToString();
            string currentMonth = DateTime.Now.ToMonthName().ToUpper();
            string currentWeek = ((Convert.ToInt32(DateTime.Now.Day) / 7) + 1).ToString();

            //               Convert.ToInt32(DateTime.Now.Day / 7).ToString();


            obj = Objdal.GetChem2WeekWise(currentYear, currentMonth, currentWeek);
            List<string> Year = obj.Select(p => p.day).Distinct().ToList();
            List<string> Discription = obj.Select(p => p.Discription).Distinct().ToList();

            var lstModel = new List<StackedViewModel>();

            for (int i = 0; i < Year.Count; i++)
            {

                List<SA_Chem2PriceWeekly> Chartdata = obj.Where(Chart => Chart.day == Year[i]).ToList();
                PId = Chartdata.FirstOrDefault().Product.Value;
                //sales of product sales by quarter  
                StackedViewModel Report = new StackedViewModel();
                Report.StackedDimensionOne = Year[i];

                List<SimpleReportViewModel> Data = new List<SimpleReportViewModel>();
                List<SimpleReportViewModel> QuantityList = new List<ViewModel.SimpleReportViewModel>();


                foreach (var item in obj.Select(p => p.ProductVariant).Distinct().ToList())
                {
                    SimpleReportViewModel Quantity = new SimpleReportViewModel()
                    {
                        DimensionOne = item,// item.Month,
                        Quantity = Chartdata.Where(x => x.ProductVariant == item).Sum(x => x.count.Value),
                        // MDimensionOne = Chartdata.FirstOrDefault(w=>w.ProductVariant== item).day
                    };
                    QuantityList.Add(Quantity);
                }


                //foreach (var item in Chartdata)
                //{
                //    SimpleReportViewModel Quantity = new SimpleReportViewModel()
                //    {
                //        DimensionOne = item.ProductVariant,
                //        Quantity = item.count.HasValue? item.count.Value:0,
                //        MDimensionOne = item.day
                //};
                //    QuantityList.Add(Quantity);
                //}
                Report.LstData = QuantityList;

                lstModel.Add(Report);
                lstModel[0].ProductName = ObjProduct.GetProductByid(PId).ProductName;
            }

           

            if (lstModel.Count() > 0)
                return PartialView("~/Views/PartialView/YearlyChartChemical2.cshtml", lstModel);
            else
                return PartialView("~/Views/PartialView/YearlyChemical.cshtml", lstModel);


        }
        public ActionResult Chem3WeekChart()
        {
            int PId = 0;
            ChemicalPricing Objdal = new DAL.ChemicalPricing();


            List<SA_Chem3PriceWeekly> obj = null;
            string compare = string.Empty;

            string currentYear = DateTime.Now.Year.ToString();
            string currentMonth = DateTime.Now.ToMonthName().ToUpper();
            string currentWeek = ((Convert.ToInt32(DateTime.Now.Day) / 7) + 1).ToString();

            //               Convert.ToInt32(DateTime.Now.Day / 7).ToString();


            obj = Objdal.GetChem3WeekWise(currentYear, currentMonth, currentWeek);
            List<string> Year = obj.Select(p => p.day).Distinct().ToList();
            List<string> Discription = obj.Select(p => p.Discription).Distinct().ToList();

            var lstModel = new List<StackedViewModel>();

            for (int i = 0; i < Year.Count; i++)
            {

                List<SA_Chem3PriceWeekly> Chartdata = obj.Where(Chart => Chart.day == Year[i]).ToList();
                //sales of product sales by quarter  
                PId = Chartdata.FirstOrDefault().Product.Value;
                StackedViewModel Report = new StackedViewModel();
                Report.StackedDimensionOne = Year[i];

                List<SimpleReportViewModel> Data = new List<SimpleReportViewModel>();
                List<SimpleReportViewModel> QuantityList = new List<ViewModel.SimpleReportViewModel>();


                foreach (var item in obj.Select(p => p.ProductVariant).Distinct().ToList())
                {
                    SimpleReportViewModel Quantity = new SimpleReportViewModel()
                    {
                        DimensionOne = item,// item.Month,
                        Quantity = Chartdata.Where(x => x.ProductVariant == item).Sum(x => x.count.Value),
                        // MDimensionOne = Chartdata.FirstOrDefault(w=>w.ProductVariant== item).day
                    };
                    QuantityList.Add(Quantity);
                }


                //foreach (var item in Chartdata)
                //{
                //    SimpleReportViewModel Quantity = new SimpleReportViewModel()
                //    {
                //        DimensionOne = item.ProductVariant,
                //        Quantity = item.count.HasValue? item.count.Value:0,
                //        MDimensionOne = item.day
                //};
                //    QuantityList.Add(Quantity);
                //}
                Report.LstData = QuantityList;

                lstModel.Add(Report);

                lstModel[0].ProductName = ObjProduct.GetProductByid(PId).ProductName;
            }

           

            if (lstModel.Count() > 0)
                return PartialView("~/Views/PartialView/YearlyChartChemical3.cshtml", lstModel);
            else
                return PartialView("~/Views/PartialView/YearlyChemical.cshtml", lstModel);


        }
        public ActionResult Chem4WeekChart()
        {
            int PId = 0;
            ChemicalPricing Objdal = new DAL.ChemicalPricing();


            List<SA_Chem4PriceWeekly> obj = null;
            string compare = string.Empty;

            string currentYear = DateTime.Now.Year.ToString();
            string currentMonth = DateTime.Now.ToMonthName().ToUpper();
            string currentWeek = ((Convert.ToInt32(DateTime.Now.Day) / 7) + 1).ToString();

            //               Convert.ToInt32(DateTime.Now.Day / 7).ToString();


            obj = Objdal.GetChem4WeekWise(currentYear, currentMonth, currentWeek);
            List<string> Year = obj.Select(p => p.day).Distinct().ToList();
            List<string> Discription = obj.Select(p => p.Discription).Distinct().ToList();

            var lstModel = new List<StackedViewModel>();

            for (int i = 0; i < Year.Count; i++)
            {

                List<SA_Chem4PriceWeekly> Chartdata = obj.Where(Chart => Chart.day == Year[i]).ToList();
                PId = Chartdata.FirstOrDefault().Product.Value;
                //sales of product sales by quarter  
                StackedViewModel Report = new StackedViewModel();
                Report.StackedDimensionOne = Year[i];

                List<SimpleReportViewModel> Data = new List<SimpleReportViewModel>();
                List<SimpleReportViewModel> QuantityList = new List<ViewModel.SimpleReportViewModel>();


                foreach (var item in obj.Select(p => p.ProductVariant).Distinct().ToList())
                {
                    SimpleReportViewModel Quantity = new SimpleReportViewModel()
                    {
                        DimensionOne = item,// item.Month,
                        Quantity = Chartdata.Where(x => x.ProductVariant == item).Sum(x => x.count.Value),
                        // MDimensionOne = Chartdata.FirstOrDefault(w=>w.ProductVariant== item).day
                    };
                    QuantityList.Add(Quantity);
                }


                //foreach (var item in Chartdata)
                //{
                //    SimpleReportViewModel Quantity = new SimpleReportViewModel()
                //    {
                //        DimensionOne = item.ProductVariant,
                //        Quantity = item.count.HasValue? item.count.Value:0,
                //        MDimensionOne = item.day
                //};
                //    QuantityList.Add(Quantity);
                //}
                Report.LstData = QuantityList;

                lstModel.Add(Report);

                lstModel[0].ProductName = ObjProduct.GetProductByid(PId).ProductName;
            }

            

            if (lstModel.Count() > 0)
                return PartialView("~/Views/PartialView/YearlyChartChemical4.cshtml", lstModel);
            else
                return PartialView("~/Views/PartialView/YearlyChemical.cshtml", lstModel);


        }
        public ActionResult Chem5WeekChart()
        {
            int PId = 0;
            ChemicalPricing Objdal = new DAL.ChemicalPricing();


            List<SA_Chem5PriceWeekly> obj = null;
            string compare = string.Empty;

            string currentYear = DateTime.Now.Year.ToString();
            string currentMonth = DateTime.Now.ToMonthName().ToUpper();
            string currentWeek = ((Convert.ToInt32(DateTime.Now.Day) / 7) + 1).ToString();

            //               Convert.ToInt32(DateTime.Now.Day / 7).ToString();


            obj = Objdal.GetChem5WeekWise(currentYear, currentMonth, currentWeek);
            List<string> Year = obj.Select(p => p.day).Distinct().ToList();
            List<string> Discription = obj.Select(p => p.Discription).Distinct().ToList();

            var lstModel = new List<StackedViewModel>();

            for (int i = 0; i < Year.Count; i++)
            {

                List<SA_Chem5PriceWeekly> Chartdata = obj.Where(Chart => Chart.day == Year[i]).ToList();
                PId = Chartdata.FirstOrDefault().Product.Value;
                //sales of product sales by quarter  
                StackedViewModel Report = new StackedViewModel();
                Report.StackedDimensionOne = Year[i];

                List<SimpleReportViewModel> Data = new List<SimpleReportViewModel>();
                List<SimpleReportViewModel> QuantityList = new List<ViewModel.SimpleReportViewModel>();


                foreach (var item in obj.Select(p => p.ProductVariant).Distinct().ToList())
                {
                    SimpleReportViewModel Quantity = new SimpleReportViewModel()
                    {
                        DimensionOne = item,// item.Month,
                        Quantity = Chartdata.Where(x => x.ProductVariant == item).Sum(x => x.count.Value),
                        // MDimensionOne = Chartdata.FirstOrDefault(w=>w.ProductVariant== item).day
                    };
                    QuantityList.Add(Quantity);
                }


                //foreach (var item in Chartdata)
                //{
                //    SimpleReportViewModel Quantity = new SimpleReportViewModel()
                //    {
                //        DimensionOne = item.ProductVariant,
                //        Quantity = item.count.HasValue? item.count.Value:0,
                //        MDimensionOne = item.day
                //};
                //    QuantityList.Add(Quantity);
                //}
                Report.LstData = QuantityList;

                lstModel.Add(Report);

                lstModel[0].ProductName = ObjProduct.GetProductByid(PId).ProductName;
            }

           

            if (lstModel.Count() > 0)
                return PartialView("~/Views/PartialView/YearlyChartChemical5.cshtml", lstModel);
            else
                return PartialView("~/Views/PartialView/YearlyChemical.cshtml", lstModel);


        }
        public ActionResult Chem6WeekChart()
        {
            int PId = 0;
            ChemicalPricing Objdal = new DAL.ChemicalPricing();


            List<SA_Chem6PriceWeekly> obj = null;
            string compare = string.Empty;

            string currentYear = DateTime.Now.Year.ToString();
            string currentMonth = DateTime.Now.ToMonthName().ToUpper();
            string currentWeek = ((Convert.ToInt32(DateTime.Now.Day) / 7) + 1).ToString();

            //               Convert.ToInt32(DateTime.Now.Day / 7).ToString();


            obj = Objdal.GetChem6WeekWise(currentYear, currentMonth, currentWeek);
            List<string> Year = obj.Select(p => p.day).Distinct().ToList();
            List<string> Discription = obj.Select(p => p.Discription).Distinct().ToList();

            var lstModel = new List<StackedViewModel>();

            for (int i = 0; i < Year.Count; i++)
            {

                List<SA_Chem6PriceWeekly> Chartdata = obj.Where(Chart => Chart.day == Year[i]).ToList();
                PId = Chartdata.FirstOrDefault().Product.Value;
                //sales of product sales by quarter  
                StackedViewModel Report = new StackedViewModel();
                Report.StackedDimensionOne = Year[i];

                List<SimpleReportViewModel> Data = new List<SimpleReportViewModel>();
                List<SimpleReportViewModel> QuantityList = new List<ViewModel.SimpleReportViewModel>();


                foreach (var item in obj.Select(p => p.ProductVariant).Distinct().ToList())
                {
                    SimpleReportViewModel Quantity = new SimpleReportViewModel()
                    {
                        DimensionOne = item,// item.Month,
                        Quantity = Chartdata.Where(x => x.ProductVariant == item).Sum(x => x.count.Value),
                        // MDimensionOne = Chartdata.FirstOrDefault(w=>w.ProductVariant== item).day
                    };
                    QuantityList.Add(Quantity);
                }


                //foreach (var item in Chartdata)
                //{
                //    SimpleReportViewModel Quantity = new SimpleReportViewModel()
                //    {
                //        DimensionOne = item.ProductVariant,
                //        Quantity = item.count.HasValue? item.count.Value:0,
                //        MDimensionOne = item.day
                //};
                //    QuantityList.Add(Quantity);
                //}
                Report.LstData = QuantityList;

                lstModel.Add(Report);

                lstModel[0].ProductName = ObjProduct.GetProductByid(PId).ProductName;
            }

          

            if (lstModel.Count() > 0)
                return PartialView("~/Views/PartialView/YearlyChartChemical6.cshtml", lstModel);
            else
                return PartialView("~/Views/PartialView/YearlyChemical.cshtml", lstModel);


        }

    }
}