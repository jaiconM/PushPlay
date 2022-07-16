using PushPlay.Application.ContaContext.Dto;

namespace PushPlay.Application.ContaContext.Handler.Command
{
    public class CreateUsuarioCommandResponse
    {
        public UsuarioOutputDto Usuario { get; set; }

        public CreateUsuarioCommandResponse(UsuarioOutputDto usuario)
        {
            Usuario = usuario;
        }
    }
}
