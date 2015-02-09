using IAPromocoes.Domain.Entities;
using System;
using System.Collections.Generic;

namespace IAPromocoes.Domain.Interfaces.Repository
{
    public interface IItemPedidoRepository : IRepositoryBase<ItemPedido>
    {
        IEnumerable<ItemPedido> BuscarItensPorIdPedido(Guid idPedido);
    }
}
