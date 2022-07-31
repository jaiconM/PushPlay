using MediatR;

namespace PushPlay.Application.AlbumContext.Handler.Query
{
    public class GetByIdAlbumQuery : IRequest<GetByIdAlbumQueryResponse>
    {
        public Guid Id { get; set; }

        public GetByIdAlbumQuery(Guid id)
        {
            Id = id;
        }
    }
}
