using System.Data.Entity.ModelConfiguration;
using IAPromocoes.Domain.Entities;

namespace IAPromocoes.Infra.Data.EntityConfig
{
    public class CidadeConfiguration : EntityTypeConfiguration<Cidade>
    {
        public CidadeConfiguration()
        {
            ToTable("Tab_Cidade");

            HasKey(c => c.IdCidade);

            Property(c => c.IdEstado)
                .IsRequired()
                .HasMaxLength(2);

            Property(c => c.Descricao)
                .IsRequired()
                .HasMaxLength(200);

            Property(c => c.FlgAtivo)
                .IsRequired();

            Property(c => c.Ordem)
                .IsRequired();

            this.HasRequired(t => t.Estado)
                .WithMany(t => t.Cidades)
                .HasForeignKey(d => d.IdEstado);
        }
    }
}
