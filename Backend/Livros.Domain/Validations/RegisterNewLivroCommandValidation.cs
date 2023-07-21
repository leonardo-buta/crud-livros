using Livros.Domain.Commands;

namespace Livros.Domain.Validations
{
    internal class RegisterNewLivroCommandValidation : LivroValidation<RegisterNewLivroCommand>
    {
        public RegisterNewLivroCommandValidation()
        {
            ValidateName();
            ValidateAutor();
            ValidateCategoria();
        }
    }
}
