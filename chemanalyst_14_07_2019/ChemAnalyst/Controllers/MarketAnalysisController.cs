using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.IO;
using System.Data;
using ChemAnalyst.DAL;
using System.Configuration;
using System.Data.SqlClient;
using ChemAnalyst.ViewModel;
using ChemAnalyst.Models;
using OfficeOpenXml;


namespace ChemAnalyst.Controllers
{
    public class MarketAnalysisController : Controller
    {
        ProductDataStore ObjProduct = new ProductDataStore();
        CommentaryDataStore ObjCommentary = new CommentaryDataStore();
        MarketAnalysis Marketanalysisobj;
        // GET: MarketAnalysis
        public MarketAnalysisController()
        {
            Marketanalysisobj = new DAL.MarketAnalysis();
        }
        // GET: MarketAnalysis
        public ActionResult MarketAnalysisList()
        {
            List<SA_MarketFileList> fileList = Marketanalysisobj.GetallUploadFile();
            return View("Market-FileList", fileList);
        }

        public ActionResult MarketAnalysisChart()
        {
            string product = null;
            string ChartType = null;
            //string Range = null;
            string Range = "Company";
            string CompareProject = null;
            bool Customer = false;
            return RedirectToAction("MarketbycompanyChart", "MarketAnalysis", new
            {
                product,
                ChartType,
                Range,
                CompareProject,
                Customer
            });

        }

        public ActionResult MarketAnalysisChartUser()
        {
            string product = null;
            string ChartType = null;
            string Range = null;
            string CompareProject = null;
            bool Customer = true;
            return RedirectToAction("MarketbycompanyChart", "MarketAnalysis", new
            {
                product,
                ChartType,
                Range,
                CompareProject,
                Customer
            });

        }

        public JsonResult GetFileList()
        {

            List<SA_MarketFileList> fileList = Marketanalysisobj.GetallUploadFile();

            return Json(new { data = fileList }, JsonRequestBehavior.AllowGet);

        }
        public ActionResult Index()
        {
            ViewBag.ProductList = ObjProduct.ProductList();

            return View("marketanalysisimport");
        }

        public ActionResult ShowChart(FormCollection FilterObject)
        {
            string product = FilterObject["ddlProduct"];
            string ChartType = FilterObject["ddlChart"];
            string Range = FilterObject["ddlRange"];
            string FromYear = FilterObject["ddlFyear"];
            string ToYear = FilterObject["ddlToYear"];
            string selectedLegends = FilterObject["hiddenLegends"];
            string CompareProject = FilterObject["example-getting-started"];
            bool Customer = false;
            if (Range == "Company")
            {
                return RedirectToAction("MarketbycompanyChart", "MarketAnalysis", new
                {
                    product,
                    ChartType,
                    Range,
                    CompareProject,
                    Customer,
                    FromYear,
                    ToYear,
                    selectedLegends
                });
                // ChecmPriceYearlyChartUser(product, ChartType, Range);
            }
            else if (Range == "Location")
            {
                return RedirectToAction("MarketbylocationChart", "MarketAnalysis", new
                {
                    product,
                    ChartType,
                    Range,
                    CompareProject,
                    Customer,
                    FromYear,
                    ToYear,
                    selectedLegends
                });
            }
            else if (Range == "Technology")
            {
                return RedirectToAction("MarketbyTechnologyChart", "MarketAnalysis", new
                {
                    product,
                    ChartType,
                    Range,
                    CompareProject,
                    Customer,
                    FromYear,
                    ToYear,
                    selectedLegends
                });
            }
            else if (Range == "Process")
            {
                return RedirectToAction("MarketbyProcessChart", "MarketAnalysis", new
                {
                    product,
                    ChartType,
                    Range,
                    CompareProject,
                    Customer,
                    FromYear,
                    ToYear,
                    selectedLegends
                });
            }
            else if (Range == "Production")
            {
                return RedirectToAction("MarketbyProductionChart", "MarketAnalysis", new
                {
                    product,
                    ChartType,
                    Range,
                    CompareProject,
                    Customer,
                    FromYear,
                    ToYear,
                    selectedLegends
                });
            }
            else if (Range == "Operating Efficiency")
            {
                return RedirectToAction("MarketbyEfficiencyChart", "MarketAnalysis", new
                {
                    product,
                    ChartType,
                    Range,
                    CompareProject,
                    Customer,
                    FromYear,
                    ToYear,
                    selectedLegends
                });
            }
            else if (Range == "Demand By EndUse(%)")
            {
                return RedirectToAction("MarketbyEndUsePercentChart", "MarketAnalysis", new
                {
                    product,
                    ChartType,
                    Range,
                    CompareProject,
                    Customer,
                    FromYear,
                    ToYear,
                    selectedLegends
                });
            }
            else if (Range == "Demand By EndUse(%)")
            {
                return RedirectToAction("MarketbyEndUsePercentChart", "MarketAnalysis", new
                {
                    product,
                    ChartType,
                    Range,
                    CompareProject,
                    Customer,
                    FromYear,
                    ToYear,
                    selectedLegends
                });
            }
            else if (Range == "Demand By EndUse(T)")
            {
                return RedirectToAction("MarketbyEndUseTonneChart", "MarketAnalysis", new
                {
                    product,
                    ChartType,
                    Range,
                    CompareProject,
                    Customer,
                    FromYear,
                    ToYear,
                    selectedLegends
                });
            }
            else if (Range == "Demand By Grade(%)")
            {
                return RedirectToAction("MarketbyGradePercentChart", "MarketAnalysis", new
                {
                    product,
                    ChartType,
                    Range,
                    CompareProject,
                    Customer,
                    FromYear,
                    ToYear,
                    selectedLegends
                });
            }
            else if (Range == "Demand By Grade(T)")
            {
                return RedirectToAction("MarketbyGradeTonneChart", "MarketAnalysis", new
                {
                    product,
                    ChartType,
                    Range,
                    CompareProject,
                    Customer,
                    FromYear,
                    ToYear,
                    selectedLegends
                });
            }
            else if (Range == "Demand By Type(%)")
            {
                return RedirectToAction("MarketbyTypePercentChart", "MarketAnalysis", new
                {
                    product,
                    ChartType,
                    Range,
                    CompareProject,
                    Customer,
                    FromYear,
                    ToYear,
                    selectedLegends
                });
            }
            else if (Range == "Demand By Type(T)")
            {
                return RedirectToAction("MarketbyTypeTonneChart", "MarketAnalysis", new
                {
                    product,
                    ChartType,
                    Range,
                    CompareProject,
                    Customer,
                    FromYear,
                    ToYear,
                    selectedLegends
                });
            }
            else if (Range == "Demand By SalesChannel(T)")
            {
                return RedirectToAction("MarketbySalesChannelTonneChart", "MarketAnalysis", new
                {
                    product,
                    ChartType,
                    Range,
                    CompareProject,
                    Customer,
                    FromYear,
                    ToYear,
                    selectedLegends
                });
            }
            else if (Range == "Demand By SalesChannel(%)")
            {
                return RedirectToAction("MarketbySalesChannelPercentChart", "MarketAnalysis", new
                {
                    product,
                    ChartType,
                    Range,
                    CompareProject,
                    Customer,
                    FromYear,
                    ToYear,
                    selectedLegends
                });
            }
            else if (Range == "Demand By GradePricing")
            {
                return RedirectToAction("MarketbyGradePricingChart", "MarketAnalysis", new
                {
                    product,
                    ChartType,
                    Range,
                    CompareProject,
                    Customer,
                    FromYear,
                    ToYear,
                    selectedLegends
                });
            }
            else if (Range == "Demand By Region(%)")
            {
                return RedirectToAction("MarketbyRegionPercentChart", "MarketAnalysis", new
                {
                    product,
                    ChartType,
                    Range,
                    CompareProject,
                    Customer,
                    FromYear,
                    ToYear,
                    selectedLegends
                });
            }
            else if (Range == "Demand By Region(T)")
            {
                return RedirectToAction("MarketbyRegionTonneChart", "MarketAnalysis", new
                {
                    product,
                    ChartType,
                    Range,
                    CompareProject,
                    Customer,
                    FromYear,
                    ToYear,
                    selectedLegends
                });
            }
            else if (Range == "Demand By TradeExport")
            {
                return RedirectToAction("MarketbyTradeExportChart", "MarketAnalysis", new
                {
                    product,
                    ChartType,
                    Range,
                    CompareProject,
                    Customer,
                    FromYear,
                    ToYear,
                    selectedLegends
                });
            }
            else if (Range == "Demand By TradeImport")
            {
                return RedirectToAction("MarketbyTradeImportChart", "MarketAnalysis", new
                {
                    product,
                    ChartType,
                    Range,
                    CompareProject,
                    Customer,
                    FromYear,
                    ToYear,
                    selectedLegends
                });
            }
            else if (Range == "Demand Supply Gap")
            {
                return RedirectToAction("MarketbySupplyGapChart", "MarketAnalysis", new
                {
                    product,
                    ChartType,
                    Range,
                    CompareProject,
                    Customer,
                    FromYear,
                    ToYear,
                    selectedLegends
                });
            }
            else if (Range == "Demand By CompanyShares(%)")
            {
                return RedirectToAction("MarketbyCompanySharesPercentChart", "MarketAnalysis", new
                {
                    product,
                    ChartType,
                    Range,
                    CompareProject,
                    Customer,
                    FromYear,
                    ToYear,
                    selectedLegends
                });
            }
            else if (Range == "Demand By CompanyShares(T)")
            {
                return RedirectToAction("MarketbyCompanySharesTonneChart", "MarketAnalysis", new
                {
                    product,
                    ChartType,
                    Range,
                    CompareProject,
                    Customer,
                    FromYear,
                    ToYear,
                    selectedLegends
                });
            }


            return RedirectToAction("index");
        }
        public ActionResult ShowUserChart(FormCollection FilterObject)
        {
            string product = FilterObject["ddlProduct"];
            string ChartType = FilterObject["ddlChart"];
            string Range = FilterObject["ddlRange"];
            string FromYear = FilterObject["ddlFyear"];
            string ToYear = FilterObject["ddlToYear"];
            string selectedLegends = FilterObject["hiddenLegends"];
            string CompareProject = FilterObject["example-getting-started"];
            bool Customer = true;
            if (Range == "Company")
            {
                return RedirectToAction("MarketbycompanyChart", "MarketAnalysis", new
                {
                    product,
                    ChartType,
                    Range,
                    CompareProject,
                    Customer,
                    FromYear,
                    ToYear,
                    selectedLegends
                });
                // ChecmPriceYearlyChartUser(product, ChartType, Range);
            }
            else if (Range == "Location")
            {
                return RedirectToAction("MarketbylocationChart", "MarketAnalysis", new
                {
                    product,
                    ChartType,
                    Range,
                    CompareProject,
                    Customer,
                    FromYear,
                    ToYear,
                    selectedLegends
                });
            }
            else if (Range == "Technology")
            {
                return RedirectToAction("MarketbyTechnologyChart", "MarketAnalysis", new
                {
                    product,
                    ChartType,
                    Range,
                    CompareProject,
                    Customer,
                    FromYear,
                    ToYear,
                    selectedLegends
                });
            }
            else if (Range == "Process")
            {
                return RedirectToAction("MarketbyProcessChart", "MarketAnalysis", new
                {
                    product,
                    ChartType,
                    Range,
                    CompareProject,
                    Customer,
                    FromYear,
                    ToYear,
                    selectedLegends
                });
            }
            else if (Range == "Production")
            {
                return RedirectToAction("MarketbyProductionChart", "MarketAnalysis", new
                {
                    product,
                    ChartType,
                    Range,
                    CompareProject,
                    Customer,
                    FromYear,
                    ToYear,
                    selectedLegends
                });
            }
            else if (Range == "Operating Efficiency")
            {
                return RedirectToAction("MarketbyEfficiencyChart", "MarketAnalysis", new
                {
                    product,
                    ChartType,
                    Range,
                    CompareProject,
                    Customer,
                    FromYear,
                    ToYear,
                    selectedLegends
                });
            }
            else if (Range == "Demand By EndUse(%)")
            {
                return RedirectToAction("MarketbyEndUsePercentChart", "MarketAnalysis", new
                {
                    product,
                    ChartType,
                    Range,
                    CompareProject,
                    Customer,
                    FromYear,
                    ToYear,
                    selectedLegends
                });
            }
            else if (Range == "Demand By EndUse(%)")
            {
                return RedirectToAction("MarketbyEndUsePercentChart", "MarketAnalysis", new
                {
                    product,
                    ChartType,
                    Range,
                    CompareProject,
                    Customer,
                    FromYear,
                    ToYear,
                    selectedLegends
                });
            }
            else if (Range == "Demand By EndUse(T)")
            {
                return RedirectToAction("MarketbyEndUseTonneChart", "MarketAnalysis", new
                {
                    product,
                    ChartType,
                    Range,
                    CompareProject,
                    Customer,
                    FromYear,
                    ToYear,
                    selectedLegends
                });
            }
            else if (Range == "Demand By Grade(%)")
            {
                return RedirectToAction("MarketbyGradePercentChart", "MarketAnalysis", new
                {
                    product,
                    ChartType,
                    Range,
                    CompareProject,
                    Customer,
                    FromYear,
                    ToYear,
                    selectedLegends
                });
            }
            else if (Range == "Demand By Grade(T)")
            {
                return RedirectToAction("MarketbyGradeTonneChart", "MarketAnalysis", new
                {
                    product,
                    ChartType,
                    Range,
                    CompareProject,
                    Customer,
                    FromYear,
                    ToYear,
                    selectedLegends
                });
            }
            else if (Range == "Demand By Type(%)")
            {
                return RedirectToAction("MarketbyTypePercentChart", "MarketAnalysis", new
                {
                    product,
                    ChartType,
                    Range,
                    CompareProject,
                    Customer,
                    FromYear,
                    ToYear,
                    selectedLegends
                });
            }
            else if (Range == "Demand By Type(T)")
            {
                return RedirectToAction("MarketbyTypeTonneChart", "MarketAnalysis", new
                {
                    product,
                    ChartType,
                    Range,
                    CompareProject,
                    Customer,
                    FromYear,
                    ToYear,
                    selectedLegends
                });
            }
            else if (Range == "Demand By SalesChannel(T)")
            {
                return RedirectToAction("MarketbySalesChannelTonneChart", "MarketAnalysis", new
                {
                    product,
                    ChartType,
                    Range,
                    CompareProject,
                    Customer,
                    FromYear,
                    ToYear,
                    selectedLegends
                });
            }
            else if (Range == "Demand By SalesChannel(%)")
            {
                return RedirectToAction("MarketbySalesChannelPercentChart", "MarketAnalysis", new
                {
                    product,
                    ChartType,
                    Range,
                    CompareProject,
                    Customer,
                    FromYear,
                    ToYear,
                    selectedLegends
                });
            }
            else if (Range == "Demand By GradePricing")
            {
                return RedirectToAction("MarketbyGradePricingChart", "MarketAnalysis", new
                {
                    product,
                    ChartType,
                    Range,
                    CompareProject,
                    Customer,
                    FromYear,
                    ToYear,
                    selectedLegends
                });
            }
            else if (Range == "Demand By Region(%)")
            {
                return RedirectToAction("MarketbyRegionPercentChart", "MarketAnalysis", new
                {
                    product,
                    ChartType,
                    Range,
                    CompareProject,
                    Customer,
                    FromYear,
                    ToYear,
                    selectedLegends
                });
            }
            else if (Range == "Demand By Region(T)")
            {
                return RedirectToAction("MarketbyRegionTonneChart", "MarketAnalysis", new
                {
                    product,
                    ChartType,
                    Range,
                    CompareProject,
                    Customer,
                    FromYear,
                    ToYear,
                    selectedLegends
                });
            }
            else if (Range == "Demand By TradeExport")
            {
                return RedirectToAction("MarketbyTradeExportChart", "MarketAnalysis", new
                {
                    product,
                    ChartType,
                    Range,
                    CompareProject,
                    Customer,
                    FromYear,
                    ToYear,
                    selectedLegends
                });
            }
            else if (Range == "Demand By TradeImport")
            {
                return RedirectToAction("MarketbyTradeImportChart", "MarketAnalysis", new
                {
                    product,
                    ChartType,
                    Range,
                    CompareProject,
                    Customer,
                    FromYear,
                    ToYear,
                    selectedLegends
                });
            }
            else if (Range == "Demand Supply Gap")
            {
                return RedirectToAction("MarketbySupplyGapChart", "MarketAnalysis", new
                {
                    product,
                    ChartType,
                    Range,
                    CompareProject,
                    Customer,
                    FromYear,
                    ToYear,
                    selectedLegends
                });
            }
            else if (Range == "Demand By CompanyShares(%)")
            {
                return RedirectToAction("MarketbyCompanySharesPercentChart", "MarketAnalysis", new
                {
                    product,
                    ChartType,
                    Range,
                    CompareProject,
                    Customer,
                    FromYear,
                    ToYear,
                    selectedLegends
                });
            }
            else if (Range == "Demand By CompanyShares(T)")
            {
                return RedirectToAction("MarketbyCompanySharesTonneChart", "MarketAnalysis", new
                {
                    product,
                    ChartType,
                    Range,
                    CompareProject,
                    Customer,
                    FromYear,
                    ToYear,
                    selectedLegends
                });
            }


            return RedirectToAction("index");
        }


        public ActionResult CompanyUpload(FormCollection formcollection)

        {
            ProductDataStore ObjProduct = new ProductDataStore();

            System.Data.DataTable dt = new System.Data.DataTable();
            string product = formcollection["hdproductid"];
            string ImportType = formcollection["Typelist"];
            string UploadFileDiscription = formcollection["UploadFileDiscription"];
            bool ReplaceData = Convert.ToBoolean(formcollection["ReplaceData"].Split(',')[0]);
            string productName = ObjProduct.GetProductByid(Convert.ToInt32(product)).ProductName;
            string path = string.Empty;
            for (int i = 0; i < Request.Files.Count; i++)
            {
                var file = Request.Files[i];

                if (file != null && file.ContentLength > 0)
                {

                    var fileName = Path.GetFileName(file.FileName);
                    if (ReplaceData)
                    {
                        int data = Marketanalysisobj.CheckExistingdata(fileName, ImportType);
                    }
                    else
                    {
                        int data = Marketanalysisobj.CheckFileuploadStatus(fileName, ImportType);
                        if (data == 1)
                        {
                            ViewBag.ProductList = ObjProduct.ProductList();
                            ViewBag.Status = "Fail";
                            ViewBag.Messge = "File is already mapped with " + ImportType + " Parameter.Kindly check if you want to Replace the existing file.";
                            return View("marketanalysisimport");
                        }

                    }
                    path = Path.Combine(Server.MapPath("~/MarketAnalysisImportfile"), fileName);
                    file.SaveAs(path);
                    if (ImportType == "Company")
                    {
                        var excel = new ExcelPackage(file.InputStream);
                        dt = excel.ToDataTable();
                        if (InsertCompExcelRecords(product, ImportType, UploadFileDiscription, path, dt, fileName) == true)
                        {
                            ViewBag.ProductList = ObjProduct.ProductList();
                            ViewBag.Status = "Success";
                            ViewBag.SuccesMessge = "File uploaded under " + productName + " & mapped with " + ImportType + " Successfully.";
                            return View("marketanalysisimport");
                        }
                        ViewBag.ProductList = ObjProduct.ProductList();
                        ViewBag.Status = "Success";
                        ViewBag.SuccesMessge = "File uploaded under " + productName + " & mapped with " + ImportType + " Successfully.";
                        return View("marketanalysisimport");
                    }
                    else if (ImportType == "Location")
                    {
                        var excel = new ExcelPackage(file.InputStream);
                        dt = excel.ToLocDataTable();
                        InsertLocExcelRecords(product, ImportType, UploadFileDiscription, path, dt, fileName);
                        ViewBag.ProductList = ObjProduct.ProductList();
                        ViewBag.Status = "Success";
                        ViewBag.SuccesMessge = "File uploaded under " + productName + " & mapped with " + ImportType + " Successfully.";
                        return View("marketanalysisimport");
                    }
                    else if (ImportType == "Technology")
                    {
                        var excel = new ExcelPackage(file.InputStream);
                        dt = excel.ToLocDataTable();
                        InsertTechnologyExcelRecords(product, ImportType, UploadFileDiscription, path, dt, fileName);
                        ViewBag.ProductList = ObjProduct.ProductList();
                        ViewBag.Status = "Success";
                        ViewBag.SuccesMessge = "File uploaded under " + productName + " & mapped with " + ImportType + " Successfully.";
                        return View("marketanalysisimport");
                    }
                    else if (ImportType == "Process")
                    {
                        var excel = new ExcelPackage(file.InputStream);
                        dt = excel.ToLocDataTable();
                        InsertProcessExcelRecords(product, ImportType, UploadFileDiscription, path, dt, fileName);
                        ViewBag.ProductList = ObjProduct.ProductList();
                        ViewBag.Status = "Success";
                        ViewBag.SuccesMessge = "File uploaded under " + productName + " & mapped with " + ImportType + " Successfully.";
                        return View("marketanalysisimport");
                    }
                    else if (ImportType == "Demand By GradePricing")
                    {
                        var excel = new ExcelPackage(file.InputStream);
                        dt = excel.ToLocDataTable();
                        InsertGradepricingExcelRecords(product, ImportType, UploadFileDiscription, path, dt, fileName);
                        ViewBag.ProductList = ObjProduct.ProductList();
                        ViewBag.Status = "Success";
                        ViewBag.SuccesMessge = "File uploaded under " + productName + " & mapped with " + ImportType + " Successfully.";
                        return View("marketanalysisimport");
                    }
                    else if (ImportType == "Demand By TradeExport")
                    {
                        var excel = new ExcelPackage(file.InputStream);
                        dt = excel.ToLocDataTable();
                        InsertDemandByTradeExportExcelRecords(product, ImportType, UploadFileDiscription, path, dt, fileName);
                        ViewBag.ProductList = ObjProduct.ProductList();
                        ViewBag.Status = "Success";
                        ViewBag.SuccesMessge = "File uploaded under " + productName + " & mapped with " + ImportType + " Successfully.";
                        return View("marketanalysisimport");
                    }
                    else if (ImportType == "Demand By TradeImport")
                    {
                        var excel = new ExcelPackage(file.InputStream);
                        dt = excel.ToLocDataTable();
                        InsertDemandByTradeImportExcelRecords(product, ImportType, UploadFileDiscription, path, dt, fileName);
                        ViewBag.ProductList = ObjProduct.ProductList();
                        ViewBag.Status = "Success";
                        ViewBag.SuccesMessge = "File uploaded under " + productName + " & mapped with " + ImportType + " Successfully.";
                        return View("marketanalysisimport");
                    }
                    else if (ImportType == "Production")
                    {
                        var excel = new ExcelPackage(file.InputStream);
                        dt = excel.ToDataTable();
                        InsertProductionExcelRecords(product, ImportType, UploadFileDiscription, path, dt, fileName);
                        ViewBag.ProductList = ObjProduct.ProductList();
                        ViewBag.Status = "Success";
                        ViewBag.SuccesMessge = "File uploaded under " + productName + " & mapped with " + ImportType + " Successfully.";
                        return View("marketanalysisimport");
                    }
                    else if (ImportType == "Demand By CompanyShares(%)")
                    {
                        var excel = new ExcelPackage(file.InputStream);
                        dt = excel.ToDataTable();
                        InsertCompanySharepercentExcelRecords(product, ImportType, UploadFileDiscription, path, dt, fileName);
                        ViewBag.ProductList = ObjProduct.ProductList();
                        ViewBag.Status = "Success";
                        ViewBag.SuccesMessge = "File uploaded under " + productName + " & mapped with " + ImportType + " Successfully.";
                        return View("marketanalysisimport");
                    }
                    else if (ImportType == "Demand By CompanyShares(T)")
                    {
                        var excel = new ExcelPackage(file.InputStream);
                        dt = excel.ToDataTable();
                        InsertCompanySharetonnesExcelRecords(product, ImportType, UploadFileDiscription, path, dt, fileName);
                        ViewBag.ProductList = ObjProduct.ProductList();
                        ViewBag.Status = "Success";
                        ViewBag.SuccesMessge = "File uploaded under " + productName + " & mapped with " + ImportType + " Successfully.";
                        return View("marketanalysisimport");
                    }
                    else if (ImportType == "Operating Efficiency")
                    {
                        var excel = new ExcelPackage(file.InputStream);
                        dt = excel.ToDataTable();
                        InsertEfficiencyExcelRecords(product, ImportType, UploadFileDiscription, path, dt, fileName);
                        ViewBag.ProductList = ObjProduct.ProductList();
                        ViewBag.Status = "Success";
                        ViewBag.SuccesMessge = "File uploaded under " + productName + " & mapped with " + ImportType + " Successfully.";
                        return View("marketanalysisimport");
                    }
                    else if (ImportType == "Demand By EndUse(%)")
                    {
                        var excel = new ExcelPackage(file.InputStream);
                        dt = excel.ToDataTable();
                        InsertEndUsepercentExcelRecords(product, ImportType, UploadFileDiscription, path, dt, fileName);
                        ViewBag.ProductList = ObjProduct.ProductList();
                        ViewBag.Status = "Success";
                        ViewBag.SuccesMessge = "File uploaded under " + productName + " & mapped with " + ImportType + " Successfully.";
                        return View("marketanalysisimport");
                    }
                    else if (ImportType == "Demand By EndUse(T)")
                    {
                        var excel = new ExcelPackage(file.InputStream);
                        dt = excel.ToDataTable();
                        InsertEndUsetonnesExcelRecords(product, ImportType, UploadFileDiscription, path, dt, fileName);
                        ViewBag.ProductList = ObjProduct.ProductList();
                        ViewBag.Status = "Success";
                        ViewBag.SuccesMessge = "File uploaded under " + productName + " & mapped with " + ImportType + " Successfully.";
                        return View("marketanalysisimport");
                    }
                    else if (ImportType == "Demand By Grade(%)")
                    {
                        var excel = new ExcelPackage(file.InputStream);
                        dt = excel.ToDataTable();
                        InsertGradepercentExcelRecords(product, ImportType, UploadFileDiscription, path, dt, fileName);
                        ViewBag.ProductList = ObjProduct.ProductList();
                        ViewBag.Status = "Success";
                        ViewBag.SuccesMessge = "File uploaded under " + productName + " & mapped with " + ImportType + " Successfully.";
                        return View("marketanalysisimport");
                    }
                    else if (ImportType == "Demand By Grade(T)")
                    {
                        var excel = new ExcelPackage(file.InputStream);
                        dt = excel.ToDataTable();
                        InsertGradetonnesExcelRecords(product, ImportType, UploadFileDiscription, path, dt, fileName);
                        ViewBag.ProductList = ObjProduct.ProductList();
                        ViewBag.Status = "Success";
                        ViewBag.SuccesMessge = "File uploaded under " + productName + " & mapped with " + ImportType + " Successfully.";
                        return View("marketanalysisimport");
                    }
                    else if (ImportType == "Demand By Region(%)")
                    {
                        var excel = new ExcelPackage(file.InputStream);
                        dt = excel.ToDataTable();
                        InsertRegionpercentExcelRecords(product, ImportType, UploadFileDiscription, path, dt, fileName);
                        ViewBag.ProductList = ObjProduct.ProductList();
                        ViewBag.Status = "Success";
                        ViewBag.SuccesMessge = "File uploaded under " + productName + " & mapped with " + ImportType + " Successfully.";
                        return View("marketanalysisimport");
                    }
                    else if (ImportType == "Demand By Region(T)")
                    {
                        var excel = new ExcelPackage(file.InputStream);
                        dt = excel.ToDataTable();
                        InsertRegiontonnesExcelRecords(product, ImportType, UploadFileDiscription, path, dt, fileName);
                        ViewBag.ProductList = ObjProduct.ProductList();
                        ViewBag.Status = "Success";
                        ViewBag.SuccesMessge = "File uploaded under " + productName + " & mapped with " + ImportType + " Successfully.";
                        return View("marketanalysisimport");
                    }
                    else if (ImportType == "Demand By SalesChannel(%)")
                    {
                        var excel = new ExcelPackage(file.InputStream);
                        dt = excel.ToDataTable();
                        InsertSalespercentExcelRecords(product, ImportType, UploadFileDiscription, path, dt, fileName);
                        ViewBag.ProductList = ObjProduct.ProductList();
                        ViewBag.Status = "Success";
                        ViewBag.SuccesMessge = "File uploaded under " + productName + " & mapped with " + ImportType + " Successfully.";
                        return View("marketanalysisimport");
                    }
                    else if (ImportType == "Demand By SalesChannel(T)")
                    {
                        var excel = new ExcelPackage(file.InputStream);
                        dt = excel.ToDataTable();
                        InsertSalestonnesExcelRecords(product, ImportType, UploadFileDiscription, path, dt, fileName);
                        ViewBag.ProductList = ObjProduct.ProductList();
                        ViewBag.Status = "Success";
                        ViewBag.SuccesMessge = "File uploaded under " + productName + " & mapped with " + ImportType + " Successfully.";
                        return View("marketanalysisimport");
                    }
                    else if (ImportType == "Demand By Type(%)")
                    {
                        var excel = new ExcelPackage(file.InputStream);
                        dt = excel.ToDataTable();
                        InsertTypepercentExcelRecords(product, ImportType, UploadFileDiscription, path, dt, fileName);
                        ViewBag.ProductList = ObjProduct.ProductList();
                        ViewBag.Status = "Success";
                        ViewBag.SuccesMessge = "File uploaded under " + productName + " & mapped with " + ImportType + " Successfully.";
                        return View("marketanalysisimport");
                    }
                    else if (ImportType == "Demand By Type(T)")
                    {
                        var excel = new ExcelPackage(file.InputStream);
                        dt = excel.ToDataTable();
                        InsertTypetonnesExcelRecords(product, ImportType, UploadFileDiscription, path, dt, fileName);
                        ViewBag.ProductList = ObjProduct.ProductList();
                        ViewBag.Status = "Success";
                        ViewBag.SuccesMessge = "File uploaded under " + productName + " & mapped with " + ImportType + " Successfully.";
                        return View("marketanalysisimport");
                    }
                    else if (ImportType == "Demand Supply Gap")
                    {
                        var excel = new ExcelPackage(file.InputStream);
                        dt = excel.ToDataTable();
                        InsertDemandsupplyExcelRecords(product, ImportType, UploadFileDiscription, path, dt, fileName);
                        ViewBag.ProductList = ObjProduct.ProductList();
                        ViewBag.Status = "Success";
                        ViewBag.SuccesMessge = "File uploaded under " + productName + " & mapped with " + ImportType + " Successfully.";
                        return View("marketanalysisimport");
                    }
                    else if (ImportType == "Demand Supply Gap Graph")
                    {
                        var excel = new ExcelPackage(file.InputStream);
                        dt = excel.ToDataTable();
                        InsertDemandsupplyGraphExcelRecords(product, ImportType, UploadFileDiscription, path, dt, fileName);
                        ViewBag.ProductList = ObjProduct.ProductList();
                        ViewBag.Status = "Success";
                        ViewBag.SuccesMessge = "File uploaded under " + productName + " & mapped with " + ImportType + " Successfully.";
                        return View("marketanalysisimport");
                    }

                }
            }
            ViewBag.ProductList = ObjProduct.ProductList();
            ViewBag.Status = "Success";
            ViewBag.SuccesMessge = "File uploaded under " + productName + " & mapped with " + ImportType + " Successfully.";
            return RedirectToAction("Index");
        }

        #region Insert data function from admin upload

