using Microsoft.AspNetCore.Components;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BlazorApp.Client.Pages.Todos
{
    public partial class Edit
    {
        [Parameter] public int todoId { get; set; }
        [Inject] NavigationManager Nav { get; set; }
        [Inject] HttpClient Client { get; set; }
        BlazorApp.Shared.Models.Todo todo = new BlazorApp.Shared.Models.Todo();

        protected override async Task OnInitializedAsync()
        {
            todo = await Client.GetFromJsonAsync<BlazorApp.Shared.Models.Todo>($"api/v1.0/todo/{todoId}");

        }

        public async Task EditTodo()
        {
            Nav.NavigateTo("todo");
            await Client.PutAsJsonAsync($"api/v1.0/todo", todo);
        }

    }
}
