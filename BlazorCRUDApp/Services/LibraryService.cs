using BlazorCRUDApp.Data;
using Microsoft.EntityFrameworkCore;
using BlazorCRUDApp.Entities;

namespace BlazorCRUDApp.Services
{
    public class LibraryService
    {
        private readonly AppDbContext _db;
        public LibraryService(AppDbContext db) => _db = db;

        public async Task<List<LibrarySong>> GetAll() => await _db.LibrarySong.ToListAsync();
        public async Task<LibrarySong?> Get(int id) => await _db.LibrarySong.FindAsync(id);
        public async Task Add(LibrarySong p) { _db.LibrarySong.Add(p); await _db.SaveChangesAsync(); }
        public async Task Update(LibrarySong p) { _db.LibrarySong.Update(p); await _db.SaveChangesAsync(); }
        public async Task Delete(LibrarySong p) { _db.LibrarySong.Remove(p); await _db.SaveChangesAsync(); }
        public async Task<List<LibrarySong>> SearchByTitle(string title)
        {
            return await _db.LibrarySong
                .Where(s => s.Title.Contains(title))
                .ToListAsync();
        }

    }
}
