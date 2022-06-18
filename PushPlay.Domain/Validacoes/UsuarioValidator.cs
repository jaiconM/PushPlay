using FluentValidation;
using PushPlay.Domain.Entidades;

namespace SpotifyLite.Domain.Account.Rules
{
    public class UsuarioValidator : AbstractValidator<Usuario>
    {
        public UsuarioValidator()
        {
            RuleFor(usuario => usuario.Nome).NotEmpty();
            RuleFor(usuario => usuario.Email).SetValidator(new EmailValidator());
            RuleFor(usuario => usuario.Senha).SetValidator(new SenhaValidator());
        }
    }
}
