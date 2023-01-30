#pragma checksum "C:\Users\User\Shopapp\shopapp.webui\views\Shop\List.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9b6ca5fac2aa9c55bd456b9d88bda52d31c4d28c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.views_Shop_List), @"mvc.1.0.view", @"/views/Shop/List.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 2 "C:\Users\User\Shopapp\shopapp.webui\views\_ViewImports.cshtml"
using shopapp.entity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\User\Shopapp\shopapp.webui\views\_ViewImports.cshtml"
using shopapp.webui.models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\User\Shopapp\shopapp.webui\views\_ViewImports.cshtml"
using Newtonsoft.Json;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9b6ca5fac2aa9c55bd456b9d88bda52d31c4d28c", @"/views/Shop/List.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1d4a1ed446793b03f0dd3caa556bce8a07984af8", @"/views/_ViewImports.cshtml")]
    public class views_Shop_List : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ProductListViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n                   \r\n            <div class=\"row\">\r\n                <div class=\"col-md-3\">\r\n                    ");
#nullable restore
#line 6 "C:\Users\User\Shopapp\shopapp.webui\views\Shop\List.cshtml"
               Write(await Component.InvokeAsync("Categories"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </div>\r\n                <div class=\"col-md-9\">\r\n                    \r\n            <div class=\"row\">\r\n");
#nullable restore
#line 11 "C:\Users\User\Shopapp\shopapp.webui\views\Shop\List.cshtml"
                 foreach (var item in Model.Products)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <div class=\"col-md-4\">\r\n                ");
#nullable restore
#line 14 "C:\Users\User\Shopapp\shopapp.webui\views\Shop\List.cshtml"
           Write(await Html.PartialAsync("_product", item));

#line default
#line hidden
#nullable disable
            WriteLiteral("   \r\n                </div>\r\n");
#nullable restore
#line 16 "C:\Users\User\Shopapp\shopapp.webui\views\Shop\List.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </div>\r\n            </div>\r\n            <div class=\"row\">\r\n                <div class=\"col\">\r\n                    <nav aria-label=\"Page navigation example\">\r\n                        <ul class=\"pagination\">\r\n");
#nullable restore
#line 23 "C:\Users\User\Shopapp\shopapp.webui\views\Shop\List.cshtml"
                             if(String.IsNullOrEmpty(Model.PageInfo.CurrentCategory))
                            {
                            

#line default
#line hidden
#nullable disable
#nullable restore
#line 25 "C:\Users\User\Shopapp\shopapp.webui\views\Shop\List.cshtml"
                             for (int i=0;i< Model.PageInfo.TotalPages();i++)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                   <li");
            BeginWriteAttribute("class", " class=\"", 1013, "\"", 1079, 2);
            WriteAttributeValue("", 1021, "page-item", 1021, 9, true);
#nullable restore
#line 27 "C:\Users\User\Shopapp\shopapp.webui\views\Shop\List.cshtml"
WriteAttributeValue(" ", 1030, Model.PageInfo.CurrentPage==(i+1)?"active":"", 1031, 48, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                                    <a class=\"page-link \"");
            BeginWriteAttribute("href", " href=\"", 1140, "\"", 1168, 2);
            WriteAttributeValue("", 1147, "/products?page=", 1147, 15, true);
#nullable restore
#line 28 "C:\Users\User\Shopapp\shopapp.webui\views\Shop\List.cshtml"
WriteAttributeValue("", 1162, i+1, 1162, 6, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 28 "C:\Users\User\Shopapp\shopapp.webui\views\Shop\List.cshtml"
                                                                                   Write(i+1);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n                                    </li>\r\n");
#nullable restore
#line 30 "C:\Users\User\Shopapp\shopapp.webui\views\Shop\List.cshtml"
                            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 30 "C:\Users\User\Shopapp\shopapp.webui\views\Shop\List.cshtml"
                              
                             
                            }

                            else
                            {
                                

#line default
#line hidden
#nullable disable
#nullable restore
#line 36 "C:\Users\User\Shopapp\shopapp.webui\views\Shop\List.cshtml"
                                 for (int i=0;i< Model.PageInfo.TotalPages();i++)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                   <li");
            BeginWriteAttribute("class", " class=\"", 1538, "\"", 1604, 2);
            WriteAttributeValue("", 1546, "page-item", 1546, 9, true);
#nullable restore
#line 38 "C:\Users\User\Shopapp\shopapp.webui\views\Shop\List.cshtml"
WriteAttributeValue(" ", 1555, Model.PageInfo.CurrentPage==(i+1)?"active":"", 1556, 48, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                                    <a class=\"page-link \"");
            BeginWriteAttribute("href", "  href=\"", 1665, "\"", 1726, 4);
            WriteAttributeValue("", 1673, "/products/", 1673, 10, true);
#nullable restore
#line 39 "C:\Users\User\Shopapp\shopapp.webui\views\Shop\List.cshtml"
WriteAttributeValue("", 1683, Model.PageInfo.CurrentCategory, 1683, 31, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1714, "?page=", 1714, 6, true);
#nullable restore
#line 39 "C:\Users\User\Shopapp\shopapp.webui\views\Shop\List.cshtml"
WriteAttributeValue("", 1720, i+1, 1720, 6, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 39 "C:\Users\User\Shopapp\shopapp.webui\views\Shop\List.cshtml"
                                                                                                                    Write(i+1);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n                                    </li>\r\n");
#nullable restore
#line 41 "C:\Users\User\Shopapp\shopapp.webui\views\Shop\List.cshtml"
                            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 41 "C:\Users\User\Shopapp\shopapp.webui\views\Shop\List.cshtml"
                              
                                 

                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                           \r\n                            \r\n                        \r\n                        </ul>\r\n                    </nav>\r\n                </div>\r\n                \r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n\r\n<script src=\"https://cdn.jsdelivr.net/npm/bootstrap@4.6.2/dist/js/bootstrap.bundle.min.js\" integrity=\"sha384-Fy6S3B9q64WdZWQUiU+q4/2Lc9npb8tCaSX9FK7E8HnRr0Jz8D6OP9dO5Vg3Q9ct\" crossorigin=\"anonymous\"></script>\r\n");
            }
            );
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ProductListViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591