using BlazorApp.Server.Services.Interfaces;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace BlazorApp.Server.Services.Repositories
{
    public class Repository : IRepository
    {
        protected readonly DataContext _context;
        protected readonly ILogger _logger;
        public Repository(DataContext context, ILogger logger)
        {
            _context = context;
            _logger = logger;
        }
        public virtual void Add<T>(T entity) where T : class
        {
            _logger.LogInformation($"Adding object of type {entity.GetType()}");
            _context.Add(entity);
        }

        public virtual void Delete<T>(T entity) where T : class
        {
            _logger.LogInformation($"Deleting object of type {entity.GetType()}");
            _context.Remove(entity);
        }

        public virtual void Update<T>(T entity) where T : class
        {
            _logger.LogInformation($"Updating entity of type {entity.GetType()}");
            _context.Update(entity);
        }

        public virtual async Task<bool> Save()
        {
            _logger.LogInformation($"Saving chages");
            return (await _context.SaveChangesAsync()) >= 0;
        }
    }
}
