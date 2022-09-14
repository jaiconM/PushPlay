using PushPlay.CrossCutting.Interfaces.Data;

namespace PushPlay.Domain.ContaContext.Repository
{
    public interface IUsuarioRepository : IRepository<Usuario>
    {
        Task<bool> Autentique(string email, string senha);
    }
}
