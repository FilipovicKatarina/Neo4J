#pragma checksum "C:\Users\acer\Desktop\Neo4JProj\Neo4JProj\Views\PlesnaSkola\PrikaziPlesneSkole.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1ba2db3dbfb910ac8a2b76934f02e70e96c03c80"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_PlesnaSkola_PrikaziPlesneSkole), @"mvc.1.0.view", @"/Views/PlesnaSkola/PrikaziPlesneSkole.cshtml")]
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
#line 1 "C:\Users\acer\Desktop\Neo4JProj\Neo4JProj\Views\_ViewImports.cshtml"
using Neo4JProj;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\acer\Desktop\Neo4JProj\Neo4JProj\Views\_ViewImports.cshtml"
using Neo4JProj.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1ba2db3dbfb910ac8a2b76934f02e70e96c03c80", @"/Views/PlesnaSkola/PrikaziPlesneSkole.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ea0a0de1c5598bbe472e324d2632d7ea120014c9", @"/Views/_ViewImports.cshtml")]
    public class Views_PlesnaSkola_PrikaziPlesneSkole : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Neo4JProj.Models.PlesnaSkola>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\acer\Desktop\Neo4JProj\Neo4JProj\Views\PlesnaSkola\PrikaziPlesneSkole.cshtml"
  
    ViewData["Title"] = "PrikaziPlesneSkole";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<h1>Prikazi Plesne Skole</h1>

<br />
<br />

<table border=""2"" style=""background-color:lightpink;text-align:center"">
    <thead>
        <tr>
            <th width=""200"">Skola ID</th>
            <th width=""200"">Ime</th>
            <th width=""200"">Grad</th>
            <th width=""200"">Adresa</th>
            <th width=""200"">Email</th>
            <th width=""200"">Brj tel</th>

            <th width=""200"">Ocena</th>

        </tr>
    </thead>
    <tbody>
");
#nullable restore
#line 27 "C:\Users\acer\Desktop\Neo4JProj\Neo4JProj\Views\PlesnaSkola\PrikaziPlesneSkole.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n            <td>");
#nullable restore
#line 30 "C:\Users\acer\Desktop\Neo4JProj\Neo4JProj\Views\PlesnaSkola\PrikaziPlesneSkole.cshtml"
           Write(item.Idskole);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 31 "C:\Users\acer\Desktop\Neo4JProj\Neo4JProj\Views\PlesnaSkola\PrikaziPlesneSkole.cshtml"
           Write(item.Ime);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 32 "C:\Users\acer\Desktop\Neo4JProj\Neo4JProj\Views\PlesnaSkola\PrikaziPlesneSkole.cshtml"
           Write(item.Grad);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 33 "C:\Users\acer\Desktop\Neo4JProj\Neo4JProj\Views\PlesnaSkola\PrikaziPlesneSkole.cshtml"
           Write(item.Adresa);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 34 "C:\Users\acer\Desktop\Neo4JProj\Neo4JProj\Views\PlesnaSkola\PrikaziPlesneSkole.cshtml"
           Write(item.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 35 "C:\Users\acer\Desktop\Neo4JProj\Neo4JProj\Views\PlesnaSkola\PrikaziPlesneSkole.cshtml"
           Write(item.Brojtel);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 36 "C:\Users\acer\Desktop\Neo4JProj\Neo4JProj\Views\PlesnaSkola\PrikaziPlesneSkole.cshtml"
           Write(item.Ocena);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n\r\n\r\n            <td>\r\n            </td>\r\n\r\n\r\n        </tr>\r\n");
#nullable restore
#line 44 "C:\Users\acer\Desktop\Neo4JProj\Neo4JProj\Views\PlesnaSkola\PrikaziPlesneSkole.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Neo4JProj.Models.PlesnaSkola>> Html { get; private set; }
    }
}
#pragma warning restore 1591
