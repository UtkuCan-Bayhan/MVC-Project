#pragma checksum "C:\Users\User\Shopapp\shopapp.webui\views\shared\_ResultMessage.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "98f83c4f0c6c8f76407990f948a1119c2dd88312"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.views_shared__ResultMessage), @"mvc.1.0.view", @"/views/shared/_ResultMessage.cshtml")]
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
#line 4 "C:\Users\User\Shopapp\shopapp.webui\views\_ViewImports.cshtml"
using shopapp.webui.Extensions;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\User\Shopapp\shopapp.webui\views\_ViewImports.cshtml"
using Newtonsoft.Json;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"98f83c4f0c6c8f76407990f948a1119c2dd88312", @"/views/shared/_ResultMessage.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"427eca76298fc45532c0ceea7805dd055d11fb9c", @"/views/_ViewImports.cshtml")]
    public class views_shared__ResultMessage : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<AlertMessage>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n        <div class=\"row\">\r\n            <div class=\"col-md-12\">\r\n                <div");
            BeginWriteAttribute("class", " class=\"", 107, "\"", 143, 3);
            WriteAttributeValue("", 115, "alert", 115, 5, true);
            WriteAttributeValue(" ", 120, "alert-", 121, 7, true);
#nullable restore
#line 5 "C:\Users\User\Shopapp\shopapp.webui\views\shared\_ResultMessage.cshtml"
WriteAttributeValue("", 127, Model.AlertType, 127, 16, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                    <h4 class=\"alert-title\">");
#nullable restore
#line 6 "C:\Users\User\Shopapp\shopapp.webui\views\shared\_ResultMessage.cshtml"
                                       Write(Model.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\r\n                    <p>");
#nullable restore
#line 7 "C:\Users\User\Shopapp\shopapp.webui\views\shared\_ResultMessage.cshtml"
                  Write(Model.Message);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p> \r\n                </div>\r\n            </div>\r\n        </div>\r\n\r\n    \r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<AlertMessage> Html { get; private set; }
    }
}
#pragma warning restore 1591
