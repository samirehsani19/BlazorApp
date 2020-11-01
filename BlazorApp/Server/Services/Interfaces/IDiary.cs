using BlazorApp.Server.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp.Server.Services.Interfaces
{
    public interface IDiary:IRepository
    {
        Task<Models.Diary[]> GetDiaries();
        Task<Models.Diary> GetDiaryByID(int id);
    }
}
