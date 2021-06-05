#pragma checksum "C:\Dex\Random.Questions\Random.Questions\Views\Home\Quiz.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "61593a34701af3142ed7bf65264cc8a6ced1e9b3"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Quiz), @"mvc.1.0.view", @"/Views/Home/Quiz.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Dex\Random.Questions\Random.Questions\Views\_ViewImports.cshtml"
using Project.Random.Questions;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Dex\Random.Questions\Random.Questions\Views\_ViewImports.cshtml"
using Project.Random.Questions.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Dex\Random.Questions\Random.Questions\Views\Home\Quiz.cshtml"
using System.Linq;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"61593a34701af3142ed7bf65264cc8a6ced1e9b3", @"/Views/Home/Quiz.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7776e20964186aa2fd9c9540e25886711f17260c", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Quiz : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Quiz>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 4 "C:\Dex\Random.Questions\Random.Questions\Views\Home\Quiz.cshtml"
  
    ViewData["Title"] = Model.Name;
    int count = 0;
    List<Reply> replies = ViewBag.replies;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h2>\r\n    ");
#nullable restore
#line 11 "C:\Dex\Random.Questions\Random.Questions\Views\Home\Quiz.cshtml"
Write(Model.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 12 "C:\Dex\Random.Questions\Random.Questions\Views\Home\Quiz.cshtml"
     if (replies.Any())
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <span class=\"badge badge-primary badge-pill\" style=\"float: right;\">");
#nullable restore
#line 14 "C:\Dex\Random.Questions\Random.Questions\Views\Home\Quiz.cshtml"
                                                                       Write(replies.Count(x=>x.Alternative.IsCorrect));

#line default
#line hidden
#nullable disable
            WriteLiteral("/");
#nullable restore
#line 14 "C:\Dex\Random.Questions\Random.Questions\Views\Home\Quiz.cshtml"
                                                                                                                    Write(Model.Questions.Count());

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n");
#nullable restore
#line 15 "C:\Dex\Random.Questions\Random.Questions\Views\Home\Quiz.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n<br />\r\n");
#nullable restore
#line 18 "C:\Dex\Random.Questions\Random.Questions\Views\Home\Quiz.cshtml"
 if (replies.Any())
{
    foreach (var question in Model.Questions)
    {
        count++;

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"card\">\r\n            <h5 class=\"card-header\">Question ");
#nullable restore
#line 24 "C:\Dex\Random.Questions\Random.Questions\Views\Home\Quiz.cshtml"
                                         Write(count);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n            <div class=\"card-body\">\r\n                <h5 class=\"card-title\">");
#nullable restore
#line 26 "C:\Dex\Random.Questions\Random.Questions\Views\Home\Quiz.cshtml"
                                   Write(question.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n                <br />\r\n                <ul class=\"list-group list-group-flush\">\r\n\r\n");
#nullable restore
#line 30 "C:\Dex\Random.Questions\Random.Questions\Views\Home\Quiz.cshtml"
                     foreach (var alternative in question.Alternatives)
                    {
                        var reply = replies.FirstOrDefault(x => alternative.IdAlternative == x.IdAlternative);


#line default
#line hidden
#nullable disable
            WriteLiteral("                        <li class=\"list-group-item\">\r\n                            <div class=\"form-check\">\r\n                                <input class=\"form-check-input\" type=\"radio\"");
            BeginWriteAttribute("name", " name=\"", 1145, "\"", 1177, 1);
#nullable restore
#line 36 "C:\Dex\Random.Questions\Random.Questions\Views\Home\Quiz.cshtml"
WriteAttributeValue("", 1152, alternative.IdQuestion, 1152, 25, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("id", " id=\"", 1178, "\"", 1213, 2);
            WriteAttributeValue("", 1183, "Id", 1183, 2, true);
#nullable restore
#line 36 "C:\Dex\Random.Questions\Random.Questions\Views\Home\Quiz.cshtml"
WriteAttributeValue("", 1185, alternative.IdAlternative, 1185, 28, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("value", " value=\"", 1214, "\"", 1250, 1);
#nullable restore
#line 36 "C:\Dex\Random.Questions\Random.Questions\Views\Home\Quiz.cshtml"
WriteAttributeValue("", 1222, alternative.IdAlternative, 1222, 28, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" disabled ");
#nullable restore
#line 36 "C:\Dex\Random.Questions\Random.Questions\Views\Home\Quiz.cshtml"
                                                                                                                                                                                            Write(reply != null ? "checked" : "");

#line default
#line hidden
#nullable disable
            WriteLiteral(">\r\n                                <label class=\"form-check-label\"");
            BeginWriteAttribute("for", " for=\"", 1360, "\"", 1396, 2);
            WriteAttributeValue("", 1366, "Id", 1366, 2, true);
#nullable restore
#line 37 "C:\Dex\Random.Questions\Random.Questions\Views\Home\Quiz.cshtml"
WriteAttributeValue("", 1368, alternative.IdAlternative, 1368, 28, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                                    ");
#nullable restore
#line 38 "C:\Dex\Random.Questions\Random.Questions\Views\Home\Quiz.cshtml"
                                Write(alternative.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </label>\r\n");
#nullable restore
#line 40 "C:\Dex\Random.Questions\Random.Questions\Views\Home\Quiz.cshtml"
                                 if (alternative.IsCorrect)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <span class=\"badge badge-success badge-pill\" style=\"float: right;\">Correct</span>\r\n");
#nullable restore
#line 43 "C:\Dex\Random.Questions\Random.Questions\Views\Home\Quiz.cshtml"
                                }
                                else if (reply != null)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <span class=\"badge badge-danger badge-pill\" style=\"float: right;\">Wrong</span>\r\n");
#nullable restore
#line 47 "C:\Dex\Random.Questions\Random.Questions\Views\Home\Quiz.cshtml"
                                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                            </div>\r\n                        </li>\r\n");
#nullable restore
#line 50 "C:\Dex\Random.Questions\Random.Questions\Views\Home\Quiz.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </ul>\r\n            </div>\r\n        </div>\r\n        <br />\r\n");
#nullable restore
#line 55 "C:\Dex\Random.Questions\Random.Questions\Views\Home\Quiz.cshtml"
    }
}
else
{
    foreach (var question in Model.Questions)
    {
        count++;

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"card\">\r\n            <h5 class=\"card-header\">Question ");
#nullable restore
#line 63 "C:\Dex\Random.Questions\Random.Questions\Views\Home\Quiz.cshtml"
                                         Write(count);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n            <div class=\"card-body\">\r\n                <h5 class=\"card-title\">");
