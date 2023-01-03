using AutoMapper;
using RepositoryPattern_Youtube.DTO;
using RepositoryPattern_Youtube.Models;

namespace RepositoryPattern_Youtube.MapModel
{
    public class MusicMapper : Profile
    {
        public MusicMapper()
        {
            // == > Source => Target
            // CreateMap<Source, Target>

            // Use inside request 
            CreateMap<Music, MusicDTO>();

            // Use inside response
            CreateMap<MusicDTO, Music>();
        }
    }
}
