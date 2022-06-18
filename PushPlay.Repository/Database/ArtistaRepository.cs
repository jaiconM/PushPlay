using PushPlay.Domain.Entidades;
using PushPlay.Domain.Repository;
using PushPlay.Repository.Contexto;

namespace PushPlay.Repository.Database
{
    public class ArtistaRepository : Repository<Artista>, IArtistaRepository
    {
        public ArtistaRepository(PushPlayContext context) : base(context) { }
    }
}
