using Microsoft.EntityFrameworkCore;
using PushPlay.Data.Contexto;
using PushPlay.Data.Database;
using PushPlay.Domain.AlbumContext;
using PushPlay.Domain.AlbumContext.Repository;

namespace PushPlay.Data.Repository
{
    public class MusicaRepository : Repository<Musica>, IMusicaRepository
    {
        public MusicaRepository(PushPlayContext context) : base(context) { }

        public async Task<IEnumerable<Musica>> GetAllWithIncludes()
        {
            return await Query.Include(musica => musica.EstiloMusical)
                              .ToListAsync();
        }
    }
}
