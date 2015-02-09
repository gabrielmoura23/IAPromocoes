using IAPromocoes.Domain.Entities;
using IAPromocoes.Domain.Interfaces.Repository;
using IAPromocoes.Infra.Data.Context;
using System;
using System.Collections.Generic;

namespace IAPromocoes.Infra.Data.Repositories
{
    public class ItemPedidoRepository : RepositoryBase<ItemPedido, IAPromocoesContext>, IItemPedidoRepository
    {
        public IEnumerable<ItemPedido> BuscarItensPorIdPedido(Guid idPedido)
        {
            return base.Find(c => c.IdPedido == idPedido);
        }
    }
}
