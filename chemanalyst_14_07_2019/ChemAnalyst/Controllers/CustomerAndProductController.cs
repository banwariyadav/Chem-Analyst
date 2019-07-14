using ChemAnalyst.Models;
using ChemAnalyst.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace ChemAnalyst.Controllers
{
    public class CustomerAndProductController : Controller
    {
        // GET: CustomerAndProduct
        public ActionResult Index()
        {
            ChemAnalystContext _context = new ChemAnalystContext();

            var customers = _context.Lead_Master;
            return View(customers);
        }

        // GET: Customer/AddCustomerAndProduct/5
        public ActionResult AddCustomerAndProduct(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            ChemAnalystContext _context = new ChemAnalystContext();
            var customer = _context.Lead_Master.SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            var viewModel = new CustomerProductFormViewModel()
            {
                Lead_Master = customer,
                SA_Product = _context.SA_Product.ToList()
            };
            return View(viewModel);
        }

        [HttpPost]
        // POST: Customer/SaveCustomerAndProductRelation
        public ActionResult SaveCustomerAndProductRelation(CustomerProductFormViewModel viewModel)
        {
            ChemAnalystContext _context = new ChemAnalystContext();

            foreach (var item in viewModel.SA_Product)
            {
                if (item.IsSelected)
                {
                    CustomerAndProducRelation customerAndProducRelation = new CustomerAndProducRelation();
                    customerAndProducRelation.Lead_MasterId = viewModel.Lead_Master.Id;
                    customerAndProducRelation.SA_ProductId = item.id;
                    _context.CustomerAndProducRelation.Add(customerAndProducRelation);
                }
            }
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Customer/ManageCustomerAndProduct/5
        public ActionResult ManageCustomerAndProduct(int? id)
        {
            ChemAnalystContext _context = new ChemAnalystContext();

            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var customerAndProducRelation = _context.CustomerAndProducRelation.Where(c => c.Lead_MasterId == id);
            List<int> i = new List<int>();
            foreach (var item in customerAndProducRelation)
            {
                i.Add(item.SA_ProductId);
            }

            List<SA_Product> cp = new List<SA_Product>();
            foreach (var item in i)
            {
                var cpdb = _context.SA_Product.SingleOrDefault(c => c.id == item);
                cp.Add(cpdb);
            }

            return View(cp);
        }

        // GET: Customer/ManageCustomerAndProduct/5
        public ActionResult CustomerAndProduct(int? id)
        {
            ChemAnalystContext _context = new ChemAnalystContext();

            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var customerAndProducRelation = _context.CustomerAndProducRelation.Where(c => c.Lead_MasterId == id);
            List<int> i = new List<int>();
            foreach (var item in customerAndProducRelation)
            {
                i.Add(item.SA_ProductId);
            }

            List<SA_Product> cp = new List<SA_Product>();
            foreach (var item in i)
            {
                var cpdb = _context.SA_Product.SingleOrDefault(c => c.id == item);
                cp.Add(cpdb);
            }

            return View(cp);
        }

        // GET: Customer/CompanyAndProductRelation/5
        //SEND SA_Product Id AS PARAMETER
        public ActionResult CompanyAndProductRelation(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            ChemAnalystContext _context = new ChemAnalystContext();

            var companyProf = _context.CompanyAndProductRelations.Include(c => c.SA_Company).Where(c => c.SA_ProductId == id).OrderBy(c => c.SA_CompanyId);

            return View(companyProf);
        }


    }
}