#pragma checksum "D:\GitHub\Sibers\Sibers\Views\Companies\CustomerCompany.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3b184276e53aa063f44efe9e85457cdc6359ab6e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Companies_CustomerCompany), @"mvc.1.0.view", @"/Views/Companies/CustomerCompany.cshtml")]
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
#line 1 "D:\GitHub\Sibers\Sibers\Views\_ViewImports.cshtml"
using Sibers;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\GitHub\Sibers\Sibers\Views\_ViewImports.cshtml"
using Sibers.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3b184276e53aa063f44efe9e85457cdc6359ab6e", @"/Views/Companies/CustomerCompany.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d6d711c3d83b26d8d197832928ead8e3d7e0ea1a", @"/Views/_ViewImports.cshtml")]
    public class Views_Companies_CustomerCompany : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<CompanyViewModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "D:\GitHub\Sibers\Sibers\Views\Companies\CustomerCompany.cshtml"
  
    ViewData["Title"] = "Компании Исполнители";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div>
    <h1 class=""name-table"">Компании Исполнители</h1>
    <div class=""screen-center"">
    <table class=""content-table"">
        <thead>
            <tr>
                <th>Название Компании</th>
                <th>Описание</th>
            </tr>
        </thead>
        <tbody>
");
#nullable restore
#line 17 "D:\GitHub\Sibers\Sibers\Views\Companies\CustomerCompany.cshtml"
             foreach (var company in Model)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <td>");
#nullable restore
#line 20 "D:\GitHub\Sibers\Sibers\Views\Companies\CustomerCompany.cshtml"
                   Write(company.CompanyName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 21 "D:\GitHub\Sibers\Sibers\Views\Companies\CustomerCompany.cshtml"
                   Write(company.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                </tr>\r\n");
#nullable restore
#line 23 "D:\GitHub\Sibers\Sibers\Views\Companies\CustomerCompany.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </tbody>\r\n    </table>\r\n    </div>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<CompanyViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591