using Microsoft.AspNetCore.Mvc;
using PushPlay.Domain.Entidades;
using PushPlay.Domain.Repository;

namespace PushPlay.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MusicaController : ControllerBase
    {
        private readonly IMusicaRepository _musicaRepository;

        public MusicaController(IMusicaRepository musicaRepository)
        {
            _musicaRepository = musicaRepository;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<Musica?> Get(string id)
        {
            return await _musicaRepository.Get(new Guid(id));
        }

        [HttpGet]
        public async Task<IEnumerable<Musica>> GetAll()
        {
            return await _musicaRepository.GetAll();
        }

    }
}