using BlazorApp.Shared.Models;
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
        [Inject] HttpClient client { get; set; }
        [Inject] IJSRuntime js { get; set; }
        [Inject] NavigationManager nav { get; set; }
        Todo[] todos { get; set; }
        private HubConnection hubConnection;

        //protected override async Task OnInitializedAsync()
        //{
        //    hubConnection = new HubConnectionBuilder()
        //        .WithUrl(nav.ToAbsoluteUri("/MainHub"))
        //        .Build();

        //    await hubConnection.StartAsync();

        //    if (IsConnected)
        //        hubConnection.On<Todo[]>("todoAdded", x =>
        //        {
        //            todos = x;
        //            StateHasChanged();
        //        });


        //}




        //public bool IsConnected => hubConnection.State == HubConnectionState.Connected;
        //protected override async Task OnInitializedAsync()
        //{
        //    hubConnection = new HubConnectionBuilder()
        //        .WithUrl(nav.ToAbsoluteUri("/MainHub"))
        //        .Build();

        //    await hubConnection.StartAsync();

        //    if(IsConnected)
        //    hubConnection.On<Todo>("todoAdded", async x =>
        //    {
        //        todos = await client.GetFromJsonAsync<Todo[]>("api/v1.0/Todo");
        //        StateHasChanged();
        //    });


        //}



        protected override async Task OnInitializedAsync()
        {
            hubConnection = new HubConnectionBuilder()
                .WithUrl(nav.ToAbsoluteUri("/MainHub"))
                .Build();
            hubConnection.On("getTodos", () =>
            {
                CallLoadData();
                StateHasChanged();
            });

            await hubConnection.StartAsync();
            await LoadData();
        }
        private void CallLoadData()
        {
            Task.Run(async () => await LoadData());
        }

        private async Task LoadData()
        {
            todos = await client.GetFromJsonAsync<Todo[]>("api/v1.0/Todo");
            StateHasChanged();
        }

        async Task Delete(int todoId)
        {
            var todo = todos.First(x => x.TodoID == todoId);
            if (await js.InvokeAsync<bool>("confirm", $"Do you want to delete {todo.Title}'s ({todo.TodoID}) Record?"))
            {
                await client.DeleteAsync($"api/v1.0/Todo/{todoId}");
                await OnInitializedAsync();
            }
        }

        public async ValueTask Dispose()
        {
            await hubConnection.DisposeAsync();
        }

    }
}
