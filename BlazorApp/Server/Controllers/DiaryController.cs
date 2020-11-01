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
        
        public async Task<IActionResult> Index()
        {
            return Ok(await _diaryRepo.GetDiaries());
        }
    }
}
