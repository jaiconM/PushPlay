using PushPlay.Domain.ContaContext;
using PushPlay.Domain.ContaContext.Repository;
using PushPlay.Repository.Contexto;

namespace PushPlay.Repository.Database
{
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(PushPlayContext context) : base(context) { }
    }
}
