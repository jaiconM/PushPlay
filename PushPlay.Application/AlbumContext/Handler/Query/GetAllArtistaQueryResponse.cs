using PushPlay.Application.AlbumContext.Dto;

namespace PushPlay.Application.AlbumContext.Handler.Query
{
    public class GetAllArtistaQueryResponse
    {
        public IList<ArtistaOutputDto> Artistas { get; set; }

        public GetAllArtistaQueryResponse(IList<ArtistaOutputDto> artistas)
        {
            Artistas = artistas;
        }
    }
}
