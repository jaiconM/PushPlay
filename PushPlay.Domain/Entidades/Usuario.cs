namespace PushPlay.Domain.Entidades
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string LinkFoto { get; set; }
        public IList<PlayList> PlayLists { get; set; }
        
        public Usuario()
        {
            PlayLists = new List<PlayList>();
        }
    }
}