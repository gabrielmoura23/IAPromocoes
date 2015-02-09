using System;
using System.Collections.Generic;
using IAPromocoes.Application.Validation;
using IAPromocoes.Application.ViewModels;

namespace IAPromocoes.Application.Interfaces
{
    public interface IStatusPedidoAppService : IDisposable
    {
        ValidationAppResult Add(StatusPedidoViewModel modelViewModel);
        StatusPedidoViewModel GetById(Guid id);
        StatusPedidoViewModel GetByIdTipoInteiro(int id);
        IEnumerable<StatusPedidoViewModel> GetAll();
        void Update(StatusPedidoViewModel modelViewModel);
        void Remove(StatusPedidoViewModel modelViewModel);
    }
}
