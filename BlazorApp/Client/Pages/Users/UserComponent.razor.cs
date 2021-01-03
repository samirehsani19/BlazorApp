using BlazorApp.Client.ToastService;
using BlazorApp.Shared.Models;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

namespace BlazorApp.Client.Pages.Users
{
    public partial class UserComponent
    {
        User UserData = new User();
        [Parameter] public EventCallback OnValidSubmit { get; set; }
        [Inject] HttpClient Client { get; set; }
        [Inject]NavigationManager Nav { get; set; }
        [Inject] ToastService.ToastService ToastService { get; set; }
        [Inject]ILocalStorageService Storage { get; set; }

        public async Task LogIn()
        {
            var result= await Client.GetAsync($"api/v1.0/user/{UserData.Email}");
            User data = await result.Content.ReadFromJsonAsync<User>();

            if (result.StatusCode==System.Net.HttpStatusCode.BadRequest)
            {
                ToastService.ShowToast("User could not be found" ,ToastLevel.Error);
            }
            else
            {
                //string json = JsonConvert.SerializeObject(data);
                //await Storage.SetItemAsync<string>("loginData", json);

                //var userData = await Storage.GetItemAsStringAsync("loginData");
                //User user =  JsonConvert.DeserializeObject<User>(userData);

                Nav.NavigateTo("todo");
            }
        }
    }
}
