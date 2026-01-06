using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorCRUDApp.Core.Entities;
using BlazorCRUDApp.Core.Interfaces;

namespace BlazorCRUDApp.Core.Services
{
    public class LibraryService : ILibraryService
    {
        private readonly ILibraryRepository _libraryRepository;

        public LibraryService(ILibraryRepository libraryRepository)
        {
            _libraryRepository = libraryRepository;
        }

        public async Task<List<LibrarySong>> GetAll() => await _libraryRepository.GetAllAsync();
        public async Task<LibrarySong?> Get(int id) => await _libraryRepository.GetAsync(id);
        public async Task Add(LibrarySong song) => await _libraryRepository.AddAsync(song);
        public async Task Update(LibrarySong song) => await _libraryRepository.UpdateAsync(song);
        public async Task Delete(LibrarySong song) => await _libraryRepository.DeleteAsync(song);
        public async Task<List<LibrarySong>> SearchByTitle(string title) => await _libraryRepository.SearchByTitleAsync(title);
    }
}