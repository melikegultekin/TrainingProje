#pragma checksum "C:\Users\mel\Desktop\Eğitim-Proje\Proje\ProjeMvc\Views\Exam\Notlar.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7db6d77575aa1d6236db873d26bed0f5846025bc"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Exam_Notlar), @"mvc.1.0.view", @"/Views/Exam/Notlar.cshtml")]
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
#nullable restore
#line 1 "C:\Users\mel\Desktop\Eğitim-Proje\Proje\ProjeMvc\Views\Exam\Notlar.cshtml"
using Entities.Concrete;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7db6d77575aa1d6236db873d26bed0f5846025bc", @"/Views/Exam/Notlar.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9815ab36a6ce6c556dced651754287f83d15f6ea", @"/Views/_ViewImports.cshtml")]
    public class Views_Exam_Notlar : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Exam>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/bootstrap/dist/css/bootstrap.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 4 "C:\Users\mel\Desktop\Eğitim-Proje\Proje\ProjeMvc\Views\Exam\Notlar.cshtml"
  
    ViewData["Title"] = "GetAllT";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<!DOCTYPE html>\r\n<html lang=\"en\">\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7db6d77575aa1d6236db873d26bed0f5846025bc4578", async() => {
                WriteLiteral("\r\n    <title>Bootstrap </title>\r\n    <meta charset=\"utf-8\">\r\n    <meta name=\"viewport\" content=\"width=device-width, initial-scale=1\">\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "7db6d77575aa1d6236db873d26bed0f5846025bc4985", async() => {
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
                WriteLiteral(@"
    <link rel=""stylesheet"" href=""https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css"">
    <script src=""https://ajax.googleapis.com/ajax/libs/jquery/3.6.0/jquery.min.js""></script>
    <script src=""https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js""></script>
");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7db6d77575aa1d6236db873d26bed0f5846025bc7171", async() => {
                WriteLiteral("\r\n    <div class=\"container\">\r\n");
                WriteLiteral("        <!-- Trigger the modal with a button -->\r\n        <br />\r\n\r\n");
#nullable restore
#line 26 "C:\Users\mel\Desktop\Eğitim-Proje\Proje\ProjeMvc\Views\Exam\Notlar.cshtml"
         if (TempData["AlertMessage"] != null)
        {

#line default
#line hidden
#nullable disable
                WriteLiteral("            <div class=\"alert alert-success\">\r\n                <strong>Mesajınız!</strong>");
#nullable restore
#line 29 "C:\Users\mel\Desktop\Eğitim-Proje\Proje\ProjeMvc\Views\Exam\Notlar.cshtml"
                                      Write(TempData["AlertMessage"]);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                <button type=\"button\" class=\"close\" data-dismiss=\"alert\">\r\n                    <span>&times;</span>\r\n");
                WriteLiteral("                </button>\r\n            </div>\r\n");
#nullable restore
#line 35 "C:\Users\mel\Desktop\Eğitim-Proje\Proje\ProjeMvc\Views\Exam\Notlar.cshtml"
        }

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n        <div class=\"p-5 w-100 m-0\">\r\n            <!--burada Add viewine yönlendirme yaptık-->\r\n");
                WriteLiteral("            <a href=\"/Exam/GetAll\" class=\"btn btn-success\">Geri Dön</a>\r\n\r\n            <a href=\"/Manager/Logout\" class=\"btn btn-danger float-lg-right\">Çıkış Yap</a>\r\n            <br />\r\n            <br />\r\n            <br />\r\n");
                WriteLiteral("        </div>\r\n        <br />\r\n        <br />\r\n        <!--<div class=\"p-2 w-50 m-2\">-->\r\n");
                WriteLiteral("\r\n        <!--</div>-->\r\n        <br />\r\n");
                WriteLiteral(@"        <h3><b>Eğitimler</b></h3>
        <table class=""table table-bordered"">
            <tr>
                <th><b>Eğitimin Adı</b></th>
                <th><b>Eğitim başlangıç tarihi</b></th>
                <th><b>Eğitim son tarihi</b></th>
                <th><b>Son başvuru tarihi</b></th>
            </tr>
            <!--Model içindeki her item için döngü dönecek ve değerleri tabloya yazılacak-->
");
#nullable restore
#line 76 "C:\Users\mel\Desktop\Eğitim-Proje\Proje\ProjeMvc\Views\Exam\Notlar.cshtml"
             foreach (var item in Model)
            {

#line default
#line hidden
#nullable disable
                WriteLiteral("                <tr>\r\n                    <td>");
#nullable restore
#line 79 "C:\Users\mel\Desktop\Eğitim-Proje\Proje\ProjeMvc\Views\Exam\Notlar.cshtml"
                   Write(item.Training.TrainingName);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 80 "C:\Users\mel\Desktop\Eğitim-Proje\Proje\ProjeMvc\Views\Exam\Notlar.cshtml"
                   Write(item.Training.TrainingStartdate.ToString("dd.MM.yyyy"));

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 81 "C:\Users\mel\Desktop\Eğitim-Proje\Proje\ProjeMvc\Views\Exam\Notlar.cshtml"
                   Write(item.Training.TrainingLastdate.ToString("dd.MM.yyyy"));

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 82 "C:\Users\mel\Desktop\Eğitim-Proje\Proje\ProjeMvc\Views\Exam\Notlar.cshtml"
                   Write(item.Training.Trainingdate.ToString("dd.MM.yyyy"));

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n");
                WriteLiteral("\r\n                    \r\n                    <td><a");
                BeginWriteAttribute("href", " href=\"", 3535, "\"", 3582, 2);
                WriteAttributeValue("", 3542, "/Exam/NotGör?TrainingId=", 3542, 24, true);
#nullable restore
#line 88 "C:\Users\mel\Desktop\Eğitim-Proje\Proje\ProjeMvc\Views\Exam\Notlar.cshtml"
WriteAttributeValue("", 3566, item.TrainingId, 3566, 16, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" class=\"btn btn-info\">Notları Gör</a></td>\r\n\r\n                </tr>\r\n");
#nullable restore
#line 91 "C:\Users\mel\Desktop\Eğitim-Proje\Proje\ProjeMvc\Views\Exam\Notlar.cshtml"

            }

#line default
#line hidden
#nullable disable
                WriteLiteral("        </table>\r\n    </div>\r\n\r\n    <br />\r\n\r\n    <br />\r\n\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</html>\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Exam>> Html { get; private set; }
    }
}
#pragma warning restore 1591