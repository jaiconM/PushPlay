using MediatR;

namespace PushPlay.Application.AlbumContext.Handler.Query
{
    public class GetAllAlbumQuery : IRequest<GetAllAlbumQueryResponse> { }
}
