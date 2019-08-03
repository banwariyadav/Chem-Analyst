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

namespace ChemAnalyst.Controllers
{
    public class CompanyProfController : Controller
    {
        // GET: CompanyProf
        public ActionResult Index()
        {
            return View();
        }

        //POST: CompanyProf/Import
        [HttpPost]
        public ActionResult Import(CompanyProfFormViewModel viewModel)
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
                    //    CompanyProf companyProf = new CompanyProf();
                    //    companyProf.CompanyName = DR[0].ToString();
                    //    companyProf.RegistrationDate = Convert.ToDateTime(DR[1]);
                    //    companyProf.Cin = DR[2].ToString();
                    //    companyProf.Category = DR[3].ToString();
                    //    companyProf.Address = DR[4].ToString();
                    //    companyProf.Contact = DR[5].ToString();
                    //    companyProf.NumberOfEmployee = Convert.ToInt32(DR[6]);
                    //    companyProf.ManagingDirector = DR[7].ToString();
                    //    companyProf.Strength = DR[8].ToString();
                    //    companyProf.Weakness = DR[9].ToString();
                    //    companyProf.Oppertunity = DR[10].ToString();
                    //    companyProf.Threat = DR[11].ToString();
                    //    companyProf.ExpansionPlans = DR[12].ToString();

                    //    _context.CompanyProfs.Add(companyProf);
                    //}
                    //_context.SaveChanges();

                    foreach (DataRow DR in DS.Tables[0].Rows)
                    {
                        SA_Company company = new SA_Company();

                        company.Name = DR[0].ToString();
                        company.Description = DR[1].ToString();
                        company.Logo = DR[2].ToString();
                        company.RegDate = Convert.ToDateTime(DR[3]);
                        company.CIN = DR[4].ToString();
                        company.Category = DR[5].ToString();
                        company.Address = DR[6].ToString();
                        company.NOE = DR[7].ToString();
                        company.CEO = DR[8].ToString();
                        company.Meta = DR[9].ToString();
                        company.MetaDescription = DR[10].ToString();
                        company.website = DR[11].ToString();
                        company.phoneNo = DR[12].ToString();
                        company.fax = DR[13].ToString();
                        company.EmailId = DR[14].ToString();
                        company.CreatedTime = DateTime.Now;

                        _context.SA_Company.Add(company);
                    }
                    _context.SaveChanges();
                }
                else
                {
                    ViewBag.ErrorMessage = "Only .xls file allowed";
                    return View("Index");
                }
            }
            
            return RedirectToAction("AllCompanyProf");
        }

        //GET: CompanyProf/AllCompanyProf
        public ActionResult AllCompanyProf()
        {
            //which layout ?
            ChemAnalystContext _context = new ChemAnalystContext();
            var companyProf = _context.SA_Company.OrderByDescending(c => c.id);
            return View(companyProf);
        }

        //GET: CompanyProf/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            ChemAnalystContext _context = new ChemAnalystContext();
            var companyProf = _context.SA_Company.SingleOrDefault(c => c.id == id);
            if (companyProf == null)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);


            return View(companyProf);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveCompanyProf(SA_Company model)
        {
            if (!ModelState.IsValid)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            ChemAnalystContext _context = new ChemAnalystContext();

            var companyProfInDb = _context.SA_Company.SingleOrDefault(c => c.id == model.id);

            if (companyProfInDb == null)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            for (int i = 0; i < Request.Files.Count; i++)
            {
                var file = Request.Files[i];

                if (file != null && file.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(file.FileName);
                    var path = Path.Combine(Server.MapPath("~/images"), fileName);
                    file.SaveAs(path);
                    companyProfInDb.Logo = fileName;
                }
            }

            companyProfInDb.Name = model.Name;
            companyProfInDb.Description = model.Description;
            //companyProfInDb.Logo = model.Logo;
            companyProfInDb.RegDate = Convert.ToDateTime(model.RegDate);
            companyProfInDb.CIN = model.CIN;
            companyProfInDb.Category = model.Category;
            companyProfInDb.Address = model.Address;
            companyProfInDb.NOE = model.NOE;
            companyProfInDb.CEO = model.CEO;
            companyProfInDb.Meta = model.Meta;
            companyProfInDb.MetaDescription = model.MetaDescription;
            companyProfInDb.website = model.website;
            companyProfInDb.phoneNo = model.phoneNo;
            companyProfInDb.fax = model.fax;
            companyProfInDb.EmailId = model.EmailId;
            //companyProfInDb.CreatedTime = model.CreatedTime;

            _context.SaveChanges();

            return RedirectToAction("AllCompanyProf");
        }
    }
}