using Microsoft.EntityFrameworkCore;
using BlazorCRUDApp.Entities;

namespace BlazorCRUDApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<Song> Songs { get; set; } = default!;
        public DbSet<LibrarySong> LibrarySong { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<LibrarySong>().HasData(
                new LibrarySong { Id = 1, Title = "Imagine", Artist = "John Lennon" },
                new LibrarySong { Id = 2, Title = "Let It Be", Artist = "The Beatles" }
            );
        }


    }
}
