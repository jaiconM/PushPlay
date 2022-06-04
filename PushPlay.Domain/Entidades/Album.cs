namespace PushPlay.Domain.Entidades
{
    public class Album
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string LinkFoto { get; set; }
        public int Ano { get; set; }
        public IList<Musica> Musicas { get; set; }

        public Album(string nome, Musica musica)
        {
            Nome = nome;
            if (musica == null)
            {
                throw new ArgumentNullException("Música obrigatória");
            }
            Musicas = new List<Musica> { musica };
        }

        public Album(string nome, IList<Musica> musicas)
        {
            Nome = nome;
            if (musicas.Any() == false)
            {
                throw new ArgumentNullException("Música obrigatória");
            }
            Musicas = musicas;
        }

        public int QuatidadeDeMusicas() => Musicas.Count;
    }
}