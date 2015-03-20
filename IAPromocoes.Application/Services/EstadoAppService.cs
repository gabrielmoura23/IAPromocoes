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
    public class EstadoAppService : AppServiceBase<IAPromocoesContext>, IEstadoAppService
    {
        private readonly IEstadoService _modelService;

        public EstadoAppService(IEstadoService modelService)
        {
            _modelService = modelService;
        }

        public EstadoViewModel GetByIdTipoString(string id)
        {
            return Mapper.Map<Estado, EstadoViewModel>(_modelService.GetByIdTipoString(id));
        }


        public IEnumerable<EstadoViewModel> GetAll()
        {
            return Mapper.Map<IEnumerable<Estado>, IEnumerable<EstadoViewModel>>(_modelService.GetAll());
        }

        public void Dispose()
        {
            _modelService.Dispose();
        }
    }
}
