using System;
using System.Collections.Generic;
using IAPromocoes.Application.Validation;
using IAPromocoes.Application.ViewModels;

namespace IAPromocoes.Application.Interfaces
{
    public interface IClienteAppService : IDisposable
    {
        ValidationAppResult Add(ClienteViewModel modelViewModel);
        ClienteViewModel GetById(Guid id);
        ClienteViewModel GetByIdTipoInteiro(int id);
        IEnumerable<ClienteViewModel> GetAll();
        void Update(ClienteViewModel modelViewModel);
        void Remove(ClienteViewModel modelViewModel);
    }
}
