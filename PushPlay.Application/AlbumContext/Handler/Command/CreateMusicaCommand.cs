using MediatR;
using PushPlay.Application.AlbumContext.Dto;

namespace PushPlay.Application.AlbumContext.Handler.Command
{
    public class CreateMusicaCommand : IRequest<CreateMusicaCommandResponse>
    {
        public MusicaInputDto Musica { get; set; }

        public CreateMusicaCommand(MusicaInputDto musica)
        {
            Musica = musica;
        }
    }
}
