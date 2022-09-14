using Microsoft.EntityFrameworkCore;
using PushPlay.Data.Contexto;
using PushPlay.Data.Database;
using PushPlay.Domain.ContaContext;
using PushPlay.Domain.ContaContext.Repository;

namespace PushPlay.Data.Repository
{
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(PushPlayContext context) : base(context) { }

        public async Task<bool> Autentique(string email, string senha)
        {
            List<Usuario> usuarios = await Query.Where(usuario => usuario.Email.Valor == email && usuario.Senha.Valor == senha)
                                                .ToListAsync();
            return usuarios.Any();
        }
    }
}
