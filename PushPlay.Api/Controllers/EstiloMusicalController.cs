using Microsoft.AspNetCore.Mvc;
using PushPlay.Domain.AlbumContext;
using PushPlay.Domain.AlbumContext.Repository;

namespace PushPlay.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EstiloMusicalController : ControllerBase
    {
        private readonly IEstiloMusicalRepository _estiloMusicalRepository;

        public EstiloMusicalController(IEstiloMusicalRepository estiloMusicalRepository)
        {
            _estiloMusicalRepository = estiloMusicalRepository;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<EstiloMusical?> Get(string id)
        {
            return await _estiloMusicalRepository.Get(new Guid(id));
        }

        [HttpGet]
        public async Task<IEnumerable<EstiloMusical>> GetAll()
        {
            return await _estiloMusicalRepository.GetAll();
        }

    }
}