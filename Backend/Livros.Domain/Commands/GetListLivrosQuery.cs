using Livros.Domain.Models;
using MediatR;

namespace Livros.Domain.Commands
{
    public class GetListLivrosQuery : IRequest<List<Livro>>
    {
    }
}
