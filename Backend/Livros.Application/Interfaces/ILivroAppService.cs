using Livros.Application.DTO;

namespace Livros.Application.Interfaces
{
    public interface ILivroAppService : IDisposable
    {
        void Register(LivroDTO livroViewModel);
        IEnumerable<LivroDTO> GetAll();
        LivroDTO GetById(int id);
        void Update(LivroDTO livroViewModel);
        void Remove(int id);
    }
}
