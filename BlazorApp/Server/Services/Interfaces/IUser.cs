using BlazorApp.Shared.Models;
using System.Threading.Tasks;

namespace BlazorApp.Server.Services.Interfaces
{
    public interface IUser : IRepository
    {
        Task<User[]> GetUsers();
        Task<User> GetUserByID(int id);
        Task<User> GetUserByEmail(string email);
    }
}
