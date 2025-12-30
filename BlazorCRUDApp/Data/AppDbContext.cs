using Microsoft.EntityFrameworkCore;
using BlazorCRUDApp.Components.Entities;

namespace BlazorCRUDApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<Song> Songs { get; set; } = default!;
    }
}
