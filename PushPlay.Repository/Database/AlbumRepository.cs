using PushPlay.Domain.Entidades;
using PushPlay.Domain.Repository;
using PushPlay.Repository.Contexto;

namespace PushPlay.Repository.Database
{
    public class AlbumRepository : Repository<Album>, IAlbumRepository
    {
        public AlbumRepository(PushPlayContext context) : base(context) { }
    }
}
