using System.Data.Entity.ModelConfiguration;
using IAPromocoes.Domain.Entities;

namespace IAPromocoes.Infra.Data.EntityConfig
{
    public class ItemPedidoConfiguration : EntityTypeConfiguration<ItemPedido>
    {
        public ItemPedidoConfiguration()
        {
            ToTable("Tab_ItemPedido");

            HasKey(c => c.IdItemPedido);

            Property(c => c.IdPedido)
                .IsRequired();
         
            Property(c => c.IdProduto)
                .IsRequired();

            Property(c => c.ValorUnitario)
                .IsRequired();
            
            Property(c => c.QtdProduto)
                .IsRequired();

            Ignore(t => t.ResultadoValidacao);
            
            this.HasRequired(t => t.Pedido)
                .WithMany(t => t.ItensPedido)
                .HasForeignKey(d => d.IdPedido);

            this.HasRequired(t => t.Produto)
                .WithMany(t => t.ItensPedido)
                .HasForeignKey(d => d.IdProduto);
            
        }
    }
}
