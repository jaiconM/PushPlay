using PushPlay.CrossCutting.Entity;
using PushPlay.Domain.ValueObjects;

namespace PushPlay.Domain.Entidades
{
    public class Musica : Entity<Guid>
    {
        public int Sequencia { get; set; }
        public string Nome { get; set; }
        public EstiloMusical EstiloMusical { get; set; }
        public Duracao Duracao { get; set; }

    }
}