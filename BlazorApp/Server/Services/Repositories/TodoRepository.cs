﻿using BlazorApp.Server.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp.Server.Services.Repositories
{
    public class TodoRepository : Repository, ITodo
    {
        public TodoRepository(DataContext context, ILogger logger) : base(context, logger)
        {
        }

        public virtual async Task<Models.Todo> GetTodoByID(int id)
        {
            _logger.LogInformation("Getting todos");
            IQueryable<Models.Todo> query = _context.Todos.Where(x=> x.TodoID==id);
            if (query == null)
            {
                _logger.LogInformation("No todo list found in database");
            }
            return await query.FirstOrDefaultAsync();
        }

        public virtual async Task<Models.Todo[]> GetTodos()
        {
            _logger.LogInformation("Getting todos");
            IQueryable<Models.Todo> query = _context.Todos;
            if (query==null)
            {
                _logger.LogInformation("No todo list found in database");
            }
            return await query.ToArrayAsync();
        }
    }
}