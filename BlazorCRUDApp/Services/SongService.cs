using BlazorCRUDApp.Data;
using BlazorCRUDApp.Entities;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace BlazorCRUDApp.Services
{
    public class SongService
    {
        private readonly AppDbContext _db;
        public SongService(AppDbContext db) => _db = db;

        public async Task<List<Song>> GetAll() => await _db.Songs.ToListAsync();
        public async Task<Song?> Get(int id) => await _db.Songs.FindAsync(id);
        public async Task Add(Song p) { _db.Songs.Add(p); await _db.SaveChangesAsync(); }
        public async Task Update(Song p) 
        {
            var existing = await _db.Songs.FindAsync(p.Id);
            if (existing == null) return;
            existing.Title = p.Title;
            existing.Artist = p.Artist;

            _db.Songs.Update(existing); 
            await _db.SaveChangesAsync(); 
        }
        public async Task Delete(int id) {
            var song = await _db.Songs.FindAsync(id);
            if (song == null) return;
            _db.Songs.Remove(song);
            await _db.SaveChangesAsync(); 
        }
    }
}
