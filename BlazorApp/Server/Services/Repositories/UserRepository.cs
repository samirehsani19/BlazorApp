﻿using BlazorApp.Server.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp.Server.Services.Repositories
{
    public class UserRepository : Repository, IUser
    {
        public UserRepository(DataContext context, ILogger logger) : base(context, logger) { }

        public virtual async Task<Models.User> GetUserByID(int id)
        {
            _logger.LogInformation($"Getting user by id: {id}");
            IQueryable<Models.User> user = _context.Users.Where(x=> x.UserID==id);
            if (user == null)
            {
                _logger.LogInformation("There is no user");
            }
            return await user.FirstOrDefaultAsync();
        }

        public virtual async Task<Models.User[]> GetUsers()
        {
            _logger.LogInformation("Getting users");
            IQueryable<Models.User> users = _context.Users;
            if (users==null)
            {
                _logger.LogInformation("There is no user");
            }
            return await users.ToArrayAsync();
            
        }

    }
}