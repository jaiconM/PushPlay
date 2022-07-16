using PushPlay.Data.Contexto;
using PushPlay.Data.Database;
using PushPlay.Domain.ContaContext;
using PushPlay.Domain.ContaContext.Repository;

namespace PushPlay.Data.Repository
{
    public class PlayListRepository : Repository<PlayList>, IPlayListRepository
    {
        public PlayListRepository(PushPlayContext context) : base(context) { }
    }
}
