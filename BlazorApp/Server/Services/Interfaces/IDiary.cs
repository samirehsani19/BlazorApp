using BlazorApp.Shared.Models;
using System.Threading.Tasks;

namespace BlazorApp.Server.Services.Interfaces
{
    public interface IDiary : IRepository
    {
        Task<Diary[]> GetDiaries();
        Task<Diary> GetDiaryByID(int id);
    }
}
