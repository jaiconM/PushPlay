using PushPlay.CrossCutting.Interfaces.Data;

namespace PushPlay.Domain.AlbumContext.Repository
{
    public interface IAlbumRepository : IRepository<Album> {
        Task<IEnumerable<Album>> ObterTodosAlbuns();
    }
}
