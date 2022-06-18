using PushPlay.Domain.Entidades;
using PushPlay.Domain.Repository;
using PushPlay.Repository.Contexto;

namespace PushPlay.Repository.Database
{
    public class PlayListRepository : Repository<PlayList>, IPlayListRepository
    {
        public PlayListRepository(PushPlayContext context) : base(context) { }
    }
}
