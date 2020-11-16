#pragma checksum "C:\Users\ehsan\source\repos\BlazorApp\BlazorApp\Client\Pages\Todo\Create.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1303874c3db3a5b18987754d983a74851b6e82bc"
// <auto-generated/>
#pragma warning disable 1591
namespace BlazorApp.Client.Pages.Todo
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\Users\ehsan\source\repos\BlazorApp\BlazorApp\Client\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\ehsan\source\repos\BlazorApp\BlazorApp\Client\_Imports.razor"
using System.Net.Http.Json;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\ehsan\source\repos\BlazorApp\BlazorApp\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\ehsan\source\repos\BlazorApp\BlazorApp\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\ehsan\source\repos\BlazorApp\BlazorApp\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\ehsan\source\repos\BlazorApp\BlazorApp\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.WebAssembly.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\ehsan\source\repos\BlazorApp\BlazorApp\Client\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\ehsan\source\repos\BlazorApp\BlazorApp\Client\_Imports.razor"
using BlazorApp.Client;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\ehsan\source\repos\BlazorApp\BlazorApp\Client\_Imports.razor"
using BlazorApp.Client.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\ehsan\source\repos\BlazorApp\BlazorApp\Client\_Imports.razor"
using BlazorApp.Shared.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\ehsan\source\repos\BlazorApp\BlazorApp\Client\Pages\Todo\Create.razor"
using Microsoft.AspNetCore.SignalR.Client;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/todo/create")]
    public partial class Create : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.AddMarkupContent(0, "<h3>Create</h3>\r\n");
            __builder.OpenComponent<BlazorApp.Client.Pages.Todo.Form>(1);
            __builder.AddAttribute(2, "ButtonText", "Create");
            __builder.AddAttribute(3, "todo", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<BlazorApp.Shared.Models.Todo>(
#nullable restore
#line 7 "C:\Users\ehsan\source\repos\BlazorApp\BlazorApp\Client\Pages\Todo\Create.razor"
                                 todo

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(4, "OnValidSubmit", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create(this, 
#nullable restore
#line 7 "C:\Users\ehsan\source\repos\BlazorApp\BlazorApp\Client\Pages\Todo\Create.razor"
                                                       CreateTodo

#line default
#line hidden
#nullable disable
            )));
            __builder.CloseComponent();
        }
        #pragma warning restore 1998
#nullable restore
#line 9 "C:\Users\ehsan\source\repos\BlazorApp\BlazorApp\Client\Pages\Todo\Create.razor"
       
    Todo todo = new Todo();

    private HubConnection hubConnection;


    protected override async Task OnInitializedAsync()
    {
        hubConnection = new HubConnectionBuilder()
        .WithUrl(nav.ToAbsoluteUri("/MainHub"))
        .Build();
        await hubConnection.StartAsync();
    }

    async Task CreateTodo()
    {
        await http.PostAsJsonAsync("api/v1.0/todo", todo);
        nav.NavigateTo("todo");
    }

    public async ValueTask Dispose()
    {
        await hubConnection.DisposeAsync();
    }


#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager nav { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private HttpClient http { get; set; }
    }
}
#pragma warning restore 1591
