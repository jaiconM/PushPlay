using PushPlay.Application.ContaContext.Dto;

namespace PushPlay.Application.ContaContext.Handler.Query
{
    public class GetAllUsuarioQueryResponse
    {
        public IList<UsuarioOutputDto> Usuarios { get; set; }

        public GetAllUsuarioQueryResponse(IList<UsuarioOutputDto> usuarios)
        {
            Usuarios = usuarios;
        }
    }
}
