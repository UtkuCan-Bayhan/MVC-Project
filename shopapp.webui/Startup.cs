using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using shopapp.data.Abstract;
using shopapp.data.Concrete.EfCore;
using shopapp.business.Abstract;
using shopapp.business;
using shopapp.business.Concrete;
using shopapp.webui.identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using shopapp.webui.EmailServices;

namespace shopapp.webui
{
    
    public class Startup
    {
     private IConfiguration _configuration;
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
           services.AddDbContext<ApplicationContext>(options=>options.UseSqlite("Data Source=ShopDb"));
           services.AddIdentity<User,IdentityRole>().AddEntityFrameworkStores<ApplicationContext>().AddDefaultTokenProviders();

           services.Configure<IdentityOptions>(o=>{
           o.Password.RequireDigit=true;
           o.Password.RequireLowercase=true;
           o.Password.RequireUppercase=true;
           o.Password.RequiredLength=6;
           o.Password.RequireNonAlphanumeric=true;

           o.Lockout.MaxFailedAccessAttempts=5;
           o.Lockout.DefaultLockoutTimeSpan=TimeSpan.FromMinutes(10);
           o.Lockout.AllowedForNewUsers=true;

          //  o.User.AllowedUserNameCharacters=""
           o.User.RequireUniqueEmail=true;

           o.SignIn.RequireConfirmedEmail=true;
           o.SignIn.RequireConfirmedPhoneNumber=false;
           o.SignIn.RequireConfirmedAccount=false;

           });

           services.ConfigureApplicationCookie(o=>{
               o.LoginPath="/account/login";
               o.LogoutPath="/account/logout";
               o.AccessDeniedPath="/account/accessdenied";
               o.SlidingExpiration=true;
               o.ExpireTimeSpan=TimeSpan.FromHours(1);
               o.Cookie=new CookieBuilder{
                    HttpOnly=true,
                    Name=".Shopapp.Security.Cookie",
                    SameSite=SameSiteMode.Strict
               };
                  

           });

            services.AddScoped<IProductRepository,EfCoreProductRepository>();
            services.AddScoped<ICategoryRepository,EfCoreCategoryRepository>();
            
            services.AddScoped<ICategoryService,CategoryManager>();
            services.AddScoped<IProductService,ProductManager>();

             services.AddScoped<IEmailSender,SmtpEmailSender>(i=> 
                new SmtpEmailSender(
                    _configuration["EmailSender:Host"],
                    _configuration.GetValue<int>("EmailSender:Port"),
                    _configuration.GetValue<bool>("EmailSender:EnableSSL"),
                    _configuration["EmailSender:UserName"],
                    _configuration["EmailSender:Password"])
                );

            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            
            app.UseStaticFiles();

         app.UseStaticFiles(new StaticFileOptions{
            FileProvider=new PhysicalFileProvider(
                Path.Combine(Directory.GetCurrentDirectory(),"node_modules")
            ),RequestPath="/modules"
         });
            if (env.IsDevelopment())
            {
                SeedDatabase.Seed();
                app.UseDeveloperExceptionPage();
            }

            app.UseAuthentication();
            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
               
                 endpoints.MapControllerRoute(
                     name:"adminproductlist",
                     pattern:"admin/products",
                     defaults:new {controller="admin",action="productlist"}
                );
                endpoints.MapControllerRoute(
                     name:"adminproductcreate",
                     pattern:"admin/product/create",
                     defaults:new {controller="admin",action="createproduct"}
                );

                endpoints.MapControllerRoute(
                     name:"admincategorylist",
                     pattern:"admin/categories",
                     defaults:new {controller="admin",action="categorylist"}
                );
                endpoints.MapControllerRoute(
                     name:"admincategorycreate",
                     pattern:"admin/category/create",
                     defaults:new {controller="admin",action="createcategory"}
                );
                endpoints.MapControllerRoute(
                     name:"admincategoryedit",
                     pattern:"admin/category/{id?}",
                     defaults:new {controller="admin",action="categoryedit"}
                );

                

                 endpoints.MapControllerRoute(
                     name:"adminproductedit",
                     pattern:"admin/product/{id?}",
                     defaults:new {controller="admin",action="productedit"}
                );


                 endpoints.MapControllerRoute(
                     name:"search",
                     pattern:"search",
                     defaults:new {controller="Shop",action="search"}
                );

                
                endpoints.MapControllerRoute(
                     name:"producdetails",
                     pattern:"{Url}",
                     defaults:new {controller="Shop",action="details"}
                );

                endpoints.MapControllerRoute(
                     name:"products",
                     pattern:"products/{category?}",
                     defaults:new {controller="Shop",action="list"}
                );
                   
                
               endpoints.MapControllerRoute(
                name:"Default",
                pattern:"{controller=Home}/{action=Index}/{id?}"
               );
            });
        }
    }
}
