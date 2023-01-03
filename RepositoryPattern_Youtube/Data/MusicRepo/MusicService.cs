using RepositoryPattern_Youtube.Models;

namespace RepositoryPattern_Youtube.Data.MusicRepo
{
    public class MusicService : IMusicService
    {
        private readonly AppDbContext _dbContext;

        public MusicService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Music> AddMusic(Music music)
        {
            if (music is not null)
            {
                // We can use Domain-Driven design inside our model
                // We can use a constructor inside the model and create an object based on the model 
                music.Id = Guid.NewGuid().ToString();
                await _dbContext.Music.AddAsync(music);
                await _dbContext.SaveChangesAsync();
            }
            return music;
        }

        public bool DeleteMusic(string id)
        {
            var music = Details(id);
            if (music is not null)
            {
                _dbContext.Music.Remove(music);
                _dbContext.SaveChanges();
                return true;
            }
            return false;
        }

        public Music Details(string id)
        {
            return _dbContext.Music.FirstOrDefault(m => m.Id == id);
        }

        public IEnumerable<Music> List()
        {
            return _dbContext.Music.OrderByDescending(m=> m.ReleaseDate).ToList();
        }

        public async Task<Music> UpdateMusic(Music music)
        {
            var musicDetails = Details(music.Id);
            if(musicDetails is not null)
            {
                // We can use any mapper libraries to map these models
                // Furthermore, we can use a simple manual mapper.
                musicDetails.Title = music.Title;
                musicDetails.ReleaseDate = music.ReleaseDate;
                musicDetails.Artist = music.Artist;
                musicDetails.Rate = music.Rate;
                await _dbContext.SaveChangesAsync();
            }
            return musicDetails;
        }
    }
}
