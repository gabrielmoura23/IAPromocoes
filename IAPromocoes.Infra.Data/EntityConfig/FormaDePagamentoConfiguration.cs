using System.Data.Entity.ModelConfiguration;
using IAPromocoes.Domain.Entities;

namespace IAPromocoes.Infra.Data.EntityConfig
{
    public class FormaDePagamentoConfiguration : EntityTypeConfiguration<FormaDePagamento>
    {
        public FormaDePagamentoConfiguration()
        {
            ToTable("Tab_FormaDePagamento");

            HasKey(c => c.IdFormaDePagamento);

            Property(c => c.Descricao)
                .IsRequired()
                .HasMaxLength(200);

            Property(c => c.FlgAtivo)
                .IsRequired();

            Ignore(t => t.ResultadoValidacao);
        }
    }
}
