//using Microsoft.AspNetCore.Components;
//using Microsoft.AspNetCore.SignalR.Client;
//using System.Net.Http;
//using System.Net.Http.Json;
//using System.Threading.Tasks;

//namespace BlazorApp.Client.Pages.Todos
//{
//    public partial class Create
//    {
//        //[Inject] HttpClient client { get; set; }
//        //[Inject] NavigationManager nav { get; set; }
//        //Todo todo = new Todo();
//        //private HubConnection hubConnection;





//        //public bool IsConnected => hubConnection.State == HubConnectionState.Connected;
//        //protected override async Task OnInitializedAsync()
//        //{
//        //    hubConnection = new HubConnectionBuilder()
//        //        .WithUrl(nav.ToAbsoluteUri("/MainHub"))
//        //        .Build();

//        //    await hubConnection.StartAsync();

//        //    hubConnection.On<Todo>("todoAdded", x =>
//        //    {
//        //        StateHasChanged();
//        //        nav.NavigateTo("todo");

//        //    });


//        //}





//        ////protected override async Task OnInitializedAsync()
//        ////{
//        ////    hubConnection = new HubConnectionBuilder()
//        ////        .WithUrl(nav.ToAbsoluteUri("/MainHub"))
//        ////        .Build();

//        ////    await hubConnection.StartAsync();
//        ////}

//        ////public bool IsConnected => hubConnection.State == HubConnectionState.Connected;
//        ////Task SendMessage() => hubConnection.SendAsync("SendMessage");
//        //async Task CreateTodo()
//        //{
//        //    await client.PostAsJsonAsync("api/v1.0/todo", todo);
//        //    nav.NavigateTo("todo");
//        //}
//        //public async ValueTask Dispose()
//        //{
//        //    await hubConnection.DisposeAsync();
//        //}
//    }
//}
