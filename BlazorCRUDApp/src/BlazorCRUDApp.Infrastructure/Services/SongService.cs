using BlazorCRUDApp.Core.Entities;
using BlazorCRUDApp.Core.Interfaces;
using BlazorCRUDApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BlazorCRUDApp.Infrastructure.Services
{
    public class SongService : ISongService
    {
        private readonly AppDbContext _db;
        public SongService(AppDbContext db) => _db = db;

        public async Task<List<Song>> GetAll() => await _db.Songs.ToListAsync();
        public async Task<Song?> Get(int id) => await _db.Songs.FindAsync(id);
        public async Task Add(Song song) { _db.Songs.Add(song); await _db.SaveChangesAsync(); }
        public async Task Update(Song song)
        {
            var existing = await _db.Songs.FindAsync(song.Id);
            if (existing == null) return;
            existing.Title = song.Title;
            existing.Artist = song.Artist;

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
