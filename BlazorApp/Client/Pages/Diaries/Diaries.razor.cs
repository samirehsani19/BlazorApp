using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.JSInterop;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BlazorApp.Client.Pages.Diaries
{
    public partial class Diaries
    {
        BlazorApp.Shared.Models.Diary[] AllDiaries { get; set; }
        [Inject] HttpClient Client { get; set; }
        [Inject] IJSRuntime Js { get; set; }
        [Inject] NavigationManager Nav { get; set; }
        private HubConnection Hub;

        protected override async Task OnInitializedAsync()
        {
            Hub = new HubConnectionBuilder()
                .WithUrl(Nav.ToAbsoluteUri("/MainHub"))
                .Build();

            Hub.On("UpdateDiary", async () =>
            {
                await LoadData();
            });

            await Hub.StartAsync();
            await LoadData();
        }

        private async Task LoadData()
        {
            AllDiaries = await Client.GetFromJsonAsync<BlazorApp.Shared.Models.Diary[]>("api/v1.0/Diary");
            StateHasChanged();
        }

        async Task Delete(int diaryId)
        {
            var diary = AllDiaries.First(x => x.DiaryID == diaryId);
            if (await Js.InvokeAsync<bool>("confirm", $"Do you want to delete {diary.Title}'s ({diary.DiaryID}) Record?"))
            {
                await Client.DeleteAsync($"api/v1.0/diary/{diaryId}");
                await OnInitializedAsync();
            }
        }
    }
}
