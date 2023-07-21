using Livros.Domain.Core.Commands;

namespace Livros.Domain.Commands
{
    public abstract class LivroCommand : Command
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Autor { get; set; }

        public string Categoria { get; set; }

        public bool Ativo { get; set; }
    }
}
