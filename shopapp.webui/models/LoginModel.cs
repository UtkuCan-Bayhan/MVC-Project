using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace shopapp.webui.models
{
    public class LoginModel
    {
       
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
         [Required]
        public string Email{get;set;}
        public string ReturnUrl {get;set;}
    }
}