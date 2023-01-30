using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using shopapp.data.Abstract;
using shopapp.entity;

namespace shopapp.business.Abstract
{
    public interface IProductService:IValidator<Product>
    {
         Product getById(int id);

         List<Product> getAll();

         bool Create(Product entity);

         void Update(Product entity);

         void Delete (Product entity);
         Product getProductDetails(string name);
         List<Product> getProductsByCategory(string name,int pagesize,int page);
        int getCountByCategory(string category);
        List<Product> getHomePageProducts();
        List<Product> getProductsBySearch(string name);
        Product GetByIdWithCategories(int id);
        bool Update(Product entity, int[] categoryIds);
    }
}