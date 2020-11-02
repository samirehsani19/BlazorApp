using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorApp.Server.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BlazorApp.Server.Controllers
{
    [Route("api/v1.0/[Controller]")]
    [ApiController]
    public class DiaryController : Controller
    {
        private readonly IDiary _diaryRepo;
        public DiaryController(IDiary d) => _diaryRepo = d;

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return Ok(await _diaryRepo.GetDiaries());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult>GetByID(int id)
        {
            var diary=_diaryRepo.GetDiaryByID(id);
            return Ok(diary);
        }

    }
}
