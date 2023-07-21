using FluentValidation.Results;
using MediatR;

namespace Livros.Domain.Core.Commands
{
    public abstract class Command : IRequest<bool>
    {
        public ValidationResult ValidationResult { get; set; }

        public abstract bool IsValid();
    }
}
