using ChemAnalyst.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ChemAnalyst.Models;
using System.IO;
using System.Data.OleDb;
using System.Data;
using System.Net;

namespace ChemAnalyst.Controllers
{
    public class CompanyProductController : Controller
    {
        // GET: CompanyProduct
        public ActionResult Index()
        {
            return View();
        }

        //POST: CompanyProf/Import
        [HttpPost]
        public ActionResult Import(CompanyProductFormViewModel viewModel)
        {
            if (viewModel.excelFile == null || viewModel.excelFile.ContentLength == 0)
            {
                //handel error
                ViewBag.ErrorMessage = "This field is required";
                return View("Index");
            }
            else
            {
                ChemAnalystContext _context = new ChemAnalystContext();

                string FileExtension = Path.GetExtension(viewModel.excelFile.FileName);
                string FileName = Path.GetFileName(viewModel.excelFile.FileName);
                if (FileExtension.ToLower() == ".xls")
                {
                    viewModel.excelFile.SaveAs(Server.MapPath("~/ExcelFiles/") + FileName);
                    string FilePath = Server.MapPath("~/ExcelFiles/" + FileName);

                    OleDbConnection OleConn = null;
                    OleConn = new OleDbConnection(@"provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + FilePath + ";Extended Properties=Excel 8.0;");
                    OleConn.Open();
                    DataTable DT = OleConn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                    string GetExcelSheetName = DT.Rows[0]["Table_Name"].ToString();
                    OleDbDataAdapter DA = new OleDbDataAdapter("SELECT * FROM [" + GetExcelSheetName + "]", OleConn);
                    DataSet DS = new DataSet();
                    DA.Fill(DS);

                    //foreach (DataRow DR in DS.Tables[0].Rows)
                    //{
                    //    CompanyProduct companyProduct = new CompanyProduct();
                    //    companyProduct.ProductName = DR[0].ToString();
                    //    companyProduct.Segment = DR[1].ToString();
                    //    companyProduct.IsSelected = false;
                    //    _context.CompanyProducts.Add(companyProduct);
                    //}
                    //_context.SaveChanges();

                    foreach (DataRow DR in DS.Tables[0].Rows)
                    {
                        SA_Product companyProduct = new SA_Product();

                        companyProduct.ProductName = DR[0].ToString();
                        companyProduct.ProductDiscription = DR[1].ToString();
                        companyProduct.Meta = DR[2].ToString();
                        companyProduct.MetaDiscription = DR[3].ToString();
                        companyProduct.status = Convert.ToInt32(DR[4].ToString());
                        companyProduct.CreatedTime = Convert.ToDateTime(DR[5]);
                        companyProduct.ProductImg = DR[6].ToString();
                        companyProduct.Category = Convert.ToInt32(DR[7].ToString());
                        companyProduct.IsSelected = false;
                        _context.SA_Product.Add(companyProduct);
                    }
                    _context.SaveChanges();



                }
                else
                {
                    ViewBag.ErrorMessage = "Only .xls file allowed";
                    return View("Index");
                }
            }
            return RedirectToAction("AllCompanyProducts");
        }

        // GET: CompanyProduct/AllCompanyProducts
        public ActionResult AllCompanyProducts()
        {
            ChemAnalystContext _context = new ChemAnalystContext();
            var companyProduct = _context.SA_Product;
            return View(companyProduct);
        }

        // GET: CompanyProduct/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            ChemAnalystContext _context = new ChemAnalystContext();
            var companyProduct = _context.SA_Product.SingleOrDefault(p => p.id == id);
            if (companyProduct == null)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            return View(companyProduct);
        }

        //POST: CompanyProduct/SaveCompanyProduct
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveCompanyProduct(SA_Product model)
        {
            if (!ModelState.IsValid)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            ChemAnalystContext _context = new ChemAnalystContext();
            var companyProductInDb = _context.SA_Product.SingleOrDefault(p => p.id == model.id);
            if(companyProductInDb == null)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            companyProductInDb.ProductName = model.ProductName;
            companyProductInDb.ProductDiscription = model.ProductDiscription;
            companyProductInDb.Meta = model.Meta;
            companyProductInDb.MetaDiscription = model.MetaDiscription;
            companyProductInDb.status = model.status;
            companyProductInDb.CreatedTime = model.CreatedTime;
            companyProductInDb.ProductImg = model.ProductImg;
            companyProductInDb.Category = model.Category;

            _context.SaveChanges();

            return RedirectToAction("AllCompanyProducts");
        }


    }
}