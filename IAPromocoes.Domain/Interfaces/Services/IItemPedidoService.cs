using System.Collections.Generic;
using IAPromocoes.Domain.Entities;
using IAPromocoes.Domain.ValueObjects;
using System;

namespace IAPromocoes.Domain.Interfaces.Services
{
    public interface IItemPedidoService : IServiceBase<ItemPedido>
    {
        ValidationResult AdicionarItemPedido(ItemPedido model);
        ValidationResult CancelarItemPedido(ItemPedido model, Guid idUsuarioAlteracao);
        IEnumerable<ItemPedido> BuscarItensPorIdPedido(Guid idPedido);
    }
}
