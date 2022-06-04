namespace PushPlay.Domain.Entidades
{
    public class PlayList
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public Usuario Usuario { get; set; } = new Usuario();
        public IEnumerable<Musica> Musicas { get; set; } = new List<Musica>();

    }
}