using PushPlay.Application.AlbumContext.Dto;

namespace PushPlay.Application.AlbumContext.Handler.Query
{
    public class GetAllAlbumQueryResponse
    {
        public IList<AlbumOutputDto> Albums { get; set; }

        public GetAllAlbumQueryResponse(IList<AlbumOutputDto> albums)
        {
            Albums = albums;
        }
    }
}
