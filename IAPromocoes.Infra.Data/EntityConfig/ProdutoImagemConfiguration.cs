using System.Data.Entity.ModelConfiguration;
using IAPromocoes.Domain.Entities;

namespace IAPromocoes.Infra.Data.EntityConfig
{
    public class ProdutoImagemConfiguration : EntityTypeConfiguration<ProdutoImagem>
    {
        public ProdutoImagemConfiguration()
        {
            ToTable("Tab_ProdutoImagem");
            
            HasKey(c => c.IdProdutoImagem);
                      
            Property(c => c.IdProduto)
                .IsRequired();

            Property(c => c.NomeArquivo)
                .IsRequired()
                .HasMaxLength(200);

            Property(c => c.Descricao)
                .IsRequired()
                .HasMaxLength(200);

            Property(c => c.CaminhoFisico)
                .IsRequired();
                    
            Property(c => c.Ordem)
                .IsRequired();

            Property(c => c.FotoPrincipal)
                .IsRequired();
                         
            Ignore(t => t.ResultadoValidacao);

            this.HasRequired(t => t.Produto)
                .WithMany(t => t.ProdutoImagens)
                .HasForeignKey(d => d.IdProduto);
        }
    }
}
