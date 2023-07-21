using Livros.Domain.Validations;

namespace Livros.Domain.Commands
{
    public class RemoveLivroCommand : LivroCommand
    {
        public RemoveLivroCommand(int id)
        {
            Id = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new RemoveLivroCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
