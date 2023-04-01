using Livraria.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Livraria.Configuration
{
    public class AutorConfiguration : IEntityTypeConfiguration<Autor>
    {
        public void Configure(EntityTypeBuilder<Autor> builder)
        {
            builder.ToTable("AUTOR");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnName("ID").HasColumnType("integer").ValueGeneratedOnAdd();
            builder.Property(x => x.Nome).HasColumnName("NOME").HasColumnType("nvarchar(100)").IsRequired();
            builder.Property(x => x.CPF).HasColumnName("CPF").HasColumnType("nvarchar(14)").IsRequired();
            builder.Property(x => x.Email).HasColumnName("EMAIL").HasColumnType("nvarchar(50)").IsRequired();
        }
    }
}
