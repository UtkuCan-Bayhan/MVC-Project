using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using shopapp.business.Abstract;
using shopapp.data.Abstract;
using shopapp.data.Concrete.EfCore;
using shopapp.entity;

namespace shopapp.business
{
    public class ProductManager : IProductService
    {
        private IProductRepository _productRepository;

       

        public ProductManager(IProductRepository productRepository)
        {
            _productRepository=productRepository;
        }
        public List<Product> getAll()
        {
           return _productRepository.getAll();
        }

        public bool Create(Product entity)
        {
            if(Validation(entity)){
                _productRepository.Create(entity);
                return true;

            }
            return false;


            
        }

        public void Delete(Product entity)
        {
            _productRepository.Delete(entity);
        }

        public Product getById(int id)
        {
            return _productRepository.getById(id);
        }

        public void Update(Product entity)
        {
             _productRepository.Update(entity);
        }

        public Product getProductDetails(string name)
        {
           return _productRepository.getProductDetails(name);
        }

        public List<Product> getProductsByCategory(string name,int pagesize,int page)
        {
            return _productRepository.getProductsByCategory(name,pagesize,page);
        }

        public int getCountByCategory(string category)
        {
            return _productRepository.getCountByCategory(category);
        }

        public List<Product> getHomePageProducts()
        {
            return _productRepository.getHomePageProducts();
        }

        public List<Product> getProductsBySearch(string name)
        {
            return _productRepository.getProductsBySearch(name);
        }

        public Product GetByIdWithCategories(int id)
        {
            return _productRepository.GetByIdWithCategories(id);
        }

        public bool Update(Product entity, int[] categoryIds)
        {
            if(Validation(entity)){

                if(categoryIds.Length==0){
                    ErrorMessage+="At least 1 category must be selected";
                    return false;
                }
                else{
                     _productRepository.Update(entity,categoryIds);
                 return true;

                }
                
                }

            else{
                return false;   
            }
                

        }
           

         public string ErrorMessage { get ; set; }

        public bool Validation(Product entity)
        {
            var isValid=true;

            if(string.IsNullOrEmpty(entity.Name)){
                ErrorMessage+="Product name is required"; 
                 isValid=false;  
            }

            if(entity.Price<0){
                ErrorMessage+="Product price must be positive";   
                 isValid=false;
            }

            return isValid;
        }

        
    }
}