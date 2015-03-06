using System.Data.Entity.ModelConfiguration;
using IAPromocoes.Domain.Entities;

namespace IAPromocoes.Infra.Data.EntityConfig
{
    public class ProdutoConfiguration : EntityTypeConfiguration<Produto>
    {
        public ProdutoConfiguration()
        {
            ToTable("Tab_Produto");

            HasKey(c => c.IdProduto);
                       
            Property(c => c.IdCategoria)
                .IsRequired();

            Property(c => c.Descricao)
                .IsRequired()
                .HasMaxLength(200);

            Property(c => c.SubDescricao)
                .IsRequired()
                .HasMaxLength(100);
            
            Property(c => c.LinkImagem)
                .HasMaxLength(255);

            Property(c => c.Atracao)
                .HasMaxLength(200);

            Property(c => c.Dia)
                .HasMaxLength(100);

            Property(c => c.DataTexto)
                .HasMaxLength(200);

            Property(c => c.Local)
                .HasMaxLength(200);

            Property(c => c.PrecoTexto)
                .HasMaxLength(50);

            Property(c => c.InstrucoesOutros)
                .HasMaxLength(null);

            Property(c => c.FlgAtivo)
                .IsRequired();

            Property(c => c.FlgEmPromocao)
                .IsRequired();
             
            Ignore(t => t.ResultadoValidacao);

            this.HasRequired(t => t.Categoria)
                .WithMany(t => t.Produtos)
                .HasForeignKey(d => d.IdCategoria);
        }
    }
}
