using BlazorApp.Server.Services.Interfaces;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace BlazorApp.Server.Services.Repositories
{
    public class Repository : IRepository
    {
        protected readonly DataContext _context;
        public Repository(DataContext context)
        {
            _context = context;
        }
        public virtual void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public virtual void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public virtual void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public virtual async Task<bool> Save()
        {
            return (await _context.SaveChangesAsync()) >= 0;
        }
    }
}
