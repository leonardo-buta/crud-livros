using Livro.Data.Context;
using Livros.Domain.Interfaces;

namespace Livros.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly LivrosDbContext _context;

        public UnitOfWork(LivrosDbContext context)
        {
            _context = context;
        }

        public bool Commit()
        {
            return _context.SaveChanges() > 0;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
