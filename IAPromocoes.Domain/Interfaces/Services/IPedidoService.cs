using System.Collections.Generic;
using IAPromocoes.Domain.Entities;
using IAPromocoes.Domain.ValueObjects;
using System;

namespace IAPromocoes.Domain.Interfaces.Services
{
    public interface IPedidoService : IServiceBase<Pedido>
    {
        ValidationResult AdicionarPedido(Pedido model);
        ValidationResult CancelarPedido(Pedido model, Guid idUsuarioAlteracao);
        IEnumerable<Pedido> BuscarPedidosPorIdCliente(Guid idCliente);

        ValidationResult AdicionarProdutoNoCarrinho(Guid idProduto);
        ValidationResult RemoverProdutoDoCarrinho(Guid idProduto);
        ValidationResult FinalizarPedido(Pedido model);
    }
}
