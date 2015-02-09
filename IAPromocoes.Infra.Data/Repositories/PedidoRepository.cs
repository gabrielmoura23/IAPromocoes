using IAPromocoes.Domain.Entities;
using IAPromocoes.Domain.Interfaces.Repository;
using IAPromocoes.Infra.Data.Context;
using System;
using System.Collections.Generic;

namespace IAPromocoes.Infra.Data.Repositories
{
    public class PedidoRepository : RepositoryBase<Pedido, IAPromocoesContext>, IPedidoRepository
    {
        public IEnumerable<Pedido> BuscarPedidosPorIdCliente(Guid idCliente)
        {
            return base.Find(c => c.IdCliente == idCliente);
        }
    }
}
