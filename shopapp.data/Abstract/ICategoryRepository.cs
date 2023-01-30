using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using shopapp.entity;

namespace shopapp.data.Abstract
{
    public interface ICategoryRepository:IRepository<Category>
    {
        List<Category> getPopularCategories();

        Category GetCategoryByName(string name);
        public Category GetByIdWithProducts(int categoryId);
        public void DeleteFromCategory(int productId,int categoryId);
       
    }
}