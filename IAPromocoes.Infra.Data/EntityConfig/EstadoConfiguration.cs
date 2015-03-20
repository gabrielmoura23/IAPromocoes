using System.Data.Entity.ModelConfiguration;
using IAPromocoes.Domain.Entities;

namespace IAPromocoes.Infra.Data.EntityConfig
{
    public class EstadoConfiguration : EntityTypeConfiguration<Estado>
    {
        public EstadoConfiguration()
        {
            ToTable("Tab_Estado");

            HasKey(c => c.IdEstado);

            Property(c => c.IdEstado)
                .HasMaxLength(2);

            Property(c => c.Descricao)
                .IsRequired()
                .HasMaxLength(200);

            Property(c => c.FlgAtivo)
                .IsRequired();

            Property(c => c.Ordem)
                .IsRequired();
            
        }
    }
}
