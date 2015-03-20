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
    public class CidadeAppService : AppServiceBase<IAPromocoesContext>, ICidadeAppService
    {
        private readonly ICidadeService _modelService;

        public CidadeAppService(ICidadeService modelService)
        {
            _modelService = modelService;
        }

        public CidadeViewModel GetById(Guid id)
        {
            return Mapper.Map<Cidade, CidadeViewModel>(_modelService.GetById(id));
        }


        public IEnumerable<CidadeViewModel> GetAll()
        {
            return Mapper.Map<IEnumerable<Cidade>, IEnumerable<CidadeViewModel>>(_modelService.GetAll());
        }

        public void Dispose()
        {
            _modelService.Dispose();
        }
    }
}
