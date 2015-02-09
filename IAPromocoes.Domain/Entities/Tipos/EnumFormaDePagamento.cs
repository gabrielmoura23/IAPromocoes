using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IAPromocoes.Domain.Entities
{
    public class EnumFormaDePagamento
    {
        public enum FormaDePagamento { NaoPago = 0, Boleto = 1, CartãoDeCrédito = 2 };
    }
}
