using Livro.Data.Context;
using Livros.Domain.Interfaces;

namespace Livros.Data.Repository
{
    public class LivroRepository : Repository<Domain.Models.Livro>, ILivroRepository
    {
        public LivroRepository(LivrosDbContext context)
            : base(context)
        {

        }
    }
}
