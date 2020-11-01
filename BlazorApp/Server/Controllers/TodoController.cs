using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorApp.Server.Models;
using BlazorApp.Server.Services.Interfaces;
using BlazorApp.Server.Services.Repositories;
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
    }
}
