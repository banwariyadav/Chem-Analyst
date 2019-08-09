using ChemAnalyst.DAL;
using ChemAnalyst.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChemAnalyst.Controllers
{
    public class ProductAndCategoryController : Controller
    {
        // GET: ProductAndCategory
        /// <summary>
        /// Get Category data
        /// </summary>
        /// <returns></returns>
        /// 
        public ActionResult Category()
        {
            CategoryDataStore Obj = new CategoryDataStore();
            //List<SA_Category> CategoryList = Obj.GetCategoryList();
            return View("Category");
        }
        public ActionResult GetCategoryList()
        {
            return View("Category");
        }
        public JsonResult CategoryList()
        {
            CategoryDataStore Obj = new CategoryDataStore();
            List<SA_Category> CategoryList = Obj.GetCategoryList();

            return Json(new { data = CategoryList }, JsonRequestBehavior.AllowGet);

        }
        public ActionResult AddCategory()
        {
            CategoryDataStore ObjDal = new CategoryDataStore();
            SA_Category objCatViewModel = new SA_Category();
           // objCatViewModel.ProductList = ObjDal.GetProductList();
           
            return View("add-category", objCatViewModel);

        }
        public ActionResult SaveCategory(SA_Category UserCategory)
        {
            for (int i = 0; i < Request.Files.Count; i++)
            {
                var file = Request.Files[i];

                if (file != null && file.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(file.FileName);

                    var path = Path.Combine(Server.MapPath("~/ProductImages"), fileName);
                    file.SaveAs(path);
                    UserCategory.CategoryImg = fileName;



                }
            }
            UserCategory.CreatedTime = DateTime.Now;
            CategoryDataStore Obj = new CategoryDataStore();
            if (UserCategory.id == 0)
            {
                Obj.AddCategory(UserCategory);
            }
            else
            {
                Obj.EditCategory(UserCategory);
            }
            return RedirectToAction("Category");
        }

      
        public ActionResult EditCategory(int id)
        {

            CategoryDataStore Obj = new CategoryDataStore();
            SA_Category obj = Obj.GetCategoryByid(id);
           // List<SelectListItem> productList = Obj.GetProductList();
             SA_Category objSaCatV = new SA_Category();
            objSaCatV.id = obj.id;
            objSaCatV.CategoryName = obj.CategoryName;
            objSaCatV.CategoryDiscription = obj.CategoryDiscription;
            objSaCatV.Meta = obj.Meta;
            objSaCatV.MetaDiscription = obj.MetaDiscription;
            objSaCatV.CategoryImg = obj.CategoryImg;
            //   objSaCatV.ProductList = productList;



            return View("add-Category", objSaCatV);
        }
        public ActionResult DeleteCategory(int id)
        {

            CategoryDataStore Obj = new CategoryDataStore();
            // check if this category is in product
            ProductDataStore ObjProd = new ProductDataStore();
            if (ObjProd.CheckCategory(id))
            {
                TempData["ErrorMessage"] = "You can not delete this category, please delete related product first.";
                return RedirectToAction("Category");
            }
            else
            {
                if (Obj.DeleteCategory(id) == true)
                {
                    //return View("Category");
                    return RedirectToAction("Category");
                }
                else
                {
                    return View("ErrorEventArgs");
                }
            }
        }
        public ActionResult Product()
        {
            ProductDataStore Obj = new ProductDataStore();
            //List<SA_Product> ProductList = Obj.GetProductList();
            return View("Product");
        }
        public ActionResult GetProductList()
        {
            return View("Product");
        }
        public JsonResult ProductList()
        {
            ProductDataStore Obj = new ProductDataStore();
            ChemAnalystContext _context = new ChemAnalystContext();
            var list=(from product in _context.SA_Product
             join category in _context.SA_Category on product.Category equals category.id
             select new
             {
                 ProductDiscription = category.CategoryName,
                 ProductName = product.ProductName,
                 CreatedTime = product.CreatedTime,
                 id = product.id,
                 status=product.status,

             }).ToList();
         
            return Json(new { data = list }, JsonRequestBehavior.AllowGet);

        }
        public ActionResult AddProduct()
        {
            CategoryDataStore ObjDal = new CategoryDataStore();
            SA_ProductViewModel obj = new SA_ProductViewModel();
            List<SelectListItem> CategoryList = ObjDal.CategoryList();
            obj.CategoryList = CategoryList;
            return View("add-Product", obj);

        }
        public ActionResult SaveProduct(SA_Product UserProduct)
        {
            for (int i = 0; i < Request.Files.Count; i++)
            {
                var file = Request.Files[i];

                if (file != null && file.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(file.FileName);

                    var path = Path.Combine(Server.MapPath("~/ProductImages"), fileName);
                    file.SaveAs(path);
                    UserProduct.ProductImg = fileName;



                }
            }
            UserProduct.CreatedTime = DateTime.Now;
            ProductDataStore Obj = new ProductDataStore();
            if (UserProduct.id == 0)
            {
                Obj.AddProduct(UserProduct);
            }
            else
            {
                Obj.EditProduct(UserProduct);
            }
            return RedirectToAction("Product");
        }


        public ActionResult EditProduct(int id)
        {

            ProductDataStore Obj = new ProductDataStore();
            SA_Product obj = Obj.GetProductByid(id);
          
            CategoryDataStore Objcat = new CategoryDataStore();
            List<SelectListItem> CategoryList = Objcat.CategoryList();
            SA_ProductViewModel objSaCatV = new SA_ProductViewModel();
            objSaCatV.id = obj.id;
            objSaCatV.ProductName = obj.ProductName;
            objSaCatV.ProductDiscription = obj.ProductDiscription;
            objSaCatV.Meta = obj.Meta;
            objSaCatV.MetaDiscription = obj.MetaDiscription;
             objSaCatV.CategoryList= CategoryList;
            objSaCatV.Category = obj.Category.ToString();

            return View("add-Product", objSaCatV);
        }
        public ActionResult DeleteProduct(int id)
        {

            ProductDataStore Obj = new ProductDataStore();
            if (Obj.DeleteProduct(id) == true)
            {
                //return View("Product");
                return RedirectToAction("Product");
            }
            else
            {
                return View("ErrorEventArgs");
            }
        }

        [HttpPost]
        public ActionResult UpdateStatus(int productId)
        {
            ProductDataStore Obj = new ProductDataStore();
            Obj.UpdateStatus(productId);
            return RedirectToAction("GetProductList");
        }

    }
}