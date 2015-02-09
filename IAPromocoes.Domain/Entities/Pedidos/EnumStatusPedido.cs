using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IAPromocoes.Domain.Entities
{
    public class EnumStatusPedido
    {
        public enum StatusPedido { Cancelado = 1, Pendente = 2, AguardandoAprovação = 3, Pago = 4, Rejeitado = 5, Erro = 6 };
    }
}
