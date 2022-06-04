namespace PushPlay.Domain.Entidades
{
    public class Musica
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public Album Album { get; set; } = new Album();
        public TimeSpan Duracao { get; set; }

    }
}