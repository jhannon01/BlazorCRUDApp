using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorCRUDApp.Core.Entities;

namespace BlazorCRUDApp.Core.Interfaces
{
    public interface ISongService
    {
        Task<List<Song>> GetAll();
        Task<Song?> Get(int id);
        Task Add(Song song);
        Task Update(Song song);
        Task Delete(int id);
    }
}