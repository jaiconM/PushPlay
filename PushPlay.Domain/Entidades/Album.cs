namespace PushPlay.Domain.Entidades
{
    public class Album
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string LinkFoto { get; set; }
        public int Ano { get; set; }
        public Artista Artista { get; set; } = new Artista();
        public IEnumerable<Musica> Musicas { get; set; } = new List<Musica>();
        public int QuantidadeDeMusicas => Musicas.Count();
    }
}