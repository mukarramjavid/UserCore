#pragma checksum "E:\Angular_Projects\_coreUSer - Copy\UserLive\Views\Shared\_ListView.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d04f955308fd5bb57ce662df0edbe22094846cc7"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__ListView), @"mvc.1.0.view", @"/Views/Shared/_ListView.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/_ListView.cshtml", typeof(AspNetCore.Views_Shared__ListView))]
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
#line 1 "E:\Angular_Projects\_coreUSer - Copy\UserLive\Views\_ViewImports.cshtml"
using UserLive;

#line default
#line hidden
#line 2 "E:\Angular_Projects\_coreUSer - Copy\UserLive\Views\_ViewImports.cshtml"
using UserLive.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d04f955308fd5bb57ce662df0edbe22094846cc7", @"/Views/Shared/_ListView.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fc3a3262aaca43f72383e090e6438ed720a4e2bd", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__ListView : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<UserLive.Models.UserViewModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(51, 6, true);
            WriteLiteral("\r\n\r\n\r\n");
            EndContext();
#line 5 "E:\Angular_Projects\_coreUSer - Copy\UserLive\Views\Shared\_ListView.cshtml"
 foreach (var item in Model) {

#line default
#line hidden
            BeginContext(89, 48, true);
            WriteLiteral("        <tr>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(138, 42, false);
#line 8 "E:\Angular_Projects\_coreUSer - Copy\UserLive\Views\Shared\_ListView.cshtml"
           Write(Html.DisplayFor(modelItem => item.user_id));

#line default
#line hidden
            EndContext();
            BeginContext(180, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(236, 44, false);
#line 11 "E:\Angular_Projects\_coreUSer - Copy\UserLive\Views\Shared\_ListView.cshtml"
           Write(Html.DisplayFor(modelItem => item.user_name));

#line default
#line hidden
            EndContext();
            BeginContext(280, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(336, 45, false);
#line 14 "E:\Angular_Projects\_coreUSer - Copy\UserLive\Views\Shared\_ListView.cshtml"
           Write(Html.DisplayFor(modelItem => item.user_email));

#line default
#line hidden
            EndContext();
            BeginContext(381, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(437, 43, false);
#line 17 "E:\Angular_Projects\_coreUSer - Copy\UserLive\Views\Shared\_ListView.cshtml"
           Write(Html.DisplayFor(modelItem => item.user_pwd));

#line default
#line hidden
            EndContext();
            BeginContext(480, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(536, 45, false);
#line 20 "E:\Angular_Projects\_coreUSer - Copy\UserLive\Views\Shared\_ListView.cshtml"
           Write(Html.DisplayFor(modelItem => item.user_phone));

#line default
#line hidden
            EndContext();
            BeginContext(581, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(637, 43, false);
#line 23 "E:\Angular_Projects\_coreUSer - Copy\UserLive\Views\Shared\_ListView.cshtml"
           Write(Html.DisplayFor(modelItem => item.user_age));

#line default
#line hidden
            EndContext();
            BeginContext(680, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(736, 40, false);
#line 26 "E:\Angular_Projects\_coreUSer - Copy\UserLive\Views\Shared\_ListView.cshtml"
           Write(Html.DisplayFor(modelItem => item.addID));

#line default
#line hidden
            EndContext();
            BeginContext(776, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(832, 43, false);
#line 29 "E:\Angular_Projects\_coreUSer - Copy\UserLive\Views\Shared\_ListView.cshtml"
           Write(Html.DisplayFor(modelItem => item.cityName));

#line default
#line hidden
            EndContext();
            BeginContext(875, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(931, 47, false);
#line 32 "E:\Angular_Projects\_coreUSer - Copy\UserLive\Views\Shared\_ListView.cshtml"
           Write(Html.DisplayFor(modelItem => item.ImagePathUvm));

#line default
#line hidden
            EndContext();
            BeginContext(978, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1034, 65, false);
#line 35 "E:\Angular_Projects\_coreUSer - Copy\UserLive\Views\Shared\_ListView.cshtml"
           Write(Html.ActionLink("Edit", "Edit", new { /* id=item.PrimaryKey */ }));

#line default
#line hidden
            EndContext();
            BeginContext(1099, 20, true);
            WriteLiteral(" |\r\n                ");
            EndContext();
            BeginContext(1120, 71, false);
#line 36 "E:\Angular_Projects\_coreUSer - Copy\UserLive\Views\Shared\_ListView.cshtml"
           Write(Html.ActionLink("Details", "Details", new { /* id=item.PrimaryKey */ }));

#line default
#line hidden
            EndContext();
            BeginContext(1191, 20, true);
            WriteLiteral(" |\r\n                ");
            EndContext();
            BeginContext(1212, 69, false);
#line 37 "E:\Angular_Projects\_coreUSer - Copy\UserLive\Views\Shared\_ListView.cshtml"
           Write(Html.ActionLink("Delete", "Delete", new { /* id=item.PrimaryKey */ }));

#line default
#line hidden
            EndContext();
            BeginContext(1281, 36, true);
            WriteLiteral("\r\n            </td>\r\n        </tr>\r\n");
            EndContext();
#line 40 "E:\Angular_Projects\_coreUSer - Copy\UserLive\Views\Shared\_ListView.cshtml"
}

#line default
#line hidden
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<UserLive.Models.UserViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
