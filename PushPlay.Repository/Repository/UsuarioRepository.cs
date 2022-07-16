using PushPlay.Data.Contexto;
using PushPlay.Data.Database;
using PushPlay.Domain.ContaContext;
using PushPlay.Domain.ContaContext.Repository;

namespace PushPlay.Data.Repository
{
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(PushPlayContext context) : base(context) { }
    }
}
