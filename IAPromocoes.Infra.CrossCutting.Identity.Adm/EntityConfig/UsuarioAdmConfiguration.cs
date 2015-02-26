using System.Data.Entity.ModelConfiguration;

namespace IAPromocoes.Infra.CrossCutting.Identity.Adm.EntityConfig
{
    public class UsuarioAdmConfiguration : EntityTypeConfiguration<UsuarioAdm>
    {
        public UsuarioAdmConfiguration()
        {
            //ToTable("Tab_Cliente");

            //HasKey(c => c.IdCliente);

            Property(c => c.Nome)
                .IsRequired()
                .HasMaxLength(255);
            
            Property(c => c.Sobrenome)
                .IsRequired()
                .HasMaxLength(255);
            
            Property(c => c.Cpf)
                .IsRequired()
                .HasMaxLength(15);

            //Property(c => c.Email)
            //    .IsRequired()
            //    .HasMaxLength(255);

            Property(c => c.DddTelefone)
                .HasMaxLength(2);

            Property(c => c.Telefone)
                .HasMaxLength(15);

            Property(c => c.DddCelular)
                .HasMaxLength(2);

            Property(c => c.Celular)
                .HasMaxLength(15);
            
            //Property(c => c.Senha)
            //    .IsRequired()
            //    .HasMaxLength(50);
            
            Property(c => c.FlgAtivo)
                .IsRequired();

        }
    }
}
