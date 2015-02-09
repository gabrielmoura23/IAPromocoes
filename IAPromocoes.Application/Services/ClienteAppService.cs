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
    public class ClienteAppService : AppServiceBase<IAPromocoesContext>, IClienteAppService
    {
        private readonly IClienteService _modelService;

        public ClienteAppService(IClienteService modelService)
        {
            _modelService = modelService;
        }

        public ValidationAppResult Add(ClienteViewModel modelViewModel)
        {
            var model = Mapper.Map<ClienteViewModel, Cliente>(modelViewModel);

            BeginTransaction();

            var result = _modelService.AdicionarCliente(model);
            if (!result.IsValid)
                return DomainToApplicationResult(result);

            Commit();

            return DomainToApplicationResult(result);
        }

        public ClienteViewModel GetById(Guid id)
        {
            return Mapper.Map<Cliente, ClienteViewModel>(_modelService.GetById(id));
        }

        public ClienteViewModel GetByIdTipoInteiro(int id)
        {
            return Mapper.Map<Cliente, ClienteViewModel>(_modelService.GetByIdTipoInteiro(id));
        }

        public IEnumerable<ClienteViewModel> GetAll()
        {
            return Mapper.Map<IEnumerable<Cliente>, IEnumerable<ClienteViewModel>>(_modelService.GetAll());
        }

        public void Update(ClienteViewModel modelViewModel)
        {
            var model = Mapper.Map<ClienteViewModel, Cliente>(modelViewModel);

            BeginTransaction();
            _modelService.Update(model);
            Commit();
        }

        public void Remove(ClienteViewModel modelViewModel)
        {
            var model = Mapper.Map<ClienteViewModel, Cliente>(modelViewModel);

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
