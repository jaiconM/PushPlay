using PushPlay.Application.AlbumContext.Dto;

namespace PushPlay.Application.AlbumContext.Handler.Query
{
    public class GetByIdAlbumQueryResponse
    {
        public AlbumOutputDto Album { get; set; }

        public GetByIdAlbumQueryResponse(AlbumOutputDto album)
        {
            Album = album;
        }
    }
}
