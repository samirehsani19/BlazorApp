using BlazorApp.Server.Services.Interfaces;
using BlazorApp.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BlazorApp.Server.Controllers
{
    [Route("api/v1.0/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUser repo;
        public UserController(IUser userRepo)
        {
            this.repo = userRepo;
        }

        [HttpGet("{email}")]
        public async Task<IActionResult> FindUser(string email)
        {
            var result = await repo.GetUserByEmail(email);
            if (result == null) return BadRequest();
            return Ok(result);
        }
    }
}
