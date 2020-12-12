using BlazorApp.Client.ToastService;
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
        [Inject] ToastService.ToastService ToastService { get; set; }
        BlazorApp.Shared.Models.Diary diary = new BlazorApp.Shared.Models.Diary();
        async Task CreateDiary()
        {
            var result = await Client.PostAsJsonAsync("api/v1.0/diary", diary);
            if (result.IsSuccessStatusCode)
            {
                ToastService.ShowToast("Saved Successfully", ToastLevel.Success);
            }
            else
            {
                ToastService.ShowToast("Failed to Save", ToastLevel.Error);
            }
            Nav.NavigateTo("diary");
        }
    }
}
