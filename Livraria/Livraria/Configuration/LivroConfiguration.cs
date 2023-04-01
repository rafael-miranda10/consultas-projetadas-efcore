using Livraria.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Livraria.Configuration
{
    public class LivroConfiguration : IEntityTypeConfiguration<Livro>
    {
        public void Configure(EntityTypeBuilder<Livro> builder)
        {
            builder.ToTable("LIVRO");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnName("ID").HasColumnType("integer").ValueGeneratedOnAdd();
            builder.Property(x => x.Titulo).HasColumnName("TITULO").HasColumnType("nvarchar(100)").IsRequired();
            builder.Property(x => x.AnoPublicacao).HasColumnName("ANOPUBLICACAO").HasColumnType("integer").IsRequired();
            builder.Property(x => x.Edicao).HasColumnName("EDICAO").HasColumnType("integer").IsRequired();
            builder.Property(x => x.Editora).HasColumnName("EDITORA").HasColumnType("nvarchar(100)").IsRequired();

            builder.HasOne(x => x.Autor)
                .WithMany(x => x.Livros)
                .HasForeignKey(x => x.AutorId);
        }
    }
}
