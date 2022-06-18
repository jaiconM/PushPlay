using PushPlay.CrossCutting.Entity;

namespace PushPlay.Domain.Entidades
{
    public class PlayList : Entity<Guid>
    {
        public string Nome { get; set; }
        public IList<Musica> Musicas { get; set; }
        public IList<Usuario> Seguidores { get; set; }

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