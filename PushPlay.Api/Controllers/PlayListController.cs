using Microsoft.AspNetCore.Mvc;
using PushPlay.Domain.Entidades;
using PushPlay.Domain.Repository;

namespace PushPlay.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlayListController : ControllerBase
    {
        private readonly IPlayListRepository _playListRepository;

        public PlayListController(IPlayListRepository playListRepository)
        {
            _playListRepository = playListRepository;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<PlayList?> Get(string id)
        {
            return await _playListRepository.Get(new Guid(id));
        }

        [HttpGet]
        public async Task<IEnumerable<PlayList>> GetAll()
        {
            return await _playListRepository.GetAll();
        }

    }
}