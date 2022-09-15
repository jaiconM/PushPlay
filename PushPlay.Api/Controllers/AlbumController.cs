using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PushPlay.Application.AlbumContext.Dto;
using PushPlay.Application.AlbumContext.Handler.Command;
using PushPlay.Application.AlbumContext.Handler.Query;

namespace PushPlay.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AlbumController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AlbumController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("ListarTodos")]
        public async Task<IActionResult> ListarTodos()
        {
            var resut = await _mediator.Send(new GetAllAlbumQuery());
            return Ok(resut.Albums);
        }

        [HttpPost("Criar")]
        public async Task<IActionResult> Criar(AlbumInputDto dto)
        {
            var result = await _mediator.Send(new CreateAlbumCommand(dto));
            return Created($"{result.Album.Id}", result.Album);
        }

        [HttpGet("ListarPorId/{id}")]
        public async Task<IActionResult> ListarPorId(Guid id)
        {
            var result = await _mediator.Send(new GetByIdAlbumQuery(id));
            return Ok(result.Album);
        }

        [HttpPut("Atualizar/{id}")]
        public async Task<IActionResult> Atualizar(Guid id, AlbumInputDto dto)
        {
            var result = await _mediator.Send(new UpdateAlbumCommand(id, dto));
            return Ok(result.Album);
        }

        [HttpDelete("Excluir/{id}")]
        public async Task<IActionResult> Excluir(Guid id)
        {
            await _mediator.Send(new DeleteAlbumCommand(id));
            return Ok("Exclusão realizada com sucesso!");
        }
    }
}