using System.Data.Entity.ModelConfiguration;
using IAPromocoes.Domain.Entities;

namespace IAPromocoes.Infra.Data.EntityConfig
{
    public class ProdutoPrecoConfiguration : EntityTypeConfiguration<ProdutoPreco>
    {
        public ProdutoPrecoConfiguration()
        {
            ToTable("Tab_ProdutoPreco");
            
            HasKey(c => c.IdProdutoPreco);
                      
            Property(c => c.IdProduto)
                .IsRequired();

            Property(c => c.Descricao)
                .IsRequired()
                .HasMaxLength(200);

            Property(c => c.InstrucoesValor)
                .HasMaxLength(255);

            Property(c => c.InstrucoesOutros)
                .HasMaxLength(null);

            Property(c => c.QtdProduto)
                .IsRequired();

            Property(c => c.FlgAtivo)
                .IsRequired();
                         
            Ignore(t => t.ResultadoValidacao);

            this.HasRequired(t => t.Produto)
                .WithMany(t => t.ProdutoPrecos)
                .HasForeignKey(d => d.IdProduto);
        }
    }
}
