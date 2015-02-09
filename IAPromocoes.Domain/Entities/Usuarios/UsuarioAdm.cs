using IAPromocoes.Domain.Validation;
using IAPromocoes.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IAPromocoes.Domain.Entities
{
    public class UsuarioAdm //: IdentityUser<Guid, IdentityUserLogin, IdentityUserRole, IdentityUserClaim>
    {
        public UsuarioAdm()
        {
            
        }

        public Guid IdUsuarioAdm { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Cpf { get; set; }
        public string Sexo { get; set; }
        public System.DateTime DataNascimento { get; set; }
        public string Email { get; set; }
        public string DddTelefone { get; set; }
        public string Telefone { get; set; }
        public string DddCelular { get; set; }
        public string Celular { get; set; }
        public string LinkImagem { get; set; }
        public string LinkFacebook { get; set; }
        public string Senha { get; set; }
        public bool FlgAceitoTermos { get; set; }
        public bool FlgAceitoNewsletter { get; set; }
        public bool FlgAtivo { get; set; }
        public System.DateTime DtCadastro { get; set; }
        public System.Nullable<Guid> IdUsuarioAlteracao { get; set; }
        public System.Nullable<System.DateTime> DtAlteracao { get; set; }

        public ValidationResult ResultadoValidacao { get; private set; }
        public bool IsValid()
        {
            //var fiscal = new ClienteEstaAptoParaCadastroNoSistema();
            //ResultadoValidacao = fiscal.Validar(this);
            //return ResultadoValidacao.IsValid;
            return true;
        }
    }
}
