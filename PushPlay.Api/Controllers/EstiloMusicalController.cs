using MediatR;
using Microsoft.AspNetCore.Mvc;
using PushPlay.Application.AlbumContext.Dto;
using PushPlay.Application.AlbumContext.Handler.Command;
using PushPlay.Application.AlbumContext.Handler.Query;

namespace PushPlay.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EstiloMusicalController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EstiloMusicalController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("ListarTodos")]
        public async Task<IActionResult> ListarTodos()
        {
            return Ok(await _mediator.Send(new GetAllEstiloMusicalQuery()));
        }

        [HttpPost("Criar")]
        public async Task<IActionResult> Criar(EstiloMusicalInputDto dto)
        {
            var result = await _mediator.Send(new CreateEstiloMusicalCommand(dto));
            return Created($"{result.EstiloMusical.Id}", result.EstiloMusical);
        }
    }
}