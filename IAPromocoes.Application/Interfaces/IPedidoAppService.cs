using System;
using System.Collections.Generic;
using IAPromocoes.Application.Validation;
using IAPromocoes.Application.ViewModels;

namespace IAPromocoes.Application.Interfaces
{
    public interface IPedidoAppService : IDisposable
    {
        ValidationAppResult Add(PedidoViewModel modelViewModel);
        PedidoViewModel GetById(Guid id);
        PedidoViewModel GetByIdTipoInteiro(int id);
        IEnumerable<PedidoViewModel> GetAll();
        void Update(PedidoViewModel modelViewModel);
        void Remove(PedidoViewModel modelViewModel);

        IEnumerable<PedidoViewModel> BuscarPedidosPorIdCliente(Guid idCliente);
        ValidationAppResult CancelarPedido(PedidoViewModel modelViewModel, Guid idUsuarioAlteracao);

        ValidationAppResult AdicionarProdutoNoCarrinho(Guid idProduto);
        ValidationAppResult RemoverProdutoDoCarrinho(Guid idProduto);
        ValidationAppResult FinalizarPedido(PedidoViewModel modelViewModel);

    }
}
