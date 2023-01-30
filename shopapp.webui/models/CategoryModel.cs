using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using shopapp.entity;

namespace shopapp.webui.models
{
    public class CategoryModel
    {

  
        public int Id { get; set; }

        // [Display (Name="Prod Name",Prompt="Enter Product Name")]
        // [Required(ErrorMessage ="Name area must be filled")]
        // [StringLength(60,MinimumLength =5,ErrorMessage ="Number of characters are not within permitted range")]
     
        public string Name { get; set; }
        //  [Required(ErrorMessage =" Url must be filled")]        
  
        public string Url { get; set; }
        //  [Required(ErrorMessage =" Description must be filled")]
        // [StringLength(100,MinimumLength =10,ErrorMessage ="Number of characters are not within permitted range")]
   
        public string Description { get; set; }
        public List<Product> Products { get; set; }
}
    }
