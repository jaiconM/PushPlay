using PushPlay.Data.Contexto;
using PushPlay.Data.Database;
using PushPlay.Domain.AlbumContext;
using PushPlay.Domain.AlbumContext.Repository;

namespace PushPlay.Data.Repository
{
    public class ArtistaRepository : Repository<Artista>, IArtistaRepository
    {
        public ArtistaRepository(PushPlayContext context) : base(context) { }
    }
}
