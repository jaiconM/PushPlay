using FluentValidation;
using PushPlay.CrossCutting.Entity;
using PushPlay.CrossCutting.Utils;
using PushPlay.Domain.ContaContext.Validacoes;
using PushPlay.Domain.ContaContext.ValueObjects;

namespace PushPlay.Domain.ContaContext
{
    public class Usuario : Entity<Guid>
    {
        public string Nome { get; set; }
        public Email Email { get; set; }
        public Senha Senha { get; set; }
        public string LinkFoto { get; set; }
        public IList<PlayList> PlayLists { get; set; }
        public IList<PlayList> PlayListsQueSegue { get; set; }

        public Usuario()
        {
            PlayLists = new List<PlayList>();
        }

        public void SetPassword() => Senha.Valor = SecurityUtils.HashSHA1(Senha.Valor);

        public void Validate() => new UsuarioValidator().ValidateAndThrow(this);

    }
}