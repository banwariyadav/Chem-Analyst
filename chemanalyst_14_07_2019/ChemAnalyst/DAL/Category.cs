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
   
        public class CategoryDataStore
        {
            private ChemAnalystContext _context = new ChemAnalystContext();

            public List<SA_Category> GetCategoryList()
            {
                return  _context.SA_Category.ToList();

            }
        
        public bool EditCategory(SA_Category Category)
        {
            //  Category.CreatedDate = DateTime.Now;
            SA_Category EditCategory= _context.SA_Category.Where(Cat=> Cat.id==Category.id).FirstOrDefault();
                        EditCategory.CategoryName = Category.CategoryName;
            EditCategory.CategoryDiscription = Category.CategoryDiscription;
            EditCategory.Meta = Category.Meta;
            EditCategory.MetaDiscription = Category.MetaDiscription;
            //EditCategory.Product = Category.Product;
            if(Category.CategoryImg!=null)
            {
                EditCategory.CategoryImg = Category.CategoryImg;
            }
            _context.Entry(EditCategory).State= EntityState.Modified;
            int x =  _context.SaveChanges();
            return x == 0 ? false : true;
        }
        public bool DeleteCategory(int CategoryId)
        {
            //  Category.CreatedDate = DateTime.Now;
            SA_Category EditCategory = _context.SA_Category.Where(Category => Category.id == CategoryId).FirstOrDefault();
            _context.Entry(EditCategory).State = EntityState.Deleted;
            int x =  _context.SaveChanges();
            return x == 0 ? false : true;
        }
        public async Task<bool> AddCategory(SA_Category Category)
            {
              //  Category.CreatedDate = DateTime.Now;
                _context.SA_Category.Add(Category);
                int x = await _context.SaveChangesAsync();
                return x == 0 ? false : true;
            }

            public async Task<bool> UpdateCategory(SA_Category Category)
            {
                _context.Entry(Category).State = EntityState.Modified;
              //  Category.ModeifiedDate = DateTime.Now;
                int x = await _context.SaveChangesAsync();
                return x == 0 ? false : true;
            }

        internal SA_Category GetCategoryByid(int id)
        {
            return _context.SA_Category.Where(x=>x.id==id).SingleOrDefault();
        }

        internal List<SelectListItem> GetProductList()
        {
            return (from product in _context.SA_Product
                                    //  select  { Fname = User.Fname+" "+User.Lname , Phone = User.Phone, Role=User.Role,Email=User.Email,UserPassword=User.Password});
                                select new SelectListItem { Text = product.ProductName, Value = product.id.ToString() }).ToList();
        }
        internal List<SelectListItem> CategoryList()
        {
            return (from category in _context.SA_Category
                        //  select  { Fname = User.Fname+" "+User.Lname , Phone = User.Phone, Role=User.Role,Email=User.Email,UserPassword=User.Password});
                    select new SelectListItem { Text = category.CategoryName, Value = category.id.ToString() }).ToList();
        }
        internal List<SelectListItem> CountryList()
        {
            return (from category in _context.SA_Country
                        //  select  { Fname = User.Fname+" "+User.Lname , Phone = User.Phone, Role=User.Role,Email=User.Email,UserPassword=User.Password});
                    select new SelectListItem { Text = category.CountryName, Value = category.id.ToString() }).ToList();
        }
    }
}