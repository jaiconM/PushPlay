namespace PushPlay.Domain.Entidades
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Login { get; set; }
        public int Senha { get; set; }
        public string LinkFoto { get; set; }
        public IEnumerable<PlayList> PlayLists { get; set; } = new List<PlayList>();
    }
}