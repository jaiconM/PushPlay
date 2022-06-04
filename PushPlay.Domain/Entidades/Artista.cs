using PushPlay.Domain.Enums;

namespace PushPlay.Domain.Entidades
{
    public class Artista
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string LinkFoto { get; set; }
        public TipoArtista Tipo { get; set; }
        public IList<Album> Albuns { get; set; }

        public Artista(string nome)
        {
            Nome = nome;
            Albuns = new List<Album>();
        }

        public Artista(string nome, Album album)
        {
            Nome = nome;
            Albuns = new List<Album> { album };
        }
    }
}