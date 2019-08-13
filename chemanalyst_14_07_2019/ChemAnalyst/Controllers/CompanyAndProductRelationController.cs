using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ChemAnalyst.Models;
using ChemAnalyst.ViewModel;
using System.Data.Entity;

namespace ChemAnalyst.Controllers
{
    public class CompanyAndProductRelationController : Controller
    {
        // GET: CompanyAndProductRelation
        public ActionResult Index()
        {
            ChemAnalystContext _context = new ChemAnalystContext();

            var viewModel = new CompanyProfAndCompanyProductRelationFormViewModel()
            {
                CompanyProf = _context.SA_Company.ToList(),
                CompanyProduct = _context.SA_Product.ToList()
            };

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult SaveCompanyAndProductRelation(CompanyProfAndCompanyProductRelationFormViewModel viewModel)
        {
            //if (!ModelState.IsValid)
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            ChemAnalystContext _context = new ChemAnalystContext();

            foreach (var item in viewModel.CompanyProduct)
            {
                if (item.IsSelected)
                {
                    var checkForSameCompany = _context.CompanyAndProductRelations.Where(w => w.SA_CompanyId == viewModel.CompanyProfId && w.SA_ProductId == item.id).FirstOrDefault();
                    if (checkForSameCompany != null)
                    {
                        TempData["Message"] = "This compnay already exist with same product.";
                    }
                    else
                    {
                        CompanyAndProductRelation companyAndProductRelation = new CompanyAndProductRelation();
                        companyAndProductRelation.SA_CompanyId = viewModel.CompanyProfId;
                        companyAndProductRelation.SA_ProductId = item.id;
                        _context.CompanyAndProductRelations.Add(companyAndProductRelation);
                    }
                }
            }
            _context.SaveChanges();
            //TEMP REDIRECT.
            return RedirectToAction("AllComAndProductRelationRecords");
        }

        // GET: CompanyAndProductRelation/AllComAndProductRelationRecords
        public ActionResult AllComAndProductRelationRecords()
        {
            ChemAnalystContext _context = new ChemAnalystContext();

            var companyAndProductRelations = _context
                .CompanyAndProductRelations
                .Include(d => d.SA_Company)
                .Include(d => d.SA_Product)
                .OrderByDescending(d => d.Id);
            return View(companyAndProductRelations);
        }


        //GET: CompanyAndProductRelation/Delete
        public ActionResult Delete(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            ChemAnalystContext _context = new ChemAnalystContext();
            var companyProductInDb = _context.CompanyAndProductRelations.Include(d => d.SA_Company).Include(d => d.SA_Product).SingleOrDefault(d => d.Id == id);
            if (companyProductInDb == null)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            return View(companyProductInDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ConfirmDelete(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            ChemAnalystContext _context = new ChemAnalystContext();
            var companyProductInDb = _context.CompanyAndProductRelations.SingleOrDefault(d => d.Id == id);

            if (companyProductInDb == null)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            _context.CompanyAndProductRelations.Remove(companyProductInDb);
            _context.SaveChanges();
            return RedirectToAction("AllComAndProductRelationRecords");
        }
    }
}