using MediatR;
using PushPlay.Application.ContaContext.Dto;

namespace PushPlay.Application.ContaContext.Handler.Command
{
    public class CreateUsuarioCommand : IRequest<CreateUsuarioCommandResponse>
    {
        public UsuarioInputDto Usuario { get; set; }

        public CreateUsuarioCommand(UsuarioInputDto usuario)
        {
            Usuario = usuario;
        }
    }
}
