using Livros.Domain.Commands;
using Livros.Domain.Interfaces;
using Livros.Domain.Models;
using MediatR;

namespace Livros.Domain.CommandHandlers
{
    public class LivroCommandHandler : CommandHandler,
        IRequestHandler<RegisterNewLivroCommand, bool>,
        IRequestHandler<UpdateLivroCommand, bool>,
        IRequestHandler<RemoveLivroCommand, bool>,
        IRequestHandler<GetListLivrosQuery, List<Livro>>
    {
        private readonly ILivroRepository _livroRepository;
        private readonly IRedisCacheService _redisCacheService;
        private const string LIVROS_FILTER_KEY = "Livros.Filter";
        private const string LIVROS_KEY = "Livro.Autor.{0}";
        private readonly TimeSpan _expirationTime;

        public LivroCommandHandler(ILivroRepository livroRepository,
                                   IRedisCacheService redisCacheService,
                                   IUnitOfWork uow) : base(uow)
        {
            _livroRepository = livroRepository;
            _redisCacheService = redisCacheService;
            _expirationTime = TimeSpan.MaxValue;
        }

        public Task<bool> Handle(RegisterNewLivroCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                return Task.FromResult(false);
            }

            var livro = new Livro(message.Nome, message.Autor, message.Categoria, message.Ativo);

            _livroRepository.Add(livro);

            string key = string.Format(LIVROS_KEY, livro.Autor);
            _redisCacheService.Set(key, livro, _expirationTime);
            _redisCacheService.Remove(LIVROS_FILTER_KEY);

            var success = Commit();

            return Task.FromResult(success);
        }

        public Task<bool> Handle(UpdateLivroCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
                return Task.FromResult(false);

            var livro = new Livro(message.Id, message.Nome, message.Autor, message.Categoria, message.Ativo);

            _livroRepository.Update(livro);

            string key = string.Format(LIVROS_KEY, livro.Autor);
            _redisCacheService.Remove(key);
            _redisCacheService.Remove(LIVROS_FILTER_KEY);
            _redisCacheService.Set(key, livro, _expirationTime);

            var success = Commit();

            return Task.FromResult(success);
        }

        public Task<bool> Handle(RemoveLivroCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
                return Task.FromResult(false);

            _livroRepository.Remove(message.Id);

            string key = string.Format(LIVROS_KEY, message.Autor);
            _redisCacheService.Remove(key);
            _redisCacheService.Remove(LIVROS_FILTER_KEY);

            var success = Commit();

            return Task.FromResult(success);
        }

        public void Dispose()
        {
            _livroRepository.Dispose();
        }

        public Task<List<Livro>> Handle(GetListLivrosQuery request, CancellationToken cancellationToken)
        {
            var data = _redisCacheService.Get<List<Livro>>(LIVROS_FILTER_KEY);
            if (data != null)
                return Task.FromResult(data);

            data = _livroRepository.GetAll().ToList();

            if (data != null && data.Any())
            {
                _redisCacheService.Set(LIVROS_FILTER_KEY, data, _expirationTime);
                return Task.FromResult(data);
            }

            return Task.FromResult(data);
        }
    }
}
