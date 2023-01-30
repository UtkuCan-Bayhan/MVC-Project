using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using shopapp.business.Abstract;
using shopapp.data.Abstract;
using shopapp.webui.models;

namespace shopapp.webui.controllers
{
    public class HomeController:Controller
    {
        public IProductService _productService;

        public HomeController(IProductService productService)
        {
            this._productService=productService;
        }
        public IActionResult Index(){
         
           var ProductViewModel= new ProductListViewModel{
           
            Products=_productService.getHomePageProducts()
           };
            return View(ProductViewModel);
        }
        
        public IActionResult About(){
            return View();
        }
         public IActionResult Contact(){
            return View("MyView");
        }
    }
    
}