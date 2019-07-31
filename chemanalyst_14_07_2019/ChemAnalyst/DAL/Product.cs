using ChemAnalyst.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ChemAnalyst.DAL
{

    public class ProductDataStore
    {
        private ChemAnalystContext _context = new ChemAnalystContext();

        public List<SA_Product> GetProductListAdmin()
        {
            return _context.SA_Product.ToList();

        }
        public List<SA_Product> GetProductList()
        {
            return _context.SA_Product.Where(x => x.status == 1).ToList();

        }
        public IQueryable<SA_Product> GetProductListBySearch(string id, string search)
        {
            IQueryable<SA_Product> lst;
            if (id != "" && search != "")
            {
                var ids = Convert.ToInt32(id);
                lst = from r in _context.SA_Product
                      join p in _context.SA_Category on r.Category equals ids
                      where p.status == 1 && r.ProductName.Contains(search) || search == null || search == ""
                      select r;
            }
            else if (id == "" && search != "")
            {

                lst = from r in _context.SA_Product
                      where r.status == 1 && r.ProductName.Contains(search) || search == null || search == ""
                      select r;
            }
            else if (id != "" && search == "")
            {
                var ids = Convert.ToInt32(id);
                lst = from r in _context.SA_Product
                      join p in _context.SA_Category on r.Category equals ids
                      where p.status == 1
                      select r;

            }
            else
            {
                lst = from r in _context.SA_Product
                      where r.status == 1
                      select r;
            }
            return lst.Distinct();

        }

        public bool EditProduct(SA_Product Product)
        {
            //  Product.CreatedDate = DateTime.Now;
            SA_Product EditProduct = _context.SA_Product.Where(Cat => Cat.id == Product.id).FirstOrDefault();
            EditProduct.ProductName = Product.ProductName;
            EditProduct.ProductDiscription = Product.ProductDiscription;
            EditProduct.Meta = Product.Meta;
            EditProduct.MetaDiscription = Product.MetaDiscription;
            EditProduct.Category = Product.Category;
            if (Product.ProductImg != null)
                EditProduct.ProductImg = Product.ProductName;
            _context.Entry(EditProduct).State = EntityState.Modified;
            int x = _context.SaveChanges();
            return x == 0 ? false : true;
        }

        public bool UpdateStatus(int productId)
        {
            //  Product.CreatedDate = DateTime.Now;
            SA_Product EditProduct = _context.SA_Product.Where(Cat => Cat.id == productId).FirstOrDefault();
            if (EditProduct.status.HasValue)
            {
                if (EditProduct.status.Value == 1)
                {
                    EditProduct.status = 2;
                }
                else
                {
                    EditProduct.status = 1;
                }
            }
            else
            {
                EditProduct.status = 1;
            }
            _context.Entry(EditProduct).State = EntityState.Modified;
            int x = _context.SaveChanges();
            return x == 0 ? false : true;
        }


        public bool DeleteProduct(int ProductId)
        {
            //  Product.CreatedDate = DateTime.Now;
            SA_Product EditProduct = _context.SA_Product.Where(Product => Product.id == ProductId).FirstOrDefault();
            _context.Entry(EditProduct).State = EntityState.Deleted;
            int x = _context.SaveChanges();
            return x == 0 ? false : true;
        }
        public async Task<bool> AddProduct(SA_Product Product)
        {
            //  Product.CreatedDate = DateTime.Now;
            _context.SA_Product.Add(Product);
            int x = await _context.SaveChangesAsync();
            return x == 0 ? false : true;
        }

        public async Task<bool> UpdateProduct(SA_Product Product)
        {
            _context.Entry(Product).State = EntityState.Modified;
            //  Product.ModeifiedDate = DateTime.Now;
            int x = await _context.SaveChangesAsync();
            return x == 0 ? false : true;
        }

        internal SA_Product GetProductByid(int id)
        {
            return _context.SA_Product.Where(x => x.id == id && x.status == 1).SingleOrDefault();
        }

        internal bool CheckCategory(int id)
        {
            var data = _context.SA_Product.Where(x => x.id == id && x.status == 1).SingleOrDefault();
            if (data != null)
                return true;
            else
                return false;
        }

        internal List<SelectListItem> ProductList()
        {
            return (from product in _context.SA_Product
                    where product.status == 1
                    //  select  { Fname = User.Fname+" "+User.Lname , Phone = User.Phone, Role=User.Role,Email=User.Email,UserPassword=User.Password});
                    select new SelectListItem { Text = product.ProductName, Value = product.id.ToString() }).ToList();
        }
        internal List<SelectListItem> ProductListByCategory(int id)
        {
            return (from product in _context.SA_Product

                    where product.Category == id && product.status == 1
                    orderby product.ProductName  //  select  { Fname = User.Fname+" "+User.Lname , Phone = User.Phone, Role=User.Role,Email=User.Email,UserPassword=User.Password});
                    select new SelectListItem { Text = product.ProductName, Value = product.id.ToString() }).ToList();
        }
        internal List<SelectListItem> ProductListByCategoryUser(int id, int CustId)
        {
            return (from product in _context.SA_Product
                    join cust in _context.CustProduct on product.id equals cust.ProdId
                    where product.Category == id && cust.CustId == CustId && product.status == 1
                    orderby product.ProductName
                    select new SelectListItem { Text = product.ProductName, Value = product.id.ToString() }).ToList();
            //  select  { Fname = User.Fname+" "+User.Lname , Phone = User.Phone, Role=User.Role,Email=User.Email,UserPassword=User.Password});
        }
        internal List<SelectListItem> CategoryByUser(int id)
        {
            if (id == 0)
                return (from product in _context.SA_Product
                        join category in _context.SA_Category on product.Category equals category.id
                        where product.status == 1
                        orderby category.CategoryName
                        //  select  { Fname = User.Fname+" "+User.Lname , Phone = User.Phone, Role=User.Role,Email=User.Email,UserPassword=User.Password});
                        select new SelectListItem { Text = category.CategoryName, Value = category.id.ToString() }).Distinct().ToList();
            else
                return (from product in _context.SA_Product
                        join category in _context.SA_Category on product.Category equals category.id
                        join cust in _context.CustProduct on product.id equals cust.ProdId
                        where cust.CustId == id && product.status == 1
                        orderby category.CategoryName
                        //  select  { Fname = User.Fname+" "+User.Lname , Phone = User.Phone, Role=User.Role,Email=User.Email,UserPassword=User.Password});
                        select new SelectListItem { Text = category.CategoryName, Value = category.id.ToString() }).Distinct().ToList();

        }

        public static IEnumerable<SelectListItem> GetProduct()
        {
            ChemAnalystContext _context1 = new ChemAnalystContext();
            var cat = (from coun in _context1.SA_Product where coun.status == 1 select new SelectListItem { Text = coun.ProductName, Value = coun.id.ToString() }).AsEnumerable();
            return cat;
        }

        public static IEnumerable<SelectListItem> GetCountry()
        {
            ChemAnalystContext _context1 = new ChemAnalystContext();
            var cat = (from coun in _context1.SA_Country select new SelectListItem { Text = coun.CountryName, Value = coun.id.ToString() }).AsEnumerable();
            return cat;
        }

        public static bool GetProductNewReletion(int newid, int product)
        {
            ChemAnalystContext _context1 = new ChemAnalystContext();
             return _context1.SA_NewsAndProductRelation.Where(x=>x.SA_NewsId== newid  && x.SA_ProductId == product).Count()==0?false:true ;
            
        }

          public static bool GetProductDealReletion(int newid, int product)
        {
            ChemAnalystContext _context1 = new ChemAnalystContext();
            return _context1.SA_DealsAndProductRelation.Where(x => x.SA_DealID == newid && x.SA_ProductId == product).Count() == 0 ? false : true;

        }
        public static string GetProductName( int ProductId)
        {
            ChemAnalystContext _context1 = new ChemAnalystContext();
            var cat = (from coun in _context1.SA_Product where coun.id==ProductId select new { Text = coun.ProductName}).FirstOrDefault().Text;
            return cat;
        }

        public List<string> GetCustProductList(int custId)
        {
            ChemAnalystContext _context = new ChemAnalystContext();
            List<CustProduct> product = new List<CustProduct>();
            product = _context.CustProduct.Where(x => x.CustId == custId).ToList();
            List<string> lst = product.Select(e => e.ProdId.ToString()).ToList();
            return lst;

        }

        public static string GetCategory(int cat)
        {
            ChemAnalystContext _context = new ChemAnalystContext();
            var category = _context.SA_Category.Where(w => w.id == cat).FirstOrDefault().CategoryName;
            return category;

        }

        public static IEnumerable<SelectListItem> GetCompany()
        {
            ChemAnalystContext _context1 = new ChemAnalystContext();
            var cat = (from coun in _context1.SA_Company select new SelectListItem { Text = coun.Name, Value = coun.id.ToString() }).AsEnumerable();
            return cat;
        }

        //internal List<SelectListItem> CategoryByCustomer(int id)
        //{
        //    return (from product in _context.SA_Product
        //            join cust in _context.CustProduct on product.id equals cust.ProdId
        //            where cust.CustId == id
        //            //  select  { Fname = User.Fname+" "+User.Lname , Phone = User.Phone, Role=User.Role,Email=User.Email,UserPassword=User.Password});
        //            select new SelectListItem { Text = product.ProductName, Value = category.id.ToString() }).Distinct().ToList();
        //}
        //public  GetProductByList()
        //{
        //    return (from product in _context.SA_Product
        //            join category in _context.SA_Category on product.Category equals category.id
        //            select new 
        //            {
        //                ProductDiscription = category.CategoryName,
        //                ProductName = product.ProductName,
        //                CreatedTime = product.CreatedTime,
        //                id = product.id

        //            }).ToList();
        //}
    }
}