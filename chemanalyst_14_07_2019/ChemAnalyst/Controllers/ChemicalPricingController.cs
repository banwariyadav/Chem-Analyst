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
    public class ChemicalPricingController : Controller
    {
        ProductDataStore ObjProduct = new ProductDataStore();
        CommentaryDataStore ObjCommentary = new CommentaryDataStore();
        ChemicalPricing Chempriceobj;
        // GET: ChemicalPricing
        public ChemicalPricingController()
        {
            Chempriceobj = new DAL.ChemicalPricing();
        }
        public ActionResult ChemicalPricingList()
        {
            return View("Chemical-FileList");
        }
        public JsonResult GetFileList()
        {

            List<SA_ChemPriceFileList> fileList = Chempriceobj.GetallUploadFile();

            return Json(new { data = fileList }, JsonRequestBehavior.AllowGet);

        }
        public ActionResult ChecmPriceChart()
        {
            string product = null;
            string ChartType = null;
            string Range = null;
            string CompareProject = null;
            bool Customer = false;
            return RedirectToAction("ChecmPriceYearlyChart", "ChemicalPricing", new
            {
                product,
                ChartType,
                Range,
                CompareProject,
                Customer
            });

        }
        public ActionResult Index()
        {

            ViewBag.ProductList = ObjProduct.ProductList();

            return View("Chemical-analysis-import");

        }
        public ActionResult ChecmPriceChartuser()
        {
            string product = null;
            string ChartType = null;
            string Range = null;
            string CompareProject = null;
            bool Customer = true;
            return RedirectToAction("ChecmPriceYearlyChart", "ChemicalPricing", new
            {
                product,
                ChartType,
                Range,
                CompareProject,
                Customer
            });

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
        public ActionResult ShowChart(FormCollection FilterObject, string submit)
        {
            string product = FilterObject["ddlProduct"];
            string ChartType = FilterObject["ddlChart"];
            string Range = FilterObject["ddlRange"];
            string Maxvalue = FilterObject["MaxValue"];
            string Minvalue = FilterObject["MinValue"];
            string ClearValue = FilterObject["ClearValue"];
            string fromdate = FilterObject["fromdate"];
            string todate = FilterObject["todate"];
            string year = FilterObject["ddlyear"];

            if (submit == "Reset")
            {
                Maxvalue = "";
            }
            else
            {
                Maxvalue = FilterObject["MaxValue"];
            }

            string CompareProject = FilterObject["example-getting-started"];
            bool Customer = false;

            if (Range == "Yearly")
            {
                return RedirectToAction("ChecmPriceYearlyChart", "ChemicalPricing", new
                {
                    product,
                    ChartType,
                    Range,
                    CompareProject,
                    Customer,
                    Maxvalue,
                    fromdate,
                    todate
                });
                // ChecmPriceYearlyChartUser(product, ChartType, Range);
            }
            else if (Range == "Monthly")
            {
                return RedirectToAction("ChecmPriceMonthlyChart", "ChemicalPricing", new
                {
                    product,
                    ChartType,
                    Range,
                    CompareProject,
                    Customer,
                    fromdate,
                    todate
                });
            }
            else if (Range == "Quarterly")
            {


                return RedirectToAction("ChecmPriceQuarterlyChart", "ChemicalPricing", new
                {
                    product,
                    ChartType,
                    Range,
                    CompareProject,
                    Customer,
                    year

                });
            }
            else if (Range == "Weekly")
            {
                return RedirectToAction("ChecmPriceWeeklyChart", "ChemicalPricing", new
                {
                    product,
                    ChartType,
                    Range,
                    CompareProject,
                    Customer,
                    fromdate,
                    todate
                });
            }
            else if (Range == "Daily basis")
            {
                return RedirectToAction("ChecmPriceDailyChart", "ChemicalPricing", new
                {
                    product,
                    ChartType,
                    Range,
                    CompareProject,
                    Customer,
                    fromdate,
                    todate
                });
            }
            else if (Range == "Daily Bulk")
            {
                return RedirectToAction("ChecmPriceDailyAverageChart", "ChemicalPricing", new
                {
                    product,
                    ChartType,
                    Range,
                    CompareProject,
                    Customer,
                    fromdate,
                    todate
                });
            }

            return RedirectToAction("index");
        }
        public ActionResult ShowUserChart(FormCollection FilterObject, string submit)
        {
            string product = FilterObject["ddlProduct"];
            string ChartType = FilterObject["ddlChart"];
            string Range = FilterObject["ddlRange"];
            string Maxvalue = FilterObject["MaxValue"];
            string Minvalue = FilterObject["MinValue"];
            string ClearValue = FilterObject["ClearValue"];
            string fromdate = FilterObject["fromdate"];
            string todate = FilterObject["todate"];
            string year = FilterObject["ddlyear"];

            if (submit == "Reset")
            {
                Maxvalue = "";
            }
            else
            {
                Maxvalue = FilterObject["MaxValue"];
            }

            string CompareProject = FilterObject["example-getting-started"];
            bool Customer = true;
            if (Range == "Yearly")
            {
                return RedirectToAction("ChecmPriceYearlyChart", "ChemicalPricing", new
                {
                    product,
                    ChartType,
                    Range,
                    CompareProject,
                    Customer,
                    Maxvalue,
                    fromdate,
                    todate
                });
                // ChecmPriceYearlyChartUser(product, ChartType, Range);
            }
            else if (Range == "Monthly")
            {
                return RedirectToAction("ChecmPriceMonthlyChart", "ChemicalPricing", new
                {
                    product,
                    ChartType,
                    Range,
                    CompareProject,
                    Customer,
                    fromdate,
                    todate
                });
            }
            else if (Range == "Quarterly")
            {
                return RedirectToAction("ChecmPriceQuarterlyChart", "ChemicalPricing", new
                {
                    product,
                    ChartType,
                    Range,
                    CompareProject,
                    Customer,
                    year
                });
            }
            else if (Range == "Weekly")
            {
                return RedirectToAction("ChecmPriceWeeklyChart", "ChemicalPricing", new
                {
                    product,
                    ChartType,
                    Range,
                    CompareProject,
                    Customer,
                    fromdate,
                    todate
                });
            }
            else if (Range == "Daily basis")
            {
                return RedirectToAction("ChecmPriceDailyChart", "ChemicalPricing", new
                {
                    product,
                    ChartType,
                    Range,
                    CompareProject,
                    Customer,
                    fromdate,
                    todate
                });
            }
            else if (Range == "Daily Bulk")
            {
                return RedirectToAction("ChecmPriceDailyAverageChart", "ChemicalPricing", new
                {
                    product,
                    ChartType,
                    Range,
                    CompareProject,
                    Customer,
                    fromdate,
                    todate
                });
            }
            return RedirectToAction("ChecmPriceYearlyChart");
        }
        public ActionResult MonthlyUpload(FormCollection formcollection)
        {
            ProductDataStore ObjProduct = new ProductDataStore();
            System.Data.DataTable dt = new System.Data.DataTable();
            string product = formcollection["hdproductid"];
            string ImportType = formcollection["Typelist"];
            string UploadFileDiscription = formcollection["UploadFileDiscription"];
            bool ReplaceData = Convert.ToBoolean(formcollection["ReplaceData"].Split(',')[0]);// formcollection["ReplaceData"];

            string productName = ObjProduct.GetProductByid(Convert.ToInt32(product)).ProductName;
            string path = string.Empty;
            string fileName = string.Empty;
            for (int i = 0; i < Request.Files.Count; i++)
            {
                var file = Request.Files[i];

                if (file != null && file.ContentLength > 0)
                {

                    fileName = Path.GetFileName(file.FileName);
                    if (ReplaceData)
                    {
                        int data = Chempriceobj.CheckExistingdata(fileName, ImportType);
                    }
                    else
                    {
                        int data = Chempriceobj.CheckFileuploadStatus(fileName, ImportType);
                        if (data == 1)
                        {
                            ViewBag.ProductList = ObjProduct.ProductList();

                            ViewBag.Status = "Fail";
                            ViewBag.Messge = "File is already uploaded under "+productName+" & mapped with "+ ImportType + " Kindly check if you want to Replace the existing file.";
                            return View("Chemical-analysis-import");
                        }

                    }
                    path = Path.Combine(Server.MapPath("~/ChemPricingImportfile"), fileName);
                    file.SaveAs(path);
                    if (ImportType == "Yearly")
                    {
                        var excel = new ExcelPackage(file.InputStream);
                        dt = excel.ToDataTable();
                        InsertYearExcelRecords(product, ImportType, UploadFileDiscription, path, dt, fileName);
                        ViewBag.ProductList = ObjProduct.ProductList();
                        ViewBag.Status = "Success";
                        ViewBag.SuccesMessge = "File uploaded under "+productName+" & mapped with "+ ImportType + " Successfully.";
                        return View("Chemical-analysis-import");
                    }
                    else if (ImportType == "Monthly")
                    {
                        var excel = new ExcelPackage(file.InputStream);
                        dt = excel.ToMonthlyDataTable();
                        InsertMonthlyExcelRecords(product, ImportType, UploadFileDiscription, path, dt, fileName);
                        ViewBag.ProductList = ObjProduct.ProductList();
                        ViewBag.Status = "Success";
                        ViewBag.SuccesMessge = "File uploaded under " + productName + " & mapped with " + ImportType + " Successfully.";
                        return View("Chemical-analysis-import");
                    }
                    else if (ImportType == "Quarterly")
                    {
                        var excel = new ExcelPackage(file.InputStream);
                        dt = excel.ToQuarterlyDataTable();
                        InsertQuaterlyExcelRecords(product, ImportType, UploadFileDiscription, path, dt, fileName);
                        ViewBag.ProductList = ObjProduct.ProductList();
                        ViewBag.Status = "Success";
                        ViewBag.SuccesMessge = "File uploaded under " + productName + " & mapped with " + ImportType + " Successfully.";
                        return View("Chemical-analysis-import");
                    }
                    else if (ImportType == "Weekly")
                    {
                        var excel = new ExcelPackage(file.InputStream);
                        dt = excel.ToDailyDataTable();
                        InsertWeeklyExcelRecords(product, ImportType, UploadFileDiscription, path, dt, fileName);
                        ViewBag.ProductList = ObjProduct.ProductList();
                        ViewBag.Status = "Success";
                        ViewBag.SuccesMessge = "File uploaded under " + productName + " & mapped with " + ImportType + " Successfully.";
                        return View("Chemical-analysis-import");
                    }
                    else if (ImportType == "Daily basis")
                    {
                        var excel = new ExcelPackage(file.InputStream);
                        dt = excel.ToDailyDataTable();
                        InsertDAilyExcelRecords(product, ImportType, UploadFileDiscription, path, dt, fileName);
                        ViewBag.ProductList = ObjProduct.ProductList();
                        ViewBag.Status = "Success";
                        ViewBag.SuccesMessge = "File uploaded under " + productName + " & mapped with " + ImportType + " Successfully.";
                        return View("Chemical-analysis-import");
                    }
                    else if (ImportType == "Daily Bulk")
                    {
                        var excel = new ExcelPackage(file.InputStream);
                        dt = excel.ToDailyDataTable();
                        InsertDailyAverageExcelRecords(product, ImportType, UploadFileDiscription, path, dt, fileName);
                        ViewBag.ProductList = ObjProduct.ProductList();
                        ViewBag.Status = "Success";
                        ViewBag.SuccesMessge = "File uploaded under " + productName + " & mapped with " + ImportType + " Successfully.";
                        return View("Chemical-analysis-import");
                    }
                    else if (ImportType == "Chemical 1")
                    {
                        var excel = new ExcelPackage(file.InputStream);
                        dt = excel.ToDataTable();
                        if (InsertChemical1ExcelRecords(product, ImportType, UploadFileDiscription, path, dt, fileName))
                        {
                            ViewBag.Status = "Success";
                            ViewBag.SuccesMessge = "File uploaded under " + productName + " & mapped with " + ImportType + " Successfully.";

                        }
                        else
                            ViewBag.Messge = "Data  not Imported successfully.";
                        ViewBag.ProductList = ObjProduct.ProductList();

                        return View("Chemical-analysis-import");
                    }
                    else if (ImportType == "Chemical 2")
                    {
                        var excel = new ExcelPackage(file.InputStream);
                        dt = excel.ToDataTable();
                        if (InsertChemical2ExcelRecords(product, ImportType, UploadFileDiscription, path, dt, fileName))
                        {
                            ViewBag.Status = "Success";
                            ViewBag.SuccesMessge = "File uploaded under " + productName + " & mapped with " + ImportType + " Successfully.";

                        }
                        else
                            ViewBag.Messge = "Data  not Imported successfully.";
                        ViewBag.ProductList = ObjProduct.ProductList();
                        return View("Chemical-analysis-import");
                    }
                    else if (ImportType == "Chemical 3")
                    {
                        var excel = new ExcelPackage(file.InputStream);
                        dt = excel.ToDataTable();
                        if (InsertChemical3ExcelRecords(product, ImportType, UploadFileDiscription, path, dt, fileName))
                        {
                            ViewBag.Status = "Success";
                            ViewBag.SuccesMessge = "File uploaded under " + productName + " & mapped with " + ImportType + " Successfully.";

                        }
                        else
                            ViewBag.Messge = "Data  not Imported successfully.";
                        ViewBag.ProductList = ObjProduct.ProductList();
                        return View("Chemical-analysis-import");
                    }
                    else if (ImportType == "Chemical 4")
                    {
                        var excel = new ExcelPackage(file.InputStream);
                        dt = excel.ToDataTable();
                        if (InsertChemical4ExcelRecords(product, ImportType, UploadFileDiscription, path, dt, fileName))
                        {
                            ViewBag.Status = "Success";
                            ViewBag.SuccesMessge = "File uploaded under " + productName + " & mapped with " + ImportType + " Successfully.";

                        }
                        else
                            ViewBag.Messge = "Data  not Imported successfully.";
                        ViewBag.ProductList = ObjProduct.ProductList();
                        return View("Chemical-analysis-import");
                    }
                    else if (ImportType == "Chemical 5")
                    {
                        var excel = new ExcelPackage(file.InputStream);
                        dt = excel.ToDataTable();
                        if (InsertChemical5ExcelRecords(product, ImportType, UploadFileDiscription, path, dt, fileName))
                        {
                            ViewBag.Status = "Success";
                            ViewBag.SuccesMessge = "File uploaded under " + productName + " & mapped with " + ImportType + " Successfully.";

                        }
                        else
                            ViewBag.Messge = "Data  not Imported successfully.";
                        ViewBag.ProductList = ObjProduct.ProductList();
                        return View("Chemical-analysis-import");
                    }
                }
            }


            ViewBag.ProductList = ObjProduct.ProductList();
            ViewBag.Status = "Success";
            ViewBag.SuccesMessge = "File uploaded under " + productName + " & mapped with " + ImportType + " Successfully.";
            return RedirectToAction("Index");

        }

        private bool InsertChemical1ExcelRecords(string product, string type, string UploadFileDiscription, string path, System.Data.DataTable Exceldt, string fileName)
        {

            try
            {

                Exceldt.Columns.Add("Product", typeof(int));
                Exceldt.Columns.Add("Discription", typeof(string));
                Exceldt.Columns.Add("FileName", typeof(string));
                Exceldt.Columns.Add("CreatedDate", typeof(DateTime));
                for (int i = Exceldt.Rows.Count - 1; i >= 0; i--)
                {
                    if ((Exceldt.Rows[i]["Product Name"] == DBNull.Value || Exceldt.Rows[i]["Year"] == DBNull.Value || Exceldt.Rows[i]["count"] == DBNull.Value) || (Exceldt.Rows[i]["Product Name"].ToString().Trim() == "" || Exceldt.Rows[i]["Year"].ToString().Trim() == "" || Exceldt.Rows[i]["count"].ToString().Trim() == ""))
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
                string productid = Exceldt.Rows[0]["Product Name"].ToString();
                string year = Exceldt.Rows[0]["Year"].ToString();


                //inserting Datatable Records to DataBase   
                var connectionString = ConfigurationManager.ConnectionStrings["ChemAnalystContext"].ConnectionString;
                SqlConnection sqlConnection = new SqlConnection();
                sqlConnection.ConnectionString = connectionString;//Connection Details  
                                                                  //creating object of SqlBulkCopy      
                SqlBulkCopy objbulk = new SqlBulkCopy(sqlConnection);
                //assigning Destination table name      
                objbulk.DestinationTableName = "SA_Chem1PriceYearly";
                //Mapping Table column    
                objbulk.ColumnMappings.Add("[Product]", "Product");
                objbulk.ColumnMappings.Add("[Product Name]", "ProductVariant");
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

                return false;


            }
            return true;

        }
        private bool InsertChemical2ExcelRecords(string product, string type, string UploadFileDiscription, string path, System.Data.DataTable Exceldt, string fileName)
        {

            try
            {

                Exceldt.Columns.Add("Product", typeof(int));
                Exceldt.Columns.Add("Discription", typeof(string));
                Exceldt.Columns.Add("FileName", typeof(string));
                Exceldt.Columns.Add("CreatedDate", typeof(DateTime));
                for (int i = Exceldt.Rows.Count - 1; i >= 0; i--)
                {
                    if ((Exceldt.Rows[i]["Product Name"] == DBNull.Value || Exceldt.Rows[i]["Year"] == DBNull.Value || Exceldt.Rows[i]["count"] == DBNull.Value) || (Exceldt.Rows[i]["Product Name"].ToString().Trim() == "" || Exceldt.Rows[i]["Year"].ToString().Trim() == "" || Exceldt.Rows[i]["count"].ToString().Trim() == ""))
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
                string productid = Exceldt.Rows[0]["Product Name"].ToString();
                string year = Exceldt.Rows[0]["Year"].ToString();


                //inserting Datatable Records to DataBase   
                var connectionString = ConfigurationManager.ConnectionStrings["ChemAnalystContext"].ConnectionString;
                SqlConnection sqlConnection = new SqlConnection();
                sqlConnection.ConnectionString = connectionString;//Connection Details  
                                                                  //creating object of SqlBulkCopy      
                SqlBulkCopy objbulk = new SqlBulkCopy(sqlConnection);
                //assigning Destination table name      
                objbulk.DestinationTableName = "SA_Chem2PriceYearly";
                //Mapping Table column    
                objbulk.ColumnMappings.Add("[Product]", "Product");
                objbulk.ColumnMappings.Add("[Product Name]", "ProductVariant");
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
                return false;



            }
            return true;

        }
        private bool InsertChemical3ExcelRecords(string product, string type, string UploadFileDiscription, string path, System.Data.DataTable Exceldt, string fileName)
        {

            try
            {

                Exceldt.Columns.Add("Product", typeof(int));
                Exceldt.Columns.Add("Discription", typeof(string));
                Exceldt.Columns.Add("FileName", typeof(string));
                Exceldt.Columns.Add("CreatedDate", typeof(DateTime));
                for (int i = Exceldt.Rows.Count - 1; i >= 0; i--)
                {
                    if ((Exceldt.Rows[i]["Product Name"] == DBNull.Value || Exceldt.Rows[i]["Year"] == DBNull.Value || Exceldt.Rows[i]["count"] == DBNull.Value) || (Exceldt.Rows[i]["Product Name"].ToString().Trim() == "" || Exceldt.Rows[i]["Year"].ToString().Trim() == "" || Exceldt.Rows[i]["count"].ToString().Trim() == ""))
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
                string productid = Exceldt.Rows[0]["Product Name"].ToString();
                string year = Exceldt.Rows[0]["Year"].ToString();


                //inserting Datatable Records to DataBase   
                var connectionString = ConfigurationManager.ConnectionStrings["ChemAnalystContext"].ConnectionString;
                SqlConnection sqlConnection = new SqlConnection();
                sqlConnection.ConnectionString = connectionString;//Connection Details  
                                                                  //creating object of SqlBulkCopy      
                SqlBulkCopy objbulk = new SqlBulkCopy(sqlConnection);
                //assigning Destination table name      
                objbulk.DestinationTableName = "SA_Chem3PriceYearly";
                //Mapping Table column    
                objbulk.ColumnMappings.Add("[Product]", "Product");
                objbulk.ColumnMappings.Add("[Product Name]", "ProductVariant");
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
                return false;



            }
            return true;

        }
        private bool InsertChemical4ExcelRecords(string product, string type, string UploadFileDiscription, string path, System.Data.DataTable Exceldt, string fileName)
        {

            try
            {

                Exceldt.Columns.Add("Product", typeof(int));
                Exceldt.Columns.Add("Discription", typeof(string));
                Exceldt.Columns.Add("FileName", typeof(string));
                Exceldt.Columns.Add("CreatedDate", typeof(DateTime));
                for (int i = Exceldt.Rows.Count - 1; i >= 0; i--)
                {
                    if ((Exceldt.Rows[i]["Product Name"] == DBNull.Value || Exceldt.Rows[i]["Year"] == DBNull.Value || Exceldt.Rows[i]["count"] == DBNull.Value) || (Exceldt.Rows[i]["Product Name"].ToString().Trim() == "" || Exceldt.Rows[i]["Year"].ToString().Trim() == "" || Exceldt.Rows[i]["count"].ToString().Trim() == ""))
                    {
                        Exceldt.Rows[i].Delete();
                    }
                    else
                    {
                        string producid = Exceldt.Rows[i]["Product Name"].ToString();

                        Exceldt.Rows[i]["Product"] = product;
                        Exceldt.Rows[i]["Discription"] = UploadFileDiscription;
                        Exceldt.Rows[i]["FileName"] = fileName;
                        Exceldt.Rows[i]["CreatedDate"] = DateTime.Now;
                    }
                }
                Exceldt.AcceptChanges();
                string productid = Exceldt.Rows[0]["Product Name"].ToString();
                string year = Exceldt.Rows[0]["Year"].ToString();


                //inserting Datatable Records to DataBase   
                var connectionString = ConfigurationManager.ConnectionStrings["ChemAnalystContext"].ConnectionString;
                SqlConnection sqlConnection = new SqlConnection();
                sqlConnection.ConnectionString = connectionString;//Connection Details  
                                                                  //creating object of SqlBulkCopy      
                SqlBulkCopy objbulk = new SqlBulkCopy(sqlConnection);
                //assigning Destination table name      
                objbulk.DestinationTableName = "SA_Chem4PriceYearly";
                //Mapping Table column    
                objbulk.ColumnMappings.Add("[Product]", "Product");
                objbulk.ColumnMappings.Add("[Product Name]", "ProductVariant");
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

                return false;


            }
            return true;

        }
        private bool InsertChemical5ExcelRecords(string product, string type, string UploadFileDiscription, string path, System.Data.DataTable Exceldt, string fileName)
        {

            try
            {

                Exceldt.Columns.Add("Product", typeof(int));
                Exceldt.Columns.Add("Discription", typeof(string));
                Exceldt.Columns.Add("FileName", typeof(string));
                Exceldt.Columns.Add("CreatedDate", typeof(DateTime));
                for (int i = Exceldt.Rows.Count - 1; i >= 0; i--)
                {
                    if ((Exceldt.Rows[i]["Product Name"] == DBNull.Value || Exceldt.Rows[i]["Year"] == DBNull.Value || Exceldt.Rows[i]["count"] == DBNull.Value) || (Exceldt.Rows[i]["Product Name"].ToString().Trim() == "" || Exceldt.Rows[i]["Year"].ToString().Trim() == "" || Exceldt.Rows[i]["count"].ToString().Trim() == ""))
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
                string productid = Exceldt.Rows[0]["Product Name"].ToString();
                string year = Exceldt.Rows[0]["Year"].ToString();


                //inserting Datatable Records to DataBase   
                var connectionString = ConfigurationManager.ConnectionStrings["ChemAnalystContext"].ConnectionString;
                SqlConnection sqlConnection = new SqlConnection();
                sqlConnection.ConnectionString = connectionString;//Connection Details  
                                                                  //creating object of SqlBulkCopy      
                SqlBulkCopy objbulk = new SqlBulkCopy(sqlConnection);
                //assigning Destination table name      
                objbulk.DestinationTableName = "SA_Chem5PriceYearly";
                //Mapping Table column    
                objbulk.ColumnMappings.Add("[Product]", "Product");
                objbulk.ColumnMappings.Add("[Product Name]", "ProductVariant");
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

                return false;


            }
            return true;

        }



        private bool InsertYearExcelRecords(string product, string type, string UploadFileDiscription, string path, System.Data.DataTable Exceldt, string fileName)
        {

            try
            {

                Exceldt.Columns.Add("Product", typeof(int));
                Exceldt.Columns.Add("Discription", typeof(string));
                Exceldt.Columns.Add("FileName", typeof(string));
                Exceldt.Columns.Add("CreatedDate", typeof(DateTime));
                for (int i = Exceldt.Rows.Count - 1; i >= 0; i--)
                {
                    if (Exceldt.Rows[i]["Product Name"] == DBNull.Value || Exceldt.Rows[i]["Year"] == DBNull.Value || Exceldt.Rows[i]["count"] == DBNull.Value)
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
                string productid = Exceldt.Rows[0]["Product Name"].ToString();
                string year = Exceldt.Rows[0]["Year"].ToString();


                //inserting Datatable Records to DataBase   
                var connectionString = ConfigurationManager.ConnectionStrings["ChemAnalystContext"].ConnectionString;
                SqlConnection sqlConnection = new SqlConnection();
                sqlConnection.ConnectionString = connectionString;//Connection Details  
                                                                  //creating object of SqlBulkCopy      
                SqlBulkCopy objbulk = new SqlBulkCopy(sqlConnection);
                //assigning Destination table name      
                objbulk.DestinationTableName = "SA_ChemPriceYearly";
                //Mapping Table column    
                objbulk.ColumnMappings.Add("[Product]", "Product");
                objbulk.ColumnMappings.Add("[Product Name]", "ProductVariant");
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
        private void InsertMonthlyExcelRecords(string product, string type, string UploadFileDiscription, string path, System.Data.DataTable Exceldt, string fileName)
        {

            try
            {


                Exceldt.Columns.Add("Product", typeof(int));
                Exceldt.Columns.Add("Discription", typeof(string));
                Exceldt.Columns.Add("FileName", typeof(string));
                Exceldt.Columns.Add("CreatedDate", typeof(DateTime));
                for (int i = Exceldt.Rows.Count - 1; i >= 0; i--)
                {
                    if (Exceldt.Rows[i]["Product Name"] == DBNull.Value || Exceldt.Rows[i]["Year"] == DBNull.Value || Exceldt.Rows[i]["count"] == DBNull.Value)
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


                //inserting Datatable Records to DataBase   
                var connectionString = ConfigurationManager.ConnectionStrings["ChemAnalystContext"].ConnectionString;
                SqlConnection sqlConnection = new SqlConnection();
                sqlConnection.ConnectionString = connectionString;//Connection Details  
                                                                  //creating object of SqlBulkCopy      
                SqlBulkCopy objbulk = new SqlBulkCopy(sqlConnection);
                //assigning Destination table name      
                objbulk.DestinationTableName = "SA_ChemPriceMonthly";
                //Mapping Table column    
                objbulk.ColumnMappings.Add("[Product]", "Product");
                objbulk.ColumnMappings.Add("[Product Name]", "ProductVariant");
                objbulk.ColumnMappings.Add("[Year]", "year");
                objbulk.ColumnMappings.Add("[Month]", "Month");
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

        }
        private void InsertQuaterlyExcelRecords(string product, string type, string UploadFileDiscription, string path, System.Data.DataTable Exceldt, string fileName)
        {


            try
            {

                Exceldt.Columns.Add("Product", typeof(int));
                Exceldt.Columns.Add("Discription", typeof(string));
                Exceldt.Columns.Add("FileName", typeof(string));
                Exceldt.Columns.Add("CreatedDate", typeof(DateTime));
                for (int i = Exceldt.Rows.Count - 1; i >= 0; i--)
                {
                    if (Exceldt.Rows[i]["Product Name"] == DBNull.Value || Exceldt.Rows[i]["Year"] == DBNull.Value || Exceldt.Rows[i]["count"] == DBNull.Value)
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


                //inserting Datatable Records to DataBase   
                var connectionString = ConfigurationManager.ConnectionStrings["ChemAnalystContext"].ConnectionString;
                SqlConnection sqlConnection = new SqlConnection();
                sqlConnection.ConnectionString = connectionString;//Connection Details  
                                                                  //creating object of SqlBulkCopy      
                SqlBulkCopy objbulk = new SqlBulkCopy(sqlConnection);
                //assigning Destination table name      
                objbulk.DestinationTableName = "SA_ChemPriceQuarterly";
                //Mapping Table column    
                objbulk.ColumnMappings.Add("[Product]", "Product");
                objbulk.ColumnMappings.Add("[Product Name]", "ProductVariant");
                objbulk.ColumnMappings.Add("[Year]", "year");
                objbulk.ColumnMappings.Add("[Quarter]", "Quarter");
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
        }
        private void InsertDAilyExcelRecords(string product, string type, string UploadFileDiscription, string path, System.Data.DataTable Exceldt, string fileName)
        {

            try
            {


                System.Data.DataTable dt = new System.Data.DataTable();

                dt.Columns.Add("Product", typeof(string));
                dt.Columns.Add("ProductVariant", typeof(string));
                dt.Columns.Add("year", typeof(string));
                dt.Columns.Add("Month", typeof(string));
                dt.Columns.Add("Day", typeof(string));
                dt.Columns.Add("count", typeof(string));
                dt.Columns.Add("Discription", typeof(string));
                dt.Columns.Add("FileName", typeof(string));
                dt.Columns.Add("CreatedDate", typeof(DateTime));
                for (int i = Exceldt.Rows.Count - 1; i >= 0; i--)
                {
                    if (Exceldt.Rows[i]["Product Name"] == DBNull.Value || Exceldt.Rows[i]["Year"] == DBNull.Value || Exceldt.Rows[i]["Month"] == DBNull.Value)
                    {
                        Exceldt.Rows[i].Delete();
                    }

                    else
                    {
                        if (Exceldt.Rows[i]["Month"].ToString().ToUpper() == "JANUARY" || Exceldt.Rows[i]["Month"].ToString().ToUpper() == "MARCH" || Exceldt.Rows[i]["Month"].ToString().ToUpper() == "MAY" || Exceldt.Rows[i]["Month"].ToString().ToUpper() == "JULY" || Exceldt.Rows[i]["Month"].ToString().ToUpper() == "AUGUST" || Exceldt.Rows[i]["Month"].ToString().ToUpper() == "OCTORBER" || Exceldt.Rows[i]["Month"].ToString().ToUpper() == "DECEMBER")
                            for (int j = 3; j < Exceldt.Columns.Count; j++)
                            {
                                DataRow daily = dt.NewRow();
                                daily["Product"] = product;
                                daily["ProductVariant"] = Exceldt.Rows[i]["Product Name"].ToString();
                                daily["year"] = Exceldt.Rows[i]["Year"].ToString();
                                daily["Month"] = Exceldt.Rows[i]["Month"].ToString();
                                daily["Day"] = j - 2;
                                daily["count"] = Exceldt.Rows[i][j].ToString();
                                daily["Discription"] = UploadFileDiscription;
                                daily["FileName"] = fileName;
                                daily["CreatedDate"] = DateTime.Now;
                                dt.Rows.Add(daily);
                            }
                        else if (Exceldt.Rows[i]["Month"].ToString().ToUpper() == "APRIL" || Exceldt.Rows[i]["Month"].ToString().ToUpper() == "JUNE" || Exceldt.Rows[i]["Month"].ToString().ToUpper() == "SEPTEMBER" || Exceldt.Rows[i]["Month"].ToString().ToUpper() == "NOVEMBER")
                            for (int j = 3; j < Exceldt.Columns.Count - 1; j++)
                            {
                                DataRow daily = dt.NewRow();
                                daily["Product"] = product;
                                daily["ProductVariant"] = Exceldt.Rows[i]["Product Name"].ToString();
                                daily["year"] = Exceldt.Rows[i]["Year"].ToString();
                                daily["Month"] = Exceldt.Rows[i]["Month"].ToString();
                                daily["Day"] = j - 2;
                                daily["count"] = Exceldt.Rows[i][j].ToString();
                                daily["Discription"] = UploadFileDiscription;
                                daily["FileName"] = fileName;
                                daily["CreatedDate"] = DateTime.Now;
                                dt.Rows.Add(daily);
                            }
                        else if (Exceldt.Rows[i]["Month"].ToString().ToUpper() == "FEBUARY" || (int.Parse(Exceldt.Rows[i]["Year"].ToString())) % 4 == 0)
                            for (int j = 3; j < Exceldt.Columns.Count - 2; j++)
                            {
                                DataRow daily = dt.NewRow();
                                daily["Product"] = product;
                                daily["ProductVariant"] = Exceldt.Rows[i]["Product Name"].ToString();
                                daily["year"] = Exceldt.Rows[i]["Year"].ToString();
                                daily["Month"] = Exceldt.Rows[i]["Month"].ToString();
                                daily["Day"] = j - 2;
                                daily["count"] = Exceldt.Rows[i][j].ToString();
                                daily["Discription"] = UploadFileDiscription;
                                daily["FileName"] = fileName;
                                daily["CreatedDate"] = DateTime.Now;
                                dt.Rows.Add(daily);
                            }
                        else
                        {
                            for (int j = 3; j < Exceldt.Columns.Count - 3; j++)
                            {
                                DataRow daily = dt.NewRow();
                                daily["Product"] = product;
                                daily["ProductVariant"] = Exceldt.Rows[i]["Product Name"].ToString();
                                daily["year"] = Exceldt.Rows[i]["Year"].ToString();
                                daily["Month"] = Exceldt.Rows[i]["Month"].ToString();
                                daily["Day"] = j - 2;
                                daily["count"] = Exceldt.Rows[i][j].ToString();
                                daily["Discription"] = UploadFileDiscription;
                                daily["FileName"] = fileName;
                                daily["CreatedDate"] = DateTime.Now;
                                dt.Rows.Add(daily);
                            }
                        }

                    }
                }
                dt.AcceptChanges();


                //inserting Datatable Records to DataBase   
                var connectionString = ConfigurationManager.ConnectionStrings["ChemAnalystContext"].ConnectionString;
                SqlConnection sqlConnection = new SqlConnection();
                sqlConnection.ConnectionString = connectionString;//Connection Details  
                                                                  //creating object of SqlBulkCopy      
                SqlBulkCopy objbulk = new SqlBulkCopy(sqlConnection);
                //assigning Destination table name      
                objbulk.DestinationTableName = "SA_ChemPriceDaily";
                //Mapping Table column    
                objbulk.ColumnMappings.Add("Product", "Product");
                objbulk.ColumnMappings.Add("ProductVariant", "ProductVariant");
                objbulk.ColumnMappings.Add("year", "year");
                objbulk.ColumnMappings.Add("Month", "Month");
                objbulk.ColumnMappings.Add("Day", "Day");
                objbulk.ColumnMappings.Add("count", "count");
                objbulk.ColumnMappings.Add("Discription", "Discription");
                objbulk.ColumnMappings.Add("[FileName]", "FileName");
                objbulk.ColumnMappings.Add("[CreatedDate]", "CreatedDate");

                sqlConnection.Open();
                objbulk.WriteToServer(dt);
                sqlConnection.Close();
                //  MessageBox.Show("Data has been Imported successfully.", "Imported", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                //  MessageBox.Show(string.Format("Data has not been Imported due to :{0}", ex.Message), "Not Imported", MessageBoxButtons.OK, MessageBoxIcon.Warning);



            }

        }
        private void InsertWeeklyExcelRecords(string product, string type, string UploadFileDiscription, string path, System.Data.DataTable Exceldt, string fileName)
        {

            try
            {


                System.Data.DataTable dt = new System.Data.DataTable();

                dt.Columns.Add("Product", typeof(string));
                dt.Columns.Add("ProductVariant", typeof(string));
                dt.Columns.Add("year", typeof(string));
                dt.Columns.Add("Month", typeof(string));
                dt.Columns.Add("Day", typeof(string));
                dt.Columns.Add("count", typeof(string));
                dt.Columns.Add("Discription", typeof(string));
                dt.Columns.Add("FileName", typeof(string));
                dt.Columns.Add("CreatedDate", typeof(DateTime));
                for (int i = Exceldt.Rows.Count - 1; i >= 0; i--)
                {
                    if (Exceldt.Rows[i]["Product Name"] == DBNull.Value || Exceldt.Rows[i]["Year"] == DBNull.Value || Exceldt.Rows[i]["Month"] == DBNull.Value)
                    {
                        Exceldt.Rows[i].Delete();
                    }

                    else
                    {
                        if (Exceldt.Rows[i]["Month"].ToString().ToUpper() == "JANUARY" || Exceldt.Rows[i]["Month"].ToString().ToUpper() == "MARCH" || Exceldt.Rows[i]["Month"].ToString().ToUpper() == "MAY" || Exceldt.Rows[i]["Month"].ToString().ToUpper() == "JULY" || Exceldt.Rows[i]["Month"].ToString().ToUpper() == "AUGUST" || Exceldt.Rows[i]["Month"].ToString().ToUpper() == "OCTORBER" || Exceldt.Rows[i]["Month"].ToString().ToUpper() == "DECEMBER")
                            for (int j = 3; j < Exceldt.Columns.Count; j++)
                            {
                                DataRow daily = dt.NewRow();
                                daily["Product"] = product;
                                daily["ProductVariant"] = Exceldt.Rows[i]["Product Name"].ToString();
                                daily["year"] = Exceldt.Rows[i]["Year"].ToString();
                                daily["Month"] = Exceldt.Rows[i]["Month"].ToString();
                                daily["Day"] = j - 2;
                                daily["count"] = Exceldt.Rows[i][j].ToString();
                                daily["Discription"] = UploadFileDiscription;
                                daily["FileName"] = fileName;
                                daily["CreatedDate"] = DateTime.Now;
                                dt.Rows.Add(daily);
                            }
                        else if (Exceldt.Rows[i]["Month"].ToString().ToUpper() == "APRIL" || Exceldt.Rows[i]["Month"].ToString().ToUpper() == "JUNE" || Exceldt.Rows[i]["Month"].ToString().ToUpper() == "SEPTEMBER" || Exceldt.Rows[i]["Month"].ToString().ToUpper() == "NOVEMBER")
                            for (int j = 3; j < Exceldt.Columns.Count - 1; j++)
                            {
                                DataRow daily = dt.NewRow();
                                daily["Product"] = product;
                                daily["ProductVariant"] = Exceldt.Rows[i]["Product Name"].ToString();
                                daily["year"] = Exceldt.Rows[i]["Year"].ToString();
                                daily["Month"] = Exceldt.Rows[i]["Month"].ToString();
                                daily["Day"] = j - 2;
                                daily["count"] = Exceldt.Rows[i][j].ToString();
                                daily["Discription"] = UploadFileDiscription;
                                daily["FileName"] = fileName;
                                daily["CreatedDate"] = DateTime.Now;
                                dt.Rows.Add(daily);
                            }
                        else if (Exceldt.Rows[i]["Month"].ToString().ToUpper() == "FEBUARY" || (int.Parse(Exceldt.Rows[i]["Year"].ToString())) % 4 == 0)
                            for (int j = 3; j < Exceldt.Columns.Count - 2; j++)
                            {
                                DataRow daily = dt.NewRow();
                                daily["Product"] = product;
                                daily["ProductVariant"] = Exceldt.Rows[i]["Product Name"].ToString();
                                daily["year"] = Exceldt.Rows[i]["Year"].ToString();
                                daily["Month"] = Exceldt.Rows[i]["Month"].ToString();
                                daily["Day"] = j - 2;
                                daily["count"] = Exceldt.Rows[i][j].ToString();
                                daily["Discription"] = UploadFileDiscription;
                                daily["FileName"] = fileName;
                                daily["CreatedDate"] = DateTime.Now;
                                dt.Rows.Add(daily);
                            }
                        else
                        {
                            for (int j = 3; j < Exceldt.Columns.Count - 3; j++)
                            {
                                DataRow daily = dt.NewRow();
                                daily["Product"] = product;
                                daily["ProductVariant"] = Exceldt.Rows[i]["Product Name"].ToString();
                                daily["year"] = Exceldt.Rows[i]["Year"].ToString();
                                daily["Month"] = Exceldt.Rows[i]["Month"].ToString();
                                daily["Day"] = j - 2;
                                daily["count"] = Exceldt.Rows[i][j].ToString();
                                daily["Discription"] = UploadFileDiscription;
                                daily["FileName"] = fileName;
                                daily["CreatedDate"] = DateTime.Now;
                                dt.Rows.Add(daily);
                            }
                        }

                    }
                }
                dt.AcceptChanges();


                //inserting Datatable Records to DataBase   
                var connectionString = ConfigurationManager.ConnectionStrings["ChemAnalystContext"].ConnectionString;
                SqlConnection sqlConnection = new SqlConnection();
                sqlConnection.ConnectionString = connectionString;//Connection Details  
                                                                  //creating object of SqlBulkCopy      
                SqlBulkCopy objbulk = new SqlBulkCopy(sqlConnection);
                //assigning Destination table name      
                objbulk.DestinationTableName = "SA_ChemPriceWeekly";
                //Mapping Table column    
                objbulk.ColumnMappings.Add("Product", "Product");
                objbulk.ColumnMappings.Add("ProductVariant", "ProductVariant");
                objbulk.ColumnMappings.Add("year", "year");
                objbulk.ColumnMappings.Add("Month", "Month");
                objbulk.ColumnMappings.Add("Day", "Day");
                objbulk.ColumnMappings.Add("count", "count");
                objbulk.ColumnMappings.Add("Discription", "Discription");
                objbulk.ColumnMappings.Add("[FileName]", "FileName");
                objbulk.ColumnMappings.Add("[CreatedDate]", "CreatedDate");

                sqlConnection.Open();
                objbulk.WriteToServer(dt);
                sqlConnection.Close();
                //  MessageBox.Show("Data has been Imported successfully.", "Imported", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                //  MessageBox.Show(string.Format("Data has not been Imported due to :{0}", ex.Message), "Not Imported", MessageBoxButtons.OK, MessageBoxIcon.Warning);



            }

        }
        private void InsertDailyAverageExcelRecords(string product, string type, string UploadFileDiscription, string path, System.Data.DataTable Exceldt, string fileName)
        {

            try
            {


                System.Data.DataTable dt = new System.Data.DataTable();

                dt.Columns.Add("Product", typeof(string));
                dt.Columns.Add("ProductVariant", typeof(string));
                dt.Columns.Add("year", typeof(string));
                dt.Columns.Add("Month", typeof(string));
                dt.Columns.Add("Day", typeof(string));
                dt.Columns.Add("count", typeof(string));
                dt.Columns.Add("Discription", typeof(string));
                dt.Columns.Add("FileName", typeof(string));
                dt.Columns.Add("CreatedDate", typeof(DateTime));
                for (int i = Exceldt.Rows.Count - 1; i >= 0; i--)
                {
                    if (Exceldt.Rows[i]["Product Name"] == DBNull.Value || Exceldt.Rows[i]["Year"] == DBNull.Value || Exceldt.Rows[i]["Month"] == DBNull.Value)
                    {
                        Exceldt.Rows[i].Delete();
                    }

                    else
                    {
                        if (Exceldt.Rows[i]["Month"].ToString().ToUpper() == "JANUARY" || Exceldt.Rows[i]["Month"].ToString().ToUpper() == "MARCH" || Exceldt.Rows[i]["Month"].ToString().ToUpper() == "MAY" || Exceldt.Rows[i]["Month"].ToString().ToUpper() == "JULY" || Exceldt.Rows[i]["Month"].ToString().ToUpper() == "AUGUST" || Exceldt.Rows[i]["Month"].ToString().ToUpper() == "OCTORBER" || Exceldt.Rows[i]["Month"].ToString().ToUpper() == "DECEMBER")
                            for (int j = 3; j < Exceldt.Columns.Count; j++)
                            {
                                DataRow daily = dt.NewRow();
                                daily["Product"] = product;
                                daily["ProductVariant"] = Exceldt.Rows[i]["Product Name"].ToString();
                                daily["year"] = Exceldt.Rows[i]["Year"].ToString();
                                daily["Month"] = Exceldt.Rows[i]["Month"].ToString();
                                daily["Day"] = j - 2;
                                daily["count"] = Exceldt.Rows[i][j].ToString();
                                daily["Discription"] = UploadFileDiscription;
                                daily["FileName"] = fileName;
                                daily["CreatedDate"] = DateTime.Now;
                                dt.Rows.Add(daily);
                            }
                        else if (Exceldt.Rows[i]["Month"].ToString().ToUpper() == "APRIL" || Exceldt.Rows[i]["Month"].ToString().ToUpper() == "JUNE" || Exceldt.Rows[i]["Month"].ToString().ToUpper() == "SEPTEMBER" || Exceldt.Rows[i]["Month"].ToString().ToUpper() == "NOVEMBER")
                            for (int j = 3; j < Exceldt.Columns.Count - 1; j++)
                            {
                                DataRow daily = dt.NewRow();
                                daily["Product"] = product;
                                daily["ProductVariant"] = Exceldt.Rows[i]["Product Name"].ToString();
                                daily["year"] = Exceldt.Rows[i]["Year"].ToString();
                                daily["Month"] = Exceldt.Rows[i]["Month"].ToString();
                                daily["Day"] = j - 2;
                                daily["count"] = Exceldt.Rows[i][j].ToString();
                                daily["Discription"] = UploadFileDiscription;
                                daily["FileName"] = fileName;
                                daily["CreatedDate"] = DateTime.Now;
                                dt.Rows.Add(daily);
                            }
                        else if (Exceldt.Rows[i]["Month"].ToString().ToUpper() == "FEBUARY" || (int.Parse(Exceldt.Rows[i]["Year"].ToString())) % 4 == 0)
                            for (int j = 3; j < Exceldt.Columns.Count - 2; j++)
                            {
                                DataRow daily = dt.NewRow();
                                daily["Product"] = product;
                                daily["ProductVariant"] = Exceldt.Rows[i]["Product Name"].ToString();
                                daily["year"] = Exceldt.Rows[i]["Year"].ToString();
                                daily["Month"] = Exceldt.Rows[i]["Month"].ToString();
                                daily["Day"] = j - 2;
                                daily["count"] = Exceldt.Rows[i][j].ToString();
                                daily["Discription"] = UploadFileDiscription;
                                daily["FileName"] = fileName;
                                daily["CreatedDate"] = DateTime.Now;
                                dt.Rows.Add(daily);
                            }
                        else
                        {
                            for (int j = 3; j < Exceldt.Columns.Count - 3; j++)
                            {
                                DataRow daily = dt.NewRow();
                                daily["Product"] = product;
                                daily["ProductVariant"] = Exceldt.Rows[i]["Product Name"].ToString();
                                daily["year"] = Exceldt.Rows[i]["Year"].ToString();
                                daily["Month"] = Exceldt.Rows[i]["Month"].ToString();
                                daily["Day"] = j - 2;
                                daily["count"] = Exceldt.Rows[i][j].ToString();
                                daily["Discription"] = UploadFileDiscription;
                                daily["FileName"] = fileName;
                                daily["CreatedDate"] = DateTime.Now;
                                dt.Rows.Add(daily);
                            }
                        }

                    }
                }
                dt.AcceptChanges();


                //inserting Datatable Records to DataBase   
                var connectionString = ConfigurationManager.ConnectionStrings["ChemAnalystContext"].ConnectionString;
                SqlConnection sqlConnection = new SqlConnection();
                sqlConnection.ConnectionString = connectionString;//Connection Details  
                                                                  //creating object of SqlBulkCopy      
                SqlBulkCopy objbulk = new SqlBulkCopy(sqlConnection);
                //assigning Destination table name      
                objbulk.DestinationTableName = "SA_ChemPriceDailyAverage";
                //Mapping Table column    
                objbulk.ColumnMappings.Add("Product", "Product");
                objbulk.ColumnMappings.Add("ProductVariant", "ProductVariant");
                objbulk.ColumnMappings.Add("year", "year");
                objbulk.ColumnMappings.Add("Month", "Month");
                objbulk.ColumnMappings.Add("Day", "Day");
                objbulk.ColumnMappings.Add("count", "count");
                objbulk.ColumnMappings.Add("Discription", "Discription");
                objbulk.ColumnMappings.Add("[FileName]", "FileName");
                objbulk.ColumnMappings.Add("[CreatedDate]", "CreatedDate");

                sqlConnection.Open();
                objbulk.WriteToServer(dt);
                sqlConnection.Close();
                //  MessageBox.Show("Data has been Imported successfully.", "Imported", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                //  MessageBox.Show(string.Format("Data has not been Imported due to :{0}", ex.Message), "Not Imported", MessageBoxButtons.OK, MessageBoxIcon.Warning);



            }

        }



        public ActionResult ChecmPriceYearlyChart(string product, string chartType, string Range, string CompareProject, bool Customer, string MaxValue, string fromdate = "", string todate = "")
        {
            if (fromdate == "")
            {
                fromdate = "01/01/" + (DateTime.Now.Year - 5);

            }
            if (todate == "")
            {
                todate = "12/31/" + DateTime.Now.Year;

            }
            //if (ClearValue == "ClearMaxValue")
            //{
            //    MaxValue = null;
            //}
            //else
            //{
            //    MaxValue = MaxValue;
            //}

            ChemicalPricing Objdal = new DAL.ChemicalPricing();
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



                ViewBag.FromDate = fromdate;
                ViewBag.ToDate = todate;

                return View("Chem-PriceDataUser");

            }
            if (Customer == true)
            {
                custid = int.Parse(Session["LoginUser"].ToString());

            }

            List<SA_ChemPriceYearly> obj = null;
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

                obj = Objdal.GetYearWiseProductListwithCompare(values);

            }
            else
            {
                obj = Objdal.GetYearWiseProductList(product, MaxValue, fromdate, todate);
                //if (MaxValue != null)
                //{
                //    obj = Objdal.GetYearWiseProductList(product);
                //}
                //else
                //{
                //    obj = Objdal.GetYearWiseProductList(product);
                //}

            }
            List<string> Year = obj.Select(p => p.year).Distinct().ToList();
            List<string> Discription = obj.Select(p => p.Discription).Distinct().ToList();

            string Commentary = "";
            if (product != null)
            {
                int ProductId = int.Parse(product);
                Commentary = ObjCommentary.GetCommentaryList().Where(x => x.Product == ProductId).OrderByDescending(w => w.CreatedTime).FirstOrDefault().Title;
            }
            else
            {
                Commentary = ObjCommentary.GetCommentaryList().OrderByDescending(w => w.CreatedTime).FirstOrDefault().Title;
            }

            var lstModel = new List<StackedViewModel>();

           

            for (int i = 0; i < Year.Count; i++)
            {

                

                List<SA_ChemPriceYearly> Chartdata = obj.Where(Chart => Chart.year == Year[i]).ToList();
                //sales of product sales by quarter  
                StackedViewModel Report = new StackedViewModel();
                Report.StackedDimensionOne = Year[i];
                Report.Discription = Discription;
                Report.category = Objdal.GetctegotyBYproduct(obj[0].Product);
                Report.Product = (obj[0].Product).ToString();
                Report.Compare = compare;
                Report.FromDate = fromdate;
                Report.ToDate = todate;
                Report.FirstValue = Objdal.GetYearWiseProductListFirstLastValues(product).Select(p => p.year).Distinct().ToList().First();
                Report.LastValues = Objdal.GetYearWiseProductListFirstLastValues(product).Select(p => p.year).Distinct().ToList().Last();
                Report.SelectedValues = MaxValue;
                List<SimpleReportViewModel> Data = new List<SimpleReportViewModel>();
                List<SimpleReportViewModel> QuantityList = new List<ViewModel.SimpleReportViewModel>();

                foreach (var item in Chartdata)
                {
                    SimpleReportViewModel Quantity = new SimpleReportViewModel()
                    {
                        DimensionOne = item.ProductVariant,
                        Quantity = item.count
                    };
                    QuantityList.Add(Quantity);
                }
                Report.LstData = QuantityList;
                if (product == null)
                {
                    Report.ChartType = "line";
                    Report.range = "Yearly";
                }
                else
                {
                    Report.Product = product;
                    Report.ChartType = chartType;
                    Report.range = Range;
                }
                lstModel.Add(Report);
                
            }

            lstModel[0].Commentary = Commentary;
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

                d.FromDate = fromdate;
                d.ToDate = todate;

                return View("Chem-PriceData", d);

            }
            else if (lstModel.Count() <= 0 && Customer == true)
            {
                ViewBag.product = product;
                ViewBag.ChartType = chartType;
                ViewBag.range = Range;

                ViewBag.ProductList = ObjProduct.CategoryByUser(custid);
                ViewBag.Category = Objdal.GetctegotyBYproduct(int.Parse(product));

                ViewBag.FromDate = fromdate;
                ViewBag.ToDate = todate;

                return View("Chem-PriceDataUser");


            }
            else if (Customer == true)
            {
                ViewBag.ProductList = ObjProduct.CategoryByUser(custid);
                return View("chemicalpricingUser", lstModel);
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
                return View("chemical-pricing", lstModel);
            }


        }
        public ActionResult ChecmPriceMonthlyChart(string product, string chartType, string Range, string CompareProject, bool Customer, string fromdate = "", string todate = "")
        {

            if (fromdate == "")
            {
                fromdate = "01/01/" + (DateTime.Now.Year - 5);

            }
            if (todate == "")
            {
                todate = "12/31/" + DateTime.Now.Year;

            }

            int custid = 0;

            ChemicalPricing Objdal = new DAL.ChemicalPricing();
            if (product == null && Customer == true)
            {
                ViewBag.product = product;
                ViewBag.ChartType = chartType;
                ViewBag.range = Range;
                ViewBag.ChartType = "line";

                custid = int.Parse(Session["LoginUser"].ToString());

                ViewBag.ProductList = ObjProduct.CategoryByUser(custid);
                ViewBag.Category = Objdal.GetctegotyBYproduct(0);

                ViewBag.FromDate = fromdate;
                ViewBag.ToDate = todate;

                return View("Chem-PriceDataUser");

            }
            if (Customer == true)
            {
                custid = int.Parse(Session["LoginUser"].ToString());

            }
            List<SA_ChemPriceMonthly> obj = null;
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
                obj = Objdal.GetMonthWiseProductListwithCompare(values);

            }
            else
                obj = Objdal.GetMonthlyWiseProductList1(product, fromdate, todate);
            List<string> Month = obj.Select(p => p.year).Distinct().ToList();
            List<string> Discription = obj.Select(p => p.Discription).Distinct().ToList();

            string Commentary = "";
            if (product != null)
            {
                int ProductId = int.Parse(product);
                Commentary = ObjCommentary.GetCommentaryList().Where(x => x.Product == ProductId).OrderByDescending(w => w.CreatedTime).FirstOrDefault().Title;
            }
            else
            {
                Commentary = ObjCommentary.GetCommentaryList().OrderByDescending(w => w.CreatedTime).FirstOrDefault().Title;
            }

            var lstModel = new List<StackedViewModel>();

           
            for (int i = 0; i < Month.Count; i++)
            {
                
                // List<SA_ChemPriceMonthly> Chartdata = obj.Where(Chart => Chart.year == DateTime.Now.Year.ToString() && Chart.Month == Month[i]).ToList();
                List<SA_ChemPriceMonthly> Chartdata = obj.Where(Chart => Chart.year == Month[i]).ToList();
                //sales of product sales by quarter  
                StackedViewModel Report = new StackedViewModel();
                Report.StackedDimensionOne = Month[i];
                Report.Discription = Discription;
                Report.category = Objdal.GetctegotyBYproduct(obj[0].Product);
                Report.Product = (obj[0].Product).ToString();
                Report.Compare = compare;
                Report.FromDate = fromdate;
                Report.ToDate = todate;
                List<SimpleReportViewModel> Data = new List<SimpleReportViewModel>();
                List<SimpleReportViewModel> QuantityList = new List<ViewModel.SimpleReportViewModel>();

                //foreach (var item in Chartdata)
                //{
                //    SimpleReportViewModel Quantity = new SimpleReportViewModel()
                //    {
                //        DimensionOne = item.Month,
                //        Quantity = item.count
                //    };
                //    QuantityList.Add(Quantity);
                //}

                string[] months = { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
                foreach (var item in months)
                {
                    SimpleReportViewModel Quantity = new SimpleReportViewModel()
                    {
                        DimensionOne = item,
                        Quantity = Chartdata.Where(x => x.Month == item).Sum(x => x.count)
                    };
                    QuantityList.Add(Quantity);
                }


                Report.LstData = QuantityList;
                if (product == null)
                {
                    Report.ChartType = "line";
                    Report.range = "Yearly";
                }
                else
                {
                    Report.Product = product;
                    Report.ChartType = chartType;
                    Report.range = Range;
                }
                lstModel.Add(Report);
            }

            lstModel[0].Commentary = Commentary;
            ViewBag.ProductList = ObjProduct.CategoryByUser(custid);
            if (lstModel.Count() <= 0 && Customer == false)
            {

                ViewBag.product = product;
                ViewBag.ChartType = chartType;
                ViewBag.range = Range;
                ViewBag.Category = Objdal.GetctegotyBYproduct(int.Parse(product));
                NewsDataStore Obj2 = new NewsDataStore();
                DealsDataStore Obj = new DealsDataStore();
                DealsDetailsViewModel d = new DealsDetailsViewModel();
                d.NewsList = Obj2.GetNewsList();
                d.DealList = Obj.GetDealsList();
                return View("Chem-PriceData", d);

            }
            else if (lstModel.Count() <= 0 && Customer == true)
            {
                ViewBag.product = product;
                ViewBag.ChartType = chartType;
                ViewBag.range = Range;
                ViewBag.Category = Objdal.GetctegotyBYproduct(int.Parse(product));

                ViewBag.FromDate = fromdate;
                ViewBag.ToDate = todate;

                return View("Chem-PriceDataUser");

            }
            else if (Customer == true)
            {
                ViewBag.Category = Objdal.GetctegotyBYproduct(int.Parse(product));

                return View("chemicalpricingUser", lstModel);
            }
            else
            {
                ViewBag.Category = Objdal.GetctegotyBYproduct(int.Parse(product));
                NewsDataStore Obj2 = new NewsDataStore();
                DealsDataStore Obj = new DealsDataStore();
                DealsDetailsViewModel d = new DealsDetailsViewModel();
                d.NewsList = Obj2.GetNewsList();
                d.DealList = Obj.GetDealsList();
                lstModel[0].NewsDetailsViewModel = d;
                return View("chemical-pricing", lstModel);
            }


        }
        public ActionResult ChecmPriceQuarterlyChart(string product, string chartType, string Range, string CompareProject, bool Customer, string year = "")
        {
            if (year == "")
            {
                year = DateTime.Now.Year.ToString();

            }




            int custid = 0;

            ChemicalPricing Objdal = new DAL.ChemicalPricing();
            ViewBag.QYears = Objdal.GetYear();
            ViewBag.CYear = year;
            if (product == null && Customer == true)
            {
                ViewBag.product = product;
                ViewBag.ChartType = chartType;
                ViewBag.range = Range;
                ViewBag.ChartType = "line";

                custid = int.Parse(Session["LoginUser"].ToString());

                ViewBag.ProductList = ObjProduct.CategoryByUser(custid);
                ViewBag.Category = Objdal.GetctegotyBYproduct(0);

                //ViewBag.FromDate = fromdate;
                //ViewBag.ToDate = todate;


                return View("Chem-PriceDataUser");

            }
            if (Customer == true)
            {
                custid = int.Parse(Session["LoginUser"].ToString());

            }
            List<SA_ChemPriceQuarterly> obj = null;
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
                obj = Objdal.GetQuarterWiseProductListwithCompare(values);

            }
            else
                obj = Objdal.GetQuarterWiseProductList(product, year);
            List<string> Quarter = obj.Select(p => p.Quarter).Distinct().ToList();
            List<string> Discription = obj.Select(p => p.Discription).Distinct().ToList();

            string Commentary = "";
            if (product != null)
            {
                int ProductId = int.Parse(product);
                Commentary = ObjCommentary.GetCommentaryList().Where(x => x.Product == ProductId).OrderByDescending(w => w.CreatedTime).FirstOrDefault().Title;
            }
            else
            {
                Commentary = ObjCommentary.GetCommentaryList().OrderByDescending(w => w.CreatedTime).FirstOrDefault().Title;
            }

            var lstModel = new List<StackedViewModel>();

           
            for (int i = 0; i < Quarter.Count; i++)
            {
                
                List<SA_ChemPriceQuarterly> Chartdata = obj.Where(Chart => Chart.year == DateTime.Now.Year.ToString() && Chart.Quarter == Quarter[i]).ToList();
                //sales of product sales by quarter  
                StackedViewModel Report = new StackedViewModel();
                Report.StackedDimensionOne = Quarter[i];
                Report.Discription = Discription;
                Report.category = Objdal.GetctegotyBYproduct(obj[0].Product);
                Report.Product = (obj[0].Product).ToString();
                Report.Compare = compare;
                Report.FromDate = "";
                Report.ToDate = "";
                List<SimpleReportViewModel> Data = new List<SimpleReportViewModel>();
                List<SimpleReportViewModel> QuantityList = new List<ViewModel.SimpleReportViewModel>();

                foreach (var item in Chartdata)
                {
                    SimpleReportViewModel Quantity = new SimpleReportViewModel()
                    {
                        DimensionOne = item.ProductVariant,
                        Quantity = item.count
                    };
                    QuantityList.Add(Quantity);
                }
                Report.LstData = QuantityList;
                if (product == null)
                {
                    Report.ChartType = "line";
                    Report.range = "Yearly";
                }
                else
                {
                    Report.Product = product;
                    Report.ChartType = chartType;
                    Report.range = Range;
                }
                lstModel.Add(Report);
            }

            lstModel[0].Commentary = Commentary;
            ViewBag.ProductList = ObjProduct.CategoryByUser(custid);
            if (lstModel.Count() <= 0 && Customer == false)
            {

                ViewBag.product = product;
                ViewBag.ChartType = chartType;
                ViewBag.range = Range;
                ViewBag.Category = Objdal.GetctegotyBYproduct(int.Parse(product));

                NewsDataStore Obj2 = new NewsDataStore();
                DealsDataStore Obj = new DealsDataStore();
                DealsDetailsViewModel d = new DealsDetailsViewModel();
                d.NewsList = Obj2.GetNewsList();
                d.DealList = Obj.GetDealsList();
                return View("Chem-PriceData", d);
            }
            else if (lstModel.Count() <= 0 && Customer == true)
            {
                ViewBag.product = product;
                ViewBag.ChartType = chartType;
                ViewBag.range = Range;
                ViewBag.Category = Objdal.GetctegotyBYproduct(int.Parse(product));

                //ViewBag.FromDate = fromdate;
                //ViewBag.ToDate = todate;

                return View("Chem-PriceDataUser");

            }
            else if (Customer == true)
            {
                ViewBag.Category = Objdal.GetctegotyBYproduct(int.Parse(product));

                return View("chemicalpricingUser", lstModel);
            }
            else
            {
                ViewBag.Category = Objdal.GetctegotyBYproduct(int.Parse(product));
                NewsDataStore Obj2 = new NewsDataStore();
                DealsDataStore Obj = new DealsDataStore();
                DealsDetailsViewModel d = new DealsDetailsViewModel();
                d.NewsList = Obj2.GetNewsList();
                d.DealList = Obj.GetDealsList();
                lstModel[0].NewsDetailsViewModel = d;
                return View("chemical-pricing", lstModel);
            }


        }
        public ActionResult ChecmPriceDailyChart(string product, string chartType, string Range, string CompareProject, bool Customer, string fromdate = "", string todate = "")
        {

            if (fromdate == "")
            {
                fromdate = (DateTime.Now.Month) + "/01/" + DateTime.Now.Year;

            }
            if (todate == "")
            {
                todate = (DateTime.Now.Month) + "/" + DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month) + "/" + DateTime.Now.Year;

            }

            int custid = 0;

            ChemicalPricing Objdal = new DAL.ChemicalPricing();
            if (product == null && Customer == true)
            {
                ViewBag.product = product;
                ViewBag.ChartType = chartType;
                ViewBag.range = Range;
                ViewBag.ChartType = "line";

                custid = int.Parse(Session["LoginUser"].ToString());

                ViewBag.ProductList = ObjProduct.CategoryByUser(custid);
                ViewBag.Category = Objdal.GetctegotyBYproduct(0);

                ViewBag.FromDate = fromdate;
                ViewBag.ToDate = todate;

                return View("Chem-PriceDataUser");

            }
            if (Customer == true)
            {
                custid = int.Parse(Session["LoginUser"].ToString());

            }
            List<SA_ChemPriceDaily> obj = null;
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
                obj = Objdal.GetDailyWiseProductListwithCompare(values);

            }
            else
                obj = Objdal.GetDailyWiseProductList(product, fromdate, todate);
            List<string> Day = obj.Select(p => p.day).Distinct().ToList();
            List<string> Discription = obj.Select(p => p.Discription).Distinct().ToList();
            string Commentary = "";
            if (product != null)
            {
                int ProductId = int.Parse(product);
                Commentary = ObjCommentary.GetCommentaryList().Where(x => x.Product == ProductId).OrderByDescending(w => w.CreatedTime).FirstOrDefault().Title;
            }
            else
            {
                Commentary = ObjCommentary.GetCommentaryList().OrderByDescending(w => w.CreatedTime).FirstOrDefault().Title;
            }

            var lstModel = new List<StackedViewModel>();

           
            for (int i = 0; i < Day.Count; i++)
            {
               
                List<SA_ChemPriceDaily> Chartdata = obj.Where(Chart => Chart.year == DateTime.Now.Year.ToString() && Chart.day == Day[i]).ToList();
                //sales of product sales by quarter  
                StackedViewModel Report = new StackedViewModel();
                Report.StackedDimensionOne = Day[i];
                Report.Discription = Discription;
                Report.category = Objdal.GetctegotyBYproduct(obj[0].Product);
                Report.Product = (obj[0].Product).ToString();
                Report.Compare = compare;
                Report.FromDate = fromdate;
                Report.ToDate = todate;
                List<SimpleReportViewModel> Data = new List<SimpleReportViewModel>();
                List<SimpleReportViewModel> QuantityList = new List<ViewModel.SimpleReportViewModel>();

                foreach (var item in Chartdata)
                {
                    SimpleReportViewModel Quantity = new SimpleReportViewModel()
                    {
                        DimensionOne = item.ProductVariant,
                        Quantity = item.count
                    };
                    QuantityList.Add(Quantity);
                }
                Report.LstData = QuantityList;
                if (product == null)
                {
                    Report.ChartType = "line";
                    Report.range = "Yearly";
                }
                else
                {
                    Report.Product = product;
                    Report.ChartType = chartType;
                    Report.range = Range;
                }
                lstModel.Add(Report);
            }
            lstModel[0].Commentary = Commentary;
            ViewBag.ProductList = ObjProduct.CategoryByUser(custid);

            if (lstModel.Count() <= 0 && Customer == false)
            {

                ViewBag.product = product;
                ViewBag.ChartType = chartType;
                ViewBag.range = Range;
                ViewBag.Category = Objdal.GetctegotyBYproduct(int.Parse(product));

                NewsDataStore Obj2 = new NewsDataStore();
                DealsDataStore Obj = new DealsDataStore();
                DealsDetailsViewModel d = new DealsDetailsViewModel();
                d.NewsList = Obj2.GetNewsList();
                d.DealList = Obj.GetDealsList();
                return View("Chem-PriceData", d);
            }
            else if (lstModel.Count() <= 0 && Customer == true)
            {
                ViewBag.product = product;
                ViewBag.ChartType = chartType;
                ViewBag.range = Range;
                ViewBag.Category = Objdal.GetctegotyBYproduct(int.Parse(product));

                ViewBag.FromDate = fromdate;
                ViewBag.ToDate = todate;

                return View("Chem-PriceDataUser");

            }
            else if (Customer == true)
            {
                ViewBag.Category = Objdal.GetctegotyBYproduct(int.Parse(product));

                return View("chemicalpricingUser", lstModel);
            }
            else
            {
                ViewBag.Category = Objdal.GetctegotyBYproduct(int.Parse(product));
                NewsDataStore Obj2 = new NewsDataStore();
                DealsDataStore Obj = new DealsDataStore();
                DealsDetailsViewModel d = new DealsDetailsViewModel();
                d.NewsList = Obj2.GetNewsList();
                d.DealList = Obj.GetDealsList();
                lstModel[0].NewsDetailsViewModel = d;
                return View("chemical-pricing", lstModel);
            }


        }
        public ActionResult ChecmPriceDailyAverageChart(string product, string chartType, string Range, string CompareProject, bool Customer, string fromdate = "", string todate = "")
        {

            if (fromdate == "")
            {
                fromdate = (DateTime.Now.Month) + "/01/" + DateTime.Now.Year;

            }
            if (todate == "")
            {
                todate = (DateTime.Now.Month) + "/" + DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month) + "/" + DateTime.Now.Year;

            }
            int custid = 0;

            ChemicalPricing Objdal = new DAL.ChemicalPricing();
            if (product == null && Customer == true)
            {
                ViewBag.product = product;
                ViewBag.ChartType = chartType;
                ViewBag.range = Range;
                ViewBag.ChartType = "line";

                custid = int.Parse(Session["LoginUser"].ToString());

                ViewBag.ProductList = ObjProduct.CategoryByUser(custid);
                ViewBag.Category = Objdal.GetctegotyBYproduct(0);

                ViewBag.FromDate = fromdate;
                ViewBag.ToDate = todate;

                return View("Chem-PriceDataUser");

            }
            if (Customer == true)
            {
                custid = int.Parse(Session["LoginUser"].ToString());

            }
            List<SA_ChemPriceDailyAverage> obj = null;
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
                obj = Objdal.GetDailyAverageWiseProductListwithCompare(values);

            }
            else
                obj = Objdal.GetDailyAverageWiseProductList(product, fromdate, todate);
            List<string> Day = obj.Select(p => p.day).Distinct().ToList();
            List<string> Discription = obj.Select(p => p.Discription).Distinct().ToList();
            string Commentary = "";
            if (product != null)
            {
                int ProductId = int.Parse(product);
                Commentary = ObjCommentary.GetCommentaryList().Where(x => x.Product == ProductId).OrderByDescending(w => w.CreatedTime).FirstOrDefault().Title;
            }
            else
            {
                Commentary = ObjCommentary.GetCommentaryList().OrderByDescending(w => w.CreatedTime).FirstOrDefault().Title;
            }

            var lstModel = new List<StackedViewModel>();

          
            for (int i = 0; i < Day.Count; i++)
            {
               
                List<SA_ChemPriceDailyAverage> Chartdata = obj.Where(Chart => Chart.year == DateTime.Now.Year.ToString() && Chart.day == Day[i]).ToList();
                //sales of product sales by quarter  
                StackedViewModel Report = new StackedViewModel();
                Report.StackedDimensionOne = Day[i];
                Report.Discription = Discription;
                Report.category = Objdal.GetctegotyBYproduct(obj[0].Product);
                Report.Product = (obj[0].Product).ToString();
                Report.Compare = compare;
                Report.FromDate = fromdate;
                Report.ToDate = todate;
                List<SimpleReportViewModel> Data = new List<SimpleReportViewModel>();
                List<SimpleReportViewModel> QuantityList = new List<ViewModel.SimpleReportViewModel>();

                foreach (var item in Chartdata)
                {
                    SimpleReportViewModel Quantity = new SimpleReportViewModel()
                    {
                        DimensionOne = item.ProductVariant,
                        Quantity = item.count
                    };
                    QuantityList.Add(Quantity);
                }
                Report.LstData = QuantityList;
                if (product == null)
                {
                    Report.ChartType = "line";
                    Report.range = "Yearly";
                }
                else
                {
                    Report.Product = product;
                    Report.ChartType = chartType;
                    Report.range = Range;
                }
                lstModel.Add(Report);
            }
            lstModel[0].Commentary = Commentary;
            ViewBag.ProductList = ObjProduct.CategoryByUser(custid);

            if (lstModel.Count() <= 0 && Customer == false)
            {

                ViewBag.product = product;
                ViewBag.ChartType = chartType;
                ViewBag.range = Range;
                ViewBag.Category = Objdal.GetctegotyBYproduct(int.Parse(product));

                NewsDataStore Obj2 = new NewsDataStore();
                DealsDataStore Obj = new DealsDataStore();
                DealsDetailsViewModel d = new DealsDetailsViewModel();
                d.NewsList = Obj2.GetNewsList();
                d.DealList = Obj.GetDealsList();
                return View("Chem-PriceData", d);
            }
            else if (lstModel.Count() <= 0 && Customer == true)
            {
                ViewBag.product = product;
                ViewBag.ChartType = chartType;
                ViewBag.range = Range;
                ViewBag.Category = Objdal.GetctegotyBYproduct(int.Parse(product));

                ViewBag.FromDate = fromdate;
                ViewBag.ToDate = todate;

                return View("Chem-PriceDataUser");

            }
            else if (Customer == true)
            {
                ViewBag.Category = Objdal.GetctegotyBYproduct(int.Parse(product));

                return View("chemicalpricingUser", lstModel);
            }
            else
            {
                ViewBag.Category = Objdal.GetctegotyBYproduct(int.Parse(product));
                NewsDataStore Obj2 = new NewsDataStore();
                DealsDataStore Obj = new DealsDataStore();
                DealsDetailsViewModel d = new DealsDetailsViewModel();
                d.NewsList = Obj2.GetNewsList();
                d.DealList = Obj.GetDealsList();
                lstModel[0].NewsDetailsViewModel = d;
                return View("chemical-pricing", lstModel);
            }


        }
        public ActionResult ChecmPriceWeeklyChart(string product, string chartType, string Range, string CompareProject, bool Customer, string fromdate = "", string todate = "")
        {
            int custid = 0;
            if (fromdate == "")
            {
                fromdate = (DateTime.Now.Month) + "/01/" + DateTime.Now.Year;

            }
            if (todate == "")
            {
                todate = (DateTime.Now.Month) + "/" + DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month) + "/" + DateTime.Now.Year;

            }
            ChemicalPricing Objdal = new DAL.ChemicalPricing();
            if (product == null && Customer == true)
            {
                ViewBag.product = product;
                ViewBag.ChartType = chartType;
                ViewBag.range = Range;
                ViewBag.ChartType = "line";

                custid = int.Parse(Session["LoginUser"].ToString());

                ViewBag.ProductList = ObjProduct.CategoryByUser(custid);
                ViewBag.Category = Objdal.GetctegotyBYproduct(0);

                ViewBag.FromDate = fromdate;
                ViewBag.ToDate = todate;

                return View("Chem-PriceDataUser");

            }
            if (Customer == true)
            {
                custid = int.Parse(Session["LoginUser"].ToString());

            }
            List<SA_ChemPriceWeekly> obj = null;
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
                obj = Objdal.GetWeeklyWiseProductListwithCompare(values);

            }
            else
                obj = Objdal.GetWeeklyWiseProductList(product, fromdate, todate);
            List<string> Day = obj.Select(p => p.Week).Distinct().ToList();
            List<string> Discription = obj.Select(p => p.Discription).Distinct().ToList();
            string Commentary = "";
            if (product != null)
            {
                int ProductId = int.Parse(product);
                Commentary = ObjCommentary.GetCommentaryList().Where(x => x.Product == ProductId).OrderByDescending(w => w.CreatedTime).FirstOrDefault().Title;
            }
            else
            {
                Commentary = ObjCommentary.GetCommentaryList().OrderByDescending(w => w.CreatedTime).FirstOrDefault().Title;
            }

            var lstModel = new List<StackedViewModel>();

          
            for (int i = 0; i < Day.Count; i++)
            {
               
                List<SA_ChemPriceWeekly> Chartdata = obj.Where(Chart => Chart.Week == Day[i]).ToList(); ;
                //obj.Where(Chart => Chart.year == DateTime.Now.Year.ToString() && Chart.day == Day[i]).ToList();
                //sales of product sales by quarter  
                StackedViewModel Report = new StackedViewModel();
                Report.StackedDimensionOne = Day[i];
                Report.Discription = Discription;
                Report.category = Objdal.GetctegotyBYproduct(obj[0].Product);
                Report.Product = (obj[0].Product).ToString();
                Report.Compare = compare;
                Report.FromDate = fromdate;
                Report.ToDate = todate;

                List<SimpleReportViewModel> Data = new List<SimpleReportViewModel>();
                List<SimpleReportViewModel> QuantityList = new List<ViewModel.SimpleReportViewModel>();

                foreach (var item in Chartdata)
                {
                    SimpleReportViewModel Quantity = new SimpleReportViewModel()
                    {
                        DimensionOne = item.ProductVariant,
                        Quantity = item.count
                    };
                    QuantityList.Add(Quantity);
                }
                Report.LstData = QuantityList;
                if (product == null)
                {
                    Report.ChartType = "line";
                    Report.range = "Week";
                }
                else
                {
                    Report.Product = product;
                    Report.ChartType = chartType;
                    Report.range = Range;
                }
                lstModel.Add(Report);
            }
            lstModel[0].Commentary = Commentary;
            ViewBag.ProductList = ObjProduct.CategoryByUser(custid);

            if (lstModel.Count() <= 0 && Customer == false)
            {

                ViewBag.product = product;
                ViewBag.ChartType = chartType;
                ViewBag.range = Range;
                ViewBag.Category = Objdal.GetctegotyBYproduct(int.Parse(product));

                NewsDataStore Obj2 = new NewsDataStore();
                DealsDataStore Obj = new DealsDataStore();
                DealsDetailsViewModel d = new DealsDetailsViewModel();
                d.NewsList = Obj2.GetNewsList();
                d.DealList = Obj.GetDealsList();
                return View("Chem-PriceData", d);
            }
            else if (lstModel.Count() <= 0 && Customer == true)
            {
                ViewBag.product = product;
                ViewBag.ChartType = chartType;
                ViewBag.range = Range;
                ViewBag.Category = Objdal.GetctegotyBYproduct(int.Parse(product));

                ViewBag.FromDate = fromdate;
                ViewBag.ToDate = todate;

                return View("Chem-PriceDataUser");

            }
            else if (Customer == true)
            {
                ViewBag.Category = Objdal.GetctegotyBYproduct(int.Parse(product));

                return View("chemicalpricingUser", lstModel);
            }
            else
            {
                ViewBag.Category = Objdal.GetctegotyBYproduct(int.Parse(product));
                NewsDataStore Obj2 = new NewsDataStore();
                DealsDataStore Obj = new DealsDataStore();
                DealsDetailsViewModel d = new DealsDetailsViewModel();
                d.NewsList = Obj2.GetNewsList();
                d.DealList = Obj.GetDealsList();
                lstModel[0].NewsDetailsViewModel = d;
                return View("chemical-pricing", lstModel);
            }


        }


        [HttpPost]
        public JsonResult GetCommentaries(string ProductId)
        {
            if (!string.IsNullOrEmpty(ProductId))
            {
                int catId = int.Parse(ProductId);
                var Commentaries = ObjCommentary.GetCommentaryList().Where(w => w.Product == catId).Select(w => new SelectListItem { Text = w.Title, Value = w.Description }).ToList();
                return Json(Commentaries);
            }

            else
            {
                var Commentaries = ObjCommentary.GetCommentaryList().Select(w => new SelectListItem { Text = w.Title, Value = w.Description }).ToList();
                return Json(Commentaries);
            }

        }


    }
}