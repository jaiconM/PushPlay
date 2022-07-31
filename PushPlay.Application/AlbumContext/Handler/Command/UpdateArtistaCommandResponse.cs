using PushPlay.Application.AlbumContext.Dto;

namespace PushPlay.Application.AlbumContext.Handler.Command
{
    public class UpdateArtistaCommandResponse
    {
        public ArtistaOutputDto Artista { get; set; }

        public UpdateArtistaCommandResponse(ArtistaOutputDto artista)
        {
            Artista = artista;
        }
    }
}
