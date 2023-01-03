using RepositoryPattern_Youtube.Models;

namespace RepositoryPattern_Youtube.Data.MusicRepo
{
    public interface IMusicService
    {
        Task<Music> AddMusic(Music music);
        Task<Music> UpdateMusic(Music music);
        bool DeleteMusic(string id);
        IEnumerable<Music> List();
        Music Details(string id);
    }
}
