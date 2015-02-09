using IAPromocoes.Domain.Validation;
using IAPromocoes.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IAPromocoes.Domain.Entities
{
    public class ProdutoPreco
    {
        public ProdutoPreco()
        {
            //this.ItemPedido = new List<ItemPedido>();
        }

        public Guid IdProdutoPreco { get; set; }
        public Guid IdProduto { get; set; }
        public string Descricao { get; set; }
        public decimal ValorUnitario { get; set; }
        public string InstrucoesValor { get; set; }
        public string InstrucoesOutros { get; set; }
        public int QtdProduto { get; set; }
        public bool FlgAtivo { get; set; }
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
