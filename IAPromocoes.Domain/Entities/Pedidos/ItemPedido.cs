using IAPromocoes.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IAPromocoes.Domain.Entities
{
    public class ItemPedido
    {
        public ItemPedido()
        {

        }

        public Guid IdItemPedido { get; set; }
        public Guid IdPedido { get; set; }
        public Guid IdProduto { get; set; }
        public decimal ValorUnitario { get; set; }
        public int QtdProduto { get; set; }
                
        public Guid IdUsuarioCadastro { get; set; }
        public System.DateTime DtCadastro { get; set; }
        public System.Nullable<Guid> IdUsuarioAlteracao { get; set; }
        public System.Nullable<System.DateTime> DtAlteracao { get; set; }

        public virtual Pedido Pedido { get; set; }
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
