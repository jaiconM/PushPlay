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
    public class MusicaController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MusicaController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("ListarTodas")]
        public async Task<IActionResult> ListarTodas()
        {
            GetAllMusicaQueryResponse result = await _mediator.Send(new GetAllMusicaQuery());
            return Ok(result.Musicas);
        }

        [HttpPost("Criar")]
        public async Task<IActionResult> Criar(MusicaInputDto dto)
        {
            CreateMusicaCommandResponse result = await _mediator.Send(new CreateMusicaCommand(dto));
            return Created($"{result.Musica.Id}", result.Musica);
        }

        [HttpGet("ListarPorId/{id}")]
        public async Task<IActionResult> ListarPorId(Guid id)
        {
            GetByIdMusicaQueryResponse result = await _mediator.Send(new GetByIdMusicaQuery(id));
            return Ok(result.Musica);
        }

        [HttpPut("Atualizar/{id}")]
        public async Task<IActionResult> Atualizar(Guid id, MusicaInputDto dto)
        {
            UpdateMusicaCommandResponse result = await _mediator.Send(new UpdateMusicaCommand(id, dto));
            return Ok(result.Musica);
        }

        [HttpDelete("Excluir/{id}")]
        public async Task<IActionResult> Excluir(Guid id)
        {
            await _mediator.Send(new DeleteMusicaCommand(id));
            return Ok("Exclusão realizada com sucesso!");
        }
    }
}