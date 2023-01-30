using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using shopapp.business.Abstract;
using shopapp.data.Abstract;
using shopapp.entity;

namespace shopapp.business.Concrete
{
    public class CategoryManager : ICategoryService
    {
         private ICategoryRepository _categoryRepository;

      

        public CategoryManager(ICategoryRepository categoryRepository)
        {
            _categoryRepository=categoryRepository;
        }
        public List<Category> getAll()
        {
            return _categoryRepository.getAll();
        }

        public bool Create(Category entity)
        {
            if (Validation(entity)){
                 _categoryRepository.Create(entity);
                 return true;

            }
            else{
                return false;
            }
           
        }

        public void Delete(Category entity)
        {
            _categoryRepository.Delete(entity);
        }

        public Category getById(int id)
        {
          return  _categoryRepository.getById(id);
        }

        public void Update(Category entity)
        {
            _categoryRepository.Update(entity);
        }

        public Category getCategoryByName(string name){
           return _categoryRepository.GetCategoryByName(name);
        }

        public Category GetByIdWithProducts(int categoryId)
        {
            return _categoryRepository.GetByIdWithProducts(categoryId);
        }

        public void DeleteFromCategory(int productId, int categoryId)
        {
             _categoryRepository.DeleteFromCategory(productId,categoryId);
        }

          public string ErrorMessage { get ; set ; }

        public bool Validation(Category entity)
        {
            var isValid=true;

            if(string.IsNullOrEmpty(entity.Name)){
                ErrorMessage+="Product name is required";   
                 isValid=false;
            }

            if(string.IsNullOrEmpty(entity.Url)){
                ErrorMessage+="Url is required";   
                isValid=false;
            }

            return isValid;
        
        }

        
    }
}