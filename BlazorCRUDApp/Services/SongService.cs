using BlazorCRUDApp.Data;
using BlazorCRUDApp.Components.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlazorCRUDApp.Services
{
    public class SongService
    {
        private readonly AppDbContext _db;
        public SongService(AppDbContext db) => _db = db;

        public async Task<List<Song>> GetAll() => await _db.Songs.ToListAsync();
        public async Task<Song?> Get(int id) => await _db.Songs.FindAsync(id);
        public async Task Add(Song p) { _db.Songs.Add(p); await _db.SaveChangesAsync(); }
        public async Task Update(Song p) { _db.Songs.Update(p); await _db.SaveChangesAsync(); }
        public async Task Delete(Song p) { _db.Songs.Remove(p); await _db.SaveChangesAsync(); }
    }
}
