using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using shopapp.business.Abstract;
using shopapp.entity;
using shopapp.webui.Extensions;
using shopapp.webui.models;


namespace shopapp.webui.controllers
{
    [Authorize]
    public class AdminController:Controller
    {
        private IProductService _ProductService;
         private ICategoryService _categoryService;

        public AdminController(IProductService Productservice,ICategoryService categoryService)
        {
            
            _ProductService=Productservice;
             _categoryService=categoryService;
        }
        


        public IActionResult ProductList(){

           return View(new ProductListViewModel{

            Products=_ProductService.getAll()

           });
        }
        [HttpGet]
        public IActionResult CreateProduct(){
            return View();

        }
        [HttpPost]
        public IActionResult CreateProduct(ProductModel product){

            if (ModelState.IsValid){
                 var entity = new Product{
                Name=product.Name,
                Url=product.Url,
                Description=product.Description,
                ImageUrl=product.ImageUrl,
                Price=product.Price
                
            };
             
            if(_ProductService.Create(entity)){
                // CreateMessage("the product is created","success");
                TempData.Put("message",new AlertMessage{
                    Title="created",
                    Message="The product is created",
                    AlertType="success"

                });
             
                  return RedirectToAction("productlist");

            };
            // CreateMessage(_ProductService.ErrorMessage,"danger");
            TempData.Put("message",new AlertMessage{
                    Title="invalid",
                    Message=_ProductService.ErrorMessage,
                    AlertType="danger"

                });

           return View(product);
                
            }

            return View(product);

          
            
          
        }
        [HttpGet]
         public IActionResult ProductEdit(int? id){

            if (id==null){
                return NotFound();
            }

           var entity= _ProductService.GetByIdWithCategories((int)id);

            if (entity==null){
                return NotFound();
            }

            var model = new ProductModel{
                ProductId=entity.ProductId,
                Name=entity.Name,
                Price=entity.Price,
                Description=entity.Description,
                ImageUrl=entity.ImageUrl,
                Url=entity.Url,
                IsApproved=entity.IsApproved,
                isHome=entity.isHome,
                 SelectedCategories = entity.ProductCategories.Select(i=>i.Category).ToList()

            };

             ViewBag.Categories=_categoryService.getAll();

            // _ProductService.getProductDetails()

            return View(model);
        }
        [HttpPost]

        public async Task<IActionResult> ProductEdit(ProductModel model,int[] categoryIds,IFormFile file){

            if (ModelState.IsValid)
            {if (model==null){
                return NotFound();
            }

           var entity= _ProductService.getById(model.ProductId);

            if (entity==null){
                return NotFound();
            }

            
            entity.Name = model.Name;
            entity.Price = model.Price;
            entity.Url = model.Url;
            entity.Description = model.Description;
            entity.isHome=model.isHome;
            entity.IsApproved=model.IsApproved;
            

            if (file!=null){
                entity.ImageUrl=file.FileName;
                var extention= Path.GetExtension(file.FileName);
                // var random= string.Format($"{DateTime.Now.Ticks}.jpg");
                var random= string.Format($"{Guid.NewGuid()}{extention}");
                entity.ImageUrl=random;
                var path =Path.Combine(Directory.GetCurrentDirectory(),"wwwroot\\img",random);

                using (var stream= new FileStream(path,FileMode.Create)){
                    await file.CopyToAsync(stream);
                }

            }
            

            // _ProductService.getProductDetails()

            _ProductService.Update(entity,categoryIds);

            if(_ProductService.Update(entity,categoryIds)){
                TempData.Put("message",new AlertMessage{
                    Title="update",
                    Message="Update is successful",
                    AlertType="success"

                });
                // CreateMessage("Update is successful","success");
                 return RedirectToAction("productlist");}

                 else{
                    // CreateMessage(_ProductService.ErrorMessage,"danger");
                    TempData.Put("message",new AlertMessage{
                    Title="invalid",
                    Message=_ProductService.ErrorMessage,
                    AlertType="danger"

                });
                      ViewBag.Categories=_categoryService.getAll();
                    return View(model);
            }
               
            }
            
            else{
                 ViewBag.Categories=_categoryService.getAll();
                return View(model);
            }
            

            
        }

        public IActionResult DeleteProduct(int productId){

           var entity= _ProductService.getById(productId);

            if(entity!=null){
                _ProductService.Delete(entity);
            }


          TempData.Put("message",new AlertMessage{
                    Title="invalid",
                    Message="invalid token",
                    AlertType="warning"

                });

           ;
           
             return RedirectToAction("Productlist");
        }
       
        
        // public IActionResult Edit(ProductModel Product){

        //     _ProductService.Update()
        // }

        [HttpGet]
            public IActionResult CreateCategory(){
                return View();
            }

             [HttpPost]
            public IActionResult CreateCategory(CategoryModel category){

                if (ModelState.IsValid){
                    var Category = new Category {
                    
                    Name=category.Name,
                    Url=category.Url,
                    Description=category.Description
                };

                _categoryService.Create(Category);

                TempData.Put("message",new AlertMessage{
                    Title="invalid",
                    Message="invalid token",
                    AlertType="warning"

                });

                return RedirectToAction("categorylist");


                }

                else {
                    return View(category);
                }

                
            }

            public IActionResult categorylist(){
                
                return View(new ProductDetailModel{
                   Categories=_categoryService.getAll()
                });
            }

            [HttpGet]
         public IActionResult CategoryEdit(int? id){

           

            if (id==null){
                return NotFound();
            }

           var entity=_categoryService.GetByIdWithProducts((int)id);

            if (entity==null){
                return NotFound();
            }

            var model = new CategoryModel{

                Id=entity.CategoryId,
                Name=entity.Name,
                Description=entity.Description,
                Url=entity.Url,
                 Products = entity.ProductCategories.Select(p=>p.Product).ToList()

            };

           

            return View(model);


         }
          [HttpPost]
        public IActionResult CategoryEdit(CategoryModel model)
        {

             if (ModelState.IsValid){
                 var entity =_categoryService.getById(model.Id);
            
            if(entity==null)
            {
                return NotFound();
            }

            entity.Name = model.Name;
            entity.Url = model.Url;
            entity.Description=model.Description;

            _categoryService.Update(entity);

             TempData.Put("message",new AlertMessage{
                    Title="invalid",
                    Message="invalid token",
                    AlertType="warning"

                });

            

            return RedirectToAction("CategoryList");

             }

             else{
                return View(model);
             }

           
        }


         public IActionResult deleteCategory(int categoryId){

            

            _categoryService.Delete(_categoryService.getById(categoryId));

             TempData.Put("message",new AlertMessage{
                    Title="invalid",
                    Message="invalid token",
                    AlertType="warning"

                });

            return RedirectToAction("categorylist");

         }

          [HttpPost]
        public IActionResult DeleteFromCategory(int productId,int categoryId)
        {
            _categoryService.DeleteFromCategory(productId,categoryId);
            return Redirect("/admin/category/"+categoryId);
        }

        // private void CreateMessage(string message,string alertType){
        //      TempData["message"]= JsonConvert.SerializeObject (new AlertMessage{
        //         Message=message,
        //         AlertType=alertType});


        // }



         
    }
}