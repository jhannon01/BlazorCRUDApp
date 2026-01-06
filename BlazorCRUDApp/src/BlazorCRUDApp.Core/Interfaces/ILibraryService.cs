using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorCRUDApp.Core.Entities;

namespace BlazorCRUDApp.Core.Interfaces
{
    public interface ILibraryService
    {
        Task<List<LibrarySong>> GetAll();
        Task<LibrarySong?> Get(int id);
        Task Add(LibrarySong song);
        Task Update(LibrarySong song);
        Task Delete(LibrarySong song);
        Task<List<LibrarySong>> SearchByTitle(string title);
    }
}