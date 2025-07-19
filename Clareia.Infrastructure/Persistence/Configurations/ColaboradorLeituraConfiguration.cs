using Clareia.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Clareia.Infrastructure.Persistence.Configurations;

public class ColaboradorLeituraConfiguration : IEntityTypeConfiguration<ColaboradorLeitura>
{
    public void Configure(EntityTypeBuilder<ColaboradorLeitura> builder)
    {
        builder.HasKey(l => l.Id);

        builder.Property(l => l.Id)
            .ValueGeneratedOnAdd();

        builder.Property(l => l.TermoId)
            .IsRequired();

        builder.Property(l => l.ColaboradorEmail)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(l => l.Compreendido)
            .IsRequired();

        builder.Property(l => l.LidoEm)
            .IsRequired();
    }
}
