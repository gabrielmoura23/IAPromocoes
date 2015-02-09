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
    public class StatusPedidoAppService : AppServiceBase<IAPromocoesContext>, IStatusPedidoAppService
    {
        private readonly IStatusPedidoService _modelService;

        public StatusPedidoAppService(IStatusPedidoService modelService)
        {
            _modelService = modelService;
        }

        public ValidationAppResult Add(StatusPedidoViewModel modelViewModel)
        {
            var model = Mapper.Map<StatusPedidoViewModel, StatusPedido>(modelViewModel);

            BeginTransaction();

            var result = _modelService.AdicionarStatusPedido(model);
            if (!result.IsValid)
                return DomainToApplicationResult(result);

            Commit();

            return DomainToApplicationResult(result);
        }

        public StatusPedidoViewModel GetById(Guid id)
        {
            return Mapper.Map<StatusPedido, StatusPedidoViewModel>(_modelService.GetById(id));
        }

        public StatusPedidoViewModel GetByIdTipoInteiro(int id)
        {
            return Mapper.Map<StatusPedido, StatusPedidoViewModel>(_modelService.GetByIdTipoInteiro(id));
        }

        public IEnumerable<StatusPedidoViewModel> GetAll()
        {
            return Mapper.Map<IEnumerable<StatusPedido>, IEnumerable<StatusPedidoViewModel>>(_modelService.GetAll());
        }

        public void Update(StatusPedidoViewModel modelViewModel)
        {
            var model = Mapper.Map<StatusPedidoViewModel, StatusPedido>(modelViewModel);

            BeginTransaction();
            _modelService.Update(model);
            Commit();
        }

        public void Remove(StatusPedidoViewModel modelViewModel)
        {
            var model = Mapper.Map<StatusPedidoViewModel, StatusPedido>(modelViewModel);

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
