#pragma checksum "C:\Users\mel\Desktop\Eğitim-Proje\Proje\ProjeMvc\Views\Exam\GetAll.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "dc5467ffb2fe8ade91c23d115ced657b5a6fb1e0"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Exam_GetAll), @"mvc.1.0.view", @"/Views/Exam/GetAll.cshtml")]
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
#line 1 "C:\Users\mel\Desktop\Eğitim-Proje\Proje\ProjeMvc\Views\Exam\GetAll.cshtml"
using Entities.Concrete;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"dc5467ffb2fe8ade91c23d115ced657b5a6fb1e0", @"/Views/Exam/GetAll.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9815ab36a6ce6c556dced651754287f83d15f6ea", @"/Views/_ViewImports.cshtml")]
    public class Views_Exam_GetAll : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Training>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/bootstrap/dist/css/bootstrap.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/AdminLTE-3.0.4/plugins/datatables-bs4/css/dataTables.bootstrap4.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/AdminLTE-3.0.4/plugins/fontawesome-free/css/fontawesome.min.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/AdminLTE-3.0.4/plugins/fontawesome-free/css/all.min.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/AdminLTE-3.0.4/dist/css/adminlte.min.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 4 "C:\Users\mel\Desktop\Eğitim-Proje\Proje\ProjeMvc\Views\Exam\GetAll.cshtml"
  
    ViewData["Title"] = "GetAllT";
    Layout = "~/Views/Shared/_AdminLayout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<!DOCTYPE html>\r\n<html lang=\"en\">\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "dc5467ffb2fe8ade91c23d115ced657b5a6fb1e06176", async() => {
                WriteLiteral("\r\n    <title>Bootstrap </title>\r\n    <meta charset=\"utf-8\">\r\n    <meta name=\"viewport\" content=\"width=device-width, initial-scale=1\">\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "dc5467ffb2fe8ade91c23d115ced657b5a6fb1e06583", async() => {
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

    <script type=""text/javascript"" src=""https://cdn.datatables.net/v/bs-3.3.7/jq-2.2.4/jszip-3.1.3/pdfmake-0.1.27/dt-1.10.15/b-1.3.1/b-colvis-1.3.1/b-flash-1.3.1/b-html5-1.3.1/b-print-1.3.1/r-2.1.1/sc-1.4.2/se-1.2.2/datatables.min.js""></script>
    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "dc5467ffb2fe8ade91c23d115ced657b5a6fb1e08329", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n\r\n    <title>AdminLTE 3 | Dashboard 3</title>\r\n    <meta name=\"viewport\" content=\"width=device-width, initial-scale=1\">\r\n    <!-- Font Awesome Icons -->\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "dc5467ffb2fe8ade91c23d115ced657b5a6fb1e09673", async() => {
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
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "dc5467ffb2fe8ade91c23d115ced657b5a6fb1e010851", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n    <link rel=\"stylesheet\"");
                BeginWriteAttribute("href", " href=\"", 1519, "\"", 1526, 0);
                EndWriteAttribute();
                WriteLiteral(">\r\n    <!-- IonIcons -->\r\n    <link rel=\"stylesheet\" href=\"http://code.ionicframework.com/ionicons/2.0.1/css/ionicons.min.css\">\r\n    <!-- Theme style -->\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "dc5467ffb2fe8ade91c23d115ced657b5a6fb1e012378", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
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
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "dc5467ffb2fe8ade91c23d115ced657b5a6fb1e014422", async() => {
                WriteLiteral("\r\n    <div class=\"container\">\r\n");
                WriteLiteral(@"        <!-- Trigger the modal with a button -->
        <br />



        <div class=""p-5 w-100 m-0"">
            

            <a href=""/Exam/Sınavlar"" style=""border: none;"" class=""btn btn-outline-dark btn-sm float-lg-right""><b>SINAVLAR</b></a>
        </div>
        <br />
        <br />
        
        <h4><b>Eğitimler</b></h4>
        <table id=""tbl1"" class=""table table-bordered"">
            <thead>
                <tr>
                    <th style=""font-size:11px;""><b>Eğitimin Adı</b></th>
                    <th style=""font-size:11px;""><b>Eğitim başlangıç tarihi</b></th>
                    <th style=""font-size:11px;""><b>Eğitim son tarihi</b></th>
                    <th style=""font-size:11px;""><b>Son başvuru tarihi</b></th>
                    <th style=""font-size:11px;""><b>Eğitimin kontenjan sayısı</b></th>
                    <th style=""font-size:11px;""><b>Toplam Eğitim saati</b></th>
                    <th></th>
                </tr>
            </thead>
            <!");
                WriteLiteral("--Model içindeki her item için döngü dönecek ve değerleri tabloya yazılacak-->\r\n");
#nullable restore
#line 68 "C:\Users\mel\Desktop\Eğitim-Proje\Proje\ProjeMvc\Views\Exam\GetAll.cshtml"
             foreach (var item in Model)
            {

#line default
#line hidden
#nullable disable
                WriteLiteral("        <tr>\r\n            <td style=\"font-size:11px;\"><br />");
#nullable restore
#line 71 "C:\Users\mel\Desktop\Eğitim-Proje\Proje\ProjeMvc\Views\Exam\GetAll.cshtml"
                                         Write(item.TrainingName);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n            <td style=\"font-size:11px;\"><br />");
#nullable restore
#line 72 "C:\Users\mel\Desktop\Eğitim-Proje\Proje\ProjeMvc\Views\Exam\GetAll.cshtml"
                                         Write(item.TrainingStartdate.ToString("dd.MM.yyyy"));

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n            <td style=\"font-size:11px;\"><br />");
#nullable restore
#line 73 "C:\Users\mel\Desktop\Eğitim-Proje\Proje\ProjeMvc\Views\Exam\GetAll.cshtml"
                                         Write(item.TrainingLastdate.ToString("dd.MM.yyyy"));

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n            <td style=\"font-size:11px;\"><br />");
#nullable restore
#line 74 "C:\Users\mel\Desktop\Eğitim-Proje\Proje\ProjeMvc\Views\Exam\GetAll.cshtml"
                                         Write(item.Trainingdate.ToString("dd.MM.yyyy"));

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n            <td style=\"font-size:11px;\"><br />");
#nullable restore
#line 75 "C:\Users\mel\Desktop\Eğitim-Proje\Proje\ProjeMvc\Views\Exam\GetAll.cshtml"
                                         Write(item.kota);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n            <td style=\"font-size:11px;\"><br />");
