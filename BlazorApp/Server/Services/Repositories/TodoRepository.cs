using BlazorApp.Server.Services.Interfaces;
using BlazorApp.Shared.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp.Server.Services.Repositories
{
    public class TodoRepository : Repository, ITodo
    {
        private ILogger<TodoRepository> _logger;

        public TodoRepository(DataContext context, ILogger<TodoRepository> logger) : base(context)
        {
            this._logger = logger;
        }

        public virtual async Task<Todo> GetTodoByID(int id)
        {
            _logger.LogInformation("Getting todos");
            IQueryable<Todo> query = _context.Todos.Where(x => x.TodoID == id);
            if (query == null)
            {
                _logger.LogInformation("No todo list found in database");
            }
            return await query.FirstOrDefaultAsync();
        }

        public virtual async Task<Todo[]> GetTodos()
        {
            _logger.LogInformation("Getting todos");
            IQueryable<Todo> query = _context.Todos;
            if (query == null)
            {
                _logger.LogInformation("No todo list found in database");
            }
            return await query.ToArrayAsync();
        }
    }
}
