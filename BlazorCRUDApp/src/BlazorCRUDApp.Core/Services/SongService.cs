using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorCRUDApp.Core.Entities;
using BlazorCRUDApp.Core.Interfaces;

namespace BlazorCRUDApp.Core.Services
{
    public class SongService : ISongService
    {
        private readonly ISongRepository _songRepository;

        public SongService(ISongRepository songRepository)
        {
            _songRepository = songRepository;
        }

        public async Task<List<Song>> GetAll() => await _songRepository.GetAllAsync();
        public async Task<Song?> Get(int id) => await _songRepository.GetAsync(id);
        public async Task Add(Song song) => await _songRepository.AddAsync(song);
        public async Task Update(Song song) => await _songRepository.UpdateAsync(song);
        public async Task Delete(int id) => await _songRepository.DeleteAsync(id);
    }
}