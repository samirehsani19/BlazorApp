using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.JSInterop;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BlazorApp.Client.Pages.Todos
{
    public partial class Todos
    {
        BlazorApp.Shared.Models.Todo[] todos { get; set; }
        [Inject] NavigationManager Nav { get; set; }
        [Inject] HttpClient Client { get; set; }
        private HubConnection hubConnection;
        [Inject] IJSRuntime Js { get; set; }
        protected override async Task OnInitializedAsync()
        {
            hubConnection = new HubConnectionBuilder()
                .WithUrl(Nav.ToAbsoluteUri("/MainHub"))
                .Build();
            hubConnection.On("ReceivedMessage", () =>
            {
                CallLoadData();
            });

            await hubConnection.StartAsync();
            await LoadData();
        }


        private void CallLoadData()
        {
            Task.Run(async () =>
            {
                await LoadData();
            });

        }

        protected async Task LoadData()
        {
            todos = await Client.GetFromJsonAsync<BlazorApp.Shared.Models.Todo[]>("api/v1.0/Todo");
            StateHasChanged();
        }

        public async ValueTask Dispose()
        {
            await hubConnection.DisposeAsync();
        }


        async Task Delete(int todoId)
        {
            var todo = todos.First(x => x.TodoID == todoId);
            if (await Js.InvokeAsync<bool>("confirm", $"Do you want to delete {todo.Title}'s ({todo.TodoID}) Record?"))
            {
                await Client.DeleteAsync($"api/v1.0/Todo/{todoId}");
                await OnInitializedAsync();
            }
        }

    }
}
