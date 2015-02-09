using System.Data.Entity.ModelConfiguration;
using IAPromocoes.Domain.Entities;

namespace IAPromocoes.Infra.Data.EntityConfig
{
    public class StatusPedidoConfiguration : EntityTypeConfiguration<StatusPedido>
    {
        public StatusPedidoConfiguration()
        {
            ToTable("Tab_StatusPedido");

            HasKey(c => c.IdStatusPedido);

            Property(c => c.Descricao)
                .IsRequired()
                .HasMaxLength(200);

            Property(c => c.FlgAtivo)
                .IsRequired();

            Ignore(t => t.ResultadoValidacao);
        }
    }
}
