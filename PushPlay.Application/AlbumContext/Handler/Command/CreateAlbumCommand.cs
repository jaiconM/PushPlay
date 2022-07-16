using MediatR;
using PushPlay.Application.AlbumContext.Dto;

namespace PushPlay.Application.AlbumContext.Handler.Command
{
    public class CreateAlbumCommand : IRequest<CreateAlbumCommandResponse>
    {
        public AlbumInputDto Album { get; set; }

        public CreateAlbumCommand(AlbumInputDto album)
        {
            Album = album;
        }
    }
}
