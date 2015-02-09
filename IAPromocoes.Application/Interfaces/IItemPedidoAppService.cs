using System;
using System.Collections.Generic;
using IAPromocoes.Application.Validation;
using IAPromocoes.Application.ViewModels;

namespace IAPromocoes.Application.Interfaces
{
    public interface IItemPedidoAppService : IDisposable
    {
        ValidationAppResult Add(ItemPedidoViewModel modelViewModel);
        ItemPedidoViewModel GetById(Guid id);
        ItemPedidoViewModel GetByIdTipoInteiro(int id);
        IEnumerable<ItemPedidoViewModel> GetAll();
        void Update(ItemPedidoViewModel modelViewModel);
        void Remove(ItemPedidoViewModel modelViewModel);

        ValidationAppResult AdicionarItemPedido(ItemPedidoViewModel modelViewModel);
        ValidationAppResult CancelarItemPedido(ItemPedidoViewModel modelViewModel, Guid idUsuarioAlteracao);
        IEnumerable<ItemPedidoViewModel> BuscarItensPorIdPedido(Guid idPedido);
        
    }
}
