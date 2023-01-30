using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using shopapp.data.Abstract;
using shopapp.entity;

namespace shopapp.data.Concrete.EfCore
{
    public class EfCoreProductRepository : EfCoreGenericRepository<Product, ShopContext>, IProductRepository
    {
        public Product GetByIdWithCategories(int id)
        {
            using(var context = new ShopContext())
            {
                return context.Products
                                .Where(i=>i.ProductId == id)
                                .Include(i=>i.ProductCategories)
                                .ThenInclude(i=>i.Category)
                                .FirstOrDefault();
            }
        }

        public int getCountByCategory(string category)
        {

            using (var db = new ShopContext()){
                var products=db.Products.Where(i=>i.IsApproved).
                AsQueryable();

                if(!string.IsNullOrEmpty(category)){
                    products=products.Include(i=>i.ProductCategories).ThenInclude(i=>i.Category).Where(c=>c.ProductCategories.Any(c=>c.Category.Url==category));
                }
            // using (var context =new ShopContext()){
            //   var categories=  context.Categories;

            //   if (categories!=null){
            //     return categories.Count();
            //   }

            //   return 0;

            return products.Count();

            }
        }

        public List<Product> getHomePageProducts()
        {
            using (var db= new ShopContext()){
               return db.Products.Where(p=>p.isHome==true && p.IsApproved==true).ToList();
            }
        }

        public List<Product> getPopularProducts()
        {
            using (var db = new ShopContext()){
                return db.Products.ToList();
            }
        }

        public Product getProductDetails(string Url)
        {
            using (var db= new ShopContext()){
                return db.Products.Where(p=>p.Url==Url).Include(i=>i.ProductCategories).ThenInclude(i=>i.Category).FirstOrDefault();
            }
        }

        public List<Product> getProductsByCategory(string name,int pagesize,int page)
        {
             using (var db = new ShopContext()){
                var products=db.Products
                .Where(i=>i.IsApproved).AsQueryable();

                if(!string.IsNullOrEmpty(name)){
                    products=products
                    .Include(i=>i.ProductCategories).ThenInclude(i=>i.Category).Where(c=>c.ProductCategories.Any(c=>c.Category.Url==name));
                }

                
                return products.Skip((page-1)*pagesize).Take(pagesize).ToList();


            }
          
        }

        public List<Product> getProductsBySearch(string name)
        {
            using (var db = new ShopContext()){
                var products=db.Products
                .Where(i=>i.IsApproved && (i.Name.ToLower().Contains(name.ToLower())) || i.Description.ToLower().Contains(name.ToLower())).AsQueryable();

                return products.ToList();

        }
    }

        public void Update(Product entity, int[] categoryIds)
        {
            using (var context= new ShopContext()){

           
            var product = context.Products.Include(i=>i.ProductCategories).FirstOrDefault(i=>i.ProductId==entity.ProductId);
            if (product!=null){
                product.Name=entity.Name;
                product.Description=entity.Description;
                product.ImageUrl=entity.ImageUrl;
                product.IsApproved=entity.IsApproved;
                product.isHome=entity.isHome;
                product.Url=entity.Url;

                product.ProductCategories=categoryIds.Select(catid=>new ProductCategory{
                    ProductId=entity.ProductId,
                    CategoryId=catid

                }).ToList();
             }
             context.SaveChanges();
             }

             
        }
    }
}
