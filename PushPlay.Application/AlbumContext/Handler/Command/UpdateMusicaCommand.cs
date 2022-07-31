using MediatR;
using PushPlay.Application.AlbumContext.Dto;

namespace PushPlay.Application.AlbumContext.Handler.Command
{
    public class UpdateMusicaCommand : IRequest<UpdateMusicaCommandResponse>
    {
        public Guid Id { get; set; }
        public MusicaInputDto Musica { get; set; }

        public UpdateMusicaCommand(Guid id, MusicaInputDto musica)
        {
            Id = id;
            Musica = musica;
        }
    }
}