        private bool InsertCompExcelRecords(string product, string type, string UploadFileDiscription, string path, System.Data.DataTable Exceldt, string fileName)
        {

            try
            {
                // string connStr = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;

                // string constr = string.Format(connStr, path);
                //  ExcelConn(_path);  C:\Users\AVI Nishad\Desktop\test1.xlsx
                //string constr = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + ";" + @"Extended Properties='Excel 12.0;HDR=Yes;'";
                // OleDbConnection Econ = new OleDbConnection(constr);
                // string Query = string.Format("Select [Product Name],[Year],[count] FROM [{0}]", "Sheet1$");
                // OleDbCommand Ecom = new OleDbCommand(Query, Econ);
                //Econ.Open();

                // DataSet ds = new DataSet();
                //OleDbDataAdapter oda = new OleDbDataAdapter(Query, Econ);
                //Econ.Close();
                //oda.Fill(ds);
                //System.Data.DataTable Exceldt = ds.Tables[0];
                Exceldt.Columns.Add("Product", typeof(int));
                Exceldt.Columns.Add("Discription", typeof(string));
                Exceldt.Columns.Add("FileName", typeof(string));
                Exceldt.Columns.Add("CreatedDate", typeof(DateTime));
                for (int i = Exceldt.Rows.Count - 1; i >= 0; i--)
                {
                    if (Exceldt.Rows[i]["Company"] == DBNull.Value || Exceldt.Rows[i]["Year"] == DBNull.Value || Exceldt.Rows[i]["count"] == DBNull.Value)
                    {
                        Exceldt.Rows[i].Delete();
                    }
                    else
                    {
                        Exceldt.Rows[i]["Product"] = product;
                        Exceldt.Rows[i]["Discription"] = UploadFileDiscription;
                        Exceldt.Rows[i]["FileName"] = fileName;
                        Exceldt.Rows[i]["CreatedDate"] = DateTime.Now;
                    }
                }
                Exceldt.AcceptChanges();
                string productid = Exceldt.Rows[0]["Company"].ToString();
                string year = Exceldt.Rows[0]["Year"].ToString();

                //if (Chempriceobj.CheckExistingdata(product, year) > 0)
                //{
                //    return true;
                //}
                //inserting Datatable Records to DataBase   
                var connectionString = ConfigurationManager.ConnectionStrings["ChemAnalystContext"].ConnectionString;
                SqlConnection sqlConnection = new SqlConnection();
                sqlConnection.ConnectionString = connectionString;//Connection Details  
                                                                  //creating object of SqlBulkCopy      
                SqlBulkCopy objbulk = new SqlBulkCopy(sqlConnection);
                //assigning Destination table name      
                objbulk.DestinationTableName = "SA_MarketbyComp";
                //Mapping Table column    
                objbulk.ColumnMappings.Add("[Product]", "Product");
                objbulk.ColumnMappings.Add("[Company]", "Company");
                objbulk.ColumnMappings.Add("[Year]", "year");
                objbulk.ColumnMappings.Add("[count]", "count");
                objbulk.ColumnMappings.Add("[Discription]", "Discription");
                objbulk.ColumnMappings.Add("[FileName]", "FileName");
                objbulk.ColumnMappings.Add("[CreatedDate]", "CreatedDate");

                sqlConnection.Open();
                objbulk.WriteToServer(Exceldt);
                sqlConnection.Close();
                //  MessageBox.Show("Data has been Imported successfully.", "Imported", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                //  MessageBox.Show(string.Format("Data has not been Imported due to :{0}", ex.Message), "Not Imported", MessageBoxButtons.OK, MessageBoxIcon.Warning);



            }
            return false;

        }

        private bool InsertProductionExcelRecords(string product, string type, string UploadFileDiscription, string path, System.Data.DataTable Exceldt, string fileName)
        {
            try
            {
                Exceldt.Columns.Add("Product", typeof(int));
                Exceldt.Columns.Add("Discription", typeof(string));
                Exceldt.Columns.Add("FileName", typeof(string));
                Exceldt.Columns.Add("CreatedDate", typeof(DateTime));
                for (int i = Exceldt.Rows.Count - 1; i >= 0; i--)
                {
                    if (Exceldt.Rows[i]["Producer"] == DBNull.Value || Exceldt.Rows[i]["Year"] == DBNull.Value || Exceldt.Rows[i]["count"] == DBNull.Value)
                    {
                        Exceldt.Rows[i].Delete();
                    }
                    else
                    {
                        Exceldt.Rows[i]["Product"] = product;
                        Exceldt.Rows[i]["Discription"] = UploadFileDiscription;
                        Exceldt.Rows[i]["FileName"] = fileName;
                        Exceldt.Rows[i]["CreatedDate"] = DateTime.Now;
                    }
                }
                Exceldt.AcceptChanges();
                string productid = Exceldt.Rows[0]["Producer"].ToString();
                string year = Exceldt.Rows[0]["Year"].ToString();

                var connectionString = ConfigurationManager.ConnectionStrings["ChemAnalystContext"].ConnectionString;
                SqlConnection sqlConnection = new SqlConnection();

                //Connection Details  
                sqlConnection.ConnectionString = connectionString;

                //creating object of SqlBulkCopy      
                SqlBulkCopy objbulk = new SqlBulkCopy(sqlConnection);

                //assigning Destination table name      
                objbulk.DestinationTableName = "SA_MarketbyProducer";

                //Mapping Table column    
                objbulk.ColumnMappings.Add("[Product]", "Product");
                objbulk.ColumnMappings.Add("[Producer]", "Producer");
                objbulk.ColumnMappings.Add("[Year]", "year");
                objbulk.ColumnMappings.Add("[count]", "count");
                objbulk.ColumnMappings.Add("[Discription]", "Discription");
                objbulk.ColumnMappings.Add("[FileName]", "FileName");
                objbulk.ColumnMappings.Add("[CreatedDate]", "CreatedDate");

                sqlConnection.Open();
                objbulk.WriteToServer(Exceldt);
                sqlConnection.Close();
            }
            catch (Exception ex)
            {

            }
            return false;
        }

        private bool InsertCompanySharepercentExcelRecords(string product, string type, string UploadFileDiscription, string path, System.Data.DataTable Exceldt, string fileName)
        {
            try
            {
                Exceldt.Columns.Add("Product", typeof(int));
                Exceldt.Columns.Add("Discription", typeof(string));
                Exceldt.Columns.Add("FileName", typeof(string));
                Exceldt.Columns.Add("CreatedDate", typeof(DateTime));
                for (int i = Exceldt.Rows.Count - 1; i >= 0; i--)
                {
                    if (Exceldt.Rows[i]["Company"] == DBNull.Value || Exceldt.Rows[i]["Year"] == DBNull.Value || Exceldt.Rows[i]["count"] == DBNull.Value)
                    {
                        Exceldt.Rows[i].Delete();
                    }
                    else
                    {
                        Exceldt.Rows[i]["Product"] = product;
                        Exceldt.Rows[i]["Discription"] = UploadFileDiscription;
                        Exceldt.Rows[i]["FileName"] = fileName;
                        Exceldt.Rows[i]["CreatedDate"] = DateTime.Now;
                    }
                }
                Exceldt.AcceptChanges();
                string productid = Exceldt.Rows[0]["Company"].ToString();
                string year = Exceldt.Rows[0]["Year"].ToString();

                var connectionString = ConfigurationManager.ConnectionStrings["ChemAnalystContext"].ConnectionString;
                SqlConnection sqlConnection = new SqlConnection();

                //Connection Details  
                sqlConnection.ConnectionString = connectionString;

                //creating object of SqlBulkCopy      
                SqlBulkCopy objbulk = new SqlBulkCopy(sqlConnection);

                //assigning Destination table name      
                objbulk.DestinationTableName = "SA_MarketbyCompanySharepercent";

                //Mapping Table column    
                objbulk.ColumnMappings.Add("[Product]", "Product");
                objbulk.ColumnMappings.Add("[Company]", "Company");
                objbulk.ColumnMappings.Add("[Year]", "year");
                objbulk.ColumnMappings.Add("[count]", "count");
                objbulk.ColumnMappings.Add("[Discription]", "Discription");
                objbulk.ColumnMappings.Add("[FileName]", "FileName");
                objbulk.ColumnMappings.Add("[CreatedDate]", "CreatedDate");

                sqlConnection.Open();
                objbulk.WriteToServer(Exceldt);
                sqlConnection.Close();
            }
            catch (Exception ex)
            {

            }
            return false;
        }

        private bool InsertCompanySharetonnesExcelRecords(string product, string type, string UploadFileDiscription, string path, System.Data.DataTable Exceldt, string fileName)
        {
            try
            {
                Exceldt.Columns.Add("Product", typeof(int));
                Exceldt.Columns.Add("Discription", typeof(string));
                Exceldt.Columns.Add("FileName", typeof(string));
                Exceldt.Columns.Add("CreatedDate", typeof(DateTime));
                for (int i = Exceldt.Rows.Count - 1; i >= 0; i--)
                {
                    if (Exceldt.Rows[i]["Company"] == DBNull.Value || Exceldt.Rows[i]["Year"] == DBNull.Value || Exceldt.Rows[i]["count"] == DBNull.Value)
                    {
                        Exceldt.Rows[i].Delete();
                    }
                    else
                    {
                        Exceldt.Rows[i]["Product"] = product;
                        Exceldt.Rows[i]["Discription"] = UploadFileDiscription;
                        Exceldt.Rows[i]["FileName"] = fileName;
                        Exceldt.Rows[i]["CreatedDate"] = DateTime.Now;
                    }
                }
                Exceldt.AcceptChanges();
                string productid = Exceldt.Rows[0]["Company"].ToString();
                string year = Exceldt.Rows[0]["Year"].ToString();

                var connectionString = ConfigurationManager.ConnectionStrings["ChemAnalystContext"].ConnectionString;
                SqlConnection sqlConnection = new SqlConnection();

                //Connection Details  
                sqlConnection.ConnectionString = connectionString;

                //creating object of SqlBulkCopy      
                SqlBulkCopy objbulk = new SqlBulkCopy(sqlConnection);

                //assigning Destination table name      
                objbulk.DestinationTableName = "SA_MarketbyCompanySharetonnes";

                //Mapping Table column    
                objbulk.ColumnMappings.Add("[Product]", "Product");
                objbulk.ColumnMappings.Add("[Company]", "Company");
                objbulk.ColumnMappings.Add("[Year]", "year");
                objbulk.ColumnMappings.Add("[count]", "count");
                objbulk.ColumnMappings.Add("[Discription]", "Discription");
                objbulk.ColumnMappings.Add("[FileName]", "FileName");
                objbulk.ColumnMappings.Add("[CreatedDate]", "CreatedDate");

                sqlConnection.Open();
                objbulk.WriteToServer(Exceldt);
                sqlConnection.Close();
            }
            catch (Exception ex)
            {

            }
            return false;
        }

        private bool InsertEfficiencyExcelRecords(string product, string type, string UploadFileDiscription, string path, System.Data.DataTable Exceldt, string fileName)
        {
            try
            {
                Exceldt.Columns.Add("Product", typeof(int));
                Exceldt.Columns.Add("Discription", typeof(string));
                Exceldt.Columns.Add("FileName", typeof(string));
                Exceldt.Columns.Add("CreatedDate", typeof(DateTime));
                for (int i = Exceldt.Rows.Count - 1; i >= 0; i--)
                {
                    if (Exceldt.Rows[i]["Producer"] == DBNull.Value || Exceldt.Rows[i]["Year"] == DBNull.Value || Exceldt.Rows[i]["count"] == DBNull.Value)
                    {
                        Exceldt.Rows[i].Delete();
                    }
                    else
                    {
                        Exceldt.Rows[i]["Product"] = product;
                        Exceldt.Rows[i]["Discription"] = UploadFileDiscription;
                        Exceldt.Rows[i]["FileName"] = fileName;
                        Exceldt.Rows[i]["CreatedDate"] = DateTime.Now;
                    }
                }
                Exceldt.AcceptChanges();
                string productid = Exceldt.Rows[0]["Producer"].ToString();
                string year = Exceldt.Rows[0]["Year"].ToString();

                var connectionString = ConfigurationManager.ConnectionStrings["ChemAnalystContext"].ConnectionString;
                SqlConnection sqlConnection = new SqlConnection();

                //Connection Details  
                sqlConnection.ConnectionString = connectionString;

                //creating object of SqlBulkCopy      
                SqlBulkCopy objbulk = new SqlBulkCopy(sqlConnection);

                //assigning Destination table name      
                objbulk.DestinationTableName = "SA_MarketbyEfficiency";

                //Mapping Table column    
                objbulk.ColumnMappings.Add("[Product]", "Product");
                objbulk.ColumnMappings.Add("[Producer]", "Producer");
                objbulk.ColumnMappings.Add("[Year]", "year");
                objbulk.ColumnMappings.Add("[count]", "count");
                objbulk.ColumnMappings.Add("[Discription]", "Discription");
                objbulk.ColumnMappings.Add("[FileName]", "FileName");
                objbulk.ColumnMappings.Add("[CreatedDate]", "CreatedDate");

                sqlConnection.Open();
                objbulk.WriteToServer(Exceldt);
                sqlConnection.Close();
            }
            catch (Exception ex)
            {

            }
            return false;
        }

        private bool InsertEndUsepercentExcelRecords(string product, string type, string UploadFileDiscription, string path, System.Data.DataTable Exceldt, string fileName)
        {
            try
            {
                Exceldt.Columns.Add("Product", typeof(int));
                Exceldt.Columns.Add("Discription", typeof(string));
                Exceldt.Columns.Add("FileName", typeof(string));
                Exceldt.Columns.Add("CreatedDate", typeof(DateTime));
                for (int i = Exceldt.Rows.Count - 1; i >= 0; i--)
                {
                    if (Exceldt.Rows[i]["Enduse"] == DBNull.Value || Exceldt.Rows[i]["Year"] == DBNull.Value || Exceldt.Rows[i]["count"] == DBNull.Value)
                    {
                        Exceldt.Rows[i].Delete();
                    }
                    else
                    {
                        Exceldt.Rows[i]["Product"] = product;
                        Exceldt.Rows[i]["Discription"] = UploadFileDiscription;
                        Exceldt.Rows[i]["FileName"] = fileName;
                        Exceldt.Rows[i]["CreatedDate"] = DateTime.Now;
                    }
                }
                Exceldt.AcceptChanges();
                string productid = Exceldt.Rows[0]["Enduse"].ToString();
                string year = Exceldt.Rows[0]["Year"].ToString();

                var connectionString = ConfigurationManager.ConnectionStrings["ChemAnalystContext"].ConnectionString;
                SqlConnection sqlConnection = new SqlConnection();

                //Connection Details  
                sqlConnection.ConnectionString = connectionString;

                //creating object of SqlBulkCopy      
                SqlBulkCopy objbulk = new SqlBulkCopy(sqlConnection);

                //assigning Destination table name      
                objbulk.DestinationTableName = "SA_MarketbyEndUsepercent";

                //Mapping Table column    
                objbulk.ColumnMappings.Add("[Product]", "Product");
                objbulk.ColumnMappings.Add("[Enduse]", "Enduse");
                objbulk.ColumnMappings.Add("[Year]", "year");
                objbulk.ColumnMappings.Add("[count]", "count");
                objbulk.ColumnMappings.Add("[Discription]", "Discription");
                objbulk.ColumnMappings.Add("[FileName]", "FileName");
                objbulk.ColumnMappings.Add("[CreatedDate]", "CreatedDate");

                sqlConnection.Open();
                objbulk.WriteToServer(Exceldt);
                sqlConnection.Close();
            }
            catch (Exception ex)
            {

            }
            return false;
        }

        private bool InsertEndUsetonnesExcelRecords(string product, string type, string UploadFileDiscription, string path, System.Data.DataTable Exceldt, string fileName)
        {
            try
            {
                Exceldt.Columns.Add("Product", typeof(int));
                Exceldt.Columns.Add("Discription", typeof(string));
                Exceldt.Columns.Add("FileName", typeof(string));
                Exceldt.Columns.Add("CreatedDate", typeof(DateTime));
                for (int i = Exceldt.Rows.Count - 1; i >= 0; i--)
                {
                    if (Exceldt.Rows[i]["Enduse"] == DBNull.Value || Exceldt.Rows[i]["Year"] == DBNull.Value || Exceldt.Rows[i]["count"] == DBNull.Value)
                    {
                        Exceldt.Rows[i].Delete();
                    }
                    else
                    {
                        Exceldt.Rows[i]["Product"] = product;
                        Exceldt.Rows[i]["Discription"] = UploadFileDiscription;
                        Exceldt.Rows[i]["FileName"] = fileName;
                        Exceldt.Rows[i]["CreatedDate"] = DateTime.Now;
                    }
                }
                Exceldt.AcceptChanges();
                string productid = Exceldt.Rows[0]["Enduse"].ToString();
                string year = Exceldt.Rows[0]["Year"].ToString();

                var connectionString = ConfigurationManager.ConnectionStrings["ChemAnalystContext"].ConnectionString;
                SqlConnection sqlConnection = new SqlConnection();

                //Connection Details  
                sqlConnection.ConnectionString = connectionString;

                //creating object of SqlBulkCopy      
                SqlBulkCopy objbulk = new SqlBulkCopy(sqlConnection);

                //assigning Destination table name      
                objbulk.DestinationTableName = "SA_MarketbyEndUsetonnes";

                //Mapping Table column    
                objbulk.ColumnMappings.Add("[Product]", "Product");
                objbulk.ColumnMappings.Add("[Enduse]", "Enduse");
                objbulk.ColumnMappings.Add("[Year]", "year");
                objbulk.ColumnMappings.Add("[count]", "count");
                objbulk.ColumnMappings.Add("[Discription]", "Discription");
                objbulk.ColumnMappings.Add("[FileName]", "FileName");
                objbulk.ColumnMappings.Add("[CreatedDate]", "CreatedDate");

                sqlConnection.Open();
                objbulk.WriteToServer(Exceldt);
                sqlConnection.Close();
            }
            catch (Exception ex)
            {

            }
            return false;
        }

        private bool InsertGradepercentExcelRecords(string product, string type, string UploadFileDiscription, string path, System.Data.DataTable Exceldt, string fileName)
        {
            try
            {
                Exceldt.Columns.Add("Product", typeof(int));
                Exceldt.Columns.Add("Discription", typeof(string));
                Exceldt.Columns.Add("FileName", typeof(string));
                Exceldt.Columns.Add("CreatedDate", typeof(DateTime));
                for (int i = Exceldt.Rows.Count - 1; i >= 0; i--)
                {
                    if (Exceldt.Rows[i]["Grade"] == DBNull.Value || Exceldt.Rows[i]["Year"] == DBNull.Value || Exceldt.Rows[i]["count"] == DBNull.Value)
                    {
                        Exceldt.Rows[i].Delete();
                    }
                    else
                    {
                        Exceldt.Rows[i]["Product"] = product;
                        Exceldt.Rows[i]["Discription"] = UploadFileDiscription;
                        Exceldt.Rows[i]["FileName"] = fileName;
                        Exceldt.Rows[i]["CreatedDate"] = DateTime.Now;
                    }
                }
                Exceldt.AcceptChanges();
                string productid = Exceldt.Rows[0]["Grade"].ToString();
                string year = Exceldt.Rows[0]["Year"].ToString();

                var connectionString = ConfigurationManager.ConnectionStrings["ChemAnalystContext"].ConnectionString;
                SqlConnection sqlConnection = new SqlConnection();

                //Connection Details  
                sqlConnection.ConnectionString = connectionString;

                //creating object of SqlBulkCopy      
                SqlBulkCopy objbulk = new SqlBulkCopy(sqlConnection);

                //assigning Destination table name      
                objbulk.DestinationTableName = "SA_MarketbyGradepercent";

                //Mapping Table column    
                objbulk.ColumnMappings.Add("[Product]", "Product");
                objbulk.ColumnMappings.Add("[Grade]", "Grade");
                objbulk.ColumnMappings.Add("[Year]", "year");
                objbulk.ColumnMappings.Add("[count]", "count");
                objbulk.ColumnMappings.Add("[Discription]", "Discription");
                objbulk.ColumnMappings.Add("[FileName]", "FileName");
                objbulk.ColumnMappings.Add("[CreatedDate]", "CreatedDate");

                sqlConnection.Open();
                objbulk.WriteToServer(Exceldt);
                sqlConnection.Close();
            }
            catch (Exception ex)
            {

            }
            return false;
        }

        private bool InsertGradetonnesExcelRecords(string product, string type, string UploadFileDiscription, string path, System.Data.DataTable Exceldt, string fileName)
        {
            try
            {
                Exceldt.Columns.Add("Product", typeof(int));
                Exceldt.Columns.Add("Discription", typeof(string));
                Exceldt.Columns.Add("FileName", typeof(string));
                Exceldt.Columns.Add("CreatedDate", typeof(DateTime));
                for (int i = Exceldt.Rows.Count - 1; i >= 0; i--)
                {
                    if (Exceldt.Rows[i]["Grade"] == DBNull.Value || Exceldt.Rows[i]["Year"] == DBNull.Value || Exceldt.Rows[i]["count"] == DBNull.Value)
                    {
                        Exceldt.Rows[i].Delete();
                    }
                    else
                    {
                        Exceldt.Rows[i]["Product"] = product;
                        Exceldt.Rows[i]["Discription"] = UploadFileDiscription;
                        Exceldt.Rows[i]["FileName"] = fileName;
                        Exceldt.Rows[i]["CreatedDate"] = DateTime.Now;
                    }
                }
                Exceldt.AcceptChanges();
                string productid = Exceldt.Rows[0]["Grade"].ToString();
                string year = Exceldt.Rows[0]["Year"].ToString();

                var connectionString = ConfigurationManager.ConnectionStrings["ChemAnalystContext"].ConnectionString;
                SqlConnection sqlConnection = new SqlConnection();

                //Connection Details  
                sqlConnection.ConnectionString = connectionString;

                //creating object of SqlBulkCopy      
                SqlBulkCopy objbulk = new SqlBulkCopy(sqlConnection);

                //assigning Destination table name      
                objbulk.DestinationTableName = "SA_MarketbyGradetonnes";

                //Mapping Table column    
                objbulk.ColumnMappings.Add("[Product]", "Product");
                objbulk.ColumnMappings.Add("[Grade]", "Grade");
                objbulk.ColumnMappings.Add("[Year]", "year");
                objbulk.ColumnMappings.Add("[count]", "count");
                objbulk.ColumnMappings.Add("[Discription]", "Discription");
                objbulk.ColumnMappings.Add("[FileName]", "FileName");
                objbulk.ColumnMappings.Add("[CreatedDate]", "CreatedDate");

                sqlConnection.Open();
                objbulk.WriteToServer(Exceldt);
                sqlConnection.Close();
            }
            catch (Exception ex)
            {

            }
            return false;
        }

        private bool InsertRegionpercentExcelRecords(string product, string type, string UploadFileDiscription, string path, System.Data.DataTable Exceldt, string fileName)
        {
            try
            {
                Exceldt.Columns.Add("Product", typeof(int));
                Exceldt.Columns.Add("Discription", typeof(string));
                Exceldt.Columns.Add("FileName", typeof(string));
                Exceldt.Columns.Add("CreatedDate", typeof(DateTime));
                for (int i = Exceldt.Rows.Count - 1; i >= 0; i--)
                {
                    if (Exceldt.Rows[i]["Region"] == DBNull.Value || Exceldt.Rows[i]["Year"] == DBNull.Value || Exceldt.Rows[i]["count"] == DBNull.Value)
                    {
                        Exceldt.Rows[i].Delete();
                    }
                    else
                    {
                        Exceldt.Rows[i]["Product"] = product;
                        Exceldt.Rows[i]["Discription"] = UploadFileDiscription;
                        Exceldt.Rows[i]["FileName"] = fileName;
                        Exceldt.Rows[i]["CreatedDate"] = DateTime.Now;
                    }
                }
                Exceldt.AcceptChanges();
                string productid = Exceldt.Rows[0]["Region"].ToString();
                string year = Exceldt.Rows[0]["Year"].ToString();

                var connectionString = ConfigurationManager.ConnectionStrings["ChemAnalystContext"].ConnectionString;
                SqlConnection sqlConnection = new SqlConnection();

                //Connection Details  
                sqlConnection.ConnectionString = connectionString;

                //creating object of SqlBulkCopy      
                SqlBulkCopy objbulk = new SqlBulkCopy(sqlConnection);

                //assigning Destination table name      
                objbulk.DestinationTableName = "SA_MarketbyRegionpercent";

                //Mapping Table column    
                objbulk.ColumnMappings.Add("[Product]", "Product");
                objbulk.ColumnMappings.Add("[Region]", "Region");
                objbulk.ColumnMappings.Add("[Year]", "year");
                objbulk.ColumnMappings.Add("[count]", "count");
                objbulk.ColumnMappings.Add("[Discription]", "Discription");
                objbulk.ColumnMappings.Add("[FileName]", "FileName");
                objbulk.ColumnMappings.Add("[CreatedDate]", "CreatedDate");

                sqlConnection.Open();
                objbulk.WriteToServer(Exceldt);
                sqlConnection.Close();
            }
            catch (Exception ex)
            {

            }
            return false;
        }

        private bool InsertRegiontonnesExcelRecords(string product, string type, string UploadFileDiscription, string path, System.Data.DataTable Exceldt, string fileName)
        {
            try
            {
                Exceldt.Columns.Add("Product", typeof(int));
                Exceldt.Columns.Add("Discription", typeof(string));
                Exceldt.Columns.Add("FileName", typeof(string));
                Exceldt.Columns.Add("CreatedDate", typeof(DateTime));
                for (int i = Exceldt.Rows.Count - 1; i >= 0; i--)
                {
                    if (Exceldt.Rows[i]["Region"] == DBNull.Value || Exceldt.Rows[i]["Year"] == DBNull.Value || Exceldt.Rows[i]["count"] == DBNull.Value)
                    {
                        Exceldt.Rows[i].Delete();
                    }
                    else
                    {
                        Exceldt.Rows[i]["Product"] = product;
                        Exceldt.Rows[i]["Discription"] = UploadFileDiscription;
                        Exceldt.Rows[i]["FileName"] = fileName;
                        Exceldt.Rows[i]["CreatedDate"] = DateTime.Now;
                    }
                }
                Exceldt.AcceptChanges();
                string productid = Exceldt.Rows[0]["Region"].ToString();
                string year = Exceldt.Rows[0]["Year"].ToString();

                var connectionString = ConfigurationManager.ConnectionStrings["ChemAnalystContext"].ConnectionString;
                SqlConnection sqlConnection = new SqlConnection();

                //Connection Details  
                sqlConnection.ConnectionString = connectionString;

                //creating object of SqlBulkCopy      
                SqlBulkCopy objbulk = new SqlBulkCopy(sqlConnection);

                //assigning Destination table name      
                objbulk.DestinationTableName = "SA_MarketbyRegiontonnes";

                //Mapping Table column    
                objbulk.ColumnMappings.Add("[Product]", "Product");
                objbulk.ColumnMappings.Add("[Region]", "Region");
                objbulk.ColumnMappings.Add("[Year]", "year");
                objbulk.ColumnMappings.Add("[count]", "count");
                objbulk.ColumnMappings.Add("[Discription]", "Discription");
                objbulk.ColumnMappings.Add("[FileName]", "FileName");
                objbulk.ColumnMappings.Add("[CreatedDate]", "CreatedDate");

                sqlConnection.Open();
                objbulk.WriteToServer(Exceldt);
                sqlConnection.Close();
            }
            catch (Exception ex)
            {

            }
            return false;
        }

        private bool InsertSalespercentExcelRecords(string product, string type, string UploadFileDiscription, string path, System.Data.DataTable Exceldt, string fileName)
        {
            try
            {
                Exceldt.Columns.Add("Product", typeof(int));
                Exceldt.Columns.Add("Discription", typeof(string));
                Exceldt.Columns.Add("FileName", typeof(string));
                Exceldt.Columns.Add("CreatedDate", typeof(DateTime));
                for (int i = Exceldt.Rows.Count - 1; i >= 0; i--)
                {
                    if (Exceldt.Rows[i]["Channel"] == DBNull.Value || Exceldt.Rows[i]["Year"] == DBNull.Value || Exceldt.Rows[i]["count"] == DBNull.Value)
                    {
                        Exceldt.Rows[i].Delete();
                    }
                    else
                    {
                        Exceldt.Rows[i]["Product"] = product;
                        Exceldt.Rows[i]["Discription"] = UploadFileDiscription;
                        Exceldt.Rows[i]["FileName"] = fileName;
                        Exceldt.Rows[i]["CreatedDate"] = DateTime.Now;
                    }
                }
                Exceldt.AcceptChanges();
                string productid = Exceldt.Rows[0]["Channel"].ToString();
                string year = Exceldt.Rows[0]["Year"].ToString();

                var connectionString = ConfigurationManager.ConnectionStrings["ChemAnalystContext"].ConnectionString;
                SqlConnection sqlConnection = new SqlConnection();

                //Connection Details  
                sqlConnection.ConnectionString = connectionString;

                //creating object of SqlBulkCopy      
                SqlBulkCopy objbulk = new SqlBulkCopy(sqlConnection);

                //assigning Destination table name      
                objbulk.DestinationTableName = "SA_MarketbySalespercent";

                //Mapping Table column    
                objbulk.ColumnMappings.Add("[Product]", "Product");
                objbulk.ColumnMappings.Add("[Channel]", "Channel");
                objbulk.ColumnMappings.Add("[Year]", "year");
                objbulk.ColumnMappings.Add("[count]", "count");
                objbulk.ColumnMappings.Add("[Discription]", "Discription");
                objbulk.ColumnMappings.Add("[FileName]", "FileName");
                objbulk.ColumnMappings.Add("[CreatedDate]", "CreatedDate");

                sqlConnection.Open();
                objbulk.WriteToServer(Exceldt);
                sqlConnection.Close();
            }
            catch (Exception ex)
            {

            }
            return false;
        }

        private bool InsertSalestonnesExcelRecords(string product, string type, string UploadFileDiscription, string path, System.Data.DataTable Exceldt, string fileName)
        {
            try
            {
                Exceldt.Columns.Add("Product", typeof(int));
                Exceldt.Columns.Add("Discription", typeof(string));
                Exceldt.Columns.Add("FileName", typeof(string));
                Exceldt.Columns.Add("CreatedDate", typeof(DateTime));
                for (int i = Exceldt.Rows.Count - 1; i >= 0; i--)
                {
                    if (Exceldt.Rows[i]["Channel"] == DBNull.Value || Exceldt.Rows[i]["Year"] == DBNull.Value || Exceldt.Rows[i]["count"] == DBNull.Value)
                    {
                        Exceldt.Rows[i].Delete();
                    }
                    else
                    {
                        Exceldt.Rows[i]["Product"] = product;
                        Exceldt.Rows[i]["Discription"] = UploadFileDiscription;
                        Exceldt.Rows[i]["FileName"] = fileName;
                        Exceldt.Rows[i]["CreatedDate"] = DateTime.Now;
                    }
                }
                Exceldt.AcceptChanges();
                string productid = Exceldt.Rows[0]["Channel"].ToString();
                string year = Exceldt.Rows[0]["Year"].ToString();

                var connectionString = ConfigurationManager.ConnectionStrings["ChemAnalystContext"].ConnectionString;
                SqlConnection sqlConnection = new SqlConnection();

                //Connection Details  
                sqlConnection.ConnectionString = connectionString;

                //creating object of SqlBulkCopy      
                SqlBulkCopy objbulk = new SqlBulkCopy(sqlConnection);

                //assigning Destination table name      
                objbulk.DestinationTableName = "SA_MarketbySalestonnes";

                //Mapping Table column    
                objbulk.ColumnMappings.Add("[Product]", "Product");
                objbulk.ColumnMappings.Add("[Channel]", "Channel");
                objbulk.ColumnMappings.Add("[Year]", "year");
                objbulk.ColumnMappings.Add("[count]", "count");
                objbulk.ColumnMappings.Add("[Discription]", "Discription");
                objbulk.ColumnMappings.Add("[FileName]", "FileName");
                objbulk.ColumnMappings.Add("[CreatedDate]", "CreatedDate");

                sqlConnection.Open();
                objbulk.WriteToServer(Exceldt);
                sqlConnection.Close();
            }
            catch (Exception ex)
            {

            }
            return false;
        }

