using PushPlay.CrossCutting.BaseEntity;

namespace PushPlay.Domain.AlbumContext
{
    public class EstiloMusical : Entity<Guid>
    {
        public string Nome { get; set; }
    }
}