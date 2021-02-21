using BlazorApp.Server.Services.Interfaces;
using BlazorApp.Shared.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp.Server.Services.Repositories
{
    public class UserRepository : Repository, IUser
    {
        private readonly ILogger<UserRepository> _logger;

        public UserRepository(DataContext context, ILogger<UserRepository> logger) : base(context) { this._logger = logger; }

        public async Task<User> GetUserByEmail(string email)
        {
            _logger.LogInformation($"Getting user by email: {email}");
            if (string.IsNullOrWhiteSpace(email)) _logger.LogInformation("Email is not valid");
            return await _context.Users.FirstOrDefaultAsync(x => x.Email == email);
        }

        public virtual async Task<User> GetUserByID(int id)
        {
            _logger.LogInformation($"Getting user by id: {id}");
            IQueryable<User> user = _context.Users.Where(x => x.UserID == id);
            if (user == null)
            {
                _logger.LogInformation("There is no user");
            }
            return await user.FirstOrDefaultAsync();
        }

        public virtual async Task<User[]> GetUsers()
        {
            _logger.LogInformation("Getting users");
            IQueryable<User> users = _context.Users;
            if (users == null)
            {
                _logger.LogInformation("There is no user");
            }
            return await users.ToArrayAsync();

        }

    }
}
