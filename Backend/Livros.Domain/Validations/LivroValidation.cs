using FluentValidation;
using Livros.Domain.Commands;

namespace Livros.Domain.Validations
{
    internal class LivroValidation<T> : AbstractValidator<T> where T : LivroCommand
    {
        protected void ValidateName()
        {
            RuleFor(c => c.Nome)
                .NotEmpty().WithMessage("O nome não pode ser vazio")
                .Length(2, 50).WithMessage("O nome deve ter entre 2 e 50 caracteres");
        }

        protected void ValidateAutor()
        {
            RuleFor(c => c.Autor)
                .NotEmpty().WithMessage("O autor não pode ser vazio")
                .Length(2, 50).WithMessage("O autor deve ter entre 2 e 50 caracteres");
        }

        protected void ValidateCategoria()
        {
            RuleFor(c => c.Categoria)
                .NotEmpty().WithMessage("A categoria não pode ser vazio")
                .Length(2, 50).WithMessage("a categoria deve ter entre 2 e 50 caracteres");
        }

        protected void ValidateId()
        {
            RuleFor(c => c.Id)
                .GreaterThan(0);
        }
    }
}
