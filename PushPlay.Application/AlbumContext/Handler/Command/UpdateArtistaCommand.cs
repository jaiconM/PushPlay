using MediatR;
using PushPlay.Application.AlbumContext.Dto;

namespace PushPlay.Application.AlbumContext.Handler.Command
{
    public class UpdateArtistaCommand : IRequest<UpdateArtistaCommandResponse>
    {
        public Guid Id { get; set; }
        public ArtistaInputDto Artista { get; set; }

        public UpdateArtistaCommand(Guid id, ArtistaInputDto artista)
        {
            Id = id;
            Artista = artista;
        }
    }
}
