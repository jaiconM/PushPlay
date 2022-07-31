using PushPlay.Application.AlbumContext.Dto;

namespace PushPlay.Application.AlbumContext.Handler.Query
{
    public class GetByIdArtistaQueryResponse
    {
        public ArtistaOutputDto Artista { get; set; }

        public GetByIdArtistaQueryResponse(ArtistaOutputDto artista)
        {
            Artista = artista;
        }
    }
}
