using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryPattern_Youtube.Data.MusicRepo;
using RepositoryPattern_Youtube.DTO;
using RepositoryPattern_Youtube.Models;

namespace RepositoryPattern_Youtube.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MusicController : ControllerBase
    {
        private readonly IMusicService _musicService;
        private readonly IMapper _mapper;

        public MusicController(IMusicService musicService, IMapper mapper)
        {
            _musicService = musicService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Gets()
        {
            var model = _musicService.List();
            if(model.Any())
            {
                return StatusCode(StatusCodes.Status200OK, _mapper.Map<IEnumerable<MusicDTO>>(model));
            }
            return StatusCode(StatusCodes.Status204NoContent);
        }

        [HttpGet("Details")]
        public IActionResult Get(string id)
        {
            var model = _musicService.Details(id);
            if(model is not null)
            {
                return StatusCode(StatusCodes.Status200OK, _mapper.Map<MusicDTO>(model));
            }
            return StatusCode(StatusCodes.Status404NotFound);
        }

        [HttpPost]
        public async Task<IActionResult> Post(MusicDTO musicDTO)
        {
            var mapModel = _mapper.Map<Music>(musicDTO);
            var result = await _musicService.AddMusic(mapModel);
            if(result is not null)
            {
                return StatusCode(StatusCodes.Status201Created, _mapper.Map<MusicDTO>(result));
            }
            return StatusCode(StatusCodes.Status400BadRequest);

        }

        [HttpPut]
        public async Task<IActionResult> Put(MusicDTO musicDTO)
        {
            var mapModel = _mapper.Map<Music>(musicDTO);
            var result = await _musicService.UpdateMusic(mapModel);
            if (result is not null)
            {
                return StatusCode(StatusCodes.Status200OK, _mapper.Map<MusicDTO>(result));
            }
            return StatusCode(StatusCodes.Status400BadRequest);
        }

        [HttpDelete]
        public IActionResult Delete(string id)
        {
            var model = _musicService.DeleteMusic(id);
            if(model is true)
            {
                return StatusCode(StatusCodes.Status200OK);
            }
            return StatusCode(StatusCodes.Status400BadRequest);
        }
    }
}
