using PushPlay.Domain.ContaContext;
using PushPlay.Domain.ContaContext.Repository;
using PushPlay.Repository.Contexto;

namespace PushPlay.Repository.Database
{
    public class PlayListRepository : Repository<PlayList>, IPlayListRepository
    {
        public PlayListRepository(PushPlayContext context) : base(context) { }
    }
}
