using PushPlay.CrossCutting.Entity;

namespace PushPlay.Domain.Entidades
{
    public class EstiloMusical : Entity<Guid>
    {
        public string Nome { get; set; }
    }
}