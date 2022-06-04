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
        public IEnumerable<Album> Albuns { get; set; } = new List<Album>();
        public IEnumerable<Musica> Musicas => Albuns.SelectMany(album => album.Musicas); 
    }
}