using IAPromocoes.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IAPromocoes.Domain.Entities
{
    public class Categoria
    {
        public Categoria()
        {
            this.Produtos = new List<Produto>();
        }

        public Guid IdCategoria { get; set; }
        public string Descricao { get; set; }
        public bool FlgAtivo { get; set; }
        public Guid IdUsuarioCadastro { get; set; }
        public System.DateTime DtCadastro { get; set; }
        public System.Nullable<Guid> IdUsuarioAlteracao { get; set; }
        public System.Nullable<System.DateTime> DtAlteracao { get; set; }

        public virtual ICollection<Produto> Produtos { get; set; }

        public ValidationResult ResultadoValidacao { get; private set; }
        public bool IsValid()
        {
            //var fiscal = new ProdutoEstaAptoParaCadastroNoSistema();
            //ResultadoValidacao = fiscal.Validar(this);
            //return ResultadoValidacao.IsValid;
            return true;
        }
    }
}
