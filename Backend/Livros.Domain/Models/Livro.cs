namespace Livros.Domain.Models
{
    public class Livro
    {
        public Livro() { }

        public Livro(int id, string nome, string autor, string categoria, bool ativo)
        {
            Id = id;
            Nome = nome;
            Autor = autor;
            Categoria = categoria;
            Ativo = ativo;
        }

        public Livro(string nome, string autor, string categoria, bool ativo)
        {
            Nome = nome;
            Autor = autor;
            Categoria = categoria;
            Ativo = ativo;
        }

        public int Id { get; set; }

        public string? Nome { get; set; }

        public string? Autor { get; set; }

        public string? Categoria { get; set; }

        public bool Ativo { get; set; }
    }
}
