using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorCRUDApp.Core.Entities;
using BlazorCRUDApp.Core.Interfaces;
using BlazorCRUDApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BlazorCRUDApp.Infrastructure.Repositories
{
    public class LibraryRepository : ILibraryRepository
    {
        private readonly AppDbContext _db;

        public LibraryRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task<List<LibrarySong>> GetAllAsync() => await _db.LibrarySong.ToListAsync();
        public async Task<LibrarySong?> GetAsync(int id) => await _db.LibrarySong.FindAsync(id);
        public async Task AddAsync(LibrarySong song) { _db.LibrarySong.Add(song); await _db.SaveChangesAsync(); }
        public async Task UpdateAsync(LibrarySong song) { _db.LibrarySong.Update(song); await _db.SaveChangesAsync(); }
        public async Task DeleteAsync(LibrarySong song) { _db.LibrarySong.Remove(song); await _db.SaveChangesAsync(); }
        public async Task<List<LibrarySong>> SearchByTitleAsync(string title)
        {
            return await _db.LibrarySong
                .Where(s => s.Title.Contains(title))
                .ToListAsync();
        }
    }
}