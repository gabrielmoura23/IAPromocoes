using IAPromocoes.Domain.Validation;
using IAPromocoes.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IAPromocoes.Domain.Entities
{
    public class ProdutoImagem
    {
        public ProdutoImagem()
        {
            //this.ItemPedido = new List<ItemPedido>();
        }

        public Guid IdProdutoImagem { get; set; }
        public Guid IdProduto { get; set; }
        public string CaminhoFisico { get; set; }
        public string Descricao { get; set; }
        public int Ordem { get; set; }
        public bool FotoPrincipal { get; set; }
        public Guid IdUsuarioCadastro { get; set; }
        public System.DateTime DtCadastro { get; set; }
        public System.Nullable<Guid> IdUsuarioAlteracao { get; set; }
        public System.Nullable<System.DateTime> DtAlteracao { get; set; }

        public virtual Produto Produto { get; set; }

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
