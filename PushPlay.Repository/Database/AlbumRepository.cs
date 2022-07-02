using PushPlay.Domain.AlbumContext;
using PushPlay.Domain.AlbumContext.Repository;
using PushPlay.Repository.Contexto;

namespace PushPlay.Repository.Database
{
    public class AlbumRepository : Repository<Album>, IAlbumRepository
    {
        public AlbumRepository(PushPlayContext context) : base(context) { }
    }
}
