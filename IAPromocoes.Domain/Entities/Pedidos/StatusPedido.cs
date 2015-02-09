using IAPromocoes.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IAPromocoes.Domain.Entities
{
    public class StatusPedido
    {
        public StatusPedido()
        {
            this.Pedidos = new List<Pedido>();
        }

        public int IdStatusPedido { get; set; }
        public string Descricao { get; set; }
        public bool FlgAtivo { get; set; }
        public Guid IdUsuarioCadastro { get; set; }
        public System.DateTime DtCadastro { get; set; }
        public Guid IdUsuarioAlteracao { get; set; }
        public System.Nullable<System.DateTime> DtAlteracao { get; set; }

        public virtual ICollection<Pedido> Pedidos { get; set; }

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
