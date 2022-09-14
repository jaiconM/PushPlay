using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PushPlay.Application.AlbumContext.Dto;
using PushPlay.Application.AlbumContext.Handler.Command;
using PushPlay.Application.AlbumContext.Handler.Query;

namespace PushPlay.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
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
            GetAllArtistaQueryResponse result = await _mediator.Send(new GetAllArtistaQuery());
            return Ok(result.Artistas);
        }

        [HttpPost("Criar")]
        public async Task<IActionResult> Criar(ArtistaInputDto dto)
        {
            CreateArtistaCommandResponse result = await _mediator.Send(new CreateArtistaCommand(dto));
            return Created($"{result.Artista.Id}", result.Artista);
        }

        [HttpGet("ListarPorId/{id}")]
        public async Task<IActionResult> ListarPorId(Guid id)
        {
            GetByIdArtistaQueryResponse result = await _mediator.Send(new GetByIdArtistaQuery(id));
            return Ok(result.Artista);
        }

        [HttpPut("Atualizar/{id}")]
        public async Task<IActionResult> Atualizar(Guid id, ArtistaInputDto dto)
        {
            UpdateArtistaCommandResponse result = await _mediator.Send(new UpdateArtistaCommand(id, dto));
            return Ok(result.Artista);
        }

        [HttpDelete("Excluir/{id}")]
        public async Task<IActionResult> Excluir(Guid id)
        {
            await _mediator.Send(new DeleteArtistaCommand(id));
            return Ok("Exclusão realizada com sucesso!");
        }
    }
}