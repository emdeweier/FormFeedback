#pragma checksum "B:\Bootcamp #33\FormFeedbackProject\FormFeedback\FormFeedback\Views\Shared\Error.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "fe6b0a7dfc1f6589f7951361158d799f1079575e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Error), @"mvc.1.0.view", @"/Views/Shared/Error.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/Error.cshtml", typeof(AspNetCore.Views_Shared_Error))]
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
#line 1 "B:\Bootcamp #33\FormFeedbackProject\FormFeedback\FormFeedback\Views\_ViewImports.cshtml"
using FormFeedback;

#line default
#line hidden
#line 2 "B:\Bootcamp #33\FormFeedbackProject\FormFeedback\FormFeedback\Views\_ViewImports.cshtml"
using FormFeedback.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fe6b0a7dfc1f6589f7951361158d799f1079575e", @"/Views/Shared/Error.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2dcc7b9b956d1f0c8aeb9a6952ef06befdfa1e6a", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Error : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ErrorViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "B:\Bootcamp #33\FormFeedbackProject\FormFeedback\FormFeedback\Views\Shared\Error.cshtml"
  
    ViewData["Title"] = "Error";

#line default
#line hidden
            BeginContext(64, 193, true);
            WriteLiteral("\r\n<section class=\"content\">\r\n    <div class=\"error-page\">\r\n        <h1 class=\"text-danger\">Error.</h1>\r\n        <h2 class=\"text-danger\">An error occurred while processing your request.</h2>\r\n\r\n");
            EndContext();
#line 11 "B:\Bootcamp #33\FormFeedbackProject\FormFeedback\FormFeedback\Views\Shared\Error.cshtml"
         if (Model.ShowRequestId)
        {

#line default
#line hidden
            BeginContext(303, 68, true);
            WriteLiteral("            <p>\r\n                <strong>Request ID:</strong> <code>");
            EndContext();
            BeginContext(372, 15, false);
#line 14 "B:\Bootcamp #33\FormFeedbackProject\FormFeedback\FormFeedback\Views\Shared\Error.cshtml"
                                              Write(Model.RequestId);

#line default
#line hidden
            EndContext();
            BeginContext(387, 27, true);
            WriteLiteral("</code>\r\n            </p>\r\n");
            EndContext();
#line 16 "B:\Bootcamp #33\FormFeedbackProject\FormFeedback\FormFeedback\Views\Shared\Error.cshtml"
        }

#line default
#line hidden
            BeginContext(425, 667, true);
            WriteLiteral(@"
        <h3>Development Mode</h3>
        <p>
            Swapping to <strong>Development</strong> environment will display more detailed information about the error that occurred.
        </p>
        <p>
            <strong>Development environment should not be enabled in deployed applications</strong>, as it can result in sensitive information from exceptions being displayed to end users. For local debugging, development environment can be enabled by setting the <strong>ASPNETCORE_ENVIRONMENT</strong> environment variable to <strong>Development</strong>, and restarting the application.
        </p>
    </div>
    <!-- /.error-page -->
</section>");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ErrorViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
