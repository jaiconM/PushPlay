namespace PushPlay.Domain.Entidades
{
    public class PlayList
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public IList<Musica> Musicas { get; set; }

        public PlayList()
        {
            Musicas = new List<Musica>();
        }

        public PlayList(string nome, IList<Musica> musicas)
        {
            Nome = nome;
            Musicas = musicas;
        }

    }
}