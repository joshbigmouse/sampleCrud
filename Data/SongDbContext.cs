using BlazorSongList.Models;
using Microsoft.EntityFrameworkCore;
namespace BlazorSongList.Data
{
    public class SongDbContext:DbContext
    {
        public DbSet<Song> Songs { get; set; }

        public SongDbContext(DbContextOptions<SongDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            base.OnModelCreating(builder);
            builder.Entity<Song>().HasData(
                new
                {
                    SongId = Guid.NewGuid().ToString(),
                    Title = "Thiller",
                    Artist = "Michael Jackson",
                    Year = "1982"
                }, new

                {
                    SongId = Guid.NewGuid().ToString(),
                    Title = "Shower the People",
                    Artist = "James Taylor",
                    Year = "1976"
                }

                );
        }
    }
}
