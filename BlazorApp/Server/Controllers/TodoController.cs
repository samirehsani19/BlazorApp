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
    public class TodoController : Controller
    {
        private readonly IHubContext<MainHub> hub;
        private readonly ITodo _todoRepo;
        public TodoController(IHubContext<MainHub> hub, ITodo repo)
        {
            this.hub = hub;
            _todoRepo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var todo = await _todoRepo.GetTodos();
            return Ok(todo);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var todo = await _todoRepo.GetTodoByID(id);
            return Ok(todo);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Todo todo)
        {
            _todoRepo.Add(todo);
            if (await _todoRepo.Save())
            {
                await hub.Clients.All.SendAsync("ReceivedMessage");
                return Ok(todo.Title);
            }
            return StatusCode(StatusCodes.Status500InternalServerError, $"Todo with title: {todo.Title} could not be created");
        }


        [HttpPut()]
        public async Task<IActionResult> Update(Todo todo)
        {
            _todoRepo.Update(todo);
            if (await _todoRepo.Save())
            {
                await hub.Clients.All.SendAsync("ReceivedMessage");
                return Ok(todo.Title);
            }
            return StatusCode(StatusCodes.Status500InternalServerError, $"Todo with title: {todo.Title} could not be updated");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var todo = await _todoRepo.GetTodoByID(id);
            _todoRepo.Delete(todo);
            if (await _todoRepo.Save())
            {
                await hub.Clients.All.SendAsync("ReceivedMessage");
                return Ok($"Todo with id {id} deleted successfully!");
            }
            return StatusCode(StatusCodes.Status500InternalServerError, $"Todo with id: {id} could not be deleted");
        }

    }
}
