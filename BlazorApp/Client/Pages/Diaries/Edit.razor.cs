using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BlazorApp.Client.Pages.Diaries
{
    public partial class Edit
    {
        [Parameter] public int diaryId { get; set; }
        [Inject] IJSRuntime Js { get; set; }
        [Inject] NavigationManager Nav { get; set; }
        [Inject] HttpClient Client { get; set; }
        BlazorApp.Shared.Models.Diary diary = new BlazorApp.Shared.Models.Diary();
        protected async override Task OnParametersSetAsync()
        {
            diary = await Client.GetFromJsonAsync<BlazorApp.Shared.Models.Diary>($"api/v1.0/diary/{diaryId}");
        }
        async Task EditDiary()
        {
            await Client.PutAsJsonAsync("api/v1.0/diary", diary);
            await Js.InvokeVoidAsync("alert", $"Updated Successfully!");
            Nav.NavigateTo("diary");
        }
    }
}
