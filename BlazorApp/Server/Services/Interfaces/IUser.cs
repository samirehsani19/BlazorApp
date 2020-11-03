using BlazorApp.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp.Server.Services.Interfaces
{
    public interface IUser:IRepository
    {
        Task<User[]> GetUsers();
        Task<User> GetUserByID(int id);
    }
}
