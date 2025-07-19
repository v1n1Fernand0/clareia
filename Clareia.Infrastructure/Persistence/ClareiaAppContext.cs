using Clareia.Domain.Entities;
using Clareia.Infrastructure.Configurations;
using Clareia.Infrastructure.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Clareia.Infrastructure.Persistence
{
    public class ClareiaAppContext : DbContext
    {
        public ClareiaAppContext(DbContextOptions<ClareiaAppContext> options)
            : base(options)
        {
        }

        public DbSet<Termo> Termos { get; set; }
        public DbSet<ColaboradorLeitura> Leituras { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TermoConfiguration());
            modelBuilder.ApplyConfiguration(new ColaboradorLeituraConfiguration());
            base.OnModelCreating(modelBuilder);
        }

    }
}
