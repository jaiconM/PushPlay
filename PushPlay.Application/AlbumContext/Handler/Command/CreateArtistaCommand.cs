using MediatR;
using PushPlay.Application.AlbumContext.Dto;

namespace PushPlay.Application.AlbumContext.Handler.Command
{
    public class CreateArtistaCommand : IRequest<CreateArtistaCommandResponse>
    {
        public ArtistaInputDto Artista { get; set; }

        public CreateArtistaCommand(ArtistaInputDto artista)
        {
            Artista = artista;
        }
    }
}
