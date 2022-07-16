using PushPlay.Data.Contexto;
using PushPlay.Data.Database;
using PushPlay.Domain.AlbumContext;
using PushPlay.Domain.AlbumContext.Repository;

namespace PushPlay.Data.Repository
{
    public class MusicaRepository : Repository<Musica>, IMusicaRepository
    {
        public MusicaRepository(PushPlayContext context) : base(context) { }
    }
}
