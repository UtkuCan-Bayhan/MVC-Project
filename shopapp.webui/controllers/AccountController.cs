using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using shopapp.webui.EmailServices;
using shopapp.webui.Extensions;
using shopapp.webui.identity;
using shopapp.webui.models;

namespace shopapp.webui.controllers
{
    public class AccountController:Controller
    {
        private UserManager<User> _userManager;
        private SignInManager<User> _signInManager;
        private IEmailSender _emailSender;

        public AccountController(UserManager<User> userManager,SignInManager<User> signInManager,IEmailSender emailSender)
        {
            _userManager=userManager;
            _signInManager=signInManager;
            _emailSender=emailSender;
        }
        public IActionResult Login(string ReturnUrl=null){
            return View(new LoginModel(){
                ReturnUrl=ReturnUrl
            });
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel model){
            if(!ModelState.IsValid){
                return View(model);
            }
            var user=await _userManager.FindByEmailAsync(model.Email);
            if(user==null){ 
                ModelState.AddModelError("","Email does not exist");
                return View(model);
            }

            if(!await _userManager.IsEmailConfirmedAsync(user)){
                 ModelState.AddModelError("","Account is not confirmed");
                return View(model);
            }

            var result =await _signInManager.PasswordSignInAsync(user,model.Password,true,false);

            if(result.Succeeded){
                return Redirect(model.ReturnUrl??"~/");
            }
             ModelState.AddModelError("","Username or password does not exist");
            return View(model);
        }
    

        public IActionResult Register(){
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
         public async Task<IActionResult> Register(RegisterModel model){
            if(!ModelState.IsValid){
            return View(model);
            }
            var user = new User{
                FirstName=model.FirstName,
                LastName=model.LastName,
                UserName=model.UserName,
                Email=model.Email
            };
            var result =await _userManager.CreateAsync(user,model.Password);
            if(result.Succeeded){
                var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                var url= Url.Action("ConfirmEmail","Account",new{
                    userId=user.Id,
                    token=code
                });
                
                 await _emailSender.SendEmailAsync(model.Email,"Hesabınızı onaylayınız.",$"Lütfen email hesabınızı onaylamak için linke <a href='https://localhost:5001{url}'>tıklayınız.</a>");
               
                return RedirectToAction("login","account");
                
            }
            ModelState.AddModelError("","Bilinmeyen hata oldu lütfen tekrar deneyiniz.");
            return View(model);
        }

        public async Task<IActionResult> Logout(){
            await _signInManager.SignOutAsync();
            return Redirect("~/");
        }

        public async Task<IActionResult> ConfirmEmail(string userId,string token){
            if(userId==null || token ==null){

                TempData.Put("message",new AlertMessage{
                    Title="invalid",
                    Message="invalid token",
                    AlertType="danger"

                });
                 return View();
                
                // CreateMessage("invalid","danger");
            
            }
            var user= await _userManager.FindByIdAsync(userId);
            if(user!=null){
                 var result= await _userManager.ConfirmEmailAsync(user,token);
            if(result.Succeeded){
                
                TempData.Put("message",new AlertMessage{
                    Title="valid",
                    Message="valid token",
                    AlertType="success"

                });
                // CreateMessage("valid","success");
                 return View();
            }  
            }
            TempData.Put("message",new AlertMessage{
                    Title="invalid",
                    Message="invalid token",
                    AlertType="warning"

                });
        //    CreateMessage("invalid","danger");
                 return View();
          

        }

        public IActionResult ForgotPassword(){
            return View();
        }
        [HttpPost]

        public async Task<IActionResult> ForgotPassword(string Email){
            if(string.IsNullOrEmpty(Email)){
                return View();
            }
            var user= await _userManager.FindByEmailAsync(Email);

            if(user==null){
                return View();
            }

            var code = await _userManager.GeneratePasswordResetTokenAsync(user);

            var url=Url.Action("Reset Password","Account",new {
                userId=user.Id,
                token=code
            });

            await _emailSender.SendEmailAsync(Email,"Reset Password",$"Click <a href='https://localhost:5001{url}'>here</a> to reset password>");

            return View();

        }

             public IActionResult ResetPassword(string userId,string token){
                if (userId==null && token==null){
                    return RedirectToAction("Home","index");
                }

                var model= new ResetPasswordModel{
                    token=token
                };

                return View();


             }
             [HttpPost]
             public async Task<IActionResult> ResetPassword(ResetPasswordModel model){
                if (ModelState.IsValid){
                    return View(model);
                }

                var user=await _userManager.FindByEmailAsync(model.Email);
                if(user==null){
                    return RedirectToAction("HOME","Index");
                }

                var result= await _userManager.ResetPasswordAsync(user,model.token,model.Password);

                if(result.Succeeded){
                     return RedirectToAction("Login","Account");

                }

                return View(model);

                
             }
        // private void CreateMessage(string message,string alertType){
        //      TempData["message"]= JsonConvert.SerializeObject (new AlertMessage{
        //         Message=message,
        //         AlertType=alertType});


        // }

    }
}