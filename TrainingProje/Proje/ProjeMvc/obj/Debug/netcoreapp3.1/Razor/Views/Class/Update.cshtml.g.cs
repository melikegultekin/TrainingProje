#pragma checksum "C:\Users\mel\Desktop\Eğitim-Proje\Proje\ProjeMvc\Views\Class\Update.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d106f0f0c517a7d8e6f092e39791563d206851aa"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Class_Update), @"mvc.1.0.view", @"/Views/Class/Update.cshtml")]
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
#line 1 "C:\Users\mel\Desktop\Eğitim-Proje\Proje\ProjeMvc\Views\_ViewImports.cshtml"
using ProjeMvc;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\mel\Desktop\Eğitim-Proje\Proje\ProjeMvc\Views\_ViewImports.cshtml"
using ProjeMvc.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d106f0f0c517a7d8e6f092e39791563d206851aa", @"/Views/Class/Update.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9815ab36a6ce6c556dced651754287f83d15f6ea", @"/Views/_ViewImports.cshtml")]
    public class Views_Class_Update : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Entities.Concrete.Class>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/bootstrap/dist/css/bootstrap.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/site.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\mel\Desktop\Eğitim-Proje\Proje\ProjeMvc\Views\Class\Update.cshtml"
  
    ViewData["Title"] = "Update";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "d106f0f0c517a7d8e6f092e39791563d206851aa4410", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d106f0f0c517a7d8e6f092e39791563d206851aa5524", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n<h1>Sınıf Güncelle</h1>\r\n<br />\r\n<div class=\"content\" style=\"width: 400px; margin-left: 35%; margin-bottom: 10%; margin-top:5%\">\r\n");
#nullable restore
#line 12 "C:\Users\mel\Desktop\Eğitim-Proje\Proje\ProjeMvc\Views\Class\Update.cshtml"
     if (TempData["AlertMessage"] != null)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"alert alert-danger\">\r\n            <strong>Uyarı!</strong>");
#nullable restore
#line 15 "C:\Users\mel\Desktop\Eğitim-Proje\Proje\ProjeMvc\Views\Class\Update.cshtml"
                              Write(TempData["AlertMessage"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            <button type=\"button\" class=\"close\" data-dismiss=\"alert\">\r\n                <span>&times;</span>\r\n");
            WriteLiteral("            </button>\r\n        </div>\r\n");
#nullable restore
#line 21 "C:\Users\mel\Desktop\Eğitim-Proje\Proje\ProjeMvc\Views\Class\Update.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"col-md-12\">\r\n        <div class=\"card\">\r\n            <div class=\"card-header\"><h5 class=\"title\">Güncelle</h5></div>\r\n            <div class=\"card-body\">\r\n");
#nullable restore
#line 26 "C:\Users\mel\Desktop\Eğitim-Proje\Proje\ProjeMvc\Views\Class\Update.cshtml"
                 using (Html.BeginForm("Update", "Class", FormMethod.Post))
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <div class=\"form-group\">\r\n                        ");
#nullable restore
#line 29 "C:\Users\mel\Desktop\Eğitim-Proje\Proje\ProjeMvc\Views\Class\Update.cshtml"
                   Write(Html.Label("Sınıfın Adı:"));

#line default
#line hidden
#nullable disable
            WriteLiteral("<br />\r\n                        ");
#nullable restore
#line 30 "C:\Users\mel\Desktop\Eğitim-Proje\Proje\ProjeMvc\Views\Class\Update.cshtml"
                   Write(Html.TextBoxFor(x => x.ClassName, new { autocomplete = "off" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("<br />\r\n");
            WriteLiteral("                        ");
#nullable restore
#line 32 "C:\Users\mel\Desktop\Eğitim-Proje\Proje\ProjeMvc\Views\Class\Update.cshtml"
                   Write(Html.ValidationMessageFor(x => x.ClassName, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        <br /><br />\r\n                        <input type=\"hidden\" name=\"ClassId\"");
            BeginWriteAttribute("value", " value=\"", 1536, "\"", 1558, 1);
#nullable restore
#line 34 "C:\Users\mel\Desktop\Eğitim-Proje\Proje\ProjeMvc\Views\Class\Update.cshtml"
WriteAttributeValue("", 1544, Model.ClassId, 1544, 14, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n");
            WriteLiteral("                        <button>Güncelle</button>\r\n\r\n                    </div>\r\n");
#nullable restore
#line 39 "C:\Users\mel\Desktop\Eğitim-Proje\Proje\ProjeMvc\Views\Class\Update.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                <a href=\"/Class/GetAll\" class=\"btn btn-success\">Geri Dön</a>\r\n            </div>\r\n");
            WriteLiteral("\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Entities.Concrete.Class> Html { get; private set; }
    }
}
#pragma warning restore 1591
