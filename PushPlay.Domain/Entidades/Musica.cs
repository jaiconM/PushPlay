using PushPlay.Domain.ValueObjects;

namespace PushPlay.Domain.Entidades
{
    public class Musica
    {
        public int Id { get; set; }
        public int Sequencia { get; set; }
        public string Nome { get; set; }
        public Duracao Duracao { get; set; }

    }
}