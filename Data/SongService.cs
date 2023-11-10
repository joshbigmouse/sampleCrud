using BlazorSongList.Models;

namespace BlazorSongList.Data
{
    public class SongService
    {
        SongDbContext _context;

        public SongService(SongDbContext context)
        { 
            _context = context;
        }

        public async Task<List<Song>> GetSongsAsync()
        {
            var result = _context.Songs;
            return await Task.FromResult(result.ToList());
        }

        public async Task<Song> GetSongByIdAsync(string id)
        {
            return await _context.Songs.FindAsync(id);
        }

        public async Task<Song> InsertSongAsync(Song song)
        {
            _context.Songs.Add(song);
            await _context.SaveChangesAsync();
            return song;
        }

        public async Task<Song> UpdateSongAsync(string id, Song s)
        {
            var song = await _context.Songs.FindAsync(id);
            if (song == null)

            song.SongId = s.SongId;
            song.Title = s.Title;
            song.Artist = s.Artist;
            song.Year = s.Year;

            _context.Songs.Update(song);
            await _context.SaveChangesAsync();


            return song;
        }

        public async Task<Song> DeleteSongAsync(string id)
        {
            var song = await _context.Songs.FindAsync(id);

            if (song == null)
                return null;

            _context.Songs.Remove(song);
            await _context.SaveChangesAsync();
            return song;
        }

    }
}