#nullable restore
#line 65 "C:\Dex\Random.Questions\Random.Questions\Views\Home\Quiz.cshtml"
                                   Write(question.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n                <br />\r\n                <ul class=\"list-group list-group-flush\">\r\n\r\n");
#nullable restore
#line 69 "C:\Dex\Random.Questions\Random.Questions\Views\Home\Quiz.cshtml"
                     foreach (var alternative in question.Alternatives)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <li class=\"list-group-item\">\r\n                            <div class=\"form-check\">\r\n                                <input class=\"form-check-input\" type=\"radio\"");
            BeginWriteAttribute("name", " name=\"", 2813, "\"", 2845, 1);
#nullable restore
#line 73 "C:\Dex\Random.Questions\Random.Questions\Views\Home\Quiz.cshtml"
WriteAttributeValue("", 2820, alternative.IdQuestion, 2820, 25, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("id", " id=\"", 2846, "\"", 2881, 2);
            WriteAttributeValue("", 2851, "Id", 2851, 2, true);
#nullable restore
#line 73 "C:\Dex\Random.Questions\Random.Questions\Views\Home\Quiz.cshtml"
WriteAttributeValue("", 2853, alternative.IdAlternative, 2853, 28, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("value", " value=\"", 2882, "\"", 2918, 1);
#nullable restore
#line 73 "C:\Dex\Random.Questions\Random.Questions\Views\Home\Quiz.cshtml"
WriteAttributeValue("", 2890, alternative.IdAlternative, 2890, 28, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                                <label class=\"form-check-label\"");
            BeginWriteAttribute("for", " for=\"", 2985, "\"", 3021, 2);
            WriteAttributeValue("", 2991, "Id", 2991, 2, true);
#nullable restore
#line 74 "C:\Dex\Random.Questions\Random.Questions\Views\Home\Quiz.cshtml"
WriteAttributeValue("", 2993, alternative.IdAlternative, 2993, 28, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                                    ");
#nullable restore
#line 75 "C:\Dex\Random.Questions\Random.Questions\Views\Home\Quiz.cshtml"
                                Write(alternative.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </label>\r\n                            </div>\r\n                        </li>\r\n");
#nullable restore
#line 79 "C:\Dex\Random.Questions\Random.Questions\Views\Home\Quiz.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </ul>\r\n            </div>\r\n        </div>\r\n        <br />\r\n");
#nullable restore
#line 84 "C:\Dex\Random.Questions\Random.Questions\Views\Home\Quiz.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"form-group\">\r\n        <input type=\"button\" value=\"Submit\" class=\"btn btn-primary\" onclick=\"submitAlternatives()\" />\r\n    </div>\r\n");
            WriteLiteral("    <script src=\"//cdn.jsdelivr.net/npm/sweetalert2@11\"></script>\r\n    <script>\r\n        window.IdsQuestions = ");
#nullable restore
#line 91 "C:\Dex\Random.Questions\Random.Questions\Views\Home\Quiz.cshtml"
                         Write(Json.Serialize(Model.Questions.Select(x => x.IdQuestion)));

#line default
#line hidden
#nullable disable
            WriteLiteral(@";

        function submitAlternatives() {

            for (var i = 0; i < window.IdsQuestions.length; i++) {
                var value = $('input[name=""' + window.IdsQuestions[i] + '""]:checked').val();
                if (!value) {
                    Swal.fire({
                        icon: 'error',
                        title: 'Oops...',
                        text: 'Please answer all questions!'
                    });
                    return;
                }
            }

            Swal.fire({
                title: 'Are you sure?',
                text: ""You won't be able to revert this!"",
                icon: 'warning',
                showCancelButton: true,
                confirmButtonColor: '#3085d6',
                cancelButtonColor: '#d33',
                confirmButtonText: 'Yes, submit it!'
            }).then((result) => {
                if (result.isConfirmed) {
                    var data = {
                        'idsAlternatives': $.map($('inpu");
            WriteLiteral("t[type=\"radio\"]:checked\'),\r\n                            function(n) {\r\n                                return n.value;\r\n                            })\r\n                    }\r\n\r\n                    $.post(\"");
#nullable restore
#line 124 "C:\Dex\Random.Questions\Random.Questions\Views\Home\Quiz.cshtml"
                        Write(Url.Action("New", "Replies"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@""",
                        data,
                        function(resp) {
                            Swal.fire(
                                'Submitted!',
                                'Questionnaire sent.',
                                'success'
                            ).then(() => {
                                location.reload();
                            });
                        }
                    );
                }
            });
        }
    </script>
");
#nullable restore
#line 140 "C:\Dex\Random.Questions\Random.Questions\Views\Home\Quiz.cshtml"
}

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Quiz> Html { get; private set; }
    }
}
#pragma warning restore 1591
