#pragma checksum "C:\Users\mel\Desktop\Eğitim-Proje\Proje\ProjeMvc\Views\Waiting\Reddet.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0ae5e417126082a1edf21238dbf0b1c37359e9ac"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Waiting_Reddet), @"mvc.1.0.view", @"/Views/Waiting/Reddet.cshtml")]
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
#line 1 "C:\Users\mel\Desktop\Eğitim-Proje\Proje\ProjeMvc\Views\Waiting\Reddet.cshtml"
using Entities.Concrete;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0ae5e417126082a1edf21238dbf0b1c37359e9ac", @"/Views/Waiting/Reddet.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9815ab36a6ce6c556dced651754287f83d15f6ea", @"/Views/_ViewImports.cshtml")]
    public class Views_Waiting_Reddet : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Waiting>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/bootstrap/dist/css/bootstrap.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/AdminLTE-3.0.4/plugins/fontawesome-free/css/all.min.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/AdminLTE-3.0.4/dist/css/adminlte.min.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 4 "C:\Users\mel\Desktop\Eğitim-Proje\Proje\ProjeMvc\Views\Waiting\Reddet.cshtml"
  
    ViewData["Title"] = "GetAll";
    Layout = "~/Views/Shared/_UserLayout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<!DOCTYPE html>\r\n<html lang=\"en\">\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0ae5e417126082a1edf21238dbf0b1c37359e9ac5382", async() => {
                WriteLiteral("\r\n    <title>Bootstrap </title>\r\n    <meta charset=\"utf-8\">\r\n    <meta name=\"viewport\" content=\"width=device-width, initial-scale=1\">\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "0ae5e417126082a1edf21238dbf0b1c37359e9ac5789", async() => {
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
                WriteLiteral(@"    <script src=""https://ajax.googleapis.com/ajax/libs/jquery/3.6.0/jquery.min.js""></script>
    <script src=""https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js""></script>


    <script src=""https://unpkg.com/sweetalert/dist/sweetalert.min.js""></script>

    <!-- Font Awesome Icons -->
    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "0ae5e417126082a1edf21238dbf0b1c37359e9ac7320", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n    <link rel=\"stylesheet\"");
                BeginWriteAttribute("href", " href=\"", 939, "\"", 946, 0);
                EndWriteAttribute();
                WriteLiteral(">\r\n    <!-- IonIcons -->\r\n    <link rel=\"stylesheet\" href=\"http://code.ionicframework.com/ionicons/2.0.1/css/ionicons.min.css\">\r\n    <!-- Theme style -->\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "0ae5e417126082a1edf21238dbf0b1c37359e9ac8844", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n    <!-- Google Font: Source Sans Pro -->\r\n    <link href=\"https://fonts.googleapis.com/css?family=Source+Sans+Pro:300,400,400i,700\" rel=\"stylesheet\">\r\n");
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
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0ae5e417126082a1edf21238dbf0b1c37359e9ac10887", async() => {
                WriteLiteral(@"
    <div class=""container"">
        <br />
        <br />
        <h4><b>Reddedilen Eğitimler</b></h4>
        <br />
        <table id=""tbl1"" class=""table table-bordered"">
            <thead>
                <tr>
                    <th><b>Eğitimin İsmi</b></th>
                    <th><b>Eğitimin başlangıç tarihi</b></th>
                    <th><b>Eğitimin bitiş tarihi</b></th>
                    <th><b>Son başvuru tarihi</b></th>
                    <th></th>
                    <th></th>
                </tr>
            </thead>
            <!--Model içindeki her item için döngü dönecek ve değerleri tabloya yazılacak-->
");
#nullable restore
#line 51 "C:\Users\mel\Desktop\Eğitim-Proje\Proje\ProjeMvc\Views\Waiting\Reddet.cshtml"
             foreach (var item in Model)
            {

#line default
#line hidden
#nullable disable
                WriteLiteral("                <tr>\r\n                    <td>");
#nullable restore
#line 54 "C:\Users\mel\Desktop\Eğitim-Proje\Proje\ProjeMvc\Views\Waiting\Reddet.cshtml"
                   Write(item.Training.TrainingName);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 55 "C:\Users\mel\Desktop\Eğitim-Proje\Proje\ProjeMvc\Views\Waiting\Reddet.cshtml"
                   Write(item.Training.TrainingStartdate.ToString("dd.MM.yyyy"));

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 56 "C:\Users\mel\Desktop\Eğitim-Proje\Proje\ProjeMvc\Views\Waiting\Reddet.cshtml"
                   Write(item.Training.TrainingLastdate.ToString("dd.MM.yyyy"));

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 57 "C:\Users\mel\Desktop\Eğitim-Proje\Proje\ProjeMvc\Views\Waiting\Reddet.cshtml"
                   Write(item.Training.Trainingdate.ToString("dd.MM.yyyy"));

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                    <td><a");
                BeginWriteAttribute("href", " href=\"", 2417, "\"", 2469, 2);
                WriteAttributeValue("", 2424, "/Training/Dersler?TrainingId=", 2424, 29, true);
#nullable restore
#line 58 "C:\Users\mel\Desktop\Eğitim-Proje\Proje\ProjeMvc\Views\Waiting\Reddet.cshtml"
WriteAttributeValue("", 2453, item.TrainingId, 2453, 16, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" style=\"border: none;\" class=\"btn btn-outline-dark btn-sm\"><b>Dersler</b></a></td>\r\n");
                WriteLiteral("\r\n                    <td>\r\n                        <button type=\"button\" class=\"btn btn-outline-dark btn-sm\" style=\"border: none;\" data-toggle=\"modal\" data-target=");
#nullable restore
#line 62 "C:\Users\mel\Desktop\Eğitim-Proje\Proje\ProjeMvc\Views\Waiting\Reddet.cshtml"
                                                                                                                                    Write("#myModal" +item.WaitingId );

#line default
#line hidden
#nullable disable
                WriteLiteral("><b>Nedeni</b></button>\r\n                        <!-- Modal -->\r\n                        <div class=\"modal fade\"");
                BeginWriteAttribute("id", " id=", 2984, "", 3017, 1);
#nullable restore
#line 64 "C:\Users\mel\Desktop\Eğitim-Proje\Proje\ProjeMvc\Views\Waiting\Reddet.cshtml"
WriteAttributeValue("", 2988, $"myModal{item.WaitingId}", 2988, 29, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@" role=""dialog"">
                            <div class=""modal-dialog"">
                                <!-- Modal content-->
                                <div class=""modal-content"">
                                    <div class=""modal-header"">
                                        <h4 class=""modal-title"">");
#nullable restore
#line 69 "C:\Users\mel\Desktop\Eğitim-Proje\Proje\ProjeMvc\Views\Waiting\Reddet.cshtml"
                                                           Write(ViewBag.username);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"</h4>
                                        <label>Yetkilinin mesajı:</label>
                                        <button type=""button"" class=""close"" data-dismiss=""modal"">&times;</button>
                                    </div>
                                    <div class=""modal-body"">
");
                WriteLiteral("                                        <p>");
#nullable restore
#line 75 "C:\Users\mel\Desktop\Eğitim-Proje\Proje\ProjeMvc\Views\Waiting\Reddet.cshtml"
                                       Write(item.MessageContext);

#line default
#line hidden
#nullable disable
                WriteLiteral("</p>\r\n                                    </div>\r\n                                    <div class=\"modal-footer\">\r\n");
                WriteLiteral(@"                                        <button type=""button"" class=""btn btn-outline-dark btn-sm"" data-dismiss=""modal"">Kapat</button>
                                    </div>
                                </div>

                            </div>
                        </div>
                    </td>
");
                WriteLiteral("                </tr>\r\n");
#nullable restore
#line 88 "C:\Users\mel\Desktop\Eğitim-Proje\Proje\ProjeMvc\Views\Waiting\Reddet.cshtml"

            }

#line default
#line hidden
#nullable disable
                WriteLiteral("        </table>\r\n    </div>\r\n\r\n");
                WriteLiteral(@"    <br />

    <br />
    <script>
        $(document).ready(function () {
            $('#tbl1').DataTable({
                pageLength: 15,
                language: {
                    url: '//cdn.datatables.net/plug-ins/1.13.1/i18n/tr.json'
                }
            });
        });
    </script>

");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Waiting>> Html { get; private set; }
    }
}
#pragma warning restore 1591
