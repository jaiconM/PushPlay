using PushPlay.Application.ContaContext.Dto;

namespace PushPlay.Application.ContaContext.Handler.Query
{
    public class GetByIdUsuarioQueryResponse
    {
        public UsuarioOutputDto Usuario { get; set; }

        public GetByIdUsuarioQueryResponse(UsuarioOutputDto usuario)
        {
            Usuario = usuario;
        }
    }
}
