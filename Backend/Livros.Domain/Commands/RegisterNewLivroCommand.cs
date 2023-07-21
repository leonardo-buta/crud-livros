using FluentValidation.Results;
using Livros.Domain.Validations;

namespace Livros.Domain.Commands
{
    public class RegisterNewLivroCommand : LivroCommand
    {
        public RegisterNewLivroCommand(string nome, string autor, string categoria, bool ativo)
        {
            Nome = nome;
            Autor = autor;
            Categoria = categoria;
            Ativo = ativo;
        }

        public override bool IsValid()
        {
            ValidationResult = new RegisterNewLivroCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
