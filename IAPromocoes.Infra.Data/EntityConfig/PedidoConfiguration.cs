using System.Data.Entity.ModelConfiguration;
using IAPromocoes.Domain.Entities;

namespace IAPromocoes.Infra.Data.EntityConfig
{
    public class PedidoConfiguration : EntityTypeConfiguration<Pedido>
    {
        public PedidoConfiguration()
        {
            ToTable("Tab_Pedido");

            HasKey(c => c.IdPedido);

            Property(c => c.IdCliente)
                .IsRequired();
            
            Property(c => c.OutrasInformacoes)
                .HasMaxLength(null);
            
            Ignore(t => t.ResultadoValidacao);

            this.HasRequired(t => t.Cliente)
                .WithMany(t => t.Pedidos)
                .HasForeignKey(d => d.IdCliente);

            this.HasRequired(t => t.StatusPedido)
                .WithMany(t => t.Pedidos)
                .HasForeignKey(d => d.IdStatusPedido);

            this.HasRequired(t => t.FormaDePagamento)
                .WithMany(t => t.Pedidos)
                .HasForeignKey(d => d.IdFormaDePagamento);
        }
    }
}
