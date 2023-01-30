using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using shopapp.entity;
using shopapp.data.Abstract;

namespace shopapp.business.Abstract
{
    public interface ICategoryService:IValidator<Category>
    {
         Category getById(int id);

         List<Category> getAll();

         bool Create(Category entity);

         void Update(Category entity);

         void Delete (Category entity);

         Category getCategoryByName (string name);
         Category GetByIdWithProducts(int categoryId);
         void DeleteFromCategory(int productId,int categoryId);
    }
}