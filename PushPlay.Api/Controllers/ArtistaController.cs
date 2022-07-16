using MediatR;
using Microsoft.AspNetCore.Mvc;
using PushPlay.Application.AlbumContext.Dto;
using PushPlay.Application.AlbumContext.Handler.Command;
using PushPlay.Application.AlbumContext.Handler.Query;

namespace PushPlay.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ArtistaController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ArtistaController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("ListarTodos")]
        public async Task<IActionResult> ListarTodos()
        {
            return Ok(await _mediator.Send(new GetAllArtistaQuery()));
        }

        [HttpPost("Criar")]
        public async Task<IActionResult> Criar(ArtistaInputDto dto)
        {
            var result = await _mediator.Send(new CreateArtistaCommand(dto));
            return Created($"{result.Artista.Id}", result.Artista);
        }
    }
}