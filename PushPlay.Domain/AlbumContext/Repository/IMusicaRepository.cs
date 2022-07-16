using PushPlay.CrossCutting.Interfaces.Data;

namespace PushPlay.Domain.AlbumContext.Repository
{
    public interface IMusicaRepository : IRepository<Musica>
    {
        Task<IEnumerable<Musica>> GetAllWithIncludes();
    }
}
