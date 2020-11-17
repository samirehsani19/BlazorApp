using BlazorApp.Shared.Models;
using System.Threading.Tasks;

namespace BlazorApp.Server.Services.Interfaces
{
    public interface ITodo : IRepository
    {
        Task<Todo[]> GetTodos();
        Task<Todo> GetTodoByID(int id);
    }
}
