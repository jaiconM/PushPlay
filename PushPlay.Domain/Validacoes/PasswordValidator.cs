using FluentValidation;
using PushPlay.Domain.ValueObjects;
using System.Text.RegularExpressions;

namespace SpotifyLite.Domain.Account.Rules
{
    public class SenhaValidator : AbstractValidator<Senha>
    {
        private const string Pattern = @"^(?=.*[A-Za-z])(?=.*\d)(?=.*[@$!%*#?&])[A-Za-z\d@$!%*#?&]{8,}$";

        public SenhaValidator()
        {
            RuleFor(senha => senha.Valor)
                .NotEmpty()
                .Must(BeValidPassword).WithMessage("A Senha deve ter no mínimo 8 caracteres, uma letra, um caracter especial e um número");
        }

        private bool BeValidPassword(string valor) => Regex.IsMatch(valor, Pattern);
    }
}