#nullable restore
#line 76 "C:\Users\mel\Desktop\Eğitim-Proje\Proje\ProjeMvc\Views\Exam\GetAll.cshtml"
                                         Write(item.TotalHours);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n            <td><button id=\"SınavEkle\" style=\"border: none;\" class=\"btn btn-outline-dark btn-sm\" title=\"SINAV EKLE\"");
                BeginWriteAttribute("onclick", " onclick=\"", 3795, "\"", 3834, 3);
                WriteAttributeValue("", 3805, "SınavEkle(\'", 3805, 11, true);
#nullable restore
#line 77 "C:\Users\mel\Desktop\Eğitim-Proje\Proje\ProjeMvc\Views\Exam\GetAll.cshtml"
WriteAttributeValue("", 3816, item.TrainingId, 3816, 16, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 3832, "\')", 3832, 2, true);
                EndWriteAttribute();
                WriteLiteral(">\r\n                <i class=\"nav-icon far fa-plus-square text-bg-dark\"></i></button></td>\r\n");
                WriteLiteral("        </tr>\r\n");
#nullable restore
#line 85 "C:\Users\mel\Desktop\Eğitim-Proje\Proje\ProjeMvc\Views\Exam\GetAll.cshtml"

            }

#line default
#line hidden
#nullable disable
                WriteLiteral(@"        </table>
    </div>

    <br />

    <br />
    <script>
        /*$('#tbl1').DataTable();*/

        $(document).ready(function () {
            $('#tbl1').DataTable({
                pageLength: 15,
                language: {
                    url: '//cdn.datatables.net/plug-ins/1.13.1/i18n/tr.json'
                }
            });
        });

        function SınavEkle(trainingId) {
            //var trainingId = document.getElementById('TrainingId').value;
            swal({
                title: ""Sınav ekle butonuna bastınız!"",
                text: ""Sınav eklemek istediğinizden emin misiniz?"",
                icon: ""warning"",
                button: true,
                dangerMode: true,

            }).then((result) => {
                if (result === true) {
                    $.ajax({
                        type: 'GET',
                        url: '/Exam/Add?trainingId=' + trainingId,
                        success: function (response) {
           ");
                WriteLiteral(@"                 if (response === '5') {
                                swal({
                                    title: ""Hata"",
                                    text: ""Sınav ekleme işleminiz başarısız! Eğitim bir derse sahip değil"",
                                    icon: ""error"",
                                }).then(() => {
                                    location.reload();

                                });
                            }
                            if (response === '2') {
                                swal({
                                    title: ""Hata"",
                                    text: ""Eğitim henüz bitmemiş!Sınav ekleyemezsiniz"",
                                    icon: ""error"",
                                }).then(() => {
                                    location.reload();

                                });
                            }
                            if (response === '200') {
                                swal({");
                WriteLiteral(@"
                                    title:""Başarılı"",
                                    text: ""Sınav ekleme işleminiz yapıldı!"",
                                    icon: ""success"",
                                }).then(() => {
                                    location.reload();

                                });
                            }
                        },
                    }).done(function (response) {

                    })
                }
            })
        }
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
            WriteLiteral("\r\n</html>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Training>> Html { get; private set; }
    }
}
#pragma warning restore 1591
