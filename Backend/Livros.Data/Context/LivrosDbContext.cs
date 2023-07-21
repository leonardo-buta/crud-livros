using Livros.Data.Mappings;
using Microsoft.EntityFrameworkCore;

namespace Livro.Data.Context
{
    public class LivrosDbContext : DbContext
    {
        public LivrosDbContext(DbContextOptions<LivrosDbContext> options) : base(options)
        {
        }

        public DbSet<Livros.Domain.Models.Livro> Livros { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new LivroMap());

            base.OnModelCreating(modelBuilder);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await SaveChangesAsync();
        }
    }
}
