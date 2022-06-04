using FluentValidation;
using PushPlay.CrossCutting.Utils;
using PushPlay.Domain.ValueObjects;
using SpotifyLite.Domain.Account.Rules;

namespace PushPlay.Domain.Entidades
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public Email Email { get; set; }
        public Senha Senha { get; set; }
        public string LinkFoto { get; set; }
        public IList<PlayList> PlayLists { get; set; }

        public Usuario()
        {
            PlayLists = new List<PlayList>();
        }

        public void SetPassword() => Senha.Valor = SecurityUtils.HashSHA1(Senha.Valor);

        public void Validate() => new UsuarioValidator().ValidateAndThrow(this);

    }
}