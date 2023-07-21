using Livros.Domain.Commands;

namespace Livros.Domain.Validations
{
    internal class RemoveLivroCommandValidation : LivroValidation<RemoveLivroCommand>
    {
        public RemoveLivroCommandValidation()
        {
            ValidateId();
        }
    }
}
