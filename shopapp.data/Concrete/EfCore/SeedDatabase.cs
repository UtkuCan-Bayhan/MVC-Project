using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using shopapp.entity;

namespace shopapp.data.Concrete.EfCore
{
    public static class SeedDatabase
    {
        public static void Seed(){
            var context = new ShopContext();
            Console.WriteLine(context.Database.GetPendingMigrations().Count());

            if(context.Database.GetPendingMigrations().Count()==0)
            {
                if (context.Categories.Count()==0){
                     context.Categories.AddRange(Categories);
                }
            
            if (context.Products.Count()==0){
                     context.Products.AddRange(Products);
                     context.AddRange(ProductCategories);
                }
                context.SaveChanges();
                }
        }
        private static Category[] Categories={
            new Category{Name="Phone",Url="phone",Description="Mobile Phones, Wired Phones"},
            new Category{Name="PC",Url="pc",Description= "Laptop, Desktop, Mac"},
            new Category{Name="TV",Url="tv", Description="LED REGULAR"}
        };
        private static Product[] Products={
            new Product{Name="Samsung S6",Url="samsung-s5",Price=2000,Description="BEST",IsApproved=true,ImageUrl="2.jpg"},
            new Product{Name="IPhone X",Url="iphone",Price=3000,Description="BEST",IsApproved=true,ImageUrl="1.jpg"},
            new Product{Name="ASUS",Url="asus",Price=5000,Description="BEST",IsApproved=true,ImageUrl="3.jpg"},
            new Product{Name="STEELSER",Url="steelser",Price=6000,Description="BEST",IsApproved=true,ImageUrl="5.jpg"},
            new Product{Name="JBL",Url="jbl",Price=4000,Description="BEST",IsApproved=true,ImageUrl="6.jpg"}
           
        };

        private static ProductCategory[] ProductCategories = {
            new ProductCategory {Product=Products[0],Category=Categories[0]},
            new ProductCategory {Product=Products[0],Category=Categories[1]},
            new ProductCategory {Product=Products[1],Category=Categories[0]},
            new ProductCategory {Product=Products[2],Category=Categories[0]},
            new ProductCategory {Product=Products[3],Category=Categories[2]},
            new ProductCategory {Product=Products[4],Category=Categories[1]},
            new ProductCategory {Product=Products[4],Category=Categories[2]}
        };
    }
}