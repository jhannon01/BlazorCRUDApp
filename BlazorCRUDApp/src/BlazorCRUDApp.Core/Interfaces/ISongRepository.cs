using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorCRUDApp.Core.Entities;

namespace BlazorCRUDApp.Core.Interfaces
{
    public interface ISongRepository
    {
        Task<List<Song>> GetAllAsync();
        Task<Song?> GetAsync(int id);
        Task AddAsync(Song song);
        Task UpdateAsync(Song song);
        Task DeleteAsync(int id);
    }
}