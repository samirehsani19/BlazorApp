using BlazorApp.Server.Services.Interfaces;
using BlazorApp.Shared.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp.Server.Services.Repositories
{
    public class DiaryRepository : Repository, IDiary
    {
        private readonly ILogger<DiaryRepository> _logger;
        public DiaryRepository(DataContext context, ILogger<DiaryRepository>logger) : base(context)
        {
            this._logger = logger;
        }

        public virtual async Task<Diary[]> GetDiaries()
        {
            _logger.LogInformation("Getting Diaries");
            IQueryable<Diary> query = _context.Diaries;
            if (query == null)
            {
                _logger.LogInformation("No dairy found in database");
            }
            return await query.ToArrayAsync();
        }

        public virtual async Task<Diary> GetDiaryByID(int id)
        {
            _logger.LogInformation("Getting Diaries");
            IQueryable<Diary> query = _context.Diaries.Where(x => x.DiaryID == id);
            if (query == null)
            {
                _logger.LogInformation("No dairy found in database");
            }
            return await query.FirstOrDefaultAsync();
        }
    }
}