        private bool InsertTypepercentExcelRecords(string product, string type, string UploadFileDiscription, string path, System.Data.DataTable Exceldt, string fileName)
        {
            try
            {
                Exceldt.Columns.Add("Product", typeof(int));
                Exceldt.Columns.Add("Discription", typeof(string));
                Exceldt.Columns.Add("FileName", typeof(string));
                Exceldt.Columns.Add("CreatedDate", typeof(DateTime));
                for (int i = Exceldt.Rows.Count - 1; i >= 0; i--)
                {
                    if (Exceldt.Rows[i]["type"] == DBNull.Value || Exceldt.Rows[i]["Year"] == DBNull.Value || Exceldt.Rows[i]["count"] == DBNull.Value)
                    {
                        Exceldt.Rows[i].Delete();
                    }
                    else
                    {
                        Exceldt.Rows[i]["Product"] = product;
                        Exceldt.Rows[i]["Discription"] = UploadFileDiscription;
                        Exceldt.Rows[i]["FileName"] = fileName;
                        Exceldt.Rows[i]["CreatedDate"] = DateTime.Now;
                    }
                }
                Exceldt.AcceptChanges();
                string productid = Exceldt.Rows[0]["type"].ToString();
                string year = Exceldt.Rows[0]["Year"].ToString();

                var connectionString = ConfigurationManager.ConnectionStrings["ChemAnalystContext"].ConnectionString;
                SqlConnection sqlConnection = new SqlConnection();

                //Connection Details  
                sqlConnection.ConnectionString = connectionString;

                //creating object of SqlBulkCopy      
                SqlBulkCopy objbulk = new SqlBulkCopy(sqlConnection);

                //assigning Destination table name      
                objbulk.DestinationTableName = "SA_MarketbyTypepercent";

                //Mapping Table column    
                objbulk.ColumnMappings.Add("[Product]", "Product");
                objbulk.ColumnMappings.Add("[type]", "type");
                objbulk.ColumnMappings.Add("[Year]", "year");
                objbulk.ColumnMappings.Add("[count]", "count");
                objbulk.ColumnMappings.Add("[Discription]", "Discription");
                objbulk.ColumnMappings.Add("[FileName]", "FileName");
                objbulk.ColumnMappings.Add("[CreatedDate]", "CreatedDate");

                sqlConnection.Open();
                objbulk.WriteToServer(Exceldt);
                sqlConnection.Close();
            }
            catch (Exception ex)
            {

            }
            return false;
        }

        private bool InsertTypetonnesExcelRecords(string product, string type, string UploadFileDiscription, string path, System.Data.DataTable Exceldt, string fileName)
        {
            try
            {
                Exceldt.Columns.Add("Product", typeof(int));
                Exceldt.Columns.Add("Discription", typeof(string));
                Exceldt.Columns.Add("FileName", typeof(string));
                Exceldt.Columns.Add("CreatedDate", typeof(DateTime));
                for (int i = Exceldt.Rows.Count - 1; i >= 0; i--)
                {
                    if (Exceldt.Rows[i]["type"] == DBNull.Value || Exceldt.Rows[i]["Year"] == DBNull.Value || Exceldt.Rows[i]["count"] == DBNull.Value)
                    {
                        Exceldt.Rows[i].Delete();
                    }
                    else
                    {
                        Exceldt.Rows[i]["Product"] = product;
                        Exceldt.Rows[i]["Discription"] = UploadFileDiscription;
                        Exceldt.Rows[i]["FileName"] = fileName;
                        Exceldt.Rows[i]["CreatedDate"] = DateTime.Now;
                    }
                }
                Exceldt.AcceptChanges();
                string productid = Exceldt.Rows[0]["type"].ToString();
                string year = Exceldt.Rows[0]["Year"].ToString();

                var connectionString = ConfigurationManager.ConnectionStrings["ChemAnalystContext"].ConnectionString;
                SqlConnection sqlConnection = new SqlConnection();

                //Connection Details  
                sqlConnection.ConnectionString = connectionString;

                //creating object of SqlBulkCopy      
                SqlBulkCopy objbulk = new SqlBulkCopy(sqlConnection);

                //assigning Destination table name      
                objbulk.DestinationTableName = "SA_MarketbyTypetonnes";

                //Mapping Table column    
                objbulk.ColumnMappings.Add("[Product]", "Product");
                objbulk.ColumnMappings.Add("[type]", "type");
                objbulk.ColumnMappings.Add("[Year]", "year");
                objbulk.ColumnMappings.Add("[count]", "count");
                objbulk.ColumnMappings.Add("[Discription]", "Discription");
                objbulk.ColumnMappings.Add("[FileName]", "FileName");
                objbulk.ColumnMappings.Add("[CreatedDate]", "CreatedDate");

                sqlConnection.Open();
                objbulk.WriteToServer(Exceldt);
                sqlConnection.Close();
            }
            catch (Exception ex)
            {

            }
            return false;
        }

        private bool InsertDemandsupplyExcelRecords(string product, string type, string UploadFileDiscription, string path, System.Data.DataTable Exceldt, string fileName)
        {
            try
            {
                Exceldt.Columns.Add("Product", typeof(int));
                Exceldt.Columns.Add("Discription", typeof(string));
                Exceldt.Columns.Add("FileName", typeof(string));
                Exceldt.Columns.Add("CreatedDate", typeof(DateTime));
                for (int i = Exceldt.Rows.Count - 1; i >= 0; i--)
                {
                    if (Exceldt.Rows[i]["DemandSupply"] == DBNull.Value || Exceldt.Rows[i]["Year"] == DBNull.Value || Exceldt.Rows[i]["count"] == DBNull.Value)
                    {
                        Exceldt.Rows[i].Delete();
                    }
                    else
                    {
                        Exceldt.Rows[i]["Product"] = product;
                        Exceldt.Rows[i]["Discription"] = UploadFileDiscription;
                        Exceldt.Rows[i]["FileName"] = fileName;
                        Exceldt.Rows[i]["CreatedDate"] = DateTime.Now;
                    }
                }
                Exceldt.AcceptChanges();
                string productid = Exceldt.Rows[0]["DemandSupply"].ToString();
                string year = Exceldt.Rows[0]["Year"].ToString();

                var connectionString = ConfigurationManager.ConnectionStrings["ChemAnalystContext"].ConnectionString;
                SqlConnection sqlConnection = new SqlConnection();

                //Connection Details  
                sqlConnection.ConnectionString = connectionString;

                //creating object of SqlBulkCopy      
                SqlBulkCopy objbulk = new SqlBulkCopy(sqlConnection);

                //assigning Destination table name      
                objbulk.DestinationTableName = "SA_MarketbyDemandsupply";

                //Mapping Table column    
                objbulk.ColumnMappings.Add("[Product]", "Product");
                objbulk.ColumnMappings.Add("[DemandSupply]", "DemandSupply");
                objbulk.ColumnMappings.Add("[Year]", "year");
                objbulk.ColumnMappings.Add("[count]", "count");
                objbulk.ColumnMappings.Add("[Discription]", "Discription");
                objbulk.ColumnMappings.Add("[FileName]", "FileName");
                objbulk.ColumnMappings.Add("[CreatedDate]", "CreatedDate");

                sqlConnection.Open();
                objbulk.WriteToServer(Exceldt);
                sqlConnection.Close();
            }
            catch (Exception ex)
            {

            }
            return false;
        }

        private bool InsertDemandsupplyGraphExcelRecords(string product, string type, string UploadFileDiscription, string path, System.Data.DataTable Exceldt, string fileName)
        {
            try
            {
                Exceldt.Columns.Add("Product", typeof(int));
                Exceldt.Columns.Add("Discription", typeof(string));
                Exceldt.Columns.Add("FileName", typeof(string));
                Exceldt.Columns.Add("CreatedDate", typeof(DateTime));
                for (int i = Exceldt.Rows.Count - 1; i >= 0; i--)
                {
                    if (Exceldt.Rows[i]["DemandSupply"] == DBNull.Value || Exceldt.Rows[i]["Year"] == DBNull.Value || Exceldt.Rows[i]["count"] == DBNull.Value)
                    {
                        Exceldt.Rows[i].Delete();
                    }
                    else
                    {
                        Exceldt.Rows[i]["Product"] = product;
                        Exceldt.Rows[i]["Discription"] = UploadFileDiscription;
                        Exceldt.Rows[i]["FileName"] = fileName;
                        Exceldt.Rows[i]["CreatedDate"] = DateTime.Now;
                    }
                }
                Exceldt.AcceptChanges();
                string productid = Exceldt.Rows[0]["DemandSupply"].ToString();
                string year = Exceldt.Rows[0]["Year"].ToString();

                var connectionString = ConfigurationManager.ConnectionStrings["ChemAnalystContext"].ConnectionString;
                SqlConnection sqlConnection = new SqlConnection();

                //Connection Details  
                sqlConnection.ConnectionString = connectionString;

                //creating object of SqlBulkCopy      
                SqlBulkCopy objbulk = new SqlBulkCopy(sqlConnection);

                //assigning Destination table name      
                objbulk.DestinationTableName = "SA_MarketbyDemandsupplyGraph";

                //Mapping Table column    
                objbulk.ColumnMappings.Add("[Product]", "Product");
                objbulk.ColumnMappings.Add("[DemandSupply]", "DemandSupply");
                objbulk.ColumnMappings.Add("[Year]", "year");
                objbulk.ColumnMappings.Add("[count]", "count");
                objbulk.ColumnMappings.Add("[Discription]", "Discription");
                objbulk.ColumnMappings.Add("[FileName]", "FileName");
                objbulk.ColumnMappings.Add("[CreatedDate]", "CreatedDate");

                sqlConnection.Open();
                objbulk.WriteToServer(Exceldt);
                sqlConnection.Close();
            }
            catch (Exception ex)
            {

            }
            return false;
        }


        
        private bool InsertLocExcelRecords(string product, string type, string UploadFileDiscription, string path, System.Data.DataTable Exceldt, string fileName)
        {

            try
            {
                // string connStr = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;

                // string constr = string.Format(connStr, path);
                //  ExcelConn(_path);  C:\Users\AVI Nishad\Desktop\test1.xlsx
                //string constr = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + ";" + @"Extended Properties='Excel 12.0;HDR=Yes;'";
                // OleDbConnection Econ = new OleDbConnection(constr);
                // string Query = string.Format("Select [Product Name],[Year],[count] FROM [{0}]", "Sheet1$");
                // OleDbCommand Ecom = new OleDbCommand(Query, Econ);
                //Econ.Open();

                // DataSet ds = new DataSet();
                //OleDbDataAdapter oda = new OleDbDataAdapter(Query, Econ);
                //Econ.Close();
                //oda.Fill(ds);
                //System.Data.DataTable Exceldt = ds.Tables[0];
                Exceldt.Columns.Add("Product", typeof(int));
                Exceldt.Columns.Add("Discription", typeof(string));
                Exceldt.Columns.Add("FileName", typeof(string));
                Exceldt.Columns.Add("CreatedDate", typeof(DateTime));
                for (int i = Exceldt.Rows.Count - 1; i >= 0; i--)
                {
                    if (Exceldt.Rows[i]["Company"] == DBNull.Value || Exceldt.Rows[i]["Year"] == DBNull.Value || Exceldt.Rows[i]["count"] == DBNull.Value)
                    {
                        Exceldt.Rows[i].Delete();
                    }
                    else
                    {
                        Exceldt.Rows[i]["Product"] = product;
                        Exceldt.Rows[i]["Discription"] = UploadFileDiscription;
                        Exceldt.Rows[i]["FileName"] = fileName;
                        Exceldt.Rows[i]["CreatedDate"] = DateTime.Now;
                    }
                }
                Exceldt.AcceptChanges();
                string productid = Exceldt.Rows[0]["Company"].ToString();
                string year = Exceldt.Rows[0]["Year"].ToString();

                //if (Chempriceobj.CheckExistingdata(product, year) > 0)
                //{
                //    return true;
                //}
                //inserting Datatable Records to DataBase   
                var connectionString = ConfigurationManager.ConnectionStrings["ChemAnalystContext"].ConnectionString;
                SqlConnection sqlConnection = new SqlConnection();
                sqlConnection.ConnectionString = connectionString;//Connection Details  
                                                                  //creating object of SqlBulkCopy      
                SqlBulkCopy objbulk = new SqlBulkCopy(sqlConnection);
                //assigning Destination table name      
                objbulk.DestinationTableName = "SA_MarketbyLoc";
                //Mapping Table column    
                objbulk.ColumnMappings.Add("[Product]", "Product");
                objbulk.ColumnMappings.Add("[Company]", "Company");
                objbulk.ColumnMappings.Add("[Location]", "Location");
                objbulk.ColumnMappings.Add("[States]", "States");
                objbulk.ColumnMappings.Add("[Year]", "year");
                objbulk.ColumnMappings.Add("[count]", "count");
                objbulk.ColumnMappings.Add("[Discription]", "Discription");
                objbulk.ColumnMappings.Add("[FileName]", "FileName");
                objbulk.ColumnMappings.Add("[CreatedDate]", "CreatedDate");


                sqlConnection.Open();
                objbulk.WriteToServer(Exceldt);
                sqlConnection.Close();
                //  MessageBox.Show("Data has been Imported successfully.", "Imported", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                //  MessageBox.Show(string.Format("Data has not been Imported due to :{0}", ex.Message), "Not Imported", MessageBoxButtons.OK, MessageBoxIcon.Warning);



            }
            return false;

        }

