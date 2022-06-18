using Microsoft.AspNetCore.Mvc;
using PushPlay.Domain.Entidades;
using PushPlay.Domain.Repository;

namespace PushPlay.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlbumController : ControllerBase
    {
        private readonly IAlbumRepository _albumRepository;

        public AlbumController(IAlbumRepository albumRepository)
        {
            _albumRepository = albumRepository;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<Album?> Get(string id)
        {
            return await _albumRepository.Get(new Guid(id));
        }

        [HttpGet]
        public async Task<IEnumerable<Album>> GetAll()
        {
            return await _albumRepository.GetAll();
        }

    }
}