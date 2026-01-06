using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorCRUDApp.Core.Entities;
using BlazorCRUDApp.Core.Interfaces;
using BlazorCRUDApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BlazorCRUDApp.Infrastructure.Repositories
{
    public class SongRepository : ISongRepository
    {
        private readonly AppDbContext _db;

        public SongRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task<List<Song>> GetAllAsync() => await _db.Songs.ToListAsync();
        public async Task<Song?> GetAsync(int id) => await _db.Songs.FindAsync(id);
        public async Task AddAsync(Song song) { _db.Songs.Add(song); await _db.SaveChangesAsync(); }
        public async Task UpdateAsync(Song song)
        {
            var existing = await _db.Songs.FindAsync(song.Id);
            if (existing == null) return;
            existing.Title = song.Title;
            existing.Artist = song.Artist;

            _db.Songs.Update(existing);
            await _db.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var song = await _db.Songs.FindAsync(id);
            if (song == null) return;
            _db.Songs.Remove(song);
            await _db.SaveChangesAsync();
        }
    }
}