using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorApp.Shared.Models;
using BlazorApp.Server.Services.Interfaces;
using BlazorApp.Server.Services.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorApp.Server.Controllers
{
    [Route("api/v1.0/[controller]")]
    [ApiController]
    public class TodoController : Controller
    {
        private readonly ITodo _todoRepo;
        public TodoController(ITodo repo) => _todoRepo = repo;
       
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
                return Ok(todo.Title);
            }
            return StatusCode(StatusCodes.Status500InternalServerError,$"Todo with title: {todo.Title} could not be created");
        }

        [HttpPut]
        public async Task<IActionResult> Put(Todo todo)
        {
            _todoRepo.Update(todo);
            if (await _todoRepo.Save())
            {
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
                return Ok($"Todo with id {id} deleted successfully!");
            }
            return StatusCode(StatusCodes.Status500InternalServerError, $"Todo with id: {id} could not be deleted");
        }

    }
}
