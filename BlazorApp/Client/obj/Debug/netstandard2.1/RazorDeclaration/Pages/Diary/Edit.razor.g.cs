#pragma checksum "C:\Users\ehsan\source\repos\BlazorApp\BlazorApp\Client\Pages\Diary\Edit.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1d0605a602b10733d3c7b07cd9c69b109ae24ef9"
// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace BlazorApp.Client.Pages.Diary
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
using BlazorApp.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\ehsan\source\repos\BlazorApp\BlazorApp\Client\Pages\Diary\Edit.razor"
using BlazorApp.Server.Models;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/diary/edit/{diaryId:int}")]
    public partial class Edit : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 10 "C:\Users\ehsan\source\repos\BlazorApp\BlazorApp\Client\Pages\Diary\Edit.razor"
 
    [Parameter]public int diaryId { get; set; }
    Diary diary = new Diary();
    protected async override Task OnParametersSetAsync()
    {
        diary = await http.GetFromJsonAsync<Diary>($"api/v1.0/diary/{diaryId}");
    }
    async Task EditDiary()
    {
        await http.PutAsJsonAsync("api/v1.0/diary/", diary);
        await js.InvokeVoidAsync("alert", "Updated successfully!");
        uriHepler.NavigateTo("diary");
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private JSRuntime js { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager uriHepler { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private HttpClient http { get; set; }
    }
}
#pragma warning restore 1591
