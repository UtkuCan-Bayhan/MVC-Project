using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using shopapp.business.Abstract;
using shopapp.entity;
using shopapp.webui.models;


namespace shopapp.webui.controllers
{
    public class ShopController:Controller
    {
         public IProductService _productService;

        public ShopController(IProductService productService)
        {
            this._productService=productService;
        }
         public IActionResult List(string category, int page=1){
           const int PageSize=2;
         
           var ProductViewModel= new ProductListViewModel{
            PageInfo= new PageInfo{
                TotalItems=_productService.getCountByCategory(category),
                CurrentPage=page,
                ItemsPerPage=PageSize,
                CurrentCategory=category
                
            },
            Products=_productService.getProductsByCategory(category,PageSize,page)
          
           };
             
            return View(ProductViewModel);
        }
        public IActionResult Details(string Url){
            // if (Url==null){  
            //     return NotFound();
            // }
            Product product=_productService.getProductDetails((Url));
            if (product==null){
                return NotFound();

            }
            else{

            return View(new ProductDetailModel{
                Product =product,
                Categories=product.ProductCategories.Select(p=>p.Category).ToList()
            });
             }
        }
        
        public IActionResult Search (string q)
        {
           var ProductViewModel= new ProductListViewModel{
           
            Products=_productService.getProductsBySearch(q)
           
        };

          return View(ProductViewModel);

    }
}
}