        private bool InsertTechnologyExcelRecords(string product, string type, string UploadFileDiscription, string path, System.Data.DataTable Exceldt, string fileName)
        {

            try
            {
                Exceldt.Columns.Add("Product", typeof(int));
                Exceldt.Columns.Add("Discription", typeof(string));
                Exceldt.Columns.Add("FileName", typeof(string));
                Exceldt.Columns.Add("CreatedDate", typeof(DateTime));
                for (int i = Exceldt.Rows.Count - 1; i >= 0; i--)
                {
                    if (Exceldt.Rows[i]["Company"] == DBNull.Value || Exceldt.Rows[i]["Technology"] == DBNull.Value || Exceldt.Rows[i]["Liscensor"] == DBNull.Value || Exceldt.Rows[i]["Year"] == DBNull.Value)
                    {
                        Exceldt.Rows[i].Delete();
                    }
                    else
                    {
                        Exceldt.Rows[i]["Product"] = product;
                        Exceldt.Rows[i]["Discription"] = UploadFileDiscription;
                        Exceldt.Rows[i]["FileName"] = fileName;
                        Exceldt.Rows[i]["CreatedDate"] = DateTime.Now;
                    }
                }
                Exceldt.AcceptChanges();
                string productid = Exceldt.Rows[0]["Company"].ToString();
                string year = Exceldt.Rows[0]["Year"].ToString();

                var connectionString = ConfigurationManager.ConnectionStrings["ChemAnalystContext"].ConnectionString;
                SqlConnection sqlConnection = new SqlConnection();

                //Connection Details
                sqlConnection.ConnectionString = connectionString;

                //creating object of SqlBulkCopy      
                SqlBulkCopy objbulk = new SqlBulkCopy(sqlConnection);

                //assigning Destination table name      
                objbulk.DestinationTableName = "SA_MarketbyTech";

                //Mapping Table column    
                objbulk.ColumnMappings.Add("[Product]", "Product");
                objbulk.ColumnMappings.Add("[Company]", "Company");
                objbulk.ColumnMappings.Add("[Technology]", "Technology");
                objbulk.ColumnMappings.Add("[Liscensor]", "Liscensor");
                objbulk.ColumnMappings.Add("[Year]", "year");
                objbulk.ColumnMappings.Add("[count]", "count");
                objbulk.ColumnMappings.Add("[Discription]", "Discription");
                objbulk.ColumnMappings.Add("[FileName]", "FileName");
                objbulk.ColumnMappings.Add("[CreatedDate]", "CreatedDate");

                sqlConnection.Open();
                objbulk.WriteToServer(Exceldt);
                sqlConnection.Close();
                //  MessageBox.Show("Data has been Imported successfully.", "Imported", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                //  MessageBox.Show(string.Format("Data has not been Imported due to :{0}", ex.Message), "Not Imported", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            return false;
        }

        private bool InsertProcessExcelRecords(string product, string type, string UploadFileDiscription, string path, System.Data.DataTable Exceldt, string fileName)
        {

            try
            {
                Exceldt.Columns.Add("Product", typeof(int));
                Exceldt.Columns.Add("Discription", typeof(string));
                Exceldt.Columns.Add("FileName", typeof(string));
                Exceldt.Columns.Add("CreatedDate", typeof(DateTime));
                for (int i = Exceldt.Rows.Count - 1; i >= 0; i--)
                {
                    if (Exceldt.Rows[i]["Company"] == DBNull.Value || Exceldt.Rows[i]["Process"] == DBNull.Value || Exceldt.Rows[i]["Liscensor"] == DBNull.Value || Exceldt.Rows[i]["Year"] == DBNull.Value)
                    {
                        Exceldt.Rows[i].Delete();
                    }
                    else
                    {
                        Exceldt.Rows[i]["Product"] = product;
                        Exceldt.Rows[i]["Discription"] = UploadFileDiscription;
                        Exceldt.Rows[i]["FileName"] = fileName;
                        Exceldt.Rows[i]["CreatedDate"] = DateTime.Now;
                    }
                }
                Exceldt.AcceptChanges();
                string productid = Exceldt.Rows[0]["Company"].ToString();
                string year = Exceldt.Rows[0]["Year"].ToString();

                var connectionString = ConfigurationManager.ConnectionStrings["ChemAnalystContext"].ConnectionString;
                SqlConnection sqlConnection = new SqlConnection();

                //Connection Details
                sqlConnection.ConnectionString = connectionString;

                //creating object of SqlBulkCopy      
                SqlBulkCopy objbulk = new SqlBulkCopy(sqlConnection);

                //assigning Destination table name      
                objbulk.DestinationTableName = "SA_MarketbyProcess";

                //Mapping Table column    
                objbulk.ColumnMappings.Add("[Product]", "Product");
                objbulk.ColumnMappings.Add("[Company]", "Company");
                objbulk.ColumnMappings.Add("[Process]", "Process");
                objbulk.ColumnMappings.Add("[Liscensor]", "Liscensor");
                objbulk.ColumnMappings.Add("[Year]", "year");
                objbulk.ColumnMappings.Add("[count]", "count");
                objbulk.ColumnMappings.Add("[Discription]", "Discription");
                objbulk.ColumnMappings.Add("[FileName]", "FileName");
                objbulk.ColumnMappings.Add("[CreatedDate]", "CreatedDate");

                sqlConnection.Open();
                objbulk.WriteToServer(Exceldt);
                sqlConnection.Close();
                //  MessageBox.Show("Data has been Imported successfully.", "Imported", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                //  MessageBox.Show(string.Format("Data has not been Imported due to :{0}", ex.Message), "Not Imported", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            return false;
        }

        private bool InsertGradepricingExcelRecords(string product, string type, string UploadFileDiscription, string path, System.Data.DataTable Exceldt, string fileName)
        {

            try
            {
                Exceldt.Columns.Add("Product", typeof(int));
                Exceldt.Columns.Add("Discription", typeof(string));
                Exceldt.Columns.Add("FileName", typeof(string));
                Exceldt.Columns.Add("CreatedDate", typeof(DateTime));
                for (int i = Exceldt.Rows.Count - 1; i >= 0; i--)
                {
                    if (Exceldt.Rows[i]["Productsv"] == DBNull.Value || Exceldt.Rows[i]["Grade"] == DBNull.Value || Exceldt.Rows[i]["Application"] == DBNull.Value || Exceldt.Rows[i]["Year"] == DBNull.Value)
                    {
                        Exceldt.Rows[i].Delete();
                    }
                    else
                    {
                        Exceldt.Rows[i]["Product"] = product;
                        Exceldt.Rows[i]["Discription"] = UploadFileDiscription;
                        Exceldt.Rows[i]["FileName"] = fileName;
                        Exceldt.Rows[i]["CreatedDate"] = DateTime.Now;
                    }
                }
                Exceldt.AcceptChanges();
                // string productid = Exceldt.Rows[0]["Company"].ToString();
                string year = Exceldt.Rows[0]["Year"].ToString();

                var connectionString = ConfigurationManager.ConnectionStrings["ChemAnalystContext"].ConnectionString;
                SqlConnection sqlConnection = new SqlConnection();

                //Connection Details
                sqlConnection.ConnectionString = connectionString;

                //creating object of SqlBulkCopy      
                SqlBulkCopy objbulk = new SqlBulkCopy(sqlConnection);

                //assigning Destination table name      
                objbulk.DestinationTableName = "SA_MarketbyGradepricing";

                //Mapping Table column    
                objbulk.ColumnMappings.Add("[Product]", "Product");
                objbulk.ColumnMappings.Add("[Productsv]", "Productsv");
                objbulk.ColumnMappings.Add("[Application]", "Application");
                objbulk.ColumnMappings.Add("[Grade]", "Grade");
                objbulk.ColumnMappings.Add("[Year]", "year");
                objbulk.ColumnMappings.Add("[count]", "count");
                objbulk.ColumnMappings.Add("[Discription]", "Discription");
                objbulk.ColumnMappings.Add("[FileName]", "FileName");
                objbulk.ColumnMappings.Add("[CreatedDate]", "CreatedDate");

                sqlConnection.Open();
                objbulk.WriteToServer(Exceldt);
                sqlConnection.Close();
                //  MessageBox.Show("Data has been Imported successfully.", "Imported", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                //  MessageBox.Show(string.Format("Data has not been Imported due to :{0}", ex.Message), "Not Imported", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            return false;
        }

        private bool InsertDemandByTradeExportExcelRecords(string product, string type, string UploadFileDiscription, string path, System.Data.DataTable Exceldt, string fileName)
        {

            try
            {
                Exceldt.Columns.Add("Product", typeof(int));
                Exceldt.Columns.Add("Discription", typeof(string));
                Exceldt.Columns.Add("FileName", typeof(string));
                Exceldt.Columns.Add("CreatedDate", typeof(DateTime));
                for (int i = Exceldt.Rows.Count - 1; i >= 0; i--)
                {
                    if (Exceldt.Rows[i]["Country"] == DBNull.Value || Exceldt.Rows[i]["value"] == DBNull.Value || Exceldt.Rows[i]["volume"] == DBNull.Value || Exceldt.Rows[i]["year"] == DBNull.Value)
                    {
                        Exceldt.Rows[i].Delete();
                    }
                    else
                    {
                        Exceldt.Rows[i]["Product"] = product;
                        Exceldt.Rows[i]["Discription"] = UploadFileDiscription;
                        Exceldt.Rows[i]["FileName"] = fileName;
                        Exceldt.Rows[i]["CreatedDate"] = DateTime.Now;
                    }
                }
                Exceldt.AcceptChanges();
                // string productid = Exceldt.Rows[0]["Company"].ToString();
                string year = Exceldt.Rows[0]["Year"].ToString();

                var connectionString = ConfigurationManager.ConnectionStrings["ChemAnalystContext"].ConnectionString;
                SqlConnection sqlConnection = new SqlConnection();

                //Connection Details
                sqlConnection.ConnectionString = connectionString;

                //creating object of SqlBulkCopy      
                SqlBulkCopy objbulk = new SqlBulkCopy(sqlConnection);

                //assigning Destination table name      
                objbulk.DestinationTableName = "SA_MarketbyTradeExport";

                //Mapping Table column    
                objbulk.ColumnMappings.Add("[Product]", "Product");
                objbulk.ColumnMappings.Add("[Country]", "Country");
                objbulk.ColumnMappings.Add("[value]", "value");
                objbulk.ColumnMappings.Add("[volume]", "volume");
                objbulk.ColumnMappings.Add("[Year]", "year");
                objbulk.ColumnMappings.Add("[Discription]", "Discription");
                objbulk.ColumnMappings.Add("[FileName]", "FileName");
                objbulk.ColumnMappings.Add("[CreatedDate]", "CreatedDate");

                sqlConnection.Open();
                objbulk.WriteToServer(Exceldt);
                sqlConnection.Close();
                //  MessageBox.Show("Data has been Imported successfully.", "Imported", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                //  MessageBox.Show(string.Format("Data has not been Imported due to :{0}", ex.Message), "Not Imported", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            return false;
        }

        private bool InsertDemandByTradeImportExcelRecords(string product, string type, string UploadFileDiscription, string path, System.Data.DataTable Exceldt, string fileName)
        {

            try
            {
                Exceldt.Columns.Add("Product", typeof(int));
                Exceldt.Columns.Add("Discription", typeof(string));
                Exceldt.Columns.Add("FileName", typeof(string));
                Exceldt.Columns.Add("CreatedDate", typeof(DateTime));
                for (int i = Exceldt.Rows.Count - 1; i >= 0; i--)
                {
                    if (Exceldt.Rows[i]["Country"] == DBNull.Value || Exceldt.Rows[i]["value"] == DBNull.Value || Exceldt.Rows[i]["volume"] == DBNull.Value || Exceldt.Rows[i]["year"] == DBNull.Value)
                    {
                        Exceldt.Rows[i].Delete();
                    }
                    else
                    {
                        Exceldt.Rows[i]["Product"] = product;
                        Exceldt.Rows[i]["Discription"] = UploadFileDiscription;
                        Exceldt.Rows[i]["FileName"] = fileName;
                        Exceldt.Rows[i]["CreatedDate"] = DateTime.Now;
                    }
                }
                Exceldt.AcceptChanges();
                // string productid = Exceldt.Rows[0]["Company"].ToString();
                string year = Exceldt.Rows[0]["Year"].ToString();

                var connectionString = ConfigurationManager.ConnectionStrings["ChemAnalystContext"].ConnectionString;
                SqlConnection sqlConnection = new SqlConnection();

                //Connection Details
                sqlConnection.ConnectionString = connectionString;

                //creating object of SqlBulkCopy      
                SqlBulkCopy objbulk = new SqlBulkCopy(sqlConnection);

                //assigning Destination table name      
                objbulk.DestinationTableName = "SA_MarketbyTradeImport";

                //Mapping Table column    
                objbulk.ColumnMappings.Add("[Product]", "Product");
                objbulk.ColumnMappings.Add("[Country]", "Country");
                objbulk.ColumnMappings.Add("[value]", "value");
                objbulk.ColumnMappings.Add("[volume]", "volume");
                objbulk.ColumnMappings.Add("[Year]", "year");
                objbulk.ColumnMappings.Add("[Discription]", "Discription");
                objbulk.ColumnMappings.Add("[FileName]", "FileName");
                objbulk.ColumnMappings.Add("[CreatedDate]", "CreatedDate");

                sqlConnection.Open();
                objbulk.WriteToServer(Exceldt);
                sqlConnection.Close();
                //  MessageBox.Show("Data has been Imported successfully.", "Imported", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                //  MessageBox.Show(string.Format("Data has not been Imported due to :{0}", ex.Message), "Not Imported", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            return false;
        }








        #endregion


        #region Front end functions

        public ActionResult MarketbycompanyChart(string product, string chartType, string Range, string CompareProject, bool Customer, string FromYear, string ToYear, string selectedLegends = "")
        {
            MarketAnalysis Objdal = new DAL.MarketAnalysis();
            int custid = 0;

            ViewBag.product = product;
            ViewBag.ChartType = chartType;
            ViewBag.range = Range;
            ViewBag.ChartType = "line";

            if (product == null && Customer == true)
            {
                custid = int.Parse(Session["LoginUser"].ToString());

                ViewBag.ProductList = ObjProduct.CategoryByUser(custid);
                ViewBag.Category = Objdal.GetctegotyBYproduct(0);
                return View("market-AnalysisDataUser");

            }
            if (Customer == true)
            {
                custid = int.Parse(Session["LoginUser"].ToString());

            }

            List<SA_MarketbyComp> obj = null;
            string compare = string.Empty;
            if (CompareProject != null)
            {
                compare = CompareProject;
                CompareProject = CompareProject + "," + product;
                string[] values = CompareProject.Split(',');
                for (int i = 0; i < values.Length; i++)
                {
                    values[i] = values[i].Trim();
                }
                //   values[values.Length] = CompareProject;

                obj = Objdal.GetCompanyWiseProductListwithCompare(values);

            }
            else
            {
                if (string.IsNullOrEmpty(selectedLegends))
                {

                    obj = Objdal.GetCompanyWiseProductList(product);

                }
                else
                {
                    string selfilter = selectedLegends + ",";
                    obj = Objdal.GetCompanyWiseProductList(product).Where(w => selfilter.Contains(w.Company + ",")).ToList();
                }

            }
            //else
            //    obj = Objdal.GetCompanyWiseProductList(product);



            List<string> Year = obj.OrderBy(w => w.year).Select(p => p.year).Distinct().ToList();
            List<string> Discription = obj.Select(p => p.Discription).Distinct().ToList();

            

            string CommentaryTitle = "";
            string CommentaryDescription = "";
            int PId = 0;
            if (product != null)
            {
                ViewBag.AllLegends = Objdal.GetAllProductVariantCompany(Convert.ToInt16(product));
                int ProductId = int.Parse(product);
                PId = ProductId;
                CommentaryTitle = ObjCommentary.GetCommentaryList().Where(x => x.Product == ProductId && x.Type == "Market Analysis").OrderByDescending(w => w.CreatedTime).FirstOrDefault() != null ? ObjCommentary.GetCommentaryList().Where(x => x.Product == ProductId && x.Type == "Market Analysis").OrderByDescending(w => w.CreatedTime).FirstOrDefault().Title : "";
                CommentaryDescription = ObjCommentary.GetCommentaryList().Where(x => x.Product == ProductId && x.Type == "Market Analysis").OrderByDescending(w => w.CreatedTime).FirstOrDefault() != null ? ObjCommentary.GetCommentaryList().Where(x => x.Product == ProductId && x.Type == "Market Analysis").OrderByDescending(w => w.CreatedTime).FirstOrDefault().Description : "";
            }
            else
            {
                ViewBag.AllLegends = obj.GroupBy(car => car.Company).Select(Name => Name.First()).ToList().Select(d=>new ProductVariantModel { Name=d.Company}).ToList();




                PId = ObjProduct.GetProductList().OrderBy(w => w.id).FirstOrDefault().id;
                CommentaryTitle = ObjCommentary.GetCommentaryList().Where(x => x.Product == PId && x.Type == "Market Analysis").OrderByDescending(w => w.CreatedTime).FirstOrDefault() != null ? ObjCommentary.GetCommentaryList().Where(x => x.Product == PId && x.Type == "Market Analysis").OrderByDescending(w => w.CreatedTime).FirstOrDefault().Title : "";
                CommentaryDescription = ObjCommentary.GetCommentaryList().Where(x => x.Product == PId && x.Type == "Market Analysis").OrderByDescending(w => w.CreatedTime).FirstOrDefault() != null ? ObjCommentary.GetCommentaryList().Where(x => x.Product == PId && x.Type == "Market Analysis").OrderByDescending(w => w.CreatedTime).FirstOrDefault().Description : "";

            }

            var lstModel = new List<MA_StackViewModel>();

            for (int i = 0; i < Year.Count; i++)
            {

                List<SA_MarketbyComp> Chartdata = obj.Where(Chart => Chart.year == Year[i]).ToList();
                //sales of product sales by quarter  
                MA_StackViewModel Report = new MA_StackViewModel();
                Report.MStackedDimensionOne = Year[i];
                Report.Discription = Discription;
                Report.category = Objdal.GetctegotyBYproduct(obj[0].Product);
                Report.Product = (obj[0].Product).ToString();
                Report.Compare = compare;
                List<SimpleReportViewModel> Data = new List<SimpleReportViewModel>();
                List<SimpleReportViewModel> QuantityList = new List<ViewModel.SimpleReportViewModel>();

                foreach (var item in Chartdata)
                {
                    SimpleReportViewModel Quantity = new SimpleReportViewModel()
                    {
                        MDimensionOne = item.Company,
                        Quantity = item.count
                    };
                    QuantityList.Add(Quantity);
                }
                SimpleReportViewModel TotalQuantity = new SimpleReportViewModel()
                {
                    MDimensionOne = "Total Capacity",
                    Quantity = QuantityList.Sum(x => x.Quantity)

                };
                QuantityList.Add(TotalQuantity);
                Report.LstData = QuantityList;
                if (product == null)
                {
                    Report.MChartType = "line";
                    Report.MRange = "Company";
                }
                else
                {
                    Report.Product = product;
                    Report.MChartType = chartType;
                    Report.MRange = Range;
                }
                lstModel.Add(Report);
            }


            if (lstModel.Count() <= 0 && Customer == false)
            {

                ViewBag.product = product;
                ViewBag.ChartType = chartType;
                ViewBag.range = Range;
                ViewBag.ProductList = ObjProduct.CategoryByUser(0);
                ViewBag.Category = Objdal.GetctegotyBYproduct(int.Parse(product));
                NewsDataStore Obj2 = new NewsDataStore();
                DealsDataStore Obj = new DealsDataStore();
                DealsDetailsViewModel d = new DealsDetailsViewModel();
                d.NewsList = Obj2.GetNewsList();
                d.DealList = Obj.GetDealsList();
                return View("market-AnalysisData", d);

            }
            else if (lstModel.Count() <= 0 && Customer == true)
            {
                ViewBag.product = product;
                ViewBag.ChartType = chartType;
                ViewBag.range = Range;
                ViewBag.ProductList = ObjProduct.CategoryByUser(custid);
                ViewBag.Category = Objdal.GetctegotyBYproduct(int.Parse(product));
                return View("market-AnalysisDataUser");

            }
            else if (Customer == true)
            {
                ViewBag.ProductList = ObjProduct.CategoryByUser(custid);

                lstModel[0].CommentaryTitle = CommentaryTitle;
                lstModel[0].CommentaryDescription = CommentaryDescription;

                lstModel[0].FromYear = string.IsNullOrEmpty(FromYear) ? Year.First() : "";
                lstModel[0].ToYear = string.IsNullOrEmpty(ToYear) ? Year.Last() : "";
                lstModel[0].selectedLegends = selectedLegends;
                return View("marketanalysisUser", lstModel);
            }
            else
            {
                ViewBag.ProductList = ObjProduct.CategoryByUser(custid);
                NewsDataStore Obj2 = new NewsDataStore();
                DealsDataStore Obj = new DealsDataStore();
                DealsDetailsViewModel d = new DealsDetailsViewModel();
                d.NewsList = Obj2.GetNewsList();
                d.DealList = Obj.GetDealsList();
                lstModel[0].NewsDetailsViewModel = d;

                lstModel[0].CommentaryTitle = CommentaryTitle;
                lstModel[0].CommentaryDescription = CommentaryDescription;

                lstModel[0].FromYear = string.IsNullOrEmpty(FromYear) ? Year.First() : "";
                lstModel[0].ToYear = string.IsNullOrEmpty(ToYear) ? Year.Last() : "";
                lstModel[0].selectedLegends = selectedLegends;
                return View("marketanalysis", lstModel);

            }



        }

        public ActionResult MarketbylocationChart(string product, string chartType, string Range, string CompareProject, bool Customer, string FromYear, string ToYear, string selectedLegends = "")
        {
            MarketAnalysis Objdal = new DAL.MarketAnalysis();
            int custid = 0;
            ViewBag.Fy = FromYear;
            ViewBag.Ty = ToYear;
            if (product == null && Customer == true)
            {
                ViewBag.product = product;
                ViewBag.ChartType = chartType;
                ViewBag.range = Range;
                ViewBag.ChartType = "line";

                custid = int.Parse(Session["LoginUser"].ToString());

                ViewBag.ProductList = ObjProduct.CategoryByUser(custid);
                ViewBag.Category = Objdal.GetctegotyBYproduct(0);
                return View("market-AnalysisDataUser");

            }
            if (Customer == true)
            {
                custid = int.Parse(Session["LoginUser"].ToString());

            }

            List<SA_MarketbyLoc> obj = null;
            string compare = string.Empty;
            if (CompareProject != null)
            {
                compare = CompareProject;
                CompareProject = CompareProject + "," + product;
                string[] values = CompareProject.Split(',');
                for (int i = 0; i < values.Length; i++)
                {
                    values[i] = values[i].Trim();
                }
                //   values[values.Length] = CompareProject;

                obj = Objdal.GetLocationWiseProductListwithCompare(values);

            }
            else
            {
                if (string.IsNullOrEmpty(selectedLegends))
                {

                    obj = Objdal.GetLocationWiseProductList(product, FromYear, ToYear);

                }
                else
                {
                    string selfilter = selectedLegends + ",";
                    obj = Objdal.GetLocationWiseProductList(product, FromYear, ToYear).Where(w => selfilter.Contains(w.Location + ",")).ToList();
                }

            }
            //else
            //    obj = Objdal.GetLocationWiseProductList(product, FromYear, ToYear);

            ViewBag.R = Objdal.GetLocationWiseProductListReport(product, FromYear, ToYear);
            List<string> Year = obj.Select(p => p.year).Distinct().ToList();
            List<string> Discription = obj.Select(p => p.Discription).Distinct().ToList();

            ViewBag.AllLegends = Objdal.GetAllProductVariantLocation(Convert.ToInt16(product));


            string CommentaryTitle = "";
            string CommentaryDescription = "";
            int PId = 0;
            if (product != null)
            {
                int ProductId = int.Parse(product);
                PId = ProductId;
                CommentaryTitle = ObjCommentary.GetCommentaryList().Where(x => x.Product == ProductId && x.Type == "Market Analysis").OrderByDescending(w => w.CreatedTime).FirstOrDefault() != null ? ObjCommentary.GetCommentaryList().Where(x => x.Product == ProductId && x.Type == "Market Analysis").OrderByDescending(w => w.CreatedTime).FirstOrDefault().Title : "";
                CommentaryDescription = ObjCommentary.GetCommentaryList().Where(x => x.Product == ProductId && x.Type == "Market Analysis").OrderByDescending(w => w.CreatedTime).FirstOrDefault() != null ? ObjCommentary.GetCommentaryList().Where(x => x.Product == ProductId && x.Type == "Market Analysis").OrderByDescending(w => w.CreatedTime).FirstOrDefault().Description : "";
            }
            else
            {
                PId = ObjProduct.GetProductList().OrderBy(w => w.id).FirstOrDefault().id;
                CommentaryTitle = ObjCommentary.GetCommentaryList().Where(x => x.Product == PId && x.Type == "Market Analysis").OrderByDescending(w => w.CreatedTime).FirstOrDefault() != null ? ObjCommentary.GetCommentaryList().Where(x => x.Product == PId && x.Type == "Market Analysis").OrderByDescending(w => w.CreatedTime).FirstOrDefault().Title : "";
                CommentaryDescription = ObjCommentary.GetCommentaryList().Where(x => x.Product == PId && x.Type == "Market Analysis").OrderByDescending(w => w.CreatedTime).FirstOrDefault() != null ? ObjCommentary.GetCommentaryList().Where(x => x.Product == PId && x.Type == "Market Analysis").OrderByDescending(w => w.CreatedTime).FirstOrDefault().Description : "";

            }


            var lstModel = new List<MA_StackViewModel>();

            for (int i = 0; i < Year.Count; i++)
            {

                List<SA_MarketbyLoc> Chartdata = obj.Where(Chart => Chart.year == Year[i]).ToList();
                //sales of product sales by quarter  
                MA_StackViewModel Report = new MA_StackViewModel();
                Report.MStackedDimensionOne = Year[i];
                Report.Discription = Discription;
                Report.category = Objdal.GetctegotyBYproduct(obj[0].Product);
                Report.Product = (obj[0].Product).ToString();
                Report.Compare = compare;
                List<SimpleReportViewModel> Data = new List<SimpleReportViewModel>();
                List<SimpleReportViewModel> QuantityList = new List<ViewModel.SimpleReportViewModel>();

                foreach (var item in Chartdata)
                {
                    SimpleReportViewModel Quantity = new SimpleReportViewModel()
                    {
                        MDimensionOne = item.Location,
                        Quantity = item.count
                    };
                    QuantityList.Add(Quantity);
                }
                Report.LstData = QuantityList;
                if (product == null)
                {
                    Report.MChartType = "line";
                    Report.MRange = "Yearly";
                }
                else
                {
                    Report.Product = product;
                    Report.MChartType = chartType;
                    Report.MRange = Range;
                }
                lstModel.Add(Report);
            }


            if (lstModel.Count() <= 0 && Customer == false)
            {

                ViewBag.product = product;
                ViewBag.ChartType = chartType;
                ViewBag.range = Range;
                ViewBag.ProductList = ObjProduct.CategoryByUser(0);
                ViewBag.Category = Objdal.GetctegotyBYproduct(int.Parse(product));
                NewsDataStore Obj2 = new NewsDataStore();
                DealsDataStore Obj = new DealsDataStore();
                DealsDetailsViewModel d = new DealsDetailsViewModel();
                d.NewsList = Obj2.GetNewsList();
                d.DealList = Obj.GetDealsList();
                return View("market-AnalysisData", d);

            }
            else if (lstModel.Count() <= 0 && Customer == true)
            {
                ViewBag.product = product;
                ViewBag.ChartType = chartType;
                ViewBag.range = Range;
                ViewBag.ProductList = ObjProduct.CategoryByUser(custid);
                ViewBag.Category = Objdal.GetctegotyBYproduct(int.Parse(product));
                return View("market-AnalysisDataUser");

            }
            else if (Customer == true)
            {
                ViewBag.ProductList = ObjProduct.CategoryByUser(custid);
                lstModel[0].CommentaryTitle = CommentaryTitle;
                lstModel[0].CommentaryDescription = CommentaryDescription;

                lstModel[0].FromYear = string.IsNullOrEmpty(FromYear) ? Year.First() : "";
                lstModel[0].ToYear = string.IsNullOrEmpty(ToYear) ? Year.Last() : "";
                lstModel[0].selectedLegends = selectedLegends;
                return View("marketanalysisUser", lstModel);
            }
            else
            {
                ViewBag.ProductList = ObjProduct.CategoryByUser(custid);
                NewsDataStore Obj2 = new NewsDataStore();
                DealsDataStore Obj = new DealsDataStore();
                DealsDetailsViewModel d = new DealsDetailsViewModel();
                d.NewsList = Obj2.GetNewsList();
                d.DealList = Obj.GetDealsList();
                lstModel[0].NewsDetailsViewModel = d;
                lstModel[0].CommentaryTitle = CommentaryTitle;
                lstModel[0].CommentaryDescription = CommentaryDescription;

                lstModel[0].FromYear = string.IsNullOrEmpty(FromYear) ? Year.First() : "";
                lstModel[0].ToYear = string.IsNullOrEmpty(ToYear) ? Year.Last() : "";
                lstModel[0].selectedLegends = selectedLegends;
                return View("marketanalysis", lstModel);
            }



        }

        public ActionResult MarketbyTechnologyChart(string product, string chartType, string Range, string CompareProject, bool Customer, string FromYear, string ToYear, string selectedLegends = "")
        {
            MarketAnalysis Objdal = new DAL.MarketAnalysis();
            int custid = 0;
            ViewBag.Fy = FromYear;
            ViewBag.Ty = ToYear;
            if (product == null && Customer == true)
            {
                ViewBag.product = product;
                ViewBag.ChartType = chartType;
                ViewBag.range = Range;
                ViewBag.ChartType = "line";

                custid = int.Parse(Session["LoginUser"].ToString());

                ViewBag.ProductList = ObjProduct.CategoryByUser(custid);
                ViewBag.Category = Objdal.GetctegotyBYproduct(0);
                return View("market-AnalysisDataUser");

            }
            if (Customer == true)
            {
                custid = int.Parse(Session["LoginUser"].ToString());

            }

            List<SA_MarketbyTech> obj = null;
            string compare = string.Empty;
            if (CompareProject != null)
            {
                compare = CompareProject;
                CompareProject = CompareProject + "," + product;
                string[] values = CompareProject.Split(',');
                for (int i = 0; i < values.Length; i++)
                {
                    values[i] = values[i].Trim();
                }
                //   values[values.Length] = CompareProject;

                obj = Objdal.GetTechnologyWiseProductListwithCompare(values);

            }
            else
            {
                if (string.IsNullOrEmpty(selectedLegends))
                {

                    obj = Objdal.GetTechnologyWiseProductList(product, FromYear, ToYear);

                }
                else
                {
                    string selfilter = selectedLegends + ",";
                    obj = Objdal.GetTechnologyWiseProductList(product, FromYear, ToYear).Where(w => selfilter.Contains(w.Technology + ",")).ToList();
                }

            }
            //else
            //    obj = Objdal.GetTechnologyWiseProductList(product, FromYear, ToYear);

            ViewBag.R = Objdal.GetTechnologyWiseProductListReport(product, FromYear, ToYear);

            List<string> Year = obj.Select(p => p.year).Distinct().ToList();
            List<string> Discription = obj.Select(p => p.Discription).Distinct().ToList();

            ViewBag.AllLegends = Objdal.GetAllProductVariantTechnology(Convert.ToInt16(product));


            string CommentaryTitle = "";
            string CommentaryDescription = "";
            int PId = 0;
            if (product != null)
            {
                int ProductId = int.Parse(product);
                PId = ProductId;
                CommentaryTitle = ObjCommentary.GetCommentaryList().Where(x => x.Product == ProductId && x.Type == "Market Analysis").OrderByDescending(w => w.CreatedTime).FirstOrDefault() != null ? ObjCommentary.GetCommentaryList().Where(x => x.Product == ProductId && x.Type == "Market Analysis").OrderByDescending(w => w.CreatedTime).FirstOrDefault().Title : "";
                CommentaryDescription = ObjCommentary.GetCommentaryList().Where(x => x.Product == ProductId && x.Type == "Market Analysis").OrderByDescending(w => w.CreatedTime).FirstOrDefault() != null ? ObjCommentary.GetCommentaryList().Where(x => x.Product == ProductId && x.Type == "Market Analysis").OrderByDescending(w => w.CreatedTime).FirstOrDefault().Description : "";
            }
            else
            {
                PId = ObjProduct.GetProductList().OrderBy(w => w.id).FirstOrDefault().id;
                CommentaryTitle = ObjCommentary.GetCommentaryList().Where(x => x.Product == PId && x.Type == "Market Analysis").OrderByDescending(w => w.CreatedTime).FirstOrDefault() != null ? ObjCommentary.GetCommentaryList().Where(x => x.Product == PId && x.Type == "Market Analysis").OrderByDescending(w => w.CreatedTime).FirstOrDefault().Title : "";
                CommentaryDescription = ObjCommentary.GetCommentaryList().Where(x => x.Product == PId && x.Type == "Market Analysis").OrderByDescending(w => w.CreatedTime).FirstOrDefault() != null ? ObjCommentary.GetCommentaryList().Where(x => x.Product == PId && x.Type == "Market Analysis").OrderByDescending(w => w.CreatedTime).FirstOrDefault().Description : "";

            }



            var lstModel = new List<MA_StackViewModel>();

            for (int i = 0; i < Year.Count; i++)
            {

                List<SA_MarketbyTech> Chartdata = obj.Where(Chart => Chart.year == Year[i]).ToList();
                //sales of product sales by quarter  
                MA_StackViewModel Report = new MA_StackViewModel();
                Report.MStackedDimensionOne = Year[i];
                Report.Discription = Discription;
                Report.category = Objdal.GetctegotyBYproduct(obj[0].Product);
                Report.Product = (obj[0].Product).ToString();
                Report.Compare = compare;
                List<SimpleReportViewModel> Data = new List<SimpleReportViewModel>();
                List<SimpleReportViewModel> QuantityList = new List<ViewModel.SimpleReportViewModel>();

                foreach (var item in Chartdata)
                {
                    SimpleReportViewModel Quantity = new SimpleReportViewModel()
                    {
                        MDimensionOne = item.Technology,
                        Quantity = item.count
                    };
                    QuantityList.Add(Quantity);
                }
                Report.LstData = QuantityList;
                if (product == null)
                {
                    Report.MChartType = "line";
                    Report.MRange = "Yearly";
                }
                else
                {
                    Report.Product = product;
                    Report.MChartType = chartType;
                    Report.MRange = Range;
                }
                lstModel.Add(Report);
            }


            if (lstModel.Count() <= 0 && Customer == false)
            {

                ViewBag.product = product;
                ViewBag.ChartType = chartType;
                ViewBag.range = Range;
                ViewBag.ProductList = ObjProduct.CategoryByUser(0);
                ViewBag.Category = Objdal.GetctegotyBYproduct(int.Parse(product));
                NewsDataStore Obj2 = new NewsDataStore();
                DealsDataStore Obj = new DealsDataStore();
                DealsDetailsViewModel d = new DealsDetailsViewModel();
                d.NewsList = Obj2.GetNewsList();
                d.DealList = Obj.GetDealsList();
                return View("market-AnalysisData", d);

            }
            else if (lstModel.Count() <= 0 && Customer == true)
            {
                ViewBag.product = product;
                ViewBag.ChartType = chartType;
                ViewBag.range = Range;
                ViewBag.ProductList = ObjProduct.CategoryByUser(custid);
                ViewBag.Category = Objdal.GetctegotyBYproduct(int.Parse(product));
                return View("market-AnalysisDataUser");

            }
            else if (Customer == true)
            {
                ViewBag.ProductList = ObjProduct.CategoryByUser(custid);
                lstModel[0].CommentaryTitle = CommentaryTitle;
                lstModel[0].CommentaryDescription = CommentaryDescription;
                lstModel[0].selectedLegends = selectedLegends;
                return View("marketanalysisUser", lstModel);
            }
            else
            {
                ViewBag.ProductList = ObjProduct.CategoryByUser(custid);
                NewsDataStore Obj2 = new NewsDataStore();
                DealsDataStore Obj = new DealsDataStore();
                DealsDetailsViewModel d = new DealsDetailsViewModel();
                d.NewsList = Obj2.GetNewsList();
                d.DealList = Obj.GetDealsList();
                lstModel[0].NewsDetailsViewModel = d;

                lstModel[0].CommentaryTitle = CommentaryTitle;
                lstModel[0].CommentaryDescription = CommentaryDescription;
                lstModel[0].selectedLegends = selectedLegends;
                return View("marketanalysis", lstModel);
            }



        }

        public ActionResult MarketbyProcessChart(string product, string chartType, string Range, string CompareProject, bool Customer, string FromYear, string ToYear, string selectedLegends = "")
        {
            MarketAnalysis Objdal = new DAL.MarketAnalysis();
            int custid = 0;
            ViewBag.Fy = FromYear;
            ViewBag.Ty = ToYear;
            if (product == null && Customer == true)
            {
                ViewBag.product = product;
                ViewBag.ChartType = chartType;
                ViewBag.range = Range;
                ViewBag.ChartType = "line";

                custid = int.Parse(Session["LoginUser"].ToString());

                ViewBag.ProductList = ObjProduct.CategoryByUser(custid);
                ViewBag.Category = Objdal.GetctegotyBYproduct(0);
                return View("market-AnalysisDataUser");

            }
            if (Customer == true)
            {
                custid = int.Parse(Session["LoginUser"].ToString());

            }

            List<SA_MarketbyProcess> obj = null;
            string compare = string.Empty;
            if (CompareProject != null)
            {
                compare = CompareProject;
                CompareProject = CompareProject + "," + product;
                string[] values = CompareProject.Split(',');
                for (int i = 0; i < values.Length; i++)
                {
                    values[i] = values[i].Trim();
                }
                //   values[values.Length] = CompareProject;

                obj = Objdal.GetProcessWiseProductListwithCompare(values);

            }
            else
            {
                if (string.IsNullOrEmpty(selectedLegends))
                {

                    obj = Objdal.GetProcessWiseProductList(product, FromYear, ToYear);

                }
                else
                {
                    string selfilter = selectedLegends + ",";
                    obj = Objdal.GetProcessWiseProductList(product, FromYear, ToYear).Where(w => selfilter.Contains(w.Process + ",")).ToList();
                }

            }
            //else
            //    obj = Objdal.GetProcessWiseProductList(product, FromYear, ToYear);

            ViewBag.R = Objdal.GetProcessWiseProductListReport(product, FromYear, ToYear);

            List<string> Year = obj.Select(p => p.year).Distinct().ToList();
            List<string> Discription = obj.Select(p => p.Discription).Distinct().ToList();

            ViewBag.AllLegends = Objdal.GetAllProductVariantProcess(Convert.ToInt16(product));

            string CommentaryTitle = "";
            string CommentaryDescription = "";
            int PId = 0;
            if (product != null)
            {
                int ProductId = int.Parse(product);
                PId = ProductId;
                CommentaryTitle = ObjCommentary.GetCommentaryList().Where(x => x.Product == ProductId && x.Type == "Market Analysis").OrderByDescending(w => w.CreatedTime).FirstOrDefault() != null ? ObjCommentary.GetCommentaryList().Where(x => x.Product == ProductId && x.Type == "Market Analysis").OrderByDescending(w => w.CreatedTime).FirstOrDefault().Title : "";
                CommentaryDescription = ObjCommentary.GetCommentaryList().Where(x => x.Product == ProductId && x.Type == "Market Analysis").OrderByDescending(w => w.CreatedTime).FirstOrDefault() != null ? ObjCommentary.GetCommentaryList().Where(x => x.Product == ProductId && x.Type == "Market Analysis").OrderByDescending(w => w.CreatedTime).FirstOrDefault().Description : "";
            }
            else
            {
                PId = ObjProduct.GetProductList().OrderBy(w => w.id).FirstOrDefault().id;
                CommentaryTitle = ObjCommentary.GetCommentaryList().Where(x => x.Product == PId && x.Type == "Market Analysis").OrderByDescending(w => w.CreatedTime).FirstOrDefault() != null ? ObjCommentary.GetCommentaryList().Where(x => x.Product == PId && x.Type == "Market Analysis").OrderByDescending(w => w.CreatedTime).FirstOrDefault().Title : "";
                CommentaryDescription = ObjCommentary.GetCommentaryList().Where(x => x.Product == PId && x.Type == "Market Analysis").OrderByDescending(w => w.CreatedTime).FirstOrDefault() != null ? ObjCommentary.GetCommentaryList().Where(x => x.Product == PId && x.Type == "Market Analysis").OrderByDescending(w => w.CreatedTime).FirstOrDefault().Description : "";

            }



            var lstModel = new List<MA_StackViewModel>();

            for (int i = 0; i < Year.Count; i++)
            {

                List<SA_MarketbyProcess> Chartdata = obj.Where(Chart => Chart.year == Year[i]).ToList();
                //sales of product sales by quarter  
                MA_StackViewModel Report = new MA_StackViewModel();
                Report.MStackedDimensionOne = Year[i];
                Report.Discription = Discription;
                Report.category = Objdal.GetctegotyBYproduct(obj[0].Product);
                Report.Product = (obj[0].Product).ToString();
                Report.Compare = compare;
                List<SimpleReportViewModel> Data = new List<SimpleReportViewModel>();
                List<SimpleReportViewModel> QuantityList = new List<ViewModel.SimpleReportViewModel>();

                foreach (var item in Chartdata)
                {
                    SimpleReportViewModel Quantity = new SimpleReportViewModel()
                    {
                        MDimensionOne = item.Process,
                        Quantity = item.count
                    };
                    QuantityList.Add(Quantity);
                }
                Report.LstData = QuantityList;
                if (product == null)
                {
                    Report.MChartType = "line";
                    Report.MRange = "Yearly";
                }
                else
                {
                    Report.Product = product;
                    Report.MChartType = chartType;
                    Report.MRange = Range;
                }
                lstModel.Add(Report);
            }


            if (lstModel.Count() <= 0 && Customer == false)
            {

                ViewBag.product = product;
                ViewBag.ChartType = chartType;
                ViewBag.range = Range;
                ViewBag.ProductList = ObjProduct.CategoryByUser(0);
                ViewBag.Category = Objdal.GetctegotyBYproduct(int.Parse(product));
                NewsDataStore Obj2 = new NewsDataStore();
                DealsDataStore Obj = new DealsDataStore();
                DealsDetailsViewModel d = new DealsDetailsViewModel();
                d.NewsList = Obj2.GetNewsList();
                d.DealList = Obj.GetDealsList();
                return View("market-AnalysisData", d);

            }
            else if (lstModel.Count() <= 0 && Customer == true)
            {
                ViewBag.product = product;
                ViewBag.ChartType = chartType;
                ViewBag.range = Range;
                ViewBag.ProductList = ObjProduct.CategoryByUser(custid);
                ViewBag.Category = Objdal.GetctegotyBYproduct(int.Parse(product));
                return View("market-AnalysisDataUser");

            }
            else if (Customer == true)
            {
                ViewBag.ProductList = ObjProduct.CategoryByUser(custid);
                lstModel[0].CommentaryTitle = CommentaryTitle;
                lstModel[0].CommentaryDescription = CommentaryDescription;

                lstModel[0].selectedLegends = selectedLegends;
                return View("marketanalysisUser", lstModel);
            }
            else
            {
                ViewBag.ProductList = ObjProduct.CategoryByUser(custid);
                NewsDataStore Obj2 = new NewsDataStore();
                DealsDataStore Obj = new DealsDataStore();
                DealsDetailsViewModel d = new DealsDetailsViewModel();
                d.NewsList = Obj2.GetNewsList();
                d.DealList = Obj.GetDealsList();
                lstModel[0].NewsDetailsViewModel = d;
                lstModel[0].CommentaryTitle = CommentaryTitle;
                lstModel[0].CommentaryDescription = CommentaryDescription;
                lstModel[0].selectedLegends = selectedLegends;
                return View("marketanalysis", lstModel);
            }



        }

        public ActionResult MarketbyProductionChart(string product, string chartType, string Range, string CompareProject, bool Customer, string FromYear, string ToYear, string selectedLegends = "")
        {
            MarketAnalysis Objdal = new DAL.MarketAnalysis();
            int custid = 0;
            if (product == null && Customer == true)
            {
                ViewBag.product = product;
                ViewBag.ChartType = chartType;
                ViewBag.range = Range;
                ViewBag.ChartType = "line";

                custid = int.Parse(Session["LoginUser"].ToString());

                ViewBag.ProductList = ObjProduct.CategoryByUser(custid);
                ViewBag.Category = Objdal.GetctegotyBYproduct(0);
                return View("market-AnalysisDataUser");

            }
            if (Customer == true)
            {
                custid = int.Parse(Session["LoginUser"].ToString());

            }

            List<SA_MarketbyProducer> obj = null;
            string compare = string.Empty;
            if (CompareProject != null)
            {
                compare = CompareProject;
                CompareProject = CompareProject + "," + product;
                string[] values = CompareProject.Split(',');
                for (int i = 0; i < values.Length; i++)
                {
                    values[i] = values[i].Trim();
                }
                //   values[values.Length] = CompareProject;

                obj = Objdal.GetProducerWiseProductListwithCompare(values);

            }
            else
            {
                if (string.IsNullOrEmpty(selectedLegends))
                {

                    obj = Objdal.GetProducerWiseProductList(product);

                }
                else
                {
                    string selfilter = selectedLegends + ",";
                    obj = Objdal.GetProducerWiseProductList(product).Where(w => selfilter.Contains(w.Producer + ",")).ToList();
                }

            }
            //else
            //    obj = Objdal.GetProducerWiseProductList(product);
            List<string> Year = obj.Select(p => p.year).Distinct().ToList();
            List<string> Discription = obj.Select(p => p.Discription).Distinct().ToList();

            ViewBag.AllLegends = Objdal.GetAllProductVariantProduction(Convert.ToInt16(product));

            string CommentaryTitle = "";
            string CommentaryDescription = "";
            int PId = 0;
            if (product != null)
            {
                int ProductId = int.Parse(product);
                PId = ProductId;
                CommentaryTitle = ObjCommentary.GetCommentaryList().Where(x => x.Product == ProductId && x.Type == "Market Analysis").OrderByDescending(w => w.CreatedTime).FirstOrDefault() != null ? ObjCommentary.GetCommentaryList().Where(x => x.Product == ProductId && x.Type == "Market Analysis").OrderByDescending(w => w.CreatedTime).FirstOrDefault().Title : "";
                CommentaryDescription = ObjCommentary.GetCommentaryList().Where(x => x.Product == ProductId && x.Type == "Market Analysis").OrderByDescending(w => w.CreatedTime).FirstOrDefault() != null ? ObjCommentary.GetCommentaryList().Where(x => x.Product == ProductId && x.Type == "Market Analysis").OrderByDescending(w => w.CreatedTime).FirstOrDefault().Description : "";
            }
            else
            {
                PId = ObjProduct.GetProductList().OrderBy(w => w.id).FirstOrDefault().id;
                CommentaryTitle = ObjCommentary.GetCommentaryList().Where(x => x.Product == PId && x.Type == "Market Analysis").OrderByDescending(w => w.CreatedTime).FirstOrDefault() != null ? ObjCommentary.GetCommentaryList().Where(x => x.Product == PId && x.Type == "Market Analysis").OrderByDescending(w => w.CreatedTime).FirstOrDefault().Title : "";
                CommentaryDescription = ObjCommentary.GetCommentaryList().Where(x => x.Product == PId && x.Type == "Market Analysis").OrderByDescending(w => w.CreatedTime).FirstOrDefault() != null ? ObjCommentary.GetCommentaryList().Where(x => x.Product == PId && x.Type == "Market Analysis").OrderByDescending(w => w.CreatedTime).FirstOrDefault().Description : "";

            }

            var lstModel = new List<MA_StackViewModel>();

            for (int i = 0; i < Year.Count; i++)
            {

                List<SA_MarketbyProducer> Chartdata = obj.Where(Chart => Chart.year == Year[i]).ToList();
                //sales of product sales by quarter  
                MA_StackViewModel Report = new MA_StackViewModel();
                Report.MStackedDimensionOne = Year[i];
                Report.Discription = Discription;
                Report.category = Objdal.GetctegotyBYproduct(obj[0].Product);
                Report.Product = (obj[0].Product).ToString();
                Report.Compare = compare;
                List<SimpleReportViewModel> Data = new List<SimpleReportViewModel>();
                List<SimpleReportViewModel> QuantityList = new List<ViewModel.SimpleReportViewModel>();

                foreach (var item in Chartdata)
                {
                    SimpleReportViewModel Quantity = new SimpleReportViewModel()
                    {
                        MDimensionOne = item.Producer,
                        Quantity = item.count
                    };
                    QuantityList.Add(Quantity);
                }
                SimpleReportViewModel TotalQuantity = new SimpleReportViewModel()
                {
                    MDimensionOne = "Total Capacity",
                    Quantity = QuantityList.Sum(x => x.Quantity)

                };
                QuantityList.Add(TotalQuantity);
                Report.LstData = QuantityList;
                if (product == null)
                {
                    Report.MChartType = "line";
                    Report.MRange = "Yearly";
                }
                else
                {
                    Report.Product = product;
                    Report.MChartType = chartType;
                    Report.MRange = Range;
                }
                lstModel.Add(Report);
            }


            if (lstModel.Count() <= 0 && Customer == false)
            {

                ViewBag.product = product;
                ViewBag.ChartType = chartType;
                ViewBag.range = Range;
                ViewBag.ProductList = ObjProduct.CategoryByUser(0);
                ViewBag.Category = Objdal.GetctegotyBYproduct(int.Parse(product));
                NewsDataStore Obj2 = new NewsDataStore();
                DealsDataStore Obj = new DealsDataStore();
                DealsDetailsViewModel d = new DealsDetailsViewModel();
                d.NewsList = Obj2.GetNewsList();
                d.DealList = Obj.GetDealsList();
                return View("market-AnalysisData", d);

            }
            else if (lstModel.Count() <= 0 && Customer == true)
            {
                ViewBag.product = product;
                ViewBag.ChartType = chartType;
                ViewBag.range = Range;
                ViewBag.ProductList = ObjProduct.CategoryByUser(custid);
                ViewBag.Category = Objdal.GetctegotyBYproduct(int.Parse(product));
                return View("market-AnalysisDataUser");

            }
            else if (Customer == true)
            {
                ViewBag.ProductList = ObjProduct.CategoryByUser(custid);

                lstModel[0].CommentaryTitle = CommentaryTitle;
                lstModel[0].CommentaryDescription = CommentaryDescription;
                lstModel[0].selectedLegends = selectedLegends;
                return View("marketanalysisUser", lstModel);
            }
            else
            {
                ViewBag.ProductList = ObjProduct.CategoryByUser(custid);
                NewsDataStore Obj2 = new NewsDataStore();
                DealsDataStore Obj = new DealsDataStore();
                DealsDetailsViewModel d = new DealsDetailsViewModel();
                d.NewsList = Obj2.GetNewsList();
                d.DealList = Obj.GetDealsList();
                lstModel[0].NewsDetailsViewModel = d;

                lstModel[0].CommentaryTitle = CommentaryTitle;
                lstModel[0].CommentaryDescription = CommentaryDescription;
                lstModel[0].selectedLegends = selectedLegends;
                return View("marketanalysis", lstModel);
            }



        }

        public ActionResult MarketbyEfficiencyChart(string product, string chartType, string Range, string CompareProject, bool Customer, string FromYear, string ToYear, string selectedLegends = "")
        {
            MarketAnalysis Objdal = new DAL.MarketAnalysis();
            int custid = 0;
            if (product == null && Customer == true)
            {
                ViewBag.product = product;
                ViewBag.ChartType = chartType;
                ViewBag.range = Range;
                ViewBag.ChartType = "line";

                custid = int.Parse(Session["LoginUser"].ToString());

                ViewBag.ProductList = ObjProduct.CategoryByUser(custid);
                ViewBag.Category = Objdal.GetctegotyBYproduct(0);
                return View("market-AnalysisDataUser");

            }
            if (Customer == true)
            {
                custid = int.Parse(Session["LoginUser"].ToString());

            }

            List<SA_MarketbyEfficiency> obj = null;
            string compare = string.Empty;
            if (CompareProject != null)
            {
                compare = CompareProject;
                CompareProject = CompareProject + "," + product;
                string[] values = CompareProject.Split(',');
                for (int i = 0; i < values.Length; i++)
                {
                    values[i] = values[i].Trim();
                }
                //   values[values.Length] = CompareProject;

                obj = Objdal.GetEfficiencyWiseProductListwithCompare(values);

            }
            else
            {
                if (string.IsNullOrEmpty(selectedLegends))
                {

                    obj = Objdal.GetEfficiencyWiseProductList(product);

                }
                else
                {
                    string selfilter = selectedLegends + ",";
                    obj = Objdal.GetEfficiencyWiseProductList(product).Where(w => selfilter.Contains(w.Producer + ",")).ToList();
                }

            }
            //else
            //    obj = Objdal.GetEfficiencyWiseProductList(product);
            List<string> Year = obj.Select(p => p.year).Distinct().ToList();
            List<string> Discription = obj.Select(p => p.Discription).Distinct().ToList();

            ViewBag.AllLegends = Objdal.GetAllProductVariantEfficiency(Convert.ToInt16(product));

            string CommentaryTitle = "";
            string CommentaryDescription = "";
            int PId = 0;
            if (product != null)
            {
                int ProductId = int.Parse(product);
                PId = ProductId;
                CommentaryTitle = ObjCommentary.GetCommentaryList().Where(x => x.Product == ProductId && x.Type == "Market Analysis").OrderByDescending(w => w.CreatedTime).FirstOrDefault() != null ? ObjCommentary.GetCommentaryList().Where(x => x.Product == ProductId && x.Type == "Market Analysis").OrderByDescending(w => w.CreatedTime).FirstOrDefault().Title : "";
                CommentaryDescription = ObjCommentary.GetCommentaryList().Where(x => x.Product == ProductId && x.Type == "Market Analysis").OrderByDescending(w => w.CreatedTime).FirstOrDefault() != null ? ObjCommentary.GetCommentaryList().Where(x => x.Product == ProductId && x.Type == "Market Analysis").OrderByDescending(w => w.CreatedTime).FirstOrDefault().Description : "";
            }
            else
            {
                PId = ObjProduct.GetProductList().OrderBy(w => w.id).FirstOrDefault().id;
                CommentaryTitle = ObjCommentary.GetCommentaryList().Where(x => x.Product == PId && x.Type == "Market Analysis").OrderByDescending(w => w.CreatedTime).FirstOrDefault() != null ? ObjCommentary.GetCommentaryList().Where(x => x.Product == PId && x.Type == "Market Analysis").OrderByDescending(w => w.CreatedTime).FirstOrDefault().Title : "";
                CommentaryDescription = ObjCommentary.GetCommentaryList().Where(x => x.Product == PId && x.Type == "Market Analysis").OrderByDescending(w => w.CreatedTime).FirstOrDefault() != null ? ObjCommentary.GetCommentaryList().Where(x => x.Product == PId && x.Type == "Market Analysis").OrderByDescending(w => w.CreatedTime).FirstOrDefault().Description : "";

            }

            var lstModel = new List<MA_StackViewModel>();

            for (int i = 0; i < Year.Count; i++)
            {

                List<SA_MarketbyEfficiency> Chartdata = obj.Where(Chart => Chart.year == Year[i]).ToList();
                //sales of product sales by quarter  
                MA_StackViewModel Report = new MA_StackViewModel();
                Report.MStackedDimensionOne = Year[i];
                Report.Discription = Discription;
                Report.category = Objdal.GetctegotyBYproduct(obj[0].Product);
                Report.Product = (obj[0].Product).ToString();
                Report.Compare = compare;
                List<SimpleReportViewModel> Data = new List<SimpleReportViewModel>();
                List<SimpleReportViewModel> QuantityList = new List<ViewModel.SimpleReportViewModel>();

                foreach (var item in Chartdata)
                {
                    SimpleReportViewModel Quantity = new SimpleReportViewModel()
                    {
                        MDimensionOne = item.Producer,
                        Quantity = item.count
                    };
                    QuantityList.Add(Quantity);
                }

                SimpleReportViewModel TotalQuantity = new SimpleReportViewModel()
                {
                    MDimensionOne = "Total Capacity",
                    Quantity = QuantityList.Sum(x => x.Quantity)

                };
                QuantityList.Add(TotalQuantity);

                Report.LstData = QuantityList;
                if (product == null)
                {
                    Report.MChartType = "line";
                    Report.MRange = "Yearly";
                }
                else
                {
                    Report.Product = product;
                    Report.MChartType = chartType;
                    Report.MRange = Range;
                }
                lstModel.Add(Report);
            }


            if (lstModel.Count() <= 0 && Customer == false)
            {

                ViewBag.product = product;
                ViewBag.ChartType = chartType;
                ViewBag.range = Range;
                ViewBag.ProductList = ObjProduct.CategoryByUser(0);
                ViewBag.Category = Objdal.GetctegotyBYproduct(int.Parse(product));
                NewsDataStore Obj2 = new NewsDataStore();
                DealsDataStore Obj = new DealsDataStore();
                DealsDetailsViewModel d = new DealsDetailsViewModel();
                d.NewsList = Obj2.GetNewsList();
                d.DealList = Obj.GetDealsList();
                return View("market-AnalysisData", d);

            }
            else if (lstModel.Count() <= 0 && Customer == true)
            {
                ViewBag.product = product;
                ViewBag.ChartType = chartType;
                ViewBag.range = Range;
                ViewBag.ProductList = ObjProduct.CategoryByUser(custid);
                ViewBag.Category = Objdal.GetctegotyBYproduct(int.Parse(product));
                return View("market-AnalysisDataUser");

            }
            else if (Customer == true)
            {
                ViewBag.ProductList = ObjProduct.CategoryByUser(custid);

                lstModel[0].CommentaryTitle = CommentaryTitle;
                lstModel[0].CommentaryDescription = CommentaryDescription;
                lstModel[0].selectedLegends = selectedLegends;
                return View("marketanalysisUser", lstModel);
            }
            else
            {
                ViewBag.ProductList = ObjProduct.CategoryByUser(custid);
                NewsDataStore Obj2 = new NewsDataStore();
                DealsDataStore Obj = new DealsDataStore();
                DealsDetailsViewModel d = new DealsDetailsViewModel();
                d.NewsList = Obj2.GetNewsList();
                d.DealList = Obj.GetDealsList();
                lstModel[0].NewsDetailsViewModel = d;

                lstModel[0].CommentaryTitle = CommentaryTitle;
                lstModel[0].CommentaryDescription = CommentaryDescription;
                lstModel[0].selectedLegends = selectedLegends;
                return View("marketanalysis", lstModel);
            }



        }

        public ActionResult MarketbyEndUsePercentChart(string product, string chartType, string Range, string CompareProject, bool Customer, string FromYear, string ToYear, string selectedLegends = "")
        {
            MarketAnalysis Objdal = new DAL.MarketAnalysis();
            int custid = 0;
            if (product == null && Customer == true)
            {
                ViewBag.product = product;
                ViewBag.ChartType = chartType;
                ViewBag.range = Range;
                ViewBag.ChartType = "line";

                custid = int.Parse(Session["LoginUser"].ToString());

                ViewBag.ProductList = ObjProduct.CategoryByUser(custid);
                ViewBag.Category = Objdal.GetctegotyBYproduct(0);
                return View("market-AnalysisDataUser");

            }
            if (Customer == true)
            {
                custid = int.Parse(Session["LoginUser"].ToString());

            }

            List<SA_MarketbyEndUsepercent> obj = null;
            string compare = string.Empty;
            if (CompareProject != null)
            {
                compare = CompareProject;
                CompareProject = CompareProject + "," + product;
                string[] values = CompareProject.Split(',');
                for (int i = 0; i < values.Length; i++)
                {
                    values[i] = values[i].Trim();
                }
                //   values[values.Length] = CompareProject;

                obj = Objdal.GetEndUsepercentWiseProductListwithCompare(values);

            }
            else
                obj = Objdal.GetEndUsepercentWiseProductList(product);
            List<string> Year = obj.Select(p => p.year).Distinct().ToList();
            List<string> Discription = obj.Select(p => p.Discription).Distinct().ToList();

            string CommentaryTitle = "";
            string CommentaryDescription = "";
            int PId = 0;
            if (product != null)
            {
                int ProductId = int.Parse(product);
                PId = ProductId;
                CommentaryTitle = ObjCommentary.GetCommentaryList().Where(x => x.Product == ProductId && x.Type == "Market Analysis").OrderByDescending(w => w.CreatedTime).FirstOrDefault() != null ? ObjCommentary.GetCommentaryList().Where(x => x.Product == ProductId && x.Type == "Market Analysis").OrderByDescending(w => w.CreatedTime).FirstOrDefault().Title : "";
                CommentaryDescription = ObjCommentary.GetCommentaryList().Where(x => x.Product == ProductId && x.Type == "Market Analysis").OrderByDescending(w => w.CreatedTime).FirstOrDefault() != null ? ObjCommentary.GetCommentaryList().Where(x => x.Product == ProductId && x.Type == "Market Analysis").OrderByDescending(w => w.CreatedTime).FirstOrDefault().Description : "";
            }
            else
            {
                PId = ObjProduct.GetProductList().OrderBy(w => w.id).FirstOrDefault().id;
                CommentaryTitle = ObjCommentary.GetCommentaryList().Where(x => x.Product == PId && x.Type == "Market Analysis").OrderByDescending(w => w.CreatedTime).FirstOrDefault() != null ? ObjCommentary.GetCommentaryList().Where(x => x.Product == PId && x.Type == "Market Analysis").OrderByDescending(w => w.CreatedTime).FirstOrDefault().Title : "";
                CommentaryDescription = ObjCommentary.GetCommentaryList().Where(x => x.Product == PId && x.Type == "Market Analysis").OrderByDescending(w => w.CreatedTime).FirstOrDefault() != null ? ObjCommentary.GetCommentaryList().Where(x => x.Product == PId && x.Type == "Market Analysis").OrderByDescending(w => w.CreatedTime).FirstOrDefault().Description : "";

            }



            var lstModel = new List<MA_StackViewModel>();

            for (int i = 0; i < Year.Count; i++)
            {

                List<SA_MarketbyEndUsepercent> Chartdata = obj.Where(Chart => Chart.year == Year[i]).ToList();
                //sales of product sales by quarter  
                MA_StackViewModel Report = new MA_StackViewModel();
                Report.MStackedDimensionOne = Year[i];
                Report.Discription = Discription;
                Report.category = Objdal.GetctegotyBYproduct(obj[0].Product);
                Report.Product = (obj[0].Product).ToString();
                Report.Compare = compare;
                List<SimpleReportViewModel> Data = new List<SimpleReportViewModel>();
                List<SimpleReportViewModel> QuantityList = new List<ViewModel.SimpleReportViewModel>();

                foreach (var item in Chartdata)
                {
                    SimpleReportViewModel Quantity = new SimpleReportViewModel()
                    {
                        MDimensionOne = item.Enduse,
                        Quantity = item.count
                    };
                    QuantityList.Add(Quantity);
                }
                Report.LstData = QuantityList;
                if (product == null)
                {
                    Report.MChartType = "line";
                    Report.MRange = "Yearly";
                }
                else
                {
                    Report.Product = product;
                    Report.MChartType = chartType;
                    Report.MRange = Range;
                }
                lstModel.Add(Report);
            }


            if (lstModel.Count() <= 0 && Customer == false)
            {

                ViewBag.product = product;
                ViewBag.ChartType = chartType;
                ViewBag.range = Range;
                ViewBag.ProductList = ObjProduct.CategoryByUser(0);
                ViewBag.Category = Objdal.GetctegotyBYproduct(int.Parse(product));
                NewsDataStore Obj2 = new NewsDataStore();
                DealsDataStore Obj = new DealsDataStore();
                DealsDetailsViewModel d = new DealsDetailsViewModel();
                d.NewsList = Obj2.GetNewsList();
                d.DealList = Obj.GetDealsList();
                return View("market-AnalysisData", d);

            }
            else if (lstModel.Count() <= 0 && Customer == true)
            {
                ViewBag.product = product;
                ViewBag.ChartType = chartType;
                ViewBag.range = Range;
                ViewBag.ProductList = ObjProduct.CategoryByUser(custid);
                ViewBag.Category = Objdal.GetctegotyBYproduct(int.Parse(product));
                return View("market-AnalysisDataUser");

            }
            else if (Customer == true)
            {
                ViewBag.ProductList = ObjProduct.CategoryByUser(custid);

                lstModel[0].CommentaryTitle = CommentaryTitle;
                lstModel[0].CommentaryDescription = CommentaryDescription;

                return View("marketanalysisUser", lstModel);
            }
            else
            {
                ViewBag.ProductList = ObjProduct.CategoryByUser(custid);
                NewsDataStore Obj2 = new NewsDataStore();
                DealsDataStore Obj = new DealsDataStore();
                DealsDetailsViewModel d = new DealsDetailsViewModel();
                d.NewsList = Obj2.GetNewsList();
                d.DealList = Obj.GetDealsList();
                lstModel[0].NewsDetailsViewModel = d;

                lstModel[0].CommentaryTitle = CommentaryTitle;
                lstModel[0].CommentaryDescription = CommentaryDescription;

                return View("marketanalysis", lstModel);
            }



        }

        public ActionResult MarketbyEndUseTonneChart(string product, string chartType, string Range, string CompareProject, bool Customer, string FromYear, string ToYear, string selectedLegends = "")
        {
            MarketAnalysis Objdal = new DAL.MarketAnalysis();
            int custid = 0;
            if (product == null && Customer == true)
            {
                ViewBag.product = product;
                ViewBag.ChartType = chartType;
                ViewBag.range = Range;
                ViewBag.ChartType = "line";

                custid = int.Parse(Session["LoginUser"].ToString());

                ViewBag.ProductList = ObjProduct.CategoryByUser(custid);
                ViewBag.Category = Objdal.GetctegotyBYproduct(0);
                return View("market-AnalysisDataUser");

            }
            if (Customer == true)
            {
                custid = int.Parse(Session["LoginUser"].ToString());

            }

            List<SA_MarketbyEndUsetonnes> obj = null;
            string compare = string.Empty;
            if (CompareProject != null)
            {
                compare = CompareProject;
                CompareProject = CompareProject + "," + product;
                string[] values = CompareProject.Split(',');
                for (int i = 0; i < values.Length; i++)
                {
                    values[i] = values[i].Trim();
                }
                //   values[values.Length] = CompareProject;

                obj = Objdal.GetEndUsetonnesWiseProductListwithCompare(values);

            }
            else
            {
                if (string.IsNullOrEmpty(selectedLegends))
                {

                    obj = Objdal.GetEndUsetonnesWiseProductList(product);

                }
                else
                {
                    string selfilter = selectedLegends + ",";
                    obj = Objdal.GetEndUsetonnesWiseProductList(product).Where(w => selfilter.Contains(w.Enduse + ",")).ToList();
                }

            }

            //else
            //    obj = Objdal.GetEndUsetonnesWiseProductList(product);
            List<string> Year = obj.Select(p => p.year).Distinct().ToList();
            List<string> Discription = obj.Select(p => p.Discription).Distinct().ToList();

            ViewBag.AllLegends = Objdal.GetAllProductVariantEndUse(Convert.ToInt16(product));

            string CommentaryTitle = "";
            string CommentaryDescription = "";
            int PId = 0;
            if (product != null)
            {
                int ProductId = int.Parse(product);
                PId = ProductId;
                CommentaryTitle = ObjCommentary.GetCommentaryList().Where(x => x.Product == ProductId && x.Type == "Market Analysis").OrderByDescending(w => w.CreatedTime).FirstOrDefault() != null ? ObjCommentary.GetCommentaryList().Where(x => x.Product == ProductId && x.Type == "Market Analysis").OrderByDescending(w => w.CreatedTime).FirstOrDefault().Title : "";
                CommentaryDescription = ObjCommentary.GetCommentaryList().Where(x => x.Product == ProductId && x.Type == "Market Analysis").OrderByDescending(w => w.CreatedTime).FirstOrDefault() != null ? ObjCommentary.GetCommentaryList().Where(x => x.Product == ProductId && x.Type == "Market Analysis").OrderByDescending(w => w.CreatedTime).FirstOrDefault().Description : "";
            }
            else
            {
                PId = ObjProduct.GetProductList().OrderBy(w => w.id).FirstOrDefault().id;
                CommentaryTitle = ObjCommentary.GetCommentaryList().Where(x => x.Product == PId && x.Type == "Market Analysis").OrderByDescending(w => w.CreatedTime).FirstOrDefault() != null ? ObjCommentary.GetCommentaryList().Where(x => x.Product == PId && x.Type == "Market Analysis").OrderByDescending(w => w.CreatedTime).FirstOrDefault().Title : "";
                CommentaryDescription = ObjCommentary.GetCommentaryList().Where(x => x.Product == PId && x.Type == "Market Analysis").OrderByDescending(w => w.CreatedTime).FirstOrDefault() != null ? ObjCommentary.GetCommentaryList().Where(x => x.Product == PId && x.Type == "Market Analysis").OrderByDescending(w => w.CreatedTime).FirstOrDefault().Description : "";

            }



            var lstModel = new List<MA_StackViewModel>();

            for (int i = 0; i < Year.Count; i++)
            {

                List<SA_MarketbyEndUsetonnes> Chartdata = obj.Where(Chart => Chart.year == Year[i]).ToList();
                //sales of product sales by quarter  
                MA_StackViewModel Report = new MA_StackViewModel();
                Report.MStackedDimensionOne = Year[i];
                Report.Discription = Discription;
                Report.category = Objdal.GetctegotyBYproduct(obj[0].Product);
                Report.Product = (obj[0].Product).ToString();
                Report.Compare = compare;
                List<SimpleReportViewModel> Data = new List<SimpleReportViewModel>();
                List<SimpleReportViewModel> QuantityList = new List<ViewModel.SimpleReportViewModel>();

                foreach (var item in Chartdata)
                {
                    SimpleReportViewModel Quantity = new SimpleReportViewModel()
                    {
                        MDimensionOne = item.Enduse,
                        Quantity = item.count
                    };
                    QuantityList.Add(Quantity);
                }
                Report.LstData = QuantityList;
                if (product == null)
                {
                    Report.MChartType = "line";
                    Report.MRange = "Yearly";
                }
                else
                {
                    Report.Product = product;
                    Report.MChartType = chartType;
                    Report.MRange = Range;
                }
                lstModel.Add(Report);
            }


            if (lstModel.Count() <= 0 && Customer == false)
            {

                ViewBag.product = product;
                ViewBag.ChartType = chartType;
                ViewBag.range = Range;
                ViewBag.ProductList = ObjProduct.CategoryByUser(0);
                ViewBag.Category = Objdal.GetctegotyBYproduct(int.Parse(product));
                NewsDataStore Obj2 = new NewsDataStore();
                DealsDataStore Obj = new DealsDataStore();
                DealsDetailsViewModel d = new DealsDetailsViewModel();
                d.NewsList = Obj2.GetNewsList();
                d.DealList = Obj.GetDealsList();
                return View("market-AnalysisData", d);

            }
            else if (lstModel.Count() <= 0 && Customer == true)
            {
                ViewBag.product = product;
                ViewBag.ChartType = chartType;
                ViewBag.range = Range;
                ViewBag.ProductList = ObjProduct.CategoryByUser(custid);
                ViewBag.Category = Objdal.GetctegotyBYproduct(int.Parse(product));
                return View("market-AnalysisDataUser");

            }
            else if (Customer == true)
            {
                ViewBag.ProductList = ObjProduct.CategoryByUser(custid);

                lstModel[0].CommentaryTitle = CommentaryTitle;
                lstModel[0].CommentaryDescription = CommentaryDescription;
                lstModel[0].selectedLegends = selectedLegends;
                return View("marketanalysisUser", lstModel);
            }
            else
            {
                ViewBag.ProductList = ObjProduct.CategoryByUser(custid);
                NewsDataStore Obj2 = new NewsDataStore();
                DealsDataStore Obj = new DealsDataStore();
                DealsDetailsViewModel d = new DealsDetailsViewModel();
                d.NewsList = Obj2.GetNewsList();
                d.DealList = Obj.GetDealsList();
                lstModel[0].NewsDetailsViewModel = d;

                lstModel[0].CommentaryTitle = CommentaryTitle;
                lstModel[0].CommentaryDescription = CommentaryDescription;
                lstModel[0].selectedLegends = selectedLegends;
                return View("marketanalysis", lstModel);
            }



        }

        public ActionResult MarketbyGradePercentChart(string product, string chartType, string Range, string CompareProject, bool Customer, string FromYear, string ToYear, string selectedLegends = "")
        {
            MarketAnalysis Objdal = new DAL.MarketAnalysis();
            int custid = 0;
            if (product == null && Customer == true)
            {
                ViewBag.product = product;
                ViewBag.ChartType = chartType;
                ViewBag.range = Range;
                ViewBag.ChartType = "line";

                custid = int.Parse(Session["LoginUser"].ToString());

                ViewBag.ProductList = ObjProduct.CategoryByUser(custid);
                ViewBag.Category = Objdal.GetctegotyBYproduct(0);
                return View("market-AnalysisDataUser");

            }
            if (Customer == true)
            {
                custid = int.Parse(Session["LoginUser"].ToString());

            }

            List<SA_MarketbyGradepercent> obj = null;
            string compare = string.Empty;
            if (CompareProject != null)
            {
                compare = CompareProject;
                CompareProject = CompareProject + "," + product;
                string[] values = CompareProject.Split(',');
                for (int i = 0; i < values.Length; i++)
                {
                    values[i] = values[i].Trim();
                }
                //   values[values.Length] = CompareProject;

                obj = Objdal.GetGradepercentWiseProductListwithCompare(values);

            }
            else
                obj = Objdal.GetGradepercentWiseProductList(product);
            List<string> Year = obj.Select(p => p.year).Distinct().ToList();
            List<string> Discription = obj.Select(p => p.Discription).Distinct().ToList();

            string CommentaryTitle = "";
            string CommentaryDescription = "";
            int PId = 0;
            if (product != null)
            {
                int ProductId = int.Parse(product);
                PId = ProductId;
                CommentaryTitle = ObjCommentary.GetCommentaryList().Where(x => x.Product == ProductId && x.Type == "Market Analysis").OrderByDescending(w => w.CreatedTime).FirstOrDefault() != null ? ObjCommentary.GetCommentaryList().Where(x => x.Product == ProductId && x.Type == "Market Analysis").OrderByDescending(w => w.CreatedTime).FirstOrDefault().Title : "";
                CommentaryDescription = ObjCommentary.GetCommentaryList().Where(x => x.Product == ProductId && x.Type == "Market Analysis").OrderByDescending(w => w.CreatedTime).FirstOrDefault() != null ? ObjCommentary.GetCommentaryList().Where(x => x.Product == ProductId && x.Type == "Market Analysis").OrderByDescending(w => w.CreatedTime).FirstOrDefault().Description : "";
            }
            else
            {
                PId = ObjProduct.GetProductList().OrderBy(w => w.id).FirstOrDefault().id;
                CommentaryTitle = ObjCommentary.GetCommentaryList().Where(x => x.Product == PId && x.Type == "Market Analysis").OrderByDescending(w => w.CreatedTime).FirstOrDefault() != null ? ObjCommentary.GetCommentaryList().Where(x => x.Product == PId && x.Type == "Market Analysis").OrderByDescending(w => w.CreatedTime).FirstOrDefault().Title : "";
                CommentaryDescription = ObjCommentary.GetCommentaryList().Where(x => x.Product == PId && x.Type == "Market Analysis").OrderByDescending(w => w.CreatedTime).FirstOrDefault() != null ? ObjCommentary.GetCommentaryList().Where(x => x.Product == PId && x.Type == "Market Analysis").OrderByDescending(w => w.CreatedTime).FirstOrDefault().Description : "";

            }



            var lstModel = new List<MA_StackViewModel>();

            for (int i = 0; i < Year.Count; i++)
            {

                List<SA_MarketbyGradepercent> Chartdata = obj.Where(Chart => Chart.year == Year[i]).ToList();
                //sales of product sales by quarter  
                MA_StackViewModel Report = new MA_StackViewModel();
                Report.MStackedDimensionOne = Year[i];
                Report.Discription = Discription;
                Report.category = Objdal.GetctegotyBYproduct(obj[0].Product);
                Report.Product = (obj[0].Product).ToString();
                Report.Compare = compare;
                List<SimpleReportViewModel> Data = new List<SimpleReportViewModel>();
                List<SimpleReportViewModel> QuantityList = new List<ViewModel.SimpleReportViewModel>();

                foreach (var item in Chartdata)
                {
                    SimpleReportViewModel Quantity = new SimpleReportViewModel()
                    {
                        MDimensionOne = item.Grade,
                        Quantity = item.count
                    };
                    QuantityList.Add(Quantity);
                }
                Report.LstData = QuantityList;
                if (product == null)
                {
                    Report.MChartType = "line";
                    Report.MRange = "Yearly";
                }
                else
                {
                    Report.Product = product;
                    Report.MChartType = chartType;
                    Report.MRange = Range;
                }
                lstModel.Add(Report);
            }


            if (lstModel.Count() <= 0 && Customer == false)
            {

                ViewBag.product = product;
                ViewBag.ChartType = chartType;
                ViewBag.range = Range;
                ViewBag.ProductList = ObjProduct.CategoryByUser(0);
                ViewBag.Category = Objdal.GetctegotyBYproduct(int.Parse(product));
                NewsDataStore Obj2 = new NewsDataStore();
                DealsDataStore Obj = new DealsDataStore();
                DealsDetailsViewModel d = new DealsDetailsViewModel();
                d.NewsList = Obj2.GetNewsList();
                d.DealList = Obj.GetDealsList();
                return View("market-AnalysisData", d);

            }
            else if (lstModel.Count() <= 0 && Customer == true)
            {
                ViewBag.product = product;
                ViewBag.ChartType = chartType;
                ViewBag.range = Range;
                ViewBag.ProductList = ObjProduct.CategoryByUser(custid);
                ViewBag.Category = Objdal.GetctegotyBYproduct(int.Parse(product));
                return View("market-AnalysisDataUser");

            }
            else if (Customer == true)
            {
                ViewBag.ProductList = ObjProduct.CategoryByUser(custid);

                lstModel[0].CommentaryTitle = CommentaryTitle;
                lstModel[0].CommentaryDescription = CommentaryDescription;

                return View("marketanalysisUser", lstModel);
            }
            else
            {
                ViewBag.ProductList = ObjProduct.CategoryByUser(custid);
                NewsDataStore Obj2 = new NewsDataStore();
                DealsDataStore Obj = new DealsDataStore();
                DealsDetailsViewModel d = new DealsDetailsViewModel();
                d.NewsList = Obj2.GetNewsList();
                d.DealList = Obj.GetDealsList();
                lstModel[0].NewsDetailsViewModel = d;

                lstModel[0].CommentaryTitle = CommentaryTitle;
                lstModel[0].CommentaryDescription = CommentaryDescription;

                return View("marketanalysis", lstModel);
            }



        }

        public ActionResult MarketbyGradeTonneChart(string product, string chartType, string Range, string CompareProject, bool Customer, string FromYear, string ToYear, string selectedLegends = "")
        {
            MarketAnalysis Objdal = new DAL.MarketAnalysis();
            int custid = 0;
            if (product == null && Customer == true)
            {
                ViewBag.product = product;
                ViewBag.ChartType = chartType;
                ViewBag.range = Range;
                ViewBag.ChartType = "line";

                custid = int.Parse(Session["LoginUser"].ToString());

                ViewBag.ProductList = ObjProduct.CategoryByUser(custid);
                ViewBag.Category = Objdal.GetctegotyBYproduct(0);
                return View("market-AnalysisDataUser");

            }
            if (Customer == true)
            {
                custid = int.Parse(Session["LoginUser"].ToString());

            }

            List<SA_MarketbyGradetonnes> obj = null;
            string compare = string.Empty;
            if (CompareProject != null)
            {
                compare = CompareProject;
                CompareProject = CompareProject + "," + product;
                string[] values = CompareProject.Split(',');
                for (int i = 0; i < values.Length; i++)
                {
                    values[i] = values[i].Trim();
                }
                //   values[values.Length] = CompareProject;

                obj = Objdal.GetGradetonnesWiseProductListwithCompare(values);

            }
            else
            {
                if (string.IsNullOrEmpty(selectedLegends))
                {

                    obj = Objdal.GetGradetonnesWiseProductList(product);

                }
                else
                {
                    string selfilter = selectedLegends + ",";
                    obj = Objdal.GetGradetonnesWiseProductList(product).Where(w => selfilter.Contains(w.Grade + ",")).ToList();
                }

            }
            //else
            //    obj = Objdal.GetGradetonnesWiseProductList(product);
            List<string> Year = obj.Select(p => p.year).Distinct().ToList();
            List<string> Discription = obj.Select(p => p.Discription).Distinct().ToList();

            ViewBag.AllLegends = Objdal.GetAllProductVariantGrade(Convert.ToInt16(product));

            string CommentaryTitle = "";
            string CommentaryDescription = "";
            int PId = 0;
            if (product != null)
            {
                int ProductId = int.Parse(product);
                PId = ProductId;
                CommentaryTitle = ObjCommentary.GetCommentaryList().Where(x => x.Product == ProductId && x.Type == "Market Analysis").OrderByDescending(w => w.CreatedTime).FirstOrDefault() != null ? ObjCommentary.GetCommentaryList().Where(x => x.Product == ProductId && x.Type == "Market Analysis").OrderByDescending(w => w.CreatedTime).FirstOrDefault().Title : "";
                CommentaryDescription = ObjCommentary.GetCommentaryList().Where(x => x.Product == ProductId && x.Type == "Market Analysis").OrderByDescending(w => w.CreatedTime).FirstOrDefault() != null ? ObjCommentary.GetCommentaryList().Where(x => x.Product == ProductId && x.Type == "Market Analysis").OrderByDescending(w => w.CreatedTime).FirstOrDefault().Description : "";
            }
            else
            {
                PId = ObjProduct.GetProductList().OrderBy(w => w.id).FirstOrDefault().id;
                CommentaryTitle = ObjCommentary.GetCommentaryList().Where(x => x.Product == PId && x.Type == "Market Analysis").OrderByDescending(w => w.CreatedTime).FirstOrDefault() != null ? ObjCommentary.GetCommentaryList().Where(x => x.Product == PId && x.Type == "Market Analysis").OrderByDescending(w => w.CreatedTime).FirstOrDefault().Title : "";
                CommentaryDescription = ObjCommentary.GetCommentaryList().Where(x => x.Product == PId && x.Type == "Market Analysis").OrderByDescending(w => w.CreatedTime).FirstOrDefault() != null ? ObjCommentary.GetCommentaryList().Where(x => x.Product == PId && x.Type == "Market Analysis").OrderByDescending(w => w.CreatedTime).FirstOrDefault().Description : "";

            }


            var lstModel = new List<MA_StackViewModel>();

            for (int i = 0; i < Year.Count; i++)
            {

                List<SA_MarketbyGradetonnes> Chartdata = obj.Where(Chart => Chart.year == Year[i]).ToList();
                //sales of product sales by quarter  
                MA_StackViewModel Report = new MA_StackViewModel();
                Report.MStackedDimensionOne = Year[i];
                Report.Discription = Discription;
                Report.category = Objdal.GetctegotyBYproduct(obj[0].Product);
                Report.Product = (obj[0].Product).ToString();
                Report.Compare = compare;
                List<SimpleReportViewModel> Data = new List<SimpleReportViewModel>();
                List<SimpleReportViewModel> QuantityList = new List<ViewModel.SimpleReportViewModel>();

                foreach (var item in Chartdata)
                {
                    SimpleReportViewModel Quantity = new SimpleReportViewModel()
                    {
                        MDimensionOne = item.Grade,
                        Quantity = item.count
                    };
                    QuantityList.Add(Quantity);
                }
                Report.LstData = QuantityList;
                if (product == null)
                {
                    Report.MChartType = "line";
                    Report.MRange = "Yearly";
                }
                else
                {
                    Report.Product = product;
                    Report.MChartType = chartType;
                    Report.MRange = Range;
                }
                lstModel.Add(Report);
            }


            if (lstModel.Count() <= 0 && Customer == false)
            {

                ViewBag.product = product;
                ViewBag.ChartType = chartType;
                ViewBag.range = Range;
                ViewBag.ProductList = ObjProduct.CategoryByUser(0);
                ViewBag.Category = Objdal.GetctegotyBYproduct(int.Parse(product));
                NewsDataStore Obj2 = new NewsDataStore();
                DealsDataStore Obj = new DealsDataStore();
                DealsDetailsViewModel d = new DealsDetailsViewModel();
                d.NewsList = Obj2.GetNewsList();
                d.DealList = Obj.GetDealsList();
                return View("market-AnalysisData", d);

            }
            else if (lstModel.Count() <= 0 && Customer == true)
            {
                ViewBag.product = product;
                ViewBag.ChartType = chartType;
                ViewBag.range = Range;
                ViewBag.ProductList = ObjProduct.CategoryByUser(custid);
                ViewBag.Category = Objdal.GetctegotyBYproduct(int.Parse(product));
                return View("market-AnalysisDataUser");

            }
            else if (Customer == true)
            {
                ViewBag.ProductList = ObjProduct.CategoryByUser(custid);

                lstModel[0].CommentaryTitle = CommentaryTitle;
                lstModel[0].CommentaryDescription = CommentaryDescription;
                lstModel[0].selectedLegends = selectedLegends;
                return View("marketanalysisUser", lstModel);
            }
            else
            {
                ViewBag.ProductList = ObjProduct.CategoryByUser(custid);
                NewsDataStore Obj2 = new NewsDataStore();
                DealsDataStore Obj = new DealsDataStore();
                DealsDetailsViewModel d = new DealsDetailsViewModel();
                d.NewsList = Obj2.GetNewsList();
                d.DealList = Obj.GetDealsList();
                lstModel[0].NewsDetailsViewModel = d;

                lstModel[0].CommentaryTitle = CommentaryTitle;
                lstModel[0].CommentaryDescription = CommentaryDescription;
                lstModel[0].selectedLegends = selectedLegends;
                return View("marketanalysis", lstModel);
            }



        }

        public ActionResult MarketbyTypePercentChart(string product, string chartType, string Range, string CompareProject, bool Customer, string FromYear, string ToYear, string selectedLegends = "")
        {
            MarketAnalysis Objdal = new DAL.MarketAnalysis();
            int custid = 0;
            if (product == null && Customer == true)
            {
                ViewBag.product = product;
                ViewBag.ChartType = chartType;
                ViewBag.range = Range;
                ViewBag.ChartType = "line";

                custid = int.Parse(Session["LoginUser"].ToString());

                ViewBag.ProductList = ObjProduct.CategoryByUser(custid);
                ViewBag.Category = Objdal.GetctegotyBYproduct(0);
                return View("market-AnalysisDataUser");

            }
            if (Customer == true)
            {
                custid = int.Parse(Session["LoginUser"].ToString());

            }

            List<SA_MarketbyTypepercent> obj = null;
            string compare = string.Empty;
            if (CompareProject != null)
            {
                compare = CompareProject;
                CompareProject = CompareProject + "," + product;
                string[] values = CompareProject.Split(',');
                for (int i = 0; i < values.Length; i++)
                {
                    values[i] = values[i].Trim();
                }
                //   values[values.Length] = CompareProject;

                obj = Objdal.GetTypepercentWiseProductListwithCompare(values);

            }
            else
                obj = Objdal.GetTypepercentWiseProductList(product);
            List<string> Year = obj.Select(p => p.year).Distinct().ToList();
            List<string> Discription = obj.Select(p => p.Discription).Distinct().ToList();

            string CommentaryTitle = "";
            string CommentaryDescription = "";
            int PId = 0;
            if (product != null)
            {
                int ProductId = int.Parse(product);
                PId = ProductId;
                CommentaryTitle = ObjCommentary.GetCommentaryList().Where(x => x.Product == ProductId && x.Type == "Market Analysis").OrderByDescending(w => w.CreatedTime).FirstOrDefault() != null ? ObjCommentary.GetCommentaryList().Where(x => x.Product == ProductId && x.Type == "Market Analysis").OrderByDescending(w => w.CreatedTime).FirstOrDefault().Title : "";
                CommentaryDescription = ObjCommentary.GetCommentaryList().Where(x => x.Product == ProductId && x.Type == "Market Analysis").OrderByDescending(w => w.CreatedTime).FirstOrDefault() != null ? ObjCommentary.GetCommentaryList().Where(x => x.Product == ProductId && x.Type == "Market Analysis").OrderByDescending(w => w.CreatedTime).FirstOrDefault().Description : "";
            }
            else
            {
                PId = ObjProduct.GetProductList().OrderBy(w => w.id).FirstOrDefault().id;
                CommentaryTitle = ObjCommentary.GetCommentaryList().Where(x => x.Product == PId && x.Type == "Market Analysis").OrderByDescending(w => w.CreatedTime).FirstOrDefault() != null ? ObjCommentary.GetCommentaryList().Where(x => x.Product == PId && x.Type == "Market Analysis").OrderByDescending(w => w.CreatedTime).FirstOrDefault().Title : "";
                CommentaryDescription = ObjCommentary.GetCommentaryList().Where(x => x.Product == PId && x.Type == "Market Analysis").OrderByDescending(w => w.CreatedTime).FirstOrDefault() != null ? ObjCommentary.GetCommentaryList().Where(x => x.Product == PId && x.Type == "Market Analysis").OrderByDescending(w => w.CreatedTime).FirstOrDefault().Description : "";

            }



            var lstModel = new List<MA_StackViewModel>();

            for (int i = 0; i < Year.Count; i++)
            {

                List<SA_MarketbyTypepercent> Chartdata = obj.Where(Chart => Chart.year == Year[i]).ToList();
                //sales of product sales by quarter  
                MA_StackViewModel Report = new MA_StackViewModel();
                Report.MStackedDimensionOne = Year[i];
                Report.Discription = Discription;
                Report.category = Objdal.GetctegotyBYproduct(obj[0].Product);
                Report.Product = (obj[0].Product).ToString();
                Report.Compare = compare;
                List<SimpleReportViewModel> Data = new List<SimpleReportViewModel>();
                List<SimpleReportViewModel> QuantityList = new List<ViewModel.SimpleReportViewModel>();

                foreach (var item in Chartdata)
                {
                    SimpleReportViewModel Quantity = new SimpleReportViewModel()
                    {
                        MDimensionOne = item.type,
                        Quantity = item.count
                    };
                    QuantityList.Add(Quantity);
                }
                Report.LstData = QuantityList;
                if (product == null)
                {
                    Report.MChartType = "line";
                    Report.MRange = "Yearly";
                }
                else
                {
                    Report.Product = product;
                    Report.MChartType = chartType;
                    Report.MRange = Range;
                }
                lstModel.Add(Report);
            }


            if (lstModel.Count() <= 0 && Customer == false)
            {

                ViewBag.product = product;
                ViewBag.ChartType = chartType;
                ViewBag.range = Range;
                ViewBag.ProductList = ObjProduct.CategoryByUser(0);
                ViewBag.Category = Objdal.GetctegotyBYproduct(int.Parse(product));
                NewsDataStore Obj2 = new NewsDataStore();
                DealsDataStore Obj = new DealsDataStore();
                DealsDetailsViewModel d = new DealsDetailsViewModel();
                d.NewsList = Obj2.GetNewsList();
                d.DealList = Obj.GetDealsList();
                return View("market-AnalysisData", d);

            }
            else if (lstModel.Count() <= 0 && Customer == true)
            {
                ViewBag.product = product;
                ViewBag.ChartType = chartType;
                ViewBag.range = Range;
                ViewBag.ProductList = ObjProduct.CategoryByUser(custid);
                ViewBag.Category = Objdal.GetctegotyBYproduct(int.Parse(product));
                return View("market-AnalysisDataUser");

            }
            else if (Customer == true)
            {
                ViewBag.ProductList = ObjProduct.CategoryByUser(custid);


                lstModel[0].CommentaryTitle = CommentaryTitle;
                lstModel[0].CommentaryDescription = CommentaryDescription;

                return View("marketanalysisUser", lstModel);
            }
            else
            {
                ViewBag.ProductList = ObjProduct.CategoryByUser(custid);
                NewsDataStore Obj2 = new NewsDataStore();
                DealsDataStore Obj = new DealsDataStore();
                DealsDetailsViewModel d = new DealsDetailsViewModel();
                d.NewsList = Obj2.GetNewsList();
                d.DealList = Obj.GetDealsList();
                lstModel[0].NewsDetailsViewModel = d;


                lstModel[0].CommentaryTitle = CommentaryTitle;
                lstModel[0].CommentaryDescription = CommentaryDescription;

                return View("marketanalysis", lstModel);
            }



        }

        public ActionResult MarketbyTypeTonneChart(string product, string chartType, string Range, string CompareProject, bool Customer, string FromYear, string ToYear, string selectedLegends = "")
        {
            MarketAnalysis Objdal = new DAL.MarketAnalysis();
            int custid = 0;
            if (product == null && Customer == true)
            {
                ViewBag.product = product;
                ViewBag.ChartType = chartType;
                ViewBag.range = Range;
                ViewBag.ChartType = "line";

                custid = int.Parse(Session["LoginUser"].ToString());

                ViewBag.ProductList = ObjProduct.CategoryByUser(custid);
                ViewBag.Category = Objdal.GetctegotyBYproduct(0);
                return View("market-AnalysisDataUser");

            }
            if (Customer == true)
            {
                custid = int.Parse(Session["LoginUser"].ToString());

            }

            List<SA_MarketbyTypetonnes> obj = null;
            string compare = string.Empty;
            if (CompareProject != null)
            {
                compare = CompareProject;
                CompareProject = CompareProject + "," + product;
                string[] values = CompareProject.Split(',');
                for (int i = 0; i < values.Length; i++)
                {
                    values[i] = values[i].Trim();
                }
                //   values[values.Length] = CompareProject;

                obj = Objdal.GetTypetonnesWiseProductListwithCompare(values);

            }
            else
            {
                if (string.IsNullOrEmpty(selectedLegends))
                {

                    obj = Objdal.GetTypetonnesWiseProductList(product);

                }
                else
                {
                    string selfilter = selectedLegends + ",";
                    obj = Objdal.GetTypetonnesWiseProductList(product).Where(w => selfilter.Contains(w.type + ",")).ToList();
                }

            }
            //else
            //    obj = Objdal.GetTypetonnesWiseProductList(product);
            List<string> Year = obj.Select(p => p.year).Distinct().ToList();
            List<string> Discription = obj.Select(p => p.Discription).Distinct().ToList();

            ViewBag.AllLegends = Objdal.GetAllProductVariantType(Convert.ToInt16(product));

            string CommentaryTitle = "";
            string CommentaryDescription = "";
            int PId = 0;
            if (product != null)
            {
                int ProductId = int.Parse(product);
                PId = ProductId;
                CommentaryTitle = ObjCommentary.GetCommentaryList().Where(x => x.Product == ProductId && x.Type == "Market Analysis").OrderByDescending(w => w.CreatedTime).FirstOrDefault() != null ? ObjCommentary.GetCommentaryList().Where(x => x.Product == ProductId && x.Type == "Market Analysis").OrderByDescending(w => w.CreatedTime).FirstOrDefault().Title : "";
                CommentaryDescription = ObjCommentary.GetCommentaryList().Where(x => x.Product == ProductId && x.Type == "Market Analysis").OrderByDescending(w => w.CreatedTime).FirstOrDefault() != null ? ObjCommentary.GetCommentaryList().Where(x => x.Product == ProductId && x.Type == "Market Analysis").OrderByDescending(w => w.CreatedTime).FirstOrDefault().Description : "";
            }
            else
            {
                PId = ObjProduct.GetProductList().OrderBy(w => w.id).FirstOrDefault().id;
                CommentaryTitle = ObjCommentary.GetCommentaryList().Where(x => x.Product == PId && x.Type == "Market Analysis").OrderByDescending(w => w.CreatedTime).FirstOrDefault() != null ? ObjCommentary.GetCommentaryList().Where(x => x.Product == PId && x.Type == "Market Analysis").OrderByDescending(w => w.CreatedTime).FirstOrDefault().Title : "";
                CommentaryDescription = ObjCommentary.GetCommentaryList().Where(x => x.Product == PId && x.Type == "Market Analysis").OrderByDescending(w => w.CreatedTime).FirstOrDefault() != null ? ObjCommentary.GetCommentaryList().Where(x => x.Product == PId && x.Type == "Market Analysis").OrderByDescending(w => w.CreatedTime).FirstOrDefault().Description : "";

            }



            var lstModel = new List<MA_StackViewModel>();

            for (int i = 0; i < Year.Count; i++)
            {

                List<SA_MarketbyTypetonnes> Chartdata = obj.Where(Chart => Chart.year == Year[i]).ToList();
                //sales of product sales by quarter  
                MA_StackViewModel Report = new MA_StackViewModel();
                Report.MStackedDimensionOne = Year[i];
                Report.Discription = Discription;
                Report.category = Objdal.GetctegotyBYproduct(obj[0].Product);
                Report.Product = (obj[0].Product).ToString();
                Report.Compare = compare;
                List<SimpleReportViewModel> Data = new List<SimpleReportViewModel>();
                List<SimpleReportViewModel> QuantityList = new List<ViewModel.SimpleReportViewModel>();

                foreach (var item in Chartdata)
                {
                    SimpleReportViewModel Quantity = new SimpleReportViewModel()
                    {
                        MDimensionOne = item.type,
                        Quantity = item.count
                    };
                    QuantityList.Add(Quantity);
                }
                Report.LstData = QuantityList;
                if (product == null)
                {
                    Report.MChartType = "line";
                    Report.MRange = "Yearly";
                }
                else
                {
                    Report.Product = product;
                    Report.MChartType = chartType;
                    Report.MRange = Range;
                }
                lstModel.Add(Report);
            }


            if (lstModel.Count() <= 0 && Customer == false)
            {

                ViewBag.product = product;
                ViewBag.ChartType = chartType;
                ViewBag.range = Range;
                ViewBag.ProductList = ObjProduct.CategoryByUser(0);
                ViewBag.Category = Objdal.GetctegotyBYproduct(int.Parse(product));
                NewsDataStore Obj2 = new NewsDataStore();
                DealsDataStore Obj = new DealsDataStore();
                DealsDetailsViewModel d = new DealsDetailsViewModel();
                d.NewsList = Obj2.GetNewsList();
                d.DealList = Obj.GetDealsList();
                return View("market-AnalysisData", d);

            }
            else if (lstModel.Count() <= 0 && Customer == true)
            {
                ViewBag.product = product;
                ViewBag.ChartType = chartType;
                ViewBag.range = Range;
                ViewBag.ProductList = ObjProduct.CategoryByUser(custid);
                ViewBag.Category = Objdal.GetctegotyBYproduct(int.Parse(product));
                return View("market-AnalysisDataUser");

            }
            else if (Customer == true)
            {
                ViewBag.ProductList = ObjProduct.CategoryByUser(custid);

                lstModel[0].CommentaryTitle = CommentaryTitle;
                lstModel[0].CommentaryDescription = CommentaryDescription;
                lstModel[0].selectedLegends = selectedLegends;
                return View("marketanalysisUser", lstModel);
            }
            else
            {
                ViewBag.ProductList = ObjProduct.CategoryByUser(custid);
                NewsDataStore Obj2 = new NewsDataStore();
                DealsDataStore Obj = new DealsDataStore();
                DealsDetailsViewModel d = new DealsDetailsViewModel();
                d.NewsList = Obj2.GetNewsList();
                d.DealList = Obj.GetDealsList();
                lstModel[0].NewsDetailsViewModel = d;

                lstModel[0].CommentaryTitle = CommentaryTitle;
                lstModel[0].CommentaryDescription = CommentaryDescription;
                lstModel[0].selectedLegends = selectedLegends;
                return View("marketanalysis", lstModel);
            }



        }

        public ActionResult MarketbySalesChannelPercentChart(string product, string chartType, string Range, string CompareProject, bool Customer, string FromYear, string ToYear, string selectedLegends = "")
        {
            MarketAnalysis Objdal = new DAL.MarketAnalysis();
            int custid = 0;
            if (product == null && Customer == true)
            {
                ViewBag.product = product;
                ViewBag.ChartType = chartType;
                ViewBag.range = Range;
                ViewBag.ChartType = "line";

                custid = int.Parse(Session["LoginUser"].ToString());

                ViewBag.ProductList = ObjProduct.CategoryByUser(custid);
                ViewBag.Category = Objdal.GetctegotyBYproduct(0);
                return View("market-AnalysisDataUser");

            }
            if (Customer == true)
            {
                custid = int.Parse(Session["LoginUser"].ToString());

            }

            List<SA_MarketbySalespercent> obj = null;
            string compare = string.Empty;
            if (CompareProject != null)
            {
                compare = CompareProject;
                CompareProject = CompareProject + "," + product;
                string[] values = CompareProject.Split(',');
                for (int i = 0; i < values.Length; i++)
                {
                    values[i] = values[i].Trim();
                }
                //   values[values.Length] = CompareProject;

                obj = Objdal.GetSalespercentWiseProductListwithCompare(values);

            }
            else
                obj = Objdal.GetSalespercentWiseProductList(product);
            List<string> Year = obj.Select(p => p.year).Distinct().ToList();
            List<string> Discription = obj.Select(p => p.Discription).Distinct().ToList();

            string CommentaryTitle = "";
            string CommentaryDescription = "";
            int PId = 0;
            if (product != null)
            {
                int ProductId = int.Parse(product);
                PId = ProductId;
                CommentaryTitle = ObjCommentary.GetCommentaryList().Where(x => x.Product == ProductId && x.Type == "Market Analysis").OrderByDescending(w => w.CreatedTime).FirstOrDefault() != null ? ObjCommentary.GetCommentaryList().Where(x => x.Product == ProductId && x.Type == "Market Analysis").OrderByDescending(w => w.CreatedTime).FirstOrDefault().Title : "";
                CommentaryDescription = ObjCommentary.GetCommentaryList().Where(x => x.Product == ProductId && x.Type == "Market Analysis").OrderByDescending(w => w.CreatedTime).FirstOrDefault() != null ? ObjCommentary.GetCommentaryList().Where(x => x.Product == ProductId && x.Type == "Market Analysis").OrderByDescending(w => w.CreatedTime).FirstOrDefault().Description : "";
            }
            else
            {
                PId = ObjProduct.GetProductList().OrderBy(w => w.id).FirstOrDefault().id;
                CommentaryTitle = ObjCommentary.GetCommentaryList().Where(x => x.Product == PId && x.Type == "Market Analysis").OrderByDescending(w => w.CreatedTime).FirstOrDefault() != null ? ObjCommentary.GetCommentaryList().Where(x => x.Product == PId && x.Type == "Market Analysis").OrderByDescending(w => w.CreatedTime).FirstOrDefault().Title : "";
                CommentaryDescription = ObjCommentary.GetCommentaryList().Where(x => x.Product == PId && x.Type == "Market Analysis").OrderByDescending(w => w.CreatedTime).FirstOrDefault() != null ? ObjCommentary.GetCommentaryList().Where(x => x.Product == PId && x.Type == "Market Analysis").OrderByDescending(w => w.CreatedTime).FirstOrDefault().Description : "";

            }



            var lstModel = new List<MA_StackViewModel>();

            for (int i = 0; i < Year.Count; i++)
            {

                List<SA_MarketbySalespercent> Chartdata = obj.Where(Chart => Chart.year == Year[i]).ToList();
                //sales of product sales by quarter  
                MA_StackViewModel Report = new MA_StackViewModel();
                Report.MStackedDimensionOne = Year[i];
                Report.Discription = Discription;
                Report.category = Objdal.GetctegotyBYproduct(obj[0].Product);
                Report.Product = (obj[0].Product).ToString();
                Report.Compare = compare;
                List<SimpleReportViewModel> Data = new List<SimpleReportViewModel>();
                List<SimpleReportViewModel> QuantityList = new List<ViewModel.SimpleReportViewModel>();

                foreach (var item in Chartdata)
                {
                    SimpleReportViewModel Quantity = new SimpleReportViewModel()
                    {
                        MDimensionOne = item.Channel,
                        Quantity = item.count
                    };
                    QuantityList.Add(Quantity);
                }
                Report.LstData = QuantityList;
                if (product == null)
                {
                    Report.MChartType = "line";
                    Report.MRange = "Yearly";
                }
                else
                {
                    Report.Product = product;
                    Report.MChartType = chartType;
                    Report.MRange = Range;
                }
                lstModel.Add(Report);
            }


            if (lstModel.Count() <= 0 && Customer == false)
            {

                ViewBag.product = product;
                ViewBag.ChartType = chartType;
                ViewBag.range = Range;
                ViewBag.ProductList = ObjProduct.CategoryByUser(0);
                ViewBag.Category = Objdal.GetctegotyBYproduct(int.Parse(product));
                NewsDataStore Obj2 = new NewsDataStore();
                DealsDataStore Obj = new DealsDataStore();
                DealsDetailsViewModel d = new DealsDetailsViewModel();
                d.NewsList = Obj2.GetNewsList();
                d.DealList = Obj.GetDealsList();
                return View("market-AnalysisData", d);

            }
            else if (lstModel.Count() <= 0 && Customer == true)
            {
                ViewBag.product = product;
                ViewBag.ChartType = chartType;
                ViewBag.range = Range;
                ViewBag.ProductList = ObjProduct.CategoryByUser(custid);
                ViewBag.Category = Objdal.GetctegotyBYproduct(int.Parse(product));
                return View("market-AnalysisDataUser");

            }
            else if (Customer == true)
            {
                ViewBag.ProductList = ObjProduct.CategoryByUser(custid);

                lstModel[0].CommentaryTitle = CommentaryTitle;
                lstModel[0].CommentaryDescription = CommentaryDescription;

                return View("marketanalysisUser", lstModel);
            }
            else
            {
                ViewBag.ProductList = ObjProduct.CategoryByUser(custid);
                NewsDataStore Obj2 = new NewsDataStore();
                DealsDataStore Obj = new DealsDataStore();
                DealsDetailsViewModel d = new DealsDetailsViewModel();
                d.NewsList = Obj2.GetNewsList();
                d.DealList = Obj.GetDealsList();
                lstModel[0].NewsDetailsViewModel = d;

                lstModel[0].CommentaryTitle = CommentaryTitle;
                lstModel[0].CommentaryDescription = CommentaryDescription;

                return View("marketanalysis", lstModel);
            }



        }

        public ActionResult MarketbySalesChannelTonneChart(string product, string chartType, string Range, string CompareProject, bool Customer, string FromYear, string ToYear, string selectedLegends = "")
        {
            MarketAnalysis Objdal = new DAL.MarketAnalysis();
            int custid = 0;
            if (product == null && Customer == true)
            {
                ViewBag.product = product;
                ViewBag.ChartType = chartType;
                ViewBag.range = Range;
                ViewBag.ChartType = "line";

                custid = int.Parse(Session["LoginUser"].ToString());

                ViewBag.ProductList = ObjProduct.CategoryByUser(custid);
                ViewBag.Category = Objdal.GetctegotyBYproduct(0);
                return View("market-AnalysisDataUser");

            }
            if (Customer == true)
            {
                custid = int.Parse(Session["LoginUser"].ToString());

            }

            List<SA_MarketbySalestonnes> obj = null;
            string compare = string.Empty;
            if (CompareProject != null)
            {
                compare = CompareProject;
                CompareProject = CompareProject + "," + product;
                string[] values = CompareProject.Split(',');
                for (int i = 0; i < values.Length; i++)
                {
                    values[i] = values[i].Trim();
                }
                //   values[values.Length] = CompareProject;

                obj = Objdal.GetSalestonnesWiseProductListwithCompare(values);

            }
            else
            {
                if (string.IsNullOrEmpty(selectedLegends))
                {

                    obj = Objdal.GetSalestonnesWiseProductList(product);

                }
                else
                {
                    string selfilter = selectedLegends + ",";
                    obj = Objdal.GetSalestonnesWiseProductList(product).Where(w => selfilter.Contains(w.Channel + ",")).ToList();
                }

            }
            //else
            //    obj = Objdal.GetSalestonnesWiseProductList(product);
            List<string> Year = obj.Select(p => p.year).Distinct().ToList();
            List<string> Discription = obj.Select(p => p.Discription).Distinct().ToList();

            ViewBag.AllLegends = Objdal.GetAllProductVariantSalesChannel(Convert.ToInt16(product));

            string CommentaryTitle = "";
            string CommentaryDescription = "";
            int PId = 0;
            if (product != null)
            {
                int ProductId = int.Parse(product);
                PId = ProductId;
                CommentaryTitle = ObjCommentary.GetCommentaryList().Where(x => x.Product == ProductId && x.Type == "Market Analysis").OrderByDescending(w => w.CreatedTime).FirstOrDefault() != null ? ObjCommentary.GetCommentaryList().Where(x => x.Product == ProductId && x.Type == "Market Analysis").OrderByDescending(w => w.CreatedTime).FirstOrDefault().Title : "";
                CommentaryDescription = ObjCommentary.GetCommentaryList().Where(x => x.Product == ProductId && x.Type == "Market Analysis").OrderByDescending(w => w.CreatedTime).FirstOrDefault() != null ? ObjCommentary.GetCommentaryList().Where(x => x.Product == ProductId && x.Type == "Market Analysis").OrderByDescending(w => w.CreatedTime).FirstOrDefault().Description : "";
            }
            else
            {
                PId = ObjProduct.GetProductList().OrderBy(w => w.id).FirstOrDefault().id;
                CommentaryTitle = ObjCommentary.GetCommentaryList().Where(x => x.Product == PId && x.Type == "Market Analysis").OrderByDescending(w => w.CreatedTime).FirstOrDefault() != null ? ObjCommentary.GetCommentaryList().Where(x => x.Product == PId && x.Type == "Market Analysis").OrderByDescending(w => w.CreatedTime).FirstOrDefault().Title : "";
                CommentaryDescription = ObjCommentary.GetCommentaryList().Where(x => x.Product == PId && x.Type == "Market Analysis").OrderByDescending(w => w.CreatedTime).FirstOrDefault() != null ? ObjCommentary.GetCommentaryList().Where(x => x.Product == PId && x.Type == "Market Analysis").OrderByDescending(w => w.CreatedTime).FirstOrDefault().Description : "";

            }


            var lstModel = new List<MA_StackViewModel>();

            for (int i = 0; i < Year.Count; i++)
            {

                List<SA_MarketbySalestonnes> Chartdata = obj.Where(Chart => Chart.year == Year[i]).ToList();
                //sales of product sales by quarter  
                MA_StackViewModel Report = new MA_StackViewModel();
                Report.MStackedDimensionOne = Year[i];
                Report.Discription = Discription;
                Report.category = Objdal.GetctegotyBYproduct(obj[0].Product);
                Report.Product = (obj[0].Product).ToString();
                Report.Compare = compare;
                List<SimpleReportViewModel> Data = new List<SimpleReportViewModel>();
                List<SimpleReportViewModel> QuantityList = new List<ViewModel.SimpleReportViewModel>();

                foreach (var item in Chartdata)
                {
                    SimpleReportViewModel Quantity = new SimpleReportViewModel()
                    {
                        MDimensionOne = item.Channel,
                        Quantity = item.count
                    };
                    QuantityList.Add(Quantity);
                }
                Report.LstData = QuantityList;
                if (product == null)
                {
                    Report.MChartType = "line";
                    Report.MRange = "Yearly";
                }
                else
                {
                    Report.Product = product;
                    Report.MChartType = chartType;
                    Report.MRange = Range;
                }
                lstModel.Add(Report);
            }


            if (lstModel.Count() <= 0 && Customer == false)
            {

                ViewBag.product = product;
                ViewBag.ChartType = chartType;
                ViewBag.range = Range;
                ViewBag.ProductList = ObjProduct.CategoryByUser(0);
                ViewBag.Category = Objdal.GetctegotyBYproduct(int.Parse(product));
                NewsDataStore Obj2 = new NewsDataStore();
                DealsDataStore Obj = new DealsDataStore();
                DealsDetailsViewModel d = new DealsDetailsViewModel();
                d.NewsList = Obj2.GetNewsList();
                d.DealList = Obj.GetDealsList();
                return View("market-AnalysisData", d);

            }
            else if (lstModel.Count() <= 0 && Customer == true)
            {
                ViewBag.product = product;
                ViewBag.ChartType = chartType;
                ViewBag.range = Range;
                ViewBag.ProductList = ObjProduct.CategoryByUser(custid);
                ViewBag.Category = Objdal.GetctegotyBYproduct(int.Parse(product));
                return View("market-AnalysisDataUser");

            }
            else if (Customer == true)
            {
                ViewBag.ProductList = ObjProduct.CategoryByUser(custid);
                lstModel[0].CommentaryTitle = CommentaryTitle;
                lstModel[0].CommentaryDescription = CommentaryDescription;
                lstModel[0].selectedLegends = selectedLegends;
                return View("marketanalysisUser", lstModel);
            }
            else
            {
                ViewBag.ProductList = ObjProduct.CategoryByUser(custid);
                NewsDataStore Obj2 = new NewsDataStore();
                DealsDataStore Obj = new DealsDataStore();
                DealsDetailsViewModel d = new DealsDetailsViewModel();
                d.NewsList = Obj2.GetNewsList();
                d.DealList = Obj.GetDealsList();
                lstModel[0].NewsDetailsViewModel = d;
                lstModel[0].CommentaryTitle = CommentaryTitle;
                lstModel[0].CommentaryDescription = CommentaryDescription;
                lstModel[0].selectedLegends = selectedLegends;
                return View("marketanalysis", lstModel);
            }



        }

        public ActionResult MarketbyGradePricingChart(string product, string chartType, string Range, string CompareProject, bool Customer, string FromYear, string ToYear, string selectedLegends = "")
        {
            MarketAnalysis Objdal = new DAL.MarketAnalysis();
            int custid = 0;
            if (product == null && Customer == true)
            {
                ViewBag.product = product;
                ViewBag.ChartType = chartType;
                ViewBag.range = Range;
                ViewBag.ChartType = "line";

                custid = int.Parse(Session["LoginUser"].ToString());

                ViewBag.ProductList = ObjProduct.CategoryByUser(custid);
                ViewBag.Category = Objdal.GetctegotyBYproduct(0);
                return View("market-AnalysisDataUser");

            }
            if (Customer == true)
            {
                custid = int.Parse(Session["LoginUser"].ToString());

            }

            List<SA_MarketbyGradepricing> obj = null;
            string compare = string.Empty;
            if (CompareProject != null)
            {
                compare = CompareProject;
                CompareProject = CompareProject + "," + product;
                string[] values = CompareProject.Split(',');
                for (int i = 0; i < values.Length; i++)
                {
                    values[i] = values[i].Trim();
                }
                //   values[values.Length] = CompareProject;

                obj = Objdal.GetGradepricingWiseProductListwithCompare(values);

            }
            else
                obj = Objdal.GetGradepricingWiseProductList(product);
            List<string> Year = obj.Select(p => p.year).Distinct().ToList();
            List<string> Discription = obj.Select(p => p.Discription).Distinct().ToList();

            string CommentaryTitle = "";
            string CommentaryDescription = "";
            int PId = 0;
            if (product != null)
            {
                int ProductId = int.Parse(product);
                PId = ProductId;
                CommentaryTitle = ObjCommentary.GetCommentaryList().Where(x => x.Product == ProductId && x.Type == "Market Analysis").OrderByDescending(w => w.CreatedTime).FirstOrDefault() != null ? ObjCommentary.GetCommentaryList().Where(x => x.Product == ProductId && x.Type == "Market Analysis").OrderByDescending(w => w.CreatedTime).FirstOrDefault().Title : "";
                CommentaryDescription = ObjCommentary.GetCommentaryList().Where(x => x.Product == ProductId && x.Type == "Market Analysis").OrderByDescending(w => w.CreatedTime).FirstOrDefault() != null ? ObjCommentary.GetCommentaryList().Where(x => x.Product == ProductId && x.Type == "Market Analysis").OrderByDescending(w => w.CreatedTime).FirstOrDefault().Description : "";
            }
            else
            {
                PId = ObjProduct.GetProductList().OrderBy(w => w.id).FirstOrDefault().id;
                CommentaryTitle = ObjCommentary.GetCommentaryList().Where(x => x.Product == PId && x.Type == "Market Analysis").OrderByDescending(w => w.CreatedTime).FirstOrDefault() != null ? ObjCommentary.GetCommentaryList().Where(x => x.Product == PId && x.Type == "Market Analysis").OrderByDescending(w => w.CreatedTime).FirstOrDefault().Title : "";
                CommentaryDescription = ObjCommentary.GetCommentaryList().Where(x => x.Product == PId && x.Type == "Market Analysis").OrderByDescending(w => w.CreatedTime).FirstOrDefault() != null ? ObjCommentary.GetCommentaryList().Where(x => x.Product == PId && x.Type == "Market Analysis").OrderByDescending(w => w.CreatedTime).FirstOrDefault().Description : "";

            }



            var lstModel = new List<MA_StackViewModel>();

            for (int i = 0; i < Year.Count; i++)
            {

                List<SA_MarketbyGradepricing> Chartdata = obj.Where(Chart => Chart.year == Year[i]).ToList();
                //sales of product sales by quarter  
                MA_StackViewModel Report = new MA_StackViewModel();
                Report.MStackedDimensionOne = Year[i];
                Report.Discription = Discription;
                Report.category = Objdal.GetctegotyBYproduct(obj[0].Product);
                Report.Product = (obj[0].Product).ToString();
                Report.Compare = compare;
                List<SimpleReportViewModel> Data = new List<SimpleReportViewModel>();
                List<SimpleReportViewModel> QuantityList = new List<ViewModel.SimpleReportViewModel>();

                foreach (var item in Chartdata)
                {
                    SimpleReportViewModel Quantity = new SimpleReportViewModel()
                    {
                        MDimensionOne = item.Grade,
                        Quantity = item.count
                    };
                    QuantityList.Add(Quantity);
                }
                Report.LstData = QuantityList;
                if (product == null)
                {
                    Report.MChartType = "line";
                    Report.MRange = "Yearly";
                }
                else
                {
                    Report.Product = product;
                    Report.MChartType = chartType;
                    Report.MRange = Range;
                }
                lstModel.Add(Report);
            }


            if (lstModel.Count() <= 0 && Customer == false)
            {

                ViewBag.product = product;
                ViewBag.ChartType = chartType;
                ViewBag.range = Range;
                ViewBag.ProductList = ObjProduct.CategoryByUser(0);
                ViewBag.Category = Objdal.GetctegotyBYproduct(int.Parse(product));
                NewsDataStore Obj2 = new NewsDataStore();
                DealsDataStore Obj = new DealsDataStore();
                DealsDetailsViewModel d = new DealsDetailsViewModel();
                d.NewsList = Obj2.GetNewsList();
                d.DealList = Obj.GetDealsList();
                return View("market-AnalysisData", d);

            }
            else if (lstModel.Count() <= 0 && Customer == true)
            {
                ViewBag.product = product;
                ViewBag.ChartType = chartType;
                ViewBag.range = Range;
                ViewBag.ProductList = ObjProduct.CategoryByUser(custid);
                ViewBag.Category = Objdal.GetctegotyBYproduct(int.Parse(product));
                return View("market-AnalysisDataUser");

            }
            else if (Customer == true)
            {
                ViewBag.ProductList = ObjProduct.CategoryByUser(custid);


                lstModel[0].CommentaryTitle = CommentaryTitle;
                lstModel[0].CommentaryDescription = CommentaryDescription;

                return View("marketanalysisUser", lstModel);
            }
            else
            {
                ViewBag.ProductList = ObjProduct.CategoryByUser(custid);
                NewsDataStore Obj2 = new NewsDataStore();
                DealsDataStore Obj = new DealsDataStore();
                DealsDetailsViewModel d = new DealsDetailsViewModel();
                d.NewsList = Obj2.GetNewsList();
                d.DealList = Obj.GetDealsList();
                lstModel[0].NewsDetailsViewModel = d;


                lstModel[0].CommentaryTitle = CommentaryTitle;
                lstModel[0].CommentaryDescription = CommentaryDescription;

                return View("marketanalysis", lstModel);
            }



        }

        public ActionResult MarketbyRegionPercentChart(string product, string chartType, string Range, string CompareProject, bool Customer, string FromYear, string ToYear, string selectedLegends = "")
        {
            MarketAnalysis Objdal = new DAL.MarketAnalysis();
            int custid = 0;
            if (product == null && Customer == true)
            {
                ViewBag.product = product;
                ViewBag.ChartType = chartType;
                ViewBag.range = Range;
                ViewBag.ChartType = "line";

                custid = int.Parse(Session["LoginUser"].ToString());

                ViewBag.ProductList = ObjProduct.CategoryByUser(custid);
                ViewBag.Category = Objdal.GetctegotyBYproduct(0);
                return View("market-AnalysisDataUser");

            }
            if (Customer == true)
            {
                custid = int.Parse(Session["LoginUser"].ToString());

            }

            List<SA_MarketbyRegionpercent> obj = null;
            string compare = string.Empty;
            if (CompareProject != null)
            {
                compare = CompareProject;
                CompareProject = CompareProject + "," + product;
                string[] values = CompareProject.Split(',');
                for (int i = 0; i < values.Length; i++)
                {
                    values[i] = values[i].Trim();
                }
                //   values[values.Length] = CompareProject;

                obj = Objdal.GetRegionpercentWiseProductListwithCompare(values);

            }
            else
            {
                if (string.IsNullOrEmpty(selectedLegends))
                {

                    obj = Objdal.GetRegionpercentWiseProductList(product);

                }
                else
                {
                    string selfilter = selectedLegends + ",";
                    obj = Objdal.GetRegionpercentWiseProductList(product).Where(w => selfilter.Contains(w.Region + ",")).ToList();
                }

            }
            //else
            //    obj = Objdal.GetRegionpercentWiseProductList(product);
            List<string> Year = obj.Select(p => p.year).Distinct().ToList();
            List<string> Discription = obj.Select(p => p.Discription).Distinct().ToList();

            ViewBag.AllLegends = Objdal.GetAllProductVariantRegion(Convert.ToInt16(product));

            string CommentaryTitle = "";
            string CommentaryDescription = "";
            int PId = 0;
            if (product != null)
            {
                int ProductId = int.Parse(product);
                PId = ProductId;
                CommentaryTitle = ObjCommentary.GetCommentaryList().Where(x => x.Product == ProductId && x.Type == "Market Analysis").OrderByDescending(w => w.CreatedTime).FirstOrDefault() != null ? ObjCommentary.GetCommentaryList().Where(x => x.Product == ProductId && x.Type == "Market Analysis").OrderByDescending(w => w.CreatedTime).FirstOrDefault().Title : "";
                CommentaryDescription = ObjCommentary.GetCommentaryList().Where(x => x.Product == ProductId && x.Type == "Market Analysis").OrderByDescending(w => w.CreatedTime).FirstOrDefault() != null ? ObjCommentary.GetCommentaryList().Where(x => x.Product == ProductId && x.Type == "Market Analysis").OrderByDescending(w => w.CreatedTime).FirstOrDefault().Description : "";
            }
            else
            {
                PId = ObjProduct.GetProductList().OrderBy(w => w.id).FirstOrDefault().id;
                CommentaryTitle = ObjCommentary.GetCommentaryList().Where(x => x.Product == PId && x.Type == "Market Analysis").OrderByDescending(w => w.CreatedTime).FirstOrDefault() != null ? ObjCommentary.GetCommentaryList().Where(x => x.Product == PId && x.Type == "Market Analysis").OrderByDescending(w => w.CreatedTime).FirstOrDefault().Title : "";
                CommentaryDescription = ObjCommentary.GetCommentaryList().Where(x => x.Product == PId && x.Type == "Market Analysis").OrderByDescending(w => w.CreatedTime).FirstOrDefault() != null ? ObjCommentary.GetCommentaryList().Where(x => x.Product == PId && x.Type == "Market Analysis").OrderByDescending(w => w.CreatedTime).FirstOrDefault().Description : "";

            }




            var lstModel = new List<MA_StackViewModel>();

            for (int i = 0; i < Year.Count; i++)
            {

                List<SA_MarketbyRegionpercent> Chartdata = obj.Where(Chart => Chart.year == Year[i]).ToList();
                //sales of product sales by quarter  
                MA_StackViewModel Report = new MA_StackViewModel();
                Report.MStackedDimensionOne = Year[i];
                Report.Discription = Discription;
                Report.category = Objdal.GetctegotyBYproduct(obj[0].Product);
                Report.Product = (obj[0].Product).ToString();
                Report.Compare = compare;
                List<SimpleReportViewModel> Data = new List<SimpleReportViewModel>();
                List<SimpleReportViewModel> QuantityList = new List<ViewModel.SimpleReportViewModel>();

                foreach (var item in Chartdata)
                {
                    SimpleReportViewModel Quantity = new SimpleReportViewModel()
                    {
                        MDimensionOne = item.Region,
                        Quantity = item.count
                    };
                    QuantityList.Add(Quantity);
                }
                Report.LstData = QuantityList;
                if (product == null)
                {
                    Report.MChartType = "line";
                    Report.MRange = "Yearly";
                }
                else
                {
                    Report.Product = product;
                    Report.MChartType = chartType;
                    Report.MRange = Range;
                }
                lstModel.Add(Report);
            }


            if (lstModel.Count() <= 0 && Customer == false)
            {

                ViewBag.product = product;
                ViewBag.ChartType = chartType;
                ViewBag.range = Range;
                ViewBag.ProductList = ObjProduct.CategoryByUser(0);
                ViewBag.Category = Objdal.GetctegotyBYproduct(int.Parse(product));
                NewsDataStore Obj2 = new NewsDataStore();
                DealsDataStore Obj = new DealsDataStore();
                DealsDetailsViewModel d = new DealsDetailsViewModel();
                d.NewsList = Obj2.GetNewsList();
                d.DealList = Obj.GetDealsList();
                return View("market-AnalysisData", d);

            }
            else if (lstModel.Count() <= 0 && Customer == true)
            {
                ViewBag.product = product;
                ViewBag.ChartType = chartType;
                ViewBag.range = Range;
                ViewBag.ProductList = ObjProduct.CategoryByUser(custid);
                ViewBag.Category = Objdal.GetctegotyBYproduct(int.Parse(product));
                return View("market-AnalysisDataUser");

            }
            else if (Customer == true)
            {
                ViewBag.ProductList = ObjProduct.CategoryByUser(custid);


                lstModel[0].CommentaryTitle = CommentaryTitle;
                lstModel[0].CommentaryDescription = CommentaryDescription;
                lstModel[0].selectedLegends = selectedLegends;
                return View("marketanalysisUser", lstModel);
            }
            else
            {
                ViewBag.ProductList = ObjProduct.CategoryByUser(custid);
                NewsDataStore Obj2 = new NewsDataStore();
                DealsDataStore Obj = new DealsDataStore();
                DealsDetailsViewModel d = new DealsDetailsViewModel();
                d.NewsList = Obj2.GetNewsList();
                d.DealList = Obj.GetDealsList();
                lstModel[0].NewsDetailsViewModel = d;


                lstModel[0].CommentaryTitle = CommentaryTitle;
                lstModel[0].CommentaryDescription = CommentaryDescription;
                lstModel[0].selectedLegends = selectedLegends;
                return View("marketanalysis", lstModel);
            }



        }

        public ActionResult MarketbyRegionTonneChart(string product, string chartType, string Range, string CompareProject, bool Customer, string FromYear, string ToYear, string selectedLegends = "")
        {
            MarketAnalysis Objdal = new DAL.MarketAnalysis();
            int custid = 0;
            if (product == null && Customer == true)
            {
                ViewBag.product = product;
                ViewBag.ChartType = chartType;
                ViewBag.range = Range;
                ViewBag.ChartType = "line";

                custid = int.Parse(Session["LoginUser"].ToString());

                ViewBag.ProductList = ObjProduct.CategoryByUser(custid);
                ViewBag.Category = Objdal.GetctegotyBYproduct(0);
                return View("market-AnalysisDataUser");

            }
            if (Customer == true)
            {
                custid = int.Parse(Session["LoginUser"].ToString());

            }

            List<SA_MarketbyRegiontonnes> obj = null;
            string compare = string.Empty;
            if (CompareProject != null)
            {
                compare = CompareProject;
                CompareProject = CompareProject + "," + product;
                string[] values = CompareProject.Split(',');
                for (int i = 0; i < values.Length; i++)
                {
                    values[i] = values[i].Trim();
                }
                //   values[values.Length] = CompareProject;

                obj = Objdal.GetRegiontonnesWiseProductListwithCompare(values);

            }
            else
            {
                if (string.IsNullOrEmpty(selectedLegends))
                {

                    obj = Objdal.GetRegiontonnesWiseProductList(product);

                }
                else
                {
                    string selfilter = selectedLegends + ",";
                    obj = Objdal.GetRegiontonnesWiseProductList(product).Where(w => selfilter.Contains(w.Region + ",")).ToList();
                }

            }
            //else
            //    obj = Objdal.GetRegiontonnesWiseProductList(product);
            List<string> Year = obj.Select(p => p.year).Distinct().ToList();
            List<string> Discription = obj.Select(p => p.Discription).Distinct().ToList();

            ViewBag.AllLegends = Objdal.GetAllProductVariantRegion(Convert.ToInt16(product));

            string CommentaryTitle = "";
            string CommentaryDescription = "";
            int PId = 0;
            if (product != null)
            {
                int ProductId = int.Parse(product);
                PId = ProductId;
                CommentaryTitle = ObjCommentary.GetCommentaryList().Where(x => x.Product == ProductId && x.Type == "Market Analysis").OrderByDescending(w => w.CreatedTime).FirstOrDefault() != null ? ObjCommentary.GetCommentaryList().Where(x => x.Product == ProductId && x.Type == "Market Analysis").OrderByDescending(w => w.CreatedTime).FirstOrDefault().Title : "";
                CommentaryDescription = ObjCommentary.GetCommentaryList().Where(x => x.Product == ProductId && x.Type == "Market Analysis").OrderByDescending(w => w.CreatedTime).FirstOrDefault() != null ? ObjCommentary.GetCommentaryList().Where(x => x.Product == ProductId && x.Type == "Market Analysis").OrderByDescending(w => w.CreatedTime).FirstOrDefault().Description : "";
            }
            else
            {
                PId = ObjProduct.GetProductList().OrderBy(w => w.id).FirstOrDefault().id;
                CommentaryTitle = ObjCommentary.GetCommentaryList().Where(x => x.Product == PId && x.Type == "Market Analysis").OrderByDescending(w => w.CreatedTime).FirstOrDefault() != null ? ObjCommentary.GetCommentaryList().Where(x => x.Product == PId && x.Type == "Market Analysis").OrderByDescending(w => w.CreatedTime).FirstOrDefault().Title : "";
                CommentaryDescription = ObjCommentary.GetCommentaryList().Where(x => x.Product == PId && x.Type == "Market Analysis").OrderByDescending(w => w.CreatedTime).FirstOrDefault() != null ? ObjCommentary.GetCommentaryList().Where(x => x.Product == PId && x.Type == "Market Analysis").OrderByDescending(w => w.CreatedTime).FirstOrDefault().Description : "";

            }



            var lstModel = new List<MA_StackViewModel>();

            for (int i = 0; i < Year.Count; i++)
            {

                List<SA_MarketbyRegiontonnes> Chartdata = obj.Where(Chart => Chart.year == Year[i]).ToList();
                //sales of product sales by quarter  
                MA_StackViewModel Report = new MA_StackViewModel();
                Report.MStackedDimensionOne = Year[i];
                Report.Discription = Discription;
                Report.category = Objdal.GetctegotyBYproduct(obj[0].Product);
                Report.Product = (obj[0].Product).ToString();
                Report.Compare = compare;
                List<SimpleReportViewModel> Data = new List<SimpleReportViewModel>();
                List<SimpleReportViewModel> QuantityList = new List<ViewModel.SimpleReportViewModel>();

                foreach (var item in Chartdata)
                {
                    SimpleReportViewModel Quantity = new SimpleReportViewModel()
                    {
                        MDimensionOne = item.Region,
                        Quantity = item.count
                    };
                    QuantityList.Add(Quantity);
                }
                Report.LstData = QuantityList;
                if (product == null)
                {
                    Report.MChartType = "line";
                    Report.MRange = "Yearly";
                }
                else
                {
                    Report.Product = product;
                    Report.MChartType = chartType;
                    Report.MRange = Range;
                }
                lstModel.Add(Report);
            }


            if (lstModel.Count() <= 0 && Customer == false)
            {

                ViewBag.product = product;
                ViewBag.ChartType = chartType;
                ViewBag.range = Range;
                ViewBag.ProductList = ObjProduct.CategoryByUser(0);
                ViewBag.Category = Objdal.GetctegotyBYproduct(int.Parse(product));
                NewsDataStore Obj2 = new NewsDataStore();
                DealsDataStore Obj = new DealsDataStore();
                DealsDetailsViewModel d = new DealsDetailsViewModel();
                d.NewsList = Obj2.GetNewsList();
                d.DealList = Obj.GetDealsList();
                return View("market-AnalysisData", d);

            }
            else if (lstModel.Count() <= 0 && Customer == true)
            {
                ViewBag.product = product;
                ViewBag.ChartType = chartType;
                ViewBag.range = Range;
                ViewBag.ProductList = ObjProduct.CategoryByUser(custid);
                ViewBag.Category = Objdal.GetctegotyBYproduct(int.Parse(product));
                return View("market-AnalysisDataUser");

            }
            else if (Customer == true)
            {
                ViewBag.ProductList = ObjProduct.CategoryByUser(custid);


                lstModel[0].CommentaryTitle = CommentaryTitle;
                lstModel[0].CommentaryDescription = CommentaryDescription;
                lstModel[0].selectedLegends = selectedLegends;
                return View("marketanalysisUser", lstModel);
            }
            else
            {
                ViewBag.ProductList = ObjProduct.CategoryByUser(custid);
                NewsDataStore Obj2 = new NewsDataStore();
                DealsDataStore Obj = new DealsDataStore();
                DealsDetailsViewModel d = new DealsDetailsViewModel();
                d.NewsList = Obj2.GetNewsList();
                d.DealList = Obj.GetDealsList();
                lstModel[0].NewsDetailsViewModel = d;

                lstModel[0].selectedLegends = selectedLegends;
                lstModel[0].CommentaryTitle = CommentaryTitle;
                lstModel[0].CommentaryDescription = CommentaryDescription;

                return View("marketanalysis", lstModel);
            }



        }

        public ActionResult MarketbyTradeExportChart(string product, string chartType, string Range, string CompareProject, bool Customer, string FromYear, string ToYear, string selectedLegends = "")
        {
            MarketAnalysis Objdal = new DAL.MarketAnalysis();
            ViewBag.Chart2 = true;
            int custid = 0;
            if (product == null && Customer == true)
            {
                ViewBag.product = product;
                ViewBag.ChartType = chartType;
                ViewBag.range = Range;
                ViewBag.ChartType = "line";

                custid = int.Parse(Session["LoginUser"].ToString());

                ViewBag.ProductList = ObjProduct.CategoryByUser(custid);
                ViewBag.Category = Objdal.GetctegotyBYproduct(0);
                return View("market-AnalysisDataUser");

            }
            if (Customer == true)
            {
                custid = int.Parse(Session["LoginUser"].ToString());

            }

            List<SA_MarketbyTradeExport> obj = null;
            string compare = string.Empty;
            if (CompareProject != null)
            {
                compare = CompareProject;
                CompareProject = CompareProject + "," + product;
                string[] values = CompareProject.Split(',');
                for (int i = 0; i < values.Length; i++)
                {
                    values[i] = values[i].Trim();
                }
                //   values[values.Length] = CompareProject;

                obj = Objdal.GetTradeExportWiseProductListwithCompare(values);

            }
            else
            {
                if (string.IsNullOrEmpty(selectedLegends))
                {

                    obj = Objdal.GetTradeExportWiseProductList(product);

                }
                else
                {
                    string selfilter = selectedLegends + ",";
                    obj = Objdal.GetTradeExportWiseProductList(product).Where(w => selfilter.Contains(w.Country + ",")).ToList();
                }

            }
            //else
            //    obj = Objdal.GetTradeExportWiseProductList(product);





            List<string> Year = obj.Select(p => p.year).Distinct().ToList();
            List<string> Discription = obj.Select(p => p.Discription).Distinct().ToList();

            ViewBag.AllLegends = Objdal.GetAllProductVariantTradeExport(Convert.ToInt16(product));

            string CommentaryTitle = "";
            string CommentaryDescription = "";
            int PId = 0;
            if (product != null)
            {
                int ProductId = int.Parse(product);
                PId = ProductId;
                CommentaryTitle = ObjCommentary.GetCommentaryList().Where(x => x.Product == ProductId && x.Type == "Market Analysis").OrderByDescending(w => w.CreatedTime).FirstOrDefault() != null ? ObjCommentary.GetCommentaryList().Where(x => x.Product == ProductId && x.Type == "Market Analysis").OrderByDescending(w => w.CreatedTime).FirstOrDefault().Title : "";
                CommentaryDescription = ObjCommentary.GetCommentaryList().Where(x => x.Product == ProductId && x.Type == "Market Analysis").OrderByDescending(w => w.CreatedTime).FirstOrDefault() != null ? ObjCommentary.GetCommentaryList().Where(x => x.Product == ProductId && x.Type == "Market Analysis").OrderByDescending(w => w.CreatedTime).FirstOrDefault().Description : "";
            }
            else
            {
                PId = ObjProduct.GetProductList().OrderBy(w => w.id).FirstOrDefault().id;
                CommentaryTitle = ObjCommentary.GetCommentaryList().Where(x => x.Product == PId && x.Type == "Market Analysis").OrderByDescending(w => w.CreatedTime).FirstOrDefault() != null ? ObjCommentary.GetCommentaryList().Where(x => x.Product == PId && x.Type == "Market Analysis").OrderByDescending(w => w.CreatedTime).FirstOrDefault().Title : "";
                CommentaryDescription = ObjCommentary.GetCommentaryList().Where(x => x.Product == PId && x.Type == "Market Analysis").OrderByDescending(w => w.CreatedTime).FirstOrDefault() != null ? ObjCommentary.GetCommentaryList().Where(x => x.Product == PId && x.Type == "Market Analysis").OrderByDescending(w => w.CreatedTime).FirstOrDefault().Description : "";

            }



            var lstModel = new List<MA_StackViewModel>();

            for (int i = 0; i < Year.Count; i++)
            {

                List<SA_MarketbyTradeExport> Chartdata = obj.Where(Chart => Chart.year == Year[i]).ToList();
                //sales of product sales by quarter  
                MA_StackViewModel Report = new MA_StackViewModel();
                Report.MStackedDimensionOne = Year[i];
                Report.Discription = Discription;
                Report.category = Objdal.GetctegotyBYproduct(obj[0].Product);
                Report.Product = (obj[0].Product).ToString();
                Report.Compare = compare;
                List<SimpleReportViewModel> Data = new List<SimpleReportViewModel>();
                List<SimpleReportViewModel> QuantityList = new List<ViewModel.SimpleReportViewModel>();

                foreach (var item in Chartdata)
                {
                    SimpleReportViewModel Quantity = new SimpleReportViewModel()
                    {
                        MDimensionOne = item.Country,
                        Quantity = item.value,
                        Quantity1 = item.volume
                    };
                    QuantityList.Add(Quantity);
                }
                Report.LstData = QuantityList;
                if (product == null)
                {
                    Report.MChartType = "line";
                    Report.MRange = "Yearly";
                }
                else
                {
                    Report.Product = product;
                    Report.MChartType = chartType;
                    Report.MRange = Range;
                }
                lstModel.Add(Report);
            }


            if (lstModel.Count() <= 0 && Customer == false)
            {

                ViewBag.product = product;
                ViewBag.ChartType = chartType;
                ViewBag.range = Range;
                ViewBag.ProductList = ObjProduct.CategoryByUser(0);
                ViewBag.Category = Objdal.GetctegotyBYproduct(int.Parse(product));
                NewsDataStore Obj2 = new NewsDataStore();
                DealsDataStore Obj = new DealsDataStore();
                DealsDetailsViewModel d = new DealsDetailsViewModel();
                d.NewsList = Obj2.GetNewsList();
                d.DealList = Obj.GetDealsList();
                return View("market-AnalysisData", d);

            }
            else if (lstModel.Count() <= 0 && Customer == true)
            {
                ViewBag.product = product;
                ViewBag.ChartType = chartType;
                ViewBag.range = Range;
                ViewBag.ProductList = ObjProduct.CategoryByUser(custid);
                ViewBag.Category = Objdal.GetctegotyBYproduct(int.Parse(product));
                return View("market-AnalysisDataUser");

            }
            else if (Customer == true)
            {
                ViewBag.ProductList = ObjProduct.CategoryByUser(custid);

                lstModel[0].CommentaryTitle = CommentaryTitle;
                lstModel[0].CommentaryDescription = CommentaryDescription;
                lstModel[0].selectedLegends = selectedLegends;
                return View("marketanalysisUser", lstModel);
            }
            else
            {
                ViewBag.ProductList = ObjProduct.CategoryByUser(custid);
                NewsDataStore Obj2 = new NewsDataStore();
                DealsDataStore Obj = new DealsDataStore();
                DealsDetailsViewModel d = new DealsDetailsViewModel();
                d.NewsList = Obj2.GetNewsList();
                d.DealList = Obj.GetDealsList();
                lstModel[0].NewsDetailsViewModel = d;

                lstModel[0].CommentaryTitle = CommentaryTitle;
                lstModel[0].CommentaryDescription = CommentaryDescription;
                lstModel[0].selectedLegends = selectedLegends;
                return View("marketanalysis", lstModel);
            }



        }

        public ActionResult MarketbyTradeImportChart(string product, string chartType, string Range, string CompareProject, bool Customer, string FromYear, string ToYear, string selectedLegends = "")
        {
            ViewBag.Chart2 = true;
            MarketAnalysis Objdal = new DAL.MarketAnalysis();
            int custid = 0;
            if (product == null && Customer == true)
            {
                ViewBag.product = product;
                ViewBag.ChartType = chartType;
                ViewBag.range = Range;
                ViewBag.ChartType = "line";

                custid = int.Parse(Session["LoginUser"].ToString());

                ViewBag.ProductList = ObjProduct.CategoryByUser(custid);
                ViewBag.Category = Objdal.GetctegotyBYproduct(0);
                return View("market-AnalysisDataUser");

            }
            if (Customer == true)
            {
                custid = int.Parse(Session["LoginUser"].ToString());

            }

            List<SA_MarketbyTradeImport> obj = null;
            string compare = string.Empty;
            if (CompareProject != null)
            {
                compare = CompareProject;
                CompareProject = CompareProject + "," + product;
                string[] values = CompareProject.Split(',');
                for (int i = 0; i < values.Length; i++)
                {
                    values[i] = values[i].Trim();
                }
                //   values[values.Length] = CompareProject;

                obj = Objdal.GetTradeImportWiseProductListwithCompare(values);

            }
            else
            {
                if (string.IsNullOrEmpty(selectedLegends))
                {

                    obj = Objdal.GetTradeImportWiseProductList(product);

                }
                else
                {
                    string selfilter = selectedLegends + ",";
                    obj = Objdal.GetTradeImportWiseProductList(product).Where(w => selfilter.Contains(w.Country + ",")).ToList();
                }
                 
            }
            List<string> Year = obj.Select(p => p.year).Distinct().ToList();
            List<string> Discription = obj.Select(p => p.Discription).Distinct().ToList();


            ViewBag.AllLegends = Objdal.GetAllProductVariantTradeImport(Convert.ToInt16(product));

            string CommentaryTitle = "";
            string CommentaryDescription = "";
            int PId = 0;
            if (product != null)
            {
                int ProductId = int.Parse(product);
                PId = ProductId;
                CommentaryTitle = ObjCommentary.GetCommentaryList().Where(x => x.Product == ProductId && x.Type == "Market Analysis").OrderByDescending(w => w.CreatedTime).FirstOrDefault() != null ? ObjCommentary.GetCommentaryList().Where(x => x.Product == ProductId && x.Type == "Market Analysis").OrderByDescending(w => w.CreatedTime).FirstOrDefault().Title : "";
                CommentaryDescription = ObjCommentary.GetCommentaryList().Where(x => x.Product == ProductId && x.Type == "Market Analysis").OrderByDescending(w => w.CreatedTime).FirstOrDefault() != null ? ObjCommentary.GetCommentaryList().Where(x => x.Product == ProductId && x.Type == "Market Analysis").OrderByDescending(w => w.CreatedTime).FirstOrDefault().Description : "";
            }
            else
            {
                PId = ObjProduct.GetProductList().OrderBy(w => w.id).FirstOrDefault().id;
                CommentaryTitle = ObjCommentary.GetCommentaryList().Where(x => x.Product == PId && x.Type == "Market Analysis").OrderByDescending(w => w.CreatedTime).FirstOrDefault() != null ? ObjCommentary.GetCommentaryList().Where(x => x.Product == PId && x.Type == "Market Analysis").OrderByDescending(w => w.CreatedTime).FirstOrDefault().Title : "";
                CommentaryDescription = ObjCommentary.GetCommentaryList().Where(x => x.Product == PId && x.Type == "Market Analysis").OrderByDescending(w => w.CreatedTime).FirstOrDefault() != null ? ObjCommentary.GetCommentaryList().Where(x => x.Product == PId && x.Type == "Market Analysis").OrderByDescending(w => w.CreatedTime).FirstOrDefault().Description : "";

            }



            var lstModel = new List<MA_StackViewModel>();

            for (int i = 0; i < Year.Count; i++)
            {

                List<SA_MarketbyTradeImport> Chartdata = obj.Where(Chart => Chart.year == Year[i]).ToList();
                //sales of product sales by quarter  
                MA_StackViewModel Report = new MA_StackViewModel();
                Report.MStackedDimensionOne = Year[i];
                Report.Discription = Discription;
                Report.category = Objdal.GetctegotyBYproduct(obj[0].Product);
                Report.Product = (obj[0].Product).ToString();
                Report.Compare = compare;
                List<SimpleReportViewModel> Data = new List<SimpleReportViewModel>();
                List<SimpleReportViewModel> QuantityList = new List<ViewModel.SimpleReportViewModel>();

                foreach (var item in Chartdata)
                {
                    SimpleReportViewModel Quantity = new SimpleReportViewModel()
                    {
                        MDimensionOne = item.Country,
                        Quantity = item.value,
                        Quantity1 = item.volume
                    };
                    QuantityList.Add(Quantity);
                }
                Report.LstData = QuantityList;
                if (product == null)
                {
                    Report.MChartType = "line";
                    Report.MRange = "Yearly";
                }
                else
                {
                    Report.Product = product;
                    Report.MChartType = chartType;
                    Report.MRange = Range;
                }
                lstModel.Add(Report);
            }


            if (lstModel.Count() <= 0 && Customer == false)
            {

                ViewBag.product = product;
                ViewBag.ChartType = chartType;
                ViewBag.range = Range;
                ViewBag.ProductList = ObjProduct.CategoryByUser(0);
                ViewBag.Category = Objdal.GetctegotyBYproduct(int.Parse(product));
                NewsDataStore Obj2 = new NewsDataStore();
                DealsDataStore Obj = new DealsDataStore();
                DealsDetailsViewModel d = new DealsDetailsViewModel();
                d.NewsList = Obj2.GetNewsList();
                d.DealList = Obj.GetDealsList();
                return View("market-AnalysisData", d);

            }
            else if (lstModel.Count() <= 0 && Customer == true)
            {
                ViewBag.product = product;
                ViewBag.ChartType = chartType;
                ViewBag.range = Range;
                ViewBag.ProductList = ObjProduct.CategoryByUser(custid);
                ViewBag.Category = Objdal.GetctegotyBYproduct(int.Parse(product));
                return View("market-AnalysisDataUser");

            }
            else if (Customer == true)
            {
                ViewBag.ProductList = ObjProduct.CategoryByUser(custid);

                lstModel[0].CommentaryTitle = CommentaryTitle;
                lstModel[0].CommentaryDescription = CommentaryDescription;
                lstModel[0].selectedLegends = selectedLegends;
                return View("marketanalysisUser", lstModel);
            }
            else
            {
                ViewBag.ProductList = ObjProduct.CategoryByUser(custid);
                NewsDataStore Obj2 = new NewsDataStore();
                DealsDataStore Obj = new DealsDataStore();
                DealsDetailsViewModel d = new DealsDetailsViewModel();
                d.NewsList = Obj2.GetNewsList();
                d.DealList = Obj.GetDealsList();
                lstModel[0].NewsDetailsViewModel = d;

                lstModel[0].CommentaryTitle = CommentaryTitle;
                lstModel[0].CommentaryDescription = CommentaryDescription;
                lstModel[0].selectedLegends = selectedLegends;
                return View("marketanalysis", lstModel);
            }



        }

        public ActionResult MarketbySupplyGapChart(string product, string chartType, string Range, string CompareProject, bool Customer, string FromYear, string ToYear, string selectedLegends = "")
        {
            MarketAnalysis Objdal = new DAL.MarketAnalysis();
            int custid = 0;
            if (product == null && Customer == true)
            {
                ViewBag.product = product;
                ViewBag.ChartType = chartType;
                ViewBag.range = Range;
                ViewBag.ChartType = "line";

                custid = int.Parse(Session["LoginUser"].ToString());

                ViewBag.ProductList = ObjProduct.CategoryByUser(custid);
                ViewBag.Category = Objdal.GetctegotyBYproduct(0);
                return View("market-AnalysisDataUser");

            }
            if (Customer == true)
            {
                custid = int.Parse(Session["LoginUser"].ToString());

            }

            List<SA_MarketbyDemandsupplyGraph> obj = null;
            string compare = string.Empty;
            if (CompareProject != null)
            {
                compare = CompareProject;
                CompareProject = CompareProject + "," + product;
                string[] values = CompareProject.Split(',');
                for (int i = 0; i < values.Length; i++)
                {
                    values[i] = values[i].Trim();
                }
                //   values[values.Length] = CompareProject;

                obj = Objdal.GetDemandsupplyWiseProductListwithCompare(values);

            }
            else
            {
                if (string.IsNullOrEmpty(selectedLegends))
                {

                    obj = Objdal.GetDemandsupplyGraphWiseProductList(product);

                }
                else
                {
                    string selfilter = selectedLegends + ",";
                    obj = Objdal.GetDemandsupplyGraphWiseProductList(product).Where(w => selfilter.Contains(w.DemandSupply + ",")).ToList();
                }

            }

            //else
            //    obj = Objdal.GetDemandsupplyGraphWiseProductList(product);


            ViewBag.R = Objdal.GetDemandsupplyWiseProductList(product);

            List<string> Year = obj.Select(p => p.year).Distinct().ToList();
            List<string> Discription = obj.Select(p => p.Discription).Distinct().ToList();

            ViewBag.AllLegends = Objdal.GetAllProductVariantSupplyGap(Convert.ToInt16(product));

            string CommentaryTitle = "";
            string CommentaryDescription = "";
            int PId = 0;
            if (product != null)
            {
                int ProductId = int.Parse(product);
                PId = ProductId;
                CommentaryTitle = ObjCommentary.GetCommentaryList().Where(x => x.Product == ProductId && x.Type == "Market Analysis").OrderByDescending(w => w.CreatedTime).FirstOrDefault() != null ? ObjCommentary.GetCommentaryList().Where(x => x.Product == ProductId && x.Type == "Market Analysis").OrderByDescending(w => w.CreatedTime).FirstOrDefault().Title : "";
                CommentaryDescription = ObjCommentary.GetCommentaryList().Where(x => x.Product == ProductId && x.Type == "Market Analysis").OrderByDescending(w => w.CreatedTime).FirstOrDefault() != null ? ObjCommentary.GetCommentaryList().Where(x => x.Product == ProductId && x.Type == "Market Analysis").OrderByDescending(w => w.CreatedTime).FirstOrDefault().Description : "";
            }
            else
            {
                PId = ObjProduct.GetProductList().OrderBy(w => w.id).FirstOrDefault().id;
                CommentaryTitle = ObjCommentary.GetCommentaryList().Where(x => x.Product == PId && x.Type == "Market Analysis").OrderByDescending(w => w.CreatedTime).FirstOrDefault() != null ? ObjCommentary.GetCommentaryList().Where(x => x.Product == PId && x.Type == "Market Analysis").OrderByDescending(w => w.CreatedTime).FirstOrDefault().Title : "";
                CommentaryDescription = ObjCommentary.GetCommentaryList().Where(x => x.Product == PId && x.Type == "Market Analysis").OrderByDescending(w => w.CreatedTime).FirstOrDefault() != null ? ObjCommentary.GetCommentaryList().Where(x => x.Product == PId && x.Type == "Market Analysis").OrderByDescending(w => w.CreatedTime).FirstOrDefault().Description : "";

            }



            var lstModel = new List<MA_StackViewModel>();

            for (int i = 0; i < Year.Count; i++)
            {

                List<SA_MarketbyDemandsupplyGraph> Chartdata = obj.Where(Chart => Chart.year == Year[i]).ToList();
                //sales of product sales by quarter  
                MA_StackViewModel Report = new MA_StackViewModel();
                Report.MStackedDimensionOne = Year[i];
                Report.Discription = Discription;
                Report.category = Objdal.GetctegotyBYproduct(obj[0].Product);
                Report.Product = (obj[0].Product).ToString();
                Report.Compare = compare;
                List<SimpleReportViewModel> Data = new List<SimpleReportViewModel>();
                List<SimpleReportViewModel> QuantityList = new List<ViewModel.SimpleReportViewModel>();

                foreach (var item in Chartdata)
                {
                    SimpleReportViewModel Quantity = new SimpleReportViewModel()
                    {
                        MDimensionOne = item.DemandSupply,
                        Quantity = item.count
                    };
                    QuantityList.Add(Quantity);
                }
                Report.LstData = QuantityList;
                if (product == null)
                {
                    Report.MChartType = "line";
                    Report.MRange = "Yearly";
                }
                else
                {
                    Report.Product = product;
                    Report.MChartType = chartType;
                    Report.MRange = Range;
                }
                lstModel.Add(Report);
            }


            if (lstModel.Count() <= 0 && Customer == false)
            {

                ViewBag.product = product;
                ViewBag.ChartType = chartType;
                ViewBag.range = Range;
                ViewBag.ProductList = ObjProduct.CategoryByUser(0);
                ViewBag.Category = Objdal.GetctegotyBYproduct(int.Parse(product));
                NewsDataStore Obj2 = new NewsDataStore();
                DealsDataStore Obj = new DealsDataStore();
                DealsDetailsViewModel d = new DealsDetailsViewModel();
                d.NewsList = Obj2.GetNewsList();
                d.DealList = Obj.GetDealsList();
                return View("market-AnalysisData", d);

            }
            else if (lstModel.Count() <= 0 && Customer == true)
            {
                ViewBag.product = product;
                ViewBag.ChartType = chartType;
                ViewBag.range = Range;
                ViewBag.ProductList = ObjProduct.CategoryByUser(custid);
                ViewBag.Category = Objdal.GetctegotyBYproduct(int.Parse(product));
                return View("market-AnalysisDataUser");

            }
            else if (Customer == true)
            {
                ViewBag.ProductList = ObjProduct.CategoryByUser(custid);

                lstModel[0].CommentaryTitle = CommentaryTitle;
                lstModel[0].CommentaryDescription = CommentaryDescription;
                lstModel[0].selectedLegends = selectedLegends;
                return View("marketanalysisUser", lstModel);
            }
            else
            {
                ViewBag.ProductList = ObjProduct.CategoryByUser(custid);
                NewsDataStore Obj2 = new NewsDataStore();
                DealsDataStore Obj = new DealsDataStore();
                DealsDetailsViewModel d = new DealsDetailsViewModel();
                d.NewsList = Obj2.GetNewsList();
                d.DealList = Obj.GetDealsList();
                lstModel[0].NewsDetailsViewModel = d;

                lstModel[0].CommentaryTitle = CommentaryTitle;
                lstModel[0].CommentaryDescription = CommentaryDescription;
                lstModel[0].selectedLegends = selectedLegends;
                return View("marketanalysis", lstModel);
            }



        }

        public ActionResult MarketbyCompanySharesPercentChart(string product, string chartType, string Range, string CompareProject, bool Customer, string FromYear, string ToYear, string selectedLegends = "")
        {
            MarketAnalysis Objdal = new DAL.MarketAnalysis();
            int custid = 0;
            if (product == null && Customer == true)
            {
                ViewBag.product = product;
                ViewBag.ChartType = chartType;
                ViewBag.range = Range;
                ViewBag.ChartType = "line";

                custid = int.Parse(Session["LoginUser"].ToString());

                ViewBag.ProductList = ObjProduct.CategoryByUser(custid);
                ViewBag.Category = Objdal.GetctegotyBYproduct(0);
                return View("market-AnalysisDataUser");

            }
            if (Customer == true)
            {
                custid = int.Parse(Session["LoginUser"].ToString());

            }

            List<SA_MarketbyCompanySharepercent> obj = null;
            string compare = string.Empty;
            if (CompareProject != null)
            {
                compare = CompareProject;
                CompareProject = CompareProject + "," + product;
                string[] values = CompareProject.Split(',');
                for (int i = 0; i < values.Length; i++)
                {
                    values[i] = values[i].Trim();
                }
                //   values[values.Length] = CompareProject;

                obj = Objdal.GetCompanySharepercentWiseProductListwithCompare(values);

            }
            else
                obj = Objdal.GetCompanySharepercentWiseProductList(product);
            List<string> Year = obj.Select(p => p.year).Distinct().ToList();
            List<string> Discription = obj.Select(p => p.Discription).Distinct().ToList();

            string CommentaryTitle = "";
            string CommentaryDescription = "";
            int PId = 0;
            if (product != null)
            {
                int ProductId = int.Parse(product);
                PId = ProductId;
                CommentaryTitle = ObjCommentary.GetCommentaryList().Where(x => x.Product == ProductId && x.Type == "Market Analysis").OrderByDescending(w => w.CreatedTime).FirstOrDefault() != null ? ObjCommentary.GetCommentaryList().Where(x => x.Product == ProductId && x.Type == "Market Analysis").OrderByDescending(w => w.CreatedTime).FirstOrDefault().Title : "";
                CommentaryDescription = ObjCommentary.GetCommentaryList().Where(x => x.Product == ProductId && x.Type == "Market Analysis").OrderByDescending(w => w.CreatedTime).FirstOrDefault() != null ? ObjCommentary.GetCommentaryList().Where(x => x.Product == ProductId && x.Type == "Market Analysis").OrderByDescending(w => w.CreatedTime).FirstOrDefault().Description : "";
            }
            else
            {
                PId = ObjProduct.GetProductList().OrderBy(w => w.id).FirstOrDefault().id;
                CommentaryTitle = ObjCommentary.GetCommentaryList().Where(x => x.Product == PId && x.Type == "Market Analysis").OrderByDescending(w => w.CreatedTime).FirstOrDefault() != null ? ObjCommentary.GetCommentaryList().Where(x => x.Product == PId && x.Type == "Market Analysis").OrderByDescending(w => w.CreatedTime).FirstOrDefault().Title : "";
                CommentaryDescription = ObjCommentary.GetCommentaryList().Where(x => x.Product == PId && x.Type == "Market Analysis").OrderByDescending(w => w.CreatedTime).FirstOrDefault() != null ? ObjCommentary.GetCommentaryList().Where(x => x.Product == PId && x.Type == "Market Analysis").OrderByDescending(w => w.CreatedTime).FirstOrDefault().Description : "";

            }



            var lstModel = new List<MA_StackViewModel>();

            for (int i = 0; i < Year.Count; i++)
            {

                List<SA_MarketbyCompanySharepercent> Chartdata = obj.Where(Chart => Chart.year == Year[i]).ToList();
                //sales of product sales by quarter  
                MA_StackViewModel Report = new MA_StackViewModel();
                Report.MStackedDimensionOne = Year[i];
                Report.Discription = Discription;
                Report.category = Objdal.GetctegotyBYproduct(obj[0].Product);
                Report.Product = (obj[0].Product).ToString();
                Report.Compare = compare;
                List<SimpleReportViewModel> Data = new List<SimpleReportViewModel>();
                List<SimpleReportViewModel> QuantityList = new List<ViewModel.SimpleReportViewModel>();

                foreach (var item in Chartdata)
                {
                    SimpleReportViewModel Quantity = new SimpleReportViewModel()
                    {
                        MDimensionOne = item.Company,
                        Quantity = item.count
                    };
                    QuantityList.Add(Quantity);
                }
                Report.LstData = QuantityList;
                if (product == null)
                {
                    Report.MChartType = "line";
                    Report.MRange = "Yearly";
                }
                else
                {
                    Report.Product = product;
                    Report.MChartType = chartType;
                    Report.MRange = Range;
                }
                lstModel.Add(Report);
            }


            if (lstModel.Count() <= 0 && Customer == false)
            {

                ViewBag.product = product;
                ViewBag.ChartType = chartType;
                ViewBag.range = Range;
                ViewBag.ProductList = ObjProduct.CategoryByUser(0);
                ViewBag.Category = Objdal.GetctegotyBYproduct(int.Parse(product));
                NewsDataStore Obj2 = new NewsDataStore();
                DealsDataStore Obj = new DealsDataStore();
                DealsDetailsViewModel d = new DealsDetailsViewModel();
                d.NewsList = Obj2.GetNewsList();
                d.DealList = Obj.GetDealsList();
                return View("market-AnalysisData", d);

            }
            else if (lstModel.Count() <= 0 && Customer == true)
            {
                ViewBag.product = product;
                ViewBag.ChartType = chartType;
                ViewBag.range = Range;
                ViewBag.ProductList = ObjProduct.CategoryByUser(custid);
                ViewBag.Category = Objdal.GetctegotyBYproduct(int.Parse(product));
                return View("market-AnalysisDataUser");

            }
            else if (Customer == true)
            {
                ViewBag.ProductList = ObjProduct.CategoryByUser(custid);

                lstModel[0].CommentaryTitle = CommentaryTitle;
                lstModel[0].CommentaryDescription = CommentaryDescription;

                return View("marketanalysisUser", lstModel);
            }
            else
            {
                ViewBag.ProductList = ObjProduct.CategoryByUser(custid);
                NewsDataStore Obj2 = new NewsDataStore();
                DealsDataStore Obj = new DealsDataStore();
                DealsDetailsViewModel d = new DealsDetailsViewModel();
                d.NewsList = Obj2.GetNewsList();
                d.DealList = Obj.GetDealsList();
                lstModel[0].NewsDetailsViewModel = d;

                lstModel[0].CommentaryTitle = CommentaryTitle;
                lstModel[0].CommentaryDescription = CommentaryDescription;

                return View("marketanalysis", lstModel);
            }



        }

        public ActionResult MarketbyCompanySharesTonneChart(string product, string chartType, string Range, string CompareProject, bool Customer, string FromYear, string ToYear, string selectedLegends = "")
        {
            MarketAnalysis Objdal = new DAL.MarketAnalysis();
            int custid = 0;
            if (product == null && Customer == true)
            {
                ViewBag.product = product;
                ViewBag.ChartType = chartType;
                ViewBag.range = Range;
                ViewBag.ChartType = "line";

                custid = int.Parse(Session["LoginUser"].ToString());

                ViewBag.ProductList = ObjProduct.CategoryByUser(custid);
                ViewBag.Category = Objdal.GetctegotyBYproduct(0);
                return View("market-AnalysisDataUser");

            }
            if (Customer == true)
            {
                custid = int.Parse(Session["LoginUser"].ToString());

            }

            List<SA_MarketbyCompanySharetonnes> obj = null;
            string compare = string.Empty;
            if (CompareProject != null)
            {
                compare = CompareProject;
                CompareProject = CompareProject + "," + product;
                string[] values = CompareProject.Split(',');
                for (int i = 0; i < values.Length; i++)
                {
                    values[i] = values[i].Trim();
                }
                //   values[values.Length] = CompareProject;

                obj = Objdal.GetCompanySharetonnesWiseProductListwithCompare(values);

            }
            else
            {
                if (string.IsNullOrEmpty(selectedLegends))
                {

                    obj = Objdal.GetCompanySharetonnesWiseProductList(product);

                }
                else
                {
                    string selfilter = selectedLegends + ",";
                    obj = Objdal.GetCompanySharetonnesWiseProductList(product).Where(w => selfilter.Contains(w.Company + ",")).ToList();
                }

            }
            //else
            //    obj = Objdal.GetCompanySharetonnesWiseProductList(product);
            //List<string> Year = obj.Select(p => p.year).Distinct().ToList();
            List<string> Year = obj.Select(p => p.Company).Distinct().ToList();
            List<string> Discription = obj.Select(p => p.Discription).Distinct().ToList();

            ViewBag.AllLegends = Objdal.GetAllProductVariantCompanyShare(Convert.ToInt16(product));

            string CommentaryTitle = "";
            string CommentaryDescription = "";
            int PId = 0;
            if (product != null)
            {
                int ProductId = int.Parse(product);
                PId = ProductId;
                CommentaryTitle = ObjCommentary.GetCommentaryList().Where(x => x.Product == ProductId && x.Type == "Market Analysis").OrderByDescending(w => w.CreatedTime).FirstOrDefault() != null ? ObjCommentary.GetCommentaryList().Where(x => x.Product == ProductId && x.Type == "Market Analysis").OrderByDescending(w => w.CreatedTime).FirstOrDefault().Title : "";
                CommentaryDescription = ObjCommentary.GetCommentaryList().Where(x => x.Product == ProductId && x.Type == "Market Analysis").OrderByDescending(w => w.CreatedTime).FirstOrDefault() != null ? ObjCommentary.GetCommentaryList().Where(x => x.Product == ProductId && x.Type == "Market Analysis").OrderByDescending(w => w.CreatedTime).FirstOrDefault().Description : "";
            }
            else
            {
                PId = ObjProduct.GetProductList().OrderBy(w => w.id).FirstOrDefault().id;
                CommentaryTitle = ObjCommentary.GetCommentaryList().Where(x => x.Product == PId && x.Type == "Market Analysis").OrderByDescending(w => w.CreatedTime).FirstOrDefault() != null ? ObjCommentary.GetCommentaryList().Where(x => x.Product == PId && x.Type == "Market Analysis").OrderByDescending(w => w.CreatedTime).FirstOrDefault().Title : "";
                CommentaryDescription = ObjCommentary.GetCommentaryList().Where(x => x.Product == PId && x.Type == "Market Analysis").OrderByDescending(w => w.CreatedTime).FirstOrDefault() != null ? ObjCommentary.GetCommentaryList().Where(x => x.Product == PId && x.Type == "Market Analysis").OrderByDescending(w => w.CreatedTime).FirstOrDefault().Description : "";

            }



            var lstModel = new List<MA_StackViewModel>();

            for (int i = 0; i < Year.Count; i++)
            {

                //List<SA_MarketbyCompanySharetonnes> Chartdata = obj.Where(Chart => Chart.year == Year[i]).ToList();
                List<SA_MarketbyCompanySharetonnes> Chartdata = obj.Where(Chart => Chart.Company == Year[i]).ToList();
                //sales of product sales by quarter  
                MA_StackViewModel Report = new MA_StackViewModel();
                Report.MStackedDimensionOne = Year[i];
                Report.Discription = Discription;
                Report.category = Objdal.GetctegotyBYproduct(obj[0].Product);
                Report.Product = (obj[0].Product).ToString();
                Report.Compare = compare;
                List<SimpleReportViewModel> Data = new List<SimpleReportViewModel>();
                List<SimpleReportViewModel> QuantityList = new List<ViewModel.SimpleReportViewModel>();

                foreach (var item in Chartdata)
                {
                    SimpleReportViewModel Quantity = new SimpleReportViewModel()
                    {
                        MDimensionOne = item.Company,
                        Quantity = item.count
                    };
                    QuantityList.Add(Quantity);
                }
                Report.LstData = QuantityList;
                if (product == null)
                {
                    Report.MChartType = "line";
                    Report.MRange = "Yearly";
                }
                else
                {
                    Report.Product = product;
                    Report.MChartType = chartType;
                    Report.MRange = Range;
                }
                lstModel.Add(Report);
            }


            if (lstModel.Count() <= 0 && Customer == false)
            {

                ViewBag.product = product;
                ViewBag.ChartType = chartType;
                ViewBag.range = Range;
                ViewBag.ProductList = ObjProduct.CategoryByUser(0);
                ViewBag.Category = Objdal.GetctegotyBYproduct(int.Parse(product));
                NewsDataStore Obj2 = new NewsDataStore();
                DealsDataStore Obj = new DealsDataStore();
                DealsDetailsViewModel d = new DealsDetailsViewModel();
                d.NewsList = Obj2.GetNewsList();
                d.DealList = Obj.GetDealsList();
                return View("market-AnalysisData", d);

            }
            else if (lstModel.Count() <= 0 && Customer == true)
            {
                ViewBag.product = product;
                ViewBag.ChartType = chartType;
                ViewBag.range = Range;
                ViewBag.ProductList = ObjProduct.CategoryByUser(custid);
                ViewBag.Category = Objdal.GetctegotyBYproduct(int.Parse(product));
                return View("market-AnalysisDataUser");

            }
            else if (Customer == true)
            {
                ViewBag.ProductList = ObjProduct.CategoryByUser(custid);

                lstModel[0].CommentaryTitle = CommentaryTitle;
                lstModel[0].CommentaryDescription = CommentaryDescription;
                lstModel[0].selectedLegends = selectedLegends;
                return View("marketanalysisUser", lstModel);
            }
            else
            {
                ViewBag.ProductList = ObjProduct.CategoryByUser(custid);
                NewsDataStore Obj2 = new NewsDataStore();
                DealsDataStore Obj = new DealsDataStore();
                DealsDetailsViewModel d = new DealsDetailsViewModel();
                d.NewsList = Obj2.GetNewsList();
                d.DealList = Obj.GetDealsList();
                lstModel[0].NewsDetailsViewModel = d;

                lstModel[0].CommentaryTitle = CommentaryTitle;
                lstModel[0].CommentaryDescription = CommentaryDescription;
                lstModel[0].selectedLegends = selectedLegends;
                return View("marketanalysis", lstModel);
            }



        }
        #endregion


        [HttpPost]
        public JsonResult CheckAccess(string ProductId)
        {
            ChemAnalystContext dbcontext = new ChemAnalystContext();
            if (!string.IsNullOrEmpty(ProductId))
            {
                int PId = int.Parse(ProductId);

                try
                {
                    var catId = dbcontext.SA_Category.OrderBy(x => x.id).FirstOrDefault().id;


                    var Firstpid = dbcontext.SA_Product.Where(w => w.Category == catId).OrderBy(x => x.id).FirstOrDefault().id;

                    //var IsAccess = dbcontext.CustProduct.Where(w=>w.ProdId == Firstpid).OrderByDescending(w => w.id).FirstOrDefault();

                    if (Firstpid == PId)
                    {
                        return Json("Access");
                    }
                    else
                    {
                        return Json("NoAcesss");
                    }
                }
                catch (Exception ex)
                {

                    throw;
                }
            }
            else
            {
                var Commentaries = ObjCommentary.GetCommentaryList().Select(w => new SelectListItem { Text = w.Title, Value = w.Description }).ToList();
                return Json(Commentaries);
            }
        }

        [HttpPost]
        public JsonResult GetUniqueYears(string rangeId)
        {
            ChemAnalystContext _context1 = new ChemAnalystContext();
            if (rangeId== "Company")
            {
                var cat = (from coun in _context1.SA_MarketbyComp select new SelectListItem { Text = coun.year, Value = coun.year.ToString() }).OrderBy(w => w.Value).Distinct().AsEnumerable();

                return Json(cat);
            }
            else if (rangeId == "Location")
            {
                var cat = (from coun in _context1.SA_MarketbyLoc select new SelectListItem { Text = coun.year, Value = coun.year.ToString() }).OrderBy(w => w.Value).Distinct().AsEnumerable();

                return Json(cat);
            }
            else if (rangeId == "Process")
            {
                var cat = (from coun in _context1.SA_MarketbyProcess select new SelectListItem { Text = coun.year, Value = coun.year.ToString() }).OrderBy(w => w.Value).Distinct().AsEnumerable();

                return Json(cat);
            }
            else if (rangeId == "Production")
            {
                var cat = (from coun in _context1.SA_MarketbyProducer select new SelectListItem { Text = coun.year, Value = coun.year.ToString() }).OrderBy(w => w.Value).Distinct().AsEnumerable();

                return Json(cat);
            }
            else if (rangeId == "Operating Efficiency")
            {
                var cat = (from coun in _context1.SA_MarketbyEfficiency select new SelectListItem { Text = coun.year, Value = coun.year.ToString() }).OrderBy(w => w.Value).Distinct().AsEnumerable();

                return Json(cat);
            }
            else if (rangeId == "Demand By EndUse(T)")
            {
                var cat = (from coun in _context1.SA_MarketbyEndUsetonnes select new SelectListItem { Text = coun.year, Value = coun.year.ToString() }).OrderBy(w => w.Value).Distinct().AsEnumerable();

                return Json(cat);
            }
            else if (rangeId == "Demand By Grade(T)")
            {
                var cat = (from coun in _context1.SA_MarketbyGradetonnes select new SelectListItem { Text = coun.year, Value = coun.year.ToString() }).OrderBy(w => w.Value).Distinct().AsEnumerable();

                return Json(cat);
            }
            else if (rangeId == "Demand By SalesChannel(T)")
            {
                var cat = (from coun in _context1.SA_MarketbySalestonnes select new SelectListItem { Text = coun.year, Value = coun.year.ToString() }).OrderBy(w => w.Value).Distinct().AsEnumerable();

                return Json(cat);
            }
            else if (rangeId == "Demand By Region(T)")
            {
                var cat = (from coun in _context1.SA_MarketbyRegiontonnes select new SelectListItem { Text = coun.year, Value = coun.year.ToString() }).OrderBy(w => w.Value).Distinct().AsEnumerable();

                return Json(cat);
            }
            else if (rangeId == "Demand By TradeExport")
            {
                var cat = (from coun in _context1.SA_MarketbyTradeExport select new SelectListItem { Text = coun.year, Value = coun.year.ToString() }).OrderBy(w => w.Value).Distinct().AsEnumerable();

                return Json(cat);
            }
            else if (rangeId == "Demand By TradeImport")
            {
                var cat = (from coun in _context1.SA_MarketbyTradeImport select new SelectListItem { Text = coun.year, Value = coun.year.ToString() }).OrderBy(w => w.Value).Distinct().AsEnumerable();

                return Json(cat);
            }
            else if (rangeId == "Demand Supply Gap")
            {
                var cat = (from coun in _context1.SA_MarketbyDemandsupply select new SelectListItem { Text = coun.year, Value = coun.year.ToString() }).OrderBy(w => w.Value).Distinct().AsEnumerable();

                return Json(cat);
            }
            else 
            {
                var cat = (from coun in _context1.SA_MarketbyCompanySharetonnes select new SelectListItem { Text = coun.year, Value = coun.year.ToString() }).OrderBy(w => w.Value).Distinct().AsEnumerable();

                return Json(cat);
            }

        }


        [HttpPost]
        public JsonResult GetProductNameUser(string CatId)
        {
            int catId = int.Parse(CatId);
            int custid = int.Parse(Session["LoginUser"].ToString());
            List<SelectListItem> customers = ObjProduct.ProductListByCategoryUser(catId, custid);
            // return Json(new { data = ObjProduct.ProductListByCategory(catId) }, JsonRequestBehavior.AllowGet);
            return Json(customers);


        }
        [HttpPost]
        public JsonResult GetProductName(string CatId)
        {
            int catId = int.Parse(CatId);
            List<SelectListItem> customers = ObjProduct.ProductListByCategory(catId);
            // return Json(new { data = ObjProduct.ProductListByCategory(catId) }, JsonRequestBehavior.AllowGet);
            return Json(customers);


        }
    }
}