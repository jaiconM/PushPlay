using PushPlay.Data.Contexto;
using PushPlay.Data.Database;
using PushPlay.Domain.AlbumContext;
using PushPlay.Domain.AlbumContext.Repository;

namespace PushPlay.Data.Repository
{
    public class EstiloMusicalRepository : Repository<EstiloMusical>, IEstiloMusicalRepository
    {
        public EstiloMusicalRepository(PushPlayContext context) : base(context) { }
    }
}
