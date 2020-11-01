using BlazorApp.Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp.Server.Services.Interfaces
{
    public interface ITodo:IRepository
    {
        Task<Todo[]> GetTodos();
        Task<Todo> GetTodoByID(int id);
    }
}
