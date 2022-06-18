using PushPlay.Domain.Entidades;
using PushPlay.Domain.Repository;
using PushPlay.Repository.Contexto;

namespace PushPlay.Repository.Database
{
    public class MusicaRepository : Repository<Musica>, IMusicaRepository
    {
        public MusicaRepository(PushPlayContext context) : base(context) { }
    }
}
