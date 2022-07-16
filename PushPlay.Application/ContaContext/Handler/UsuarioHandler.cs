using MediatR;
using PushPlay.Application.ContaContext.Handler.Command;
using PushPlay.Application.ContaContext.Handler.Query;
using PushPlay.Application.ContaContext.Service;

namespace PushPlay.Application.ContaContext.Handler
{
    public class UsuarioHandler : IRequestHandler<CreateUsuarioCommand, CreateUsuarioCommandResponse>,
                                IRequestHandler<GetAllUsuarioQuery, GetAllUsuarioQueryResponse>
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioHandler(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        public async Task<CreateUsuarioCommandResponse> Handle(CreateUsuarioCommand request, CancellationToken cancellationToken)
        {
            var result = await _usuarioService.Create(request.Usuario);
            return new CreateUsuarioCommandResponse(result);
        }

        public async Task<GetAllUsuarioQueryResponse> Handle(GetAllUsuarioQuery request, CancellationToken cancellationToken)
        {
            var result = await _usuarioService.GetAll();
            return new GetAllUsuarioQueryResponse(result);
        }
    }
}
