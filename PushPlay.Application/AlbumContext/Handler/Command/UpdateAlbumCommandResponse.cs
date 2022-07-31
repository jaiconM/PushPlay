using PushPlay.Application.AlbumContext.Dto;

namespace PushPlay.Application.AlbumContext.Handler.Command
{
    public class UpdateAlbumCommandResponse
    {
        public AlbumOutputDto Album { get; set; }

        public UpdateAlbumCommandResponse(AlbumOutputDto album)
        {
            Album = album;
        }
    }
}
