using Livros.Domain.Commands;
using Livros.Domain.Interfaces;
using Livros.Domain.Models;
using MediatR;

namespace Livros.Domain.CommandHandlers
{
    public class LivroCommandHandler : CommandHandler,
        IRequestHandler<RegisterNewLivroCommand, bool>,
        IRequestHandler<UpdateLivroCommand, bool>,
        IRequestHandler<RemoveLivroCommand, bool>
    {
        private readonly ILivroRepository _livroRepository;

        public LivroCommandHandler(ILivroRepository livroRepository,
                                   IUnitOfWork uow) : base(uow)
        {
            _livroRepository = livroRepository;
        }

        public Task<bool> Handle(RegisterNewLivroCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                return Task.FromResult(false);
            }

            var livro = new Livro(message.Nome, message.Autor, message.Categoria, message.Ativo);

            _livroRepository.Add(livro);

            var success = Commit();

            return Task.FromResult(success);
        }

        public Task<bool> Handle(UpdateLivroCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
                return Task.FromResult(false);

            var livro = new Livro(message.Id, message.Nome, message.Autor, message.Categoria, message.Ativo);

            _livroRepository.Update(livro);

            var success = Commit();

            return Task.FromResult(success);
        }

        public Task<bool> Handle(RemoveLivroCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
                return Task.FromResult(false);

            _livroRepository.Remove(message.Id);

            var success = Commit();

            return Task.FromResult(success);
        }

        public void Dispose()
        {
            _livroRepository.Dispose();
        }
    }
}
