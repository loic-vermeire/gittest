#pragma checksum "D:\KdG\2018-2019\Programmeren 2 .NET Framework\Projecten\SupportCenter\UI-MVC\Views\Ticket\_TicketDetailsPartial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7cfaa8376f8cf8af3d7cd07e5fe5935768e758a3"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Ticket__TicketDetailsPartial), @"mvc.1.0.view", @"/Views/Ticket/_TicketDetailsPartial.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Ticket/_TicketDetailsPartial.cshtml", typeof(AspNetCore.Views_Ticket__TicketDetailsPartial))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7cfaa8376f8cf8af3d7cd07e5fe5935768e758a3", @"/Views/Ticket/_TicketDetailsPartial.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"23ac09be4bcfaa7f9829a01d1a134874eaae1f3b", @"/Views/_ViewImports.cshtml")]
    public class Views_Ticket__TicketDetailsPartial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 47, true);
            WriteLiteral("<dl class=\"dl-horizontal\">\r\n    <dt>Id</dt><dd>");
            EndContext();
            BeginContext(48, 18, false);
#line 2 "D:\KdG\2018-2019\Programmeren 2 .NET Framework\Projecten\SupportCenter\UI-MVC\Views\Ticket\_TicketDetailsPartial.cshtml"
              Write(Model.TicketNumber);

#line default
#line hidden
            EndContext();
            BeginContext(66, 31, true);
            WriteLiteral("</dd>\r\n    <dt>Account</dt><dd>");
            EndContext();
            BeginContext(98, 15, false);
#line 3 "D:\KdG\2018-2019\Programmeren 2 .NET Framework\Projecten\SupportCenter\UI-MVC\Views\Ticket\_TicketDetailsPartial.cshtml"
                   Write(Model.AccountID);

#line default
#line hidden
            EndContext();
            BeginContext(113, 32, true);
            WriteLiteral("</dd>\r\n    <dt>Probleem</dt><dd>");
            EndContext();
            BeginContext(146, 10, false);
#line 4 "D:\KdG\2018-2019\Programmeren 2 .NET Framework\Projecten\SupportCenter\UI-MVC\Views\Ticket\_TicketDetailsPartial.cshtml"
                    Write(Model.Text);

#line default
#line hidden
            EndContext();
            BeginContext(156, 37, true);
            WriteLiteral("</dd>\r\n    <dt>Aangemaakt op</dt><dd>");
            EndContext();
            BeginContext(194, 16, false);
#line 5 "D:\KdG\2018-2019\Programmeren 2 .NET Framework\Projecten\SupportCenter\UI-MVC\Views\Ticket\_TicketDetailsPartial.cshtml"
                         Write(Model.DateOpened);

#line default
#line hidden
            EndContext();
            BeginContext(210, 63, true);
            WriteLiteral("</dd>\r\n    <dt>Status</dt>\r\n    <dd>\r\n        <span id=\"state\">");
            EndContext();
            BeginContext(274, 11, false);
#line 8 "D:\KdG\2018-2019\Programmeren 2 .NET Framework\Projecten\SupportCenter\UI-MVC\Views\Ticket\_TicketDetailsPartial.cshtml"
                    Write(Model.State);

#line default
#line hidden
            EndContext();
            BeginContext(285, 9, true);
            WriteLiteral("</span>\r\n");
            EndContext();
#line 9 "D:\KdG\2018-2019\Programmeren 2 .NET Framework\Projecten\SupportCenter\UI-MVC\Views\Ticket\_TicketDetailsPartial.cshtml"
         if (Model.State != SC.BL.Domain.TicketState.Closed)
        {

#line default
#line hidden
            BeginContext(367, 57, true);
            WriteLiteral("            <button type=\"button\" class=\"btn btn-default\"");
            EndContext();
            BeginWriteAttribute("onclick", " onclick=\"", 424, "\"", 466, 3);
            WriteAttributeValue("", 434, "closeTicket(", 434, 12, true);
#line 11 "D:\KdG\2018-2019\Programmeren 2 .NET Framework\Projecten\SupportCenter\UI-MVC\Views\Ticket\_TicketDetailsPartial.cshtml"
WriteAttributeValue("", 446, Model.TicketNumber, 446, 19, false);

#line default
#line hidden
            WriteAttributeValue("", 465, ")", 465, 1, true);
            EndWriteAttribute();
            BeginContext(467, 17, true);
            WriteLiteral(">Close</button>\r\n");
            EndContext();
#line 12 "D:\KdG\2018-2019\Programmeren 2 .NET Framework\Projecten\SupportCenter\UI-MVC\Views\Ticket\_TicketDetailsPartial.cshtml"
        }        

#line default
#line hidden
            BeginContext(503, 332, true);
            WriteLiteral(@"    </dd>
</dl>

<script type=""text/javascript"">
    function closeTicket(ticketNumber) {
        $.ajax('/api/Tickets/' + ticketNumber + '/State/Closed',{type: 'PUT'})
            .done(function() { $('#state').html('Closed'); })
            .fail(function() { alert(""Oops, something went wrong!""); });
    }
</script>

");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
