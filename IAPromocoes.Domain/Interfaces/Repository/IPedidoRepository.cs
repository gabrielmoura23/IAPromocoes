using IAPromocoes.Domain.Entities;
using System;
using System.Collections.Generic;

namespace IAPromocoes.Domain.Interfaces.Repository
{
    public interface IPedidoRepository : IRepositoryBase<Pedido>
    {
        IEnumerable<Pedido> BuscarPedidosPorIdCliente(Guid idCliente);
    }
}
