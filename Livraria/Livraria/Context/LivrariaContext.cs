using Livraria.Configuration;
using Livraria.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Livraria.Context
{
    public  class LivrariaContext : DbContext
    {
        public DbSet<Autor> Autores { get; set; } = default!;
        public DbSet<Livro> Livros { get; set; } = default!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AutorConfiguration());
            modelBuilder.ApplyConfiguration(new LivroConfiguration());
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            const string strConnection = "Server=localhost,1433;Database=LIVRARIA;User ID=sa;Password=1r35246$#@;Trusted_Connection=False; TrustServerCertificate=True;";

            optionsBuilder
                .UseSqlServer(strConnection)
                .LogTo(Console.WriteLine, LogLevel.Information)
                .EnableSensitiveDataLogging();
        }
    }
}
