using ChemAnalyst.Models;
using ChemAnalyst.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace ChemAnalyst.Controllers
{
    public class CompanyProfRecordController : Controller
    {
        // GET: CompanyProfRecord
        public ActionResult Index()
        {
            ChemAnalystContext _context = new ChemAnalystContext();

            var viewModel = new CompanyProfRecordViewModel()
            {
                FinancialYear = _context.FinancialYears.ToList(),
                SA_Company = _context.SA_Company.ToList()
            };

            return View(viewModel);
        }

        //POST: CompanyProfRecord/Import
        [HttpPost]
        public ActionResult Import(CompanyProfRecordViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            if (viewModel.excelFile == null || viewModel.excelFile.ContentLength == 0)
            {
                //handel error
                ViewBag.ErrorMessage = "This field is required";
                ChemAnalystContext _context = new ChemAnalystContext();
                var viewModelIndex = new CompanyProfRecordViewModel()
                {
                    FinancialYear = _context.FinancialYears.ToList(),
                    SA_Company = _context.SA_Company.ToList()
                };
                return View("Index", viewModelIndex);
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
                    OleConn.Close();
                    foreach (DataRow DR in DS.Tables[0].Rows)
                    {
                        if (_context.CompanyProfRecordNew.FirstOrDefault(x => x.SA_CompanyId == viewModel.SA_CompanyId && x.FinancialYearId == viewModel.FinancialYearId) == null)
                        {
                            try { 
                            CompanyProfRecordNew cpr = new CompanyProfRecordNew();
                            cpr.Revenue = Convert.ToDecimal(DR[0]);
                            cpr.Growth = Convert.ToInt16(DR[1]);
                            cpr.PBT = Convert.ToInt16(DR[2]);
                            cpr.Margin = Convert.ToDecimal(DR[3]);
                            cpr.PBT = Convert.ToInt16(DR[4]);
                            cpr.Pat = Convert.ToDecimal(DR[5]);
                            cpr.Liablities = viewModel.FinancialYearId;
                            cpr.SA_CompanyId = viewModel.SA_CompanyId;
                                cpr.FinancialYearId = viewModel.FinancialYearId;
                                cpr.CreateDate = DateTime.Now;
                            _context.CompanyProfRecordNew.Add(cpr);
                                _context.SaveChanges();
                            }
                            catch (Exception ex ) {
                                ViewBag.ErrorMessage = "Import operation failed. Please upload a valid formate for import.";

                                var viewModelIndex = new CompanyProfRecordViewModel()
                                {
                                    FinancialYear = _context.FinancialYears.ToList(),
                                    SA_Company = _context.SA_Company.ToList()
                                };
                                return View("Index", viewModelIndex);
                            }
                        }
                        else {
                            ViewBag.ErrorMessage = "Financial data already exists with same company for same financial year";
                            
                            var viewModelIndex = new CompanyProfRecordViewModel()
                            {
                                FinancialYear = _context.FinancialYears.ToList(),
                                SA_Company = _context.SA_Company.ToList()
                            };
                            return View("Index", viewModelIndex);
                        }
                    }
                   
                }
                else
                {
                    ViewBag.ErrorMessage = "Only .xls file allowed";
                    var viewModelIndex = new CompanyProfRecordViewModel()
                    {
                        FinancialYear = _context.FinancialYears.ToList(),
                        SA_Company = _context.SA_Company.ToList()
                    };
                    return View("Index", viewModelIndex);
                }
                return RedirectToAction("AllCompanyProfileRecords");
            }
        }

        // GET: CompanyProfRecord/AllCompanyProfileRecords
        public ActionResult AllCompanyProfileRecords()
        {
            ChemAnalystContext _context = new ChemAnalystContext();
            var companyProfilerRcord = _context.CompanyProfRecordNew.Include(p => p.FinancialYear).Include(p => p.SA_Company);
            return View(companyProfilerRcord);
        }

        // GET: CompanyProfRecord/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            ChemAnalystContext _context = new ChemAnalystContext();
            var companyProfileRecord = _context.CompanyProfRecords.SingleOrDefault(c => c.Id == id);

            if (companyProfileRecord == null)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            var viewModel = new CompanyProfRecordViewModel()
            {
                FinancialYearId = companyProfileRecord.FinancialYearId,
                SA_CompanyId = companyProfileRecord.SA_CompanyId,
                Revenues = companyProfileRecord.Revenues,
                Growth = companyProfileRecord.Growth,
                FinancialYear = _context.FinancialYears.ToList(),
                SA_Company = _context.SA_Company.ToList()
            };
            return View(viewModel);
        }

        //POST: CompanyProfRecord/SaveCompanyProfile
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveCompanyProfile(CompanyProfRecordViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            ChemAnalystContext _context = new ChemAnalystContext();
            var companyProfileInDb = _context.CompanyProfRecords.SingleOrDefault(c => c.Id == viewModel.Id);
            if (companyProfileInDb == null)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            companyProfileInDb.FinancialYearId = viewModel.FinancialYearId;
            companyProfileInDb.SA_CompanyId = viewModel.SA_CompanyId;
            companyProfileInDb.Revenues = viewModel.Revenues;
            companyProfileInDb.Growth = viewModel.Growth;

            _context.SaveChanges();

            return RedirectToAction("AllCompanyProfileRecords");
        }

        // GET: CompanyProfRecord/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            ChemAnalystContext _context = new ChemAnalystContext();
            var companyProfileRecord = _context.CompanyProfRecords.Include(c => c.FinancialYear).Include(c => c.SA_Company).SingleOrDefault(c => c.Id == id);

            if (companyProfileRecord == null)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            return View(companyProfileRecord);
        }

        //POST: CompanyProfRecord/DeleteConfirm/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirm(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            ChemAnalystContext _context = new ChemAnalystContext();
            var companyProfileRecord = _context.CompanyProfRecords.SingleOrDefault(c => c.Id == id);

            if (companyProfileRecord == null)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            _context.CompanyProfRecords.Remove(companyProfileRecord);
            _context.SaveChanges();

            return RedirectToAction("AllCompanyProfileRecords");
        }

    }
}