using PushPlay.CrossCutting.BaseEntity;
using PushPlay.Domain.AlbumContext.ValueObjects;
using PushPlay.Domain.ContaContext;

namespace PushPlay.Domain.AlbumContext
{
    public class Musica : Entity<Guid>
    {
        public string Nome { get; set; }
        public EstiloMusical EstiloMusical { get; set; }
        public Duracao Duracao { get; set; }
        public IList<PlayList> PlayLists { get; set; }

        public Musica()
        {
            PlayLists = new List<PlayList>();
        }
    }
}