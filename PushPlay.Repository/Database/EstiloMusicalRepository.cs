using PushPlay.Domain.Entidades;
using PushPlay.Domain.Repository;
using PushPlay.Repository.Contexto;

namespace PushPlay.Repository.Database
{
    public class EstiloMusicalRepository : Repository<EstiloMusical>, IEstiloMusicalRepository
    {
        public EstiloMusicalRepository(PushPlayContext context) : base(context) { }
    }
}
