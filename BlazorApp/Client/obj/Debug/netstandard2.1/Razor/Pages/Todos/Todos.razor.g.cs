#pragma checksum "C:\Users\seh\source\repos\BlazorApp\BlazorApp\Client\Pages\Todos\Todos.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1f51bfb564085c0325342fae2cd9eb0738e951b1"
// <auto-generated/>
#pragma warning disable 1591
namespace BlazorApp.Client.Pages.Todos
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\Users\seh\source\repos\BlazorApp\BlazorApp\Client\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\seh\source\repos\BlazorApp\BlazorApp\Client\_Imports.razor"
using System.Net.Http.Json;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\seh\source\repos\BlazorApp\BlazorApp\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\seh\source\repos\BlazorApp\BlazorApp\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\seh\source\repos\BlazorApp\BlazorApp\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\seh\source\repos\BlazorApp\BlazorApp\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.WebAssembly.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\seh\source\repos\BlazorApp\BlazorApp\Client\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\seh\source\repos\BlazorApp\BlazorApp\Client\_Imports.razor"
using BlazorApp.Client;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\seh\source\repos\BlazorApp\BlazorApp\Client\_Imports.razor"
using BlazorApp.Client.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\seh\source\repos\BlazorApp\BlazorApp\Client\_Imports.razor"
using BlazorApp.Shared.Models;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/todo")]
    public partial class Todos : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.AddMarkupContent(0, "<h3>Todo</h3>\r\n");
            __builder.AddMarkupContent(1, "<small>Add thing to todo list.</small>\r\n");
            __builder.AddMarkupContent(2, "<div class=\"form-group\"><a class=\"btn btn-success\" href=\"Todo/create\"><i class=\"oi oi-plus\"></i> Create New</a></div>\r\n<br>");
#nullable restore
#line 8 "C:\Users\seh\source\repos\BlazorApp\BlazorApp\Client\Pages\Todos\Todos.razor"
 if (todos == null)
{
    

#line default
#line hidden
#nullable disable
            __builder.AddContent(3, "Loading todos... ");
#nullable restore
#line 10 "C:\Users\seh\source\repos\BlazorApp\BlazorApp\Client\Pages\Todos\Todos.razor"
                                  
}
else if (todos.Length == 0)
{
    

#line default
#line hidden
#nullable disable
            __builder.AddContent(4, "No Records Found.");
#nullable restore
#line 14 "C:\Users\seh\source\repos\BlazorApp\BlazorApp\Client\Pages\Todos\Todos.razor"
                                  
}
else
{

#line default
#line hidden
#nullable disable
            __builder.OpenElement(5, "table");
            __builder.AddAttribute(6, "class", "table table-striped");
            __builder.AddMarkupContent(7, "<thead><tr><th>Id</th>\r\n                <th>Date</th>\r\n                <th>Title</th>\r\n                <th>Description</th>\r\n                <th></th></tr></thead>\r\n        ");
            __builder.OpenElement(8, "tbody");
#nullable restore
#line 29 "C:\Users\seh\source\repos\BlazorApp\BlazorApp\Client\Pages\Todos\Todos.razor"
             foreach (var item in todos)
            {

#line default
#line hidden
#nullable disable
            __builder.OpenElement(9, "tr");
            __builder.OpenElement(10, "td");
            __builder.AddContent(11, 
#nullable restore
#line 32 "C:\Users\seh\source\repos\BlazorApp\BlazorApp\Client\Pages\Todos\Todos.razor"
                         item.TodoID

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(12, "\r\n                    ");
            __builder.OpenElement(13, "td");
            __builder.AddContent(14, 
#nullable restore
#line 33 "C:\Users\seh\source\repos\BlazorApp\BlazorApp\Client\Pages\Todos\Todos.razor"
                         item.Date

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(15, "\r\n                    ");
            __builder.OpenElement(16, "td");
            __builder.AddContent(17, 
#nullable restore
#line 34 "C:\Users\seh\source\repos\BlazorApp\BlazorApp\Client\Pages\Todos\Todos.razor"
                         item.Title

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(18, "\r\n                    ");
            __builder.OpenElement(19, "td");
            __builder.AddContent(20, 
#nullable restore
#line 35 "C:\Users\seh\source\repos\BlazorApp\BlazorApp\Client\Pages\Todos\Todos.razor"
                         item.Description

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(21, "\r\n                    ");
            __builder.OpenElement(22, "td");
            __builder.OpenElement(23, "a");
            __builder.AddAttribute(24, "class", "btn btn-success");
            __builder.AddAttribute(25, "href", "todo/edit/" + (
#nullable restore
#line 37 "C:\Users\seh\source\repos\BlazorApp\BlazorApp\Client\Pages\Todos\Todos.razor"
                                                                    item.TodoID

#line default
#line hidden
#nullable disable
            ));
            __builder.AddContent(26, "Edit");
            __builder.CloseElement();
            __builder.AddMarkupContent(27, "\r\n                        ");
            __builder.OpenElement(28, "button");
            __builder.AddAttribute(29, "class", "btn btn-danger");
            __builder.AddAttribute(30, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 38 "C:\Users\seh\source\repos\BlazorApp\BlazorApp\Client\Pages\Todos\Todos.razor"
                                                                   () => Delete(item.TodoID)

#line default
#line hidden
#nullable disable
            ));
            __builder.AddContent(31, "Delete");
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
#nullable restore
#line 41 "C:\Users\seh\source\repos\BlazorApp\BlazorApp\Client\Pages\Todos\Todos.razor"
            }

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.CloseElement();
#nullable restore
#line 44 "C:\Users\seh\source\repos\BlazorApp\BlazorApp\Client\Pages\Todos\Todos.razor"
}

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
    }
}
#pragma warning restore 1591
