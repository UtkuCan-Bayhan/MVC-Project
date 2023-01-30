using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using shopapp.data.Abstract;
using shopapp.entity;

namespace shopapp.data.Concrete.EfCore
{
    public class EfCoreCategoryRepository : EfCoreGenericRepository<Category, ShopContext>, ICategoryRepository
    {

        public List<Category> getPopularCategories()
        {
            throw new NotImplementedException();
        }

        public Category GetCategoryByName(string name){
            using (var db =new ShopContext()){
               return db.Categories.Where(c=>c.Name==name).FirstOrDefault();

            }

        }

        public Category GetByIdWithProducts(int categoryId)
        {
            using (var db = new ShopContext()){
              return  db.Categories.Where(c=>c.CategoryId==categoryId).Include(i=>i.ProductCategories).ThenInclude(c=>c.Product).FirstOrDefault();
            }
        }

        public void DeleteFromCategory(int productId, int categoryId)
        {
            using (var db =new ShopContext()){
                 var cmd = "delete from productcategory where ProductId=@p0 and CategoryId=@p1";
                db.Database.ExecuteSqlRaw(cmd,productId,categoryId);
            }
        }
    }
}