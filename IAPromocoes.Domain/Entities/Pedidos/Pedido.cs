using IAPromocoes.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IAPromocoes.Domain.Entities
{
    public class Pedido
    {
        public Pedido()
        {
            this.ItensPedido = new List<ItemPedido>();
        }

        public Guid IdPedido { get; set; }
        public Guid IdCliente { get; set; }
        public int IdStatusPedido { get; set; }
        public int IdFormaDePagamento { get; set; }
        public string OutrasInformacoes { get; set; }
        public System.DateTime DataPedido { get; set; }
        public System.DateTime HoraPedido { get; set; }
        public System.Nullable<System.DateTime> DtPagamento { get; set; }
        public System.Nullable<Decimal> ValorTotal { get; set; }
        public System.DateTime DtCadastro { get; set; }
        public System.Nullable<Guid> IdUsuarioAlteracao { get; set; }
        public System.Nullable<System.DateTime> DtAlteracao { get; set; }

        public virtual StatusPedido StatusPedido { get; set; }
        public virtual FormaDePagamento FormaDePagamento { get; set; }
        public virtual Cliente Cliente { get; set; }
        public virtual ICollection<ItemPedido> ItensPedido { get; set; }

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
