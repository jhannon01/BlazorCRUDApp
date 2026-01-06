using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorCRUDApp.Core.Entities;

namespace BlazorCRUDApp.Core.Interfaces
{
    public interface ILibraryRepository
    {
        Task<List<LibrarySong>> GetAllAsync();
        Task<LibrarySong?> GetAsync(int id);
        Task AddAsync(LibrarySong song);
        Task UpdateAsync(LibrarySong song);
        Task DeleteAsync(LibrarySong song);
        Task<List<LibrarySong>> SearchByTitleAsync(string title);
    }
}