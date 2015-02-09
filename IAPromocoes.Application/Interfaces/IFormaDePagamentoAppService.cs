using System;
using System.Collections.Generic;
using IAPromocoes.Application.Validation;
using IAPromocoes.Application.ViewModels;

namespace IAPromocoes.Application.Interfaces
{
    public interface IFormaDePagamentoAppService : IDisposable
    {
        ValidationAppResult Add(FormaDePagamentoViewModel modelViewModel);
        FormaDePagamentoViewModel GetById(Guid id);
        FormaDePagamentoViewModel GetByIdTipoInteiro(int id);
        IEnumerable<FormaDePagamentoViewModel> GetAll();
        void Update(FormaDePagamentoViewModel modelViewModel);
        void Remove(FormaDePagamentoViewModel modelViewModel);
    }
}
