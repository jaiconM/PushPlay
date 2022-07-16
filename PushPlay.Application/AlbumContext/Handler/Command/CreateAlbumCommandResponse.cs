using PushPlay.Application.AlbumContext.Dto;

namespace PushPlay.Application.AlbumContext.Handler.Command
{
    public class CreateAlbumCommandResponse
    {
        public AlbumOutputDto Album { get; set; }

        public CreateAlbumCommandResponse(AlbumOutputDto album)
        {
            Album = album;
        }
    }
}
