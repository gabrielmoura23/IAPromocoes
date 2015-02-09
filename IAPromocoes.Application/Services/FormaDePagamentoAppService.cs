using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using IAPromocoes.Application.Interfaces;
using IAPromocoes.Application.Validation;
using IAPromocoes.Application.ViewModels;
using IAPromocoes.Domain.Entities;
using IAPromocoes.Domain.Interfaces.Services;
using IAPromocoes.Infra.Data.Context;

namespace IAPromocoes.Application.Services
{
    public class FormaDePagamentoAppService : AppServiceBase<IAPromocoesContext>, IFormaDePagamentoAppService
    {
        private readonly IFormaDePagamentoService _modelService;

        public FormaDePagamentoAppService(IFormaDePagamentoService modelService)
        {
            _modelService = modelService;
        }

        public ValidationAppResult Add(FormaDePagamentoViewModel modelViewModel)
        {
            var model = Mapper.Map<FormaDePagamentoViewModel, FormaDePagamento>(modelViewModel);

            BeginTransaction();

            var result = _modelService.AdicionarFormaDePagamento(model);
            if (!result.IsValid)
                return DomainToApplicationResult(result);

            Commit();

            return DomainToApplicationResult(result);
        }

        public FormaDePagamentoViewModel GetById(Guid id)
        {
            return Mapper.Map<FormaDePagamento, FormaDePagamentoViewModel>(_modelService.GetById(id));
        }

        public FormaDePagamentoViewModel GetByIdTipoInteiro(int id)
        {
            return Mapper.Map<FormaDePagamento, FormaDePagamentoViewModel>(_modelService.GetByIdTipoInteiro(id));
        }

        public IEnumerable<FormaDePagamentoViewModel> GetAll()
        {
            return Mapper.Map<IEnumerable<FormaDePagamento>, IEnumerable<FormaDePagamentoViewModel>>(_modelService.GetAll());
        }

        public void Update(FormaDePagamentoViewModel modelViewModel)
        {
            var model = Mapper.Map<FormaDePagamentoViewModel, FormaDePagamento>(modelViewModel);

            BeginTransaction();
            _modelService.Update(model);
            Commit();
        }

        public void Remove(FormaDePagamentoViewModel modelViewModel)
        {
            var model = Mapper.Map<FormaDePagamentoViewModel, FormaDePagamento>(modelViewModel);

            BeginTransaction();
            _modelService.Remove(model);
            Commit();
        }

        public void Dispose()
        {
            _modelService.Dispose();
        }
    }
}
