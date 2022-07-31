using PushPlay.Application.ContaContext.Dto;

namespace PushPlay.Application.ContaContext.Handler.Command
{
    public class UpdateUsuarioCommandResponse
    {
        public UsuarioOutputDto Usuario { get; set; }

        public UpdateUsuarioCommandResponse(UsuarioOutputDto usuario)
        {
            Usuario = usuario;
        }
    }
}
