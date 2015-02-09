using System.Data.Entity.ModelConfiguration;
using IAPromocoes.Domain.Entities;

namespace IAPromocoes.Infra.Data.EntityConfig
{
    public class CategoriaConfiguration : EntityTypeConfiguration<Categoria>
    {
        public CategoriaConfiguration()
        {
            ToTable("Tab_Categoria");

            HasKey(c => c.IdCategoria);

            Property(c => c.Descricao)
                .IsRequired()
                .HasMaxLength(200);

            Property(c => c.FlgAtivo)
                .IsRequired();

            Ignore(t => t.ResultadoValidacao);
        }
    }
}
