using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PushPlay.Application.ContaContext.Dto;
using PushPlay.Application.ContaContext.Handler.Command;
using PushPlay.Application.ContaContext.Handler.Query;

namespace PushPlay.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class UsuarioController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsuarioController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("ListarTodos")]
        public async Task<IActionResult> ListarTodos()
        {
            GetAllUsuarioQueryResponse result = await _mediator.Send(new GetAllUsuarioQuery());
            return Ok(result.Usuarios);
        }

        [HttpPost("Criar")]
        public async Task<IActionResult> Criar(UsuarioInputDto dto)
        {
            CreateUsuarioCommandResponse result = await _mediator.Send(new CreateUsuarioCommand(dto));
            return Created($"{result.Usuario.Id}", result.Usuario);
        }

        [HttpGet("ListarPorId/{id}")]
        public async Task<IActionResult> ListarPorId(Guid id)
        {
            GetByIdUsuarioQueryResponse result = await _mediator.Send(new GetByIdUsuarioQuery(id));
            return Ok(result.Usuario);
        }

        [HttpPut("Atualizar/{id}")]
        public async Task<IActionResult> Atualizar(Guid id, UsuarioInputDto dto)
        {
            UpdateUsuarioCommandResponse result = await _mediator.Send(new UpdateUsuarioCommand(id, dto));
            return Ok(result.Usuario);
        }

        [HttpDelete("Excluir/{id}")]
        public async Task<IActionResult> Excluir(Guid id)
        {
            await _mediator.Send(new DeleteUsuarioCommand(id));
            return Ok("Exclusão realizada com sucesso!");
        }
    }
}