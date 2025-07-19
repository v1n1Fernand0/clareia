using Clareia.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Clareia.Infrastructure.Configurations;

public class TermoConfiguration : IEntityTypeConfiguration<Termo>
{
    public void Configure(EntityTypeBuilder<Termo> builder)
    {
        builder.HasKey(t => t.Id);

        builder.Property(t => t.Id)
            .ValueGeneratedOnAdd();

        builder.Property(t => t.Titulo)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(t => t.Conteudo)
            .IsRequired();

        builder.Property(t => t.CriadoEm)
            .IsRequired();

        builder.Property(t => t.ExpiraEm); 
    }
}
