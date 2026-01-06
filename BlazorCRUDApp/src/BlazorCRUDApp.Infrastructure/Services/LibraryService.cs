using BlazorCRUDApp.Core.Entities;
using BlazorCRUDApp.Core.Interfaces;
using BlazorCRUDApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BlazorCRUDApp.Infrastructure.Services
{
    public class LibraryService : ILibraryService
    {
        private readonly AppDbContext _db;
        public LibraryService(AppDbContext db) => _db = db;

        public async Task<List<LibrarySong>> GetAll() => await _db.LibrarySong.ToListAsync();
        public async Task<LibrarySong?> Get(int id) => await _db.LibrarySong.FindAsync(id);
        public async Task Add(LibrarySong song) { _db.LibrarySong.Add(song); await _db.SaveChangesAsync(); }
        public async Task Update(LibrarySong song) { _db.LibrarySong.Update(song); await _db.SaveChangesAsync(); }
        public async Task Delete(LibrarySong song) { _db.LibrarySong.Remove(song); await _db.SaveChangesAsync(); }
        public async Task<List<LibrarySong>> SearchByTitle(string title)
        {
            return await _db.LibrarySong
                .Where(s => s.Title.Contains(title))
                .ToListAsync();
        }

    }
}
