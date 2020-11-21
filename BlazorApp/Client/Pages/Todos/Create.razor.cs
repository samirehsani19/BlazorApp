using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.SignalR.Client;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BlazorApp.Client.Pages.Todos
{
    public partial class Create
    {
        [Inject] NavigationManager Nav { get; set; }
        [Inject] HttpClient Client { get; set; }
        BlazorApp.Shared.Models.Todo todo = new BlazorApp.Shared.Models.Todo();

        async Task CreateTodo()
        {
            await Client.PostAsJsonAsync("api/v1.0/todo", todo);
            Nav.NavigateTo("todo");
        }


    }
}
