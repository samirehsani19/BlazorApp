using BlazorApp.Client.ToastService;
using Microsoft.AspNetCore.Components;
using System.Net;
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
        [Inject] ToastService.ToastService ToastService { get; set; }
        BlazorApp.Shared.Models.Todo todo = new BlazorApp.Shared.Models.Todo();

        protected override async Task OnInitializedAsync()
        {
            todo = await Client.GetFromJsonAsync<BlazorApp.Shared.Models.Todo>($"api/v1.0/todo/{todoId}");

        }

        public async Task EditTodo()
        {
            var result = await Client.PutAsJsonAsync($"api/v1.0/todo", todo);
            if (result.StatusCode == HttpStatusCode.OK)
            {
                ToastService.ShowToast("Updated Successfully", ToastLevel.Success);
                Nav.NavigateTo("diary");
            }
            else
            {
                ToastService.ShowToast("update failed", ToastLevel.Error);
            }
        }

    }
}
