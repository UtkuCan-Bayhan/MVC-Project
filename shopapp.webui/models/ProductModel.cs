using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using shopapp.entity;
using shopapp.webui.models;
namespace shopapp.webui.models
{
    public class ProductModel
    {
        public int ProductId { get; set; }  
        // [Display (Name="Prod Name",Prompt="Enter Product Name")]
        // [Required(ErrorMessage ="Name area must be filled")]
        // [StringLength(60,MinimumLength =5,ErrorMessage ="Number of characters are not within permitted range")]
        public string Name { get; set; }    
        // [Required(ErrorMessage =" Price must be filled")]   
        // [Range(1,10000,ErrorMessage ="Not in allowed range")]
        public double? Price { get; set; } 
        // [Required(ErrorMessage =" Description must be filled")]
        // [StringLength(100,MinimumLength =10,ErrorMessage ="Number of characters are not within permitted range")]
        public string Description { get; set; } 
        [Required(ErrorMessage =" ImageUrl must be filled")]        
        public string ImageUrl { get; set; }
        public bool IsApproved { get; set; }
        public string Url {get;set;}
        public bool isHome {get;set;}
        public List<Category> SelectedCategories { get; set; }
        
        
    }
    }
