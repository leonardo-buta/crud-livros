using Livros.Domain.Commands;

namespace Livros.Domain.Validations
{
    internal class UpdateLivroCommandValidation : LivroValidation<UpdateLivroCommand>
    {
        public UpdateLivroCommandValidation()
        {
            ValidateId();
            ValidateName();
            ValidateAutor();
            ValidateCategoria();
        }
    }
}
