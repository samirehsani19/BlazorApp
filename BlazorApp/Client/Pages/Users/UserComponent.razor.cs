using BlazorApp.Shared.Models;
using Microsoft.AspNetCore.Components;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BlazorApp.Client.Pages.Users
{
    public partial class UserComponent
    {
        User UserData = new User();
        [Parameter] public EventCallback OnValidSubmit { get; set; }
        [Inject] HttpClient Client { get; set; }
        [Inject]NavigationManager Nav { get; set; }

        public async Task LogIn()
        {
            var result= await Client.GetAsync($"api/v1.0/user/{UserData.Email}");
            if (result.StatusCode==System.Net.HttpStatusCode.BadRequest)
            {
                Nav.NavigateTo("error");
            }
            else
            {
                Nav.NavigateTo("todo");
            }
        }
    }
}
