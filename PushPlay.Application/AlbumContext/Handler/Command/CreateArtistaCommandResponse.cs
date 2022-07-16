using PushPlay.Application.AlbumContext.Dto;

namespace PushPlay.Application.AlbumContext.Handler.Command
{
    public class CreateArtistaCommandResponse
    {
        public ArtistaOutputDto Artista { get; set; }

        public CreateArtistaCommandResponse(ArtistaOutputDto artista)
        {
            Artista = artista;
        }
    }
}
