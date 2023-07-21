using Livros.Domain.Validations;

namespace Livros.Domain.Commands
{
    public class UpdateLivroCommand : LivroCommand
    {
        public UpdateLivroCommand(int id, string nome, string autor, string categoria, bool ativo)
        {
            Id = id;
            Nome = nome;
            Autor = autor;
            Categoria = categoria;
            Ativo = ativo;
        }

        public override bool IsValid()
        {
            ValidationResult = new UpdateLivroCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
