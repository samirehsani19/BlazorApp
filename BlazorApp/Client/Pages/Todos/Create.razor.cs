using BlazorApp.Client.ToastService;
using BlazorApp.Shared.Models;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BlazorApp.Client.Pages.Todos
{
    public partial class Create
    {
        [Inject] NavigationManager Nav { get; set; }
        [Inject] HttpClient Client { get; set; }
        [Inject] ToastService.ToastService ToastService { get; set; }
        BlazorApp.Shared.Models.Todo todo = new BlazorApp.Shared.Models.Todo();

        [Inject] Blazored.LocalStorage.ILocalStorageService localStorage { get; set; }
        
        async Task CreateTodo()
        {
            var result = await Client.PostAsJsonAsync("api/v1.0/todo", todo);
            if (result.IsSuccessStatusCode)
            {
                ToastService.ShowToast("Saved successfully", ToastLevel.Success);
            }
            else
            {
                ToastService.ShowToast("Failed to save", ToastLevel.Error);
            }
            Nav.NavigateTo("todo");
        }
    }
}
