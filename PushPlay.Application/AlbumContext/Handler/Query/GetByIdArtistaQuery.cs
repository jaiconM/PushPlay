using MediatR;

namespace PushPlay.Application.AlbumContext.Handler.Query
{
    public class GetByIdArtistaQuery : IRequest<GetByIdArtistaQueryResponse>
    {
        public Guid Id { get; set; }

        public GetByIdArtistaQuery(Guid id)
        {
            Id = id;
        }
    }
}
