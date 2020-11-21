using BlazorApp.Server.Hubs;
using BlazorApp.Server.Services.Interfaces;
using BlazorApp.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace BlazorApp.Server.Controllers
{
    [Route("api/v1.0/[controller]")]
    [ApiController]
    public class DiaryController : Controller
    {
        private readonly IDiary _diaryRepo;
        private readonly IHubContext<MainHub> hub;
        public DiaryController(IHubContext<MainHub> h, IDiary d)
        {
            _diaryRepo = d;
            this.hub = h;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return Ok(await _diaryRepo.GetDiaries());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByID(int id)
        {
            var diary = await _diaryRepo.GetDiaryByID(id);
            if (diary == null)
            {
                return NotFound($"Diary with id: {id} could not be found");
            }
            return Ok(diary);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Diary diary)
        {
            if (diary == null) { return StatusCode(StatusCodes.Status400BadRequest, "Model is empty"); }

            _diaryRepo.Add(diary);
            if (await _diaryRepo.Save())
            {
                await hub.Clients.All.SendAsync("UpdateDiary");
                return Ok($"Diary with title {diary.Title} saved succecfully");
            }
            return StatusCode(StatusCodes.Status500InternalServerError, $"Database faulure!");
        }

        [HttpPut]
        public async Task<IActionResult> Put(Diary diary)
        {
            _diaryRepo.Update(diary);
            if (await _diaryRepo.Save())
            {
                await hub.Clients.All.SendAsync("UpdateDiary");
                return Ok($"Diary updated successfully");

            }
            return StatusCode(StatusCodes.Status500InternalServerError, $"Database failure");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var diary = await _diaryRepo.GetDiaryByID(id);
            if (diary == null)
            {
                return NotFound();
            }

            _diaryRepo.Delete(diary);
            if (await _diaryRepo.Save())
            {
                await hub.Clients.All.SendAsync("UpdateDiary");
                return Ok($"Diary with id: {id} deleted successfully");
            }
            return StatusCode(StatusCodes.Status500InternalServerError, $"Database failure");

        }
    }
}
