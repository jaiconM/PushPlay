using PushPlay.CrossCutting.Entity;

namespace PushPlay.Domain.AlbumContext
{
    public class EstiloMusical : Entity<Guid>
    {
        public string Nome { get; set; }
    }
}