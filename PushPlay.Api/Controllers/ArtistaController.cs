using Microsoft.AspNetCore.Mvc;
using PushPlay.Domain.AlbumContext;
using PushPlay.Domain.AlbumContext.Repository;

namespace PushPlay.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ArtistaController : ControllerBase
    {
        private readonly IArtistaRepository _artistaRepository;

        public ArtistaController(IArtistaRepository artistaRepository)
        {
            _artistaRepository = artistaRepository;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<Artista?> Get(string id)
        {
            return await _artistaRepository.Get(new Guid(id));
        }

        [HttpGet]
        public async Task<IEnumerable<Artista>> GetAll()
        {
            return await _artistaRepository.GetAll();
        }

    }
}