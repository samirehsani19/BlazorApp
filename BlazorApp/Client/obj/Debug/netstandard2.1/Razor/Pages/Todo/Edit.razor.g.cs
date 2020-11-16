#pragma checksum "C:\Users\ehsan\source\repos\BlazorApp\BlazorApp\Client\Pages\Todo\Edit.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "06c29c51dd4e851c2bc3d4df7ad5de194dda6bc4"
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
#line 5 "C:\Users\ehsan\source\repos\BlazorApp\BlazorApp\Client\Pages\Todo\Edit.razor"
using Microsoft.AspNetCore.SignalR.Client;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/todo/edit/{todoId:int}")]
    public partial class Edit : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.AddMarkupContent(0, "<h3>Edit</h3>\r\n");
            __builder.OpenComponent<BlazorApp.Client.Pages.Todo.Form>(1);
            __builder.AddAttribute(2, "ButtonText", "Update");
            __builder.AddAttribute(3, "todo", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<BlazorApp.Shared.Models.Todo>(
#nullable restore
#line 7 "C:\Users\ehsan\source\repos\BlazorApp\BlazorApp\Client\Pages\Todo\Edit.razor"
                                todo

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(4, "OnValidSubmit", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create(this, 
#nullable restore
#line 7 "C:\Users\ehsan\source\repos\BlazorApp\BlazorApp\Client\Pages\Todo\Edit.razor"
                                                      EditTodo

#line default
#line hidden
#nullable disable
            )));
            __builder.CloseComponent();
        }
        #pragma warning restore 1998
#nullable restore
#line 9 "C:\Users\ehsan\source\repos\BlazorApp\BlazorApp\Client\Pages\Todo\Edit.razor"
       
    [Parameter] public int todoId { get; set; }
    Todo todo = new Todo();
    private HubConnection hubConnection;


    protected override async Task OnInitializedAsync()
    {
        todo = await http.GetFromJsonAsync<Todo>($"api/v1.0/todo/{todoId}");

        hubConnection = new HubConnectionBuilder()
        .WithUrl(nav.ToAbsoluteUri("/MainHub"))
        .Build();
        await hubConnection.StartAsync();
    }

   // public bool IsConnected => hubConnection.State == HubConnectionState.Connected;

    public async Task EditTodo()
    {
        nav.NavigateTo("todo");
        await http.PutAsJsonAsync($"api/v1.0/todo", todo);
        //if (IsConnected) await SendMessage();
    }

    //Task SendMessage() => hubConnection.SendAsync("SendMessage");


    public async ValueTask Dispose()
    {
        await hubConnection.DisposeAsync();
    }




    //protected async override Task OnParametersSetAsync()
    //{
    //    todo = await http.GetFromJsonAsync<Todo>($"api/v1.0/todo/{todoId}");
    //}
    //async Task EditTodo()
    //{
    //    await http.PutAsJsonAsync($"api/v1.0/todo", todo);
    //    await js.InvokeVoidAsync("alert", $"Updated Successfully!");
    //    uriHelper.NavigateTo("todo");
    //}

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IJSRuntime js { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager nav { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private HttpClient http { get; set; }
    }
}
#pragma warning restore 1591
