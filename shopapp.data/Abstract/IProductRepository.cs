using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using shopapp.entity;

namespace shopapp.data.Abstract
{
    public interface IProductRepository:IRepository<Product>
    {
       Product getProductDetails(string name);
       List<Product> getPopularProducts();
       List<Product> getProductsByCategory(string name,int pagesize,int page);
       int getCountByCategory(string category);
       List<Product> getHomePageProducts();
       List<Product> getProductsBySearch(string name);
        Product GetByIdWithCategories(int id);

        void Update(Product entity, int[] categoryIds);

     
    

      
    }
}