using Livros.Domain.Interfaces;

namespace Livros.Domain.CommandHandlers
{
    public class CommandHandler
    {
        private readonly IUnitOfWork _uow;

        public CommandHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public bool Commit()
        {
            return _uow.Commit();
        }
    }
}
