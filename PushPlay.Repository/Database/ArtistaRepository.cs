using PushPlay.Domain.AlbumContext;
using PushPlay.Domain.AlbumContext.Repository;
using PushPlay.Repository.Contexto;

namespace PushPlay.Repository.Database
{
    public class ArtistaRepository : Repository<Artista>, IArtistaRepository
    {
        public ArtistaRepository(PushPlayContext context) : base(context) { }
    }
}
