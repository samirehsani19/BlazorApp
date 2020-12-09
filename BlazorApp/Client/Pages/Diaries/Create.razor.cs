using Microsoft.AspNetCore.Components;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BlazorApp.Client.Pages.Diaries
{
    public partial class Create
    {
        [Inject] HttpClient Client { get; set; }
        [Inject] NavigationManager Nav { get; set; }
        BlazorApp.Shared.Models.Diary diary = new BlazorApp.Shared.Models.Diary();
        async Task CreateDiary()
        {
            await Client.PostAsJsonAsync("api/v1.0/diary", diary);
            Nav.NavigateTo("diary");
        }
    }
}
