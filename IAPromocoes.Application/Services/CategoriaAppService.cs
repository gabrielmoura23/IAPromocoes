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
    public class CategoriaAppService : AppServiceBase<IAPromocoesContext>, ICategoriaAppService
    {
        private readonly ICategoriaService _modelService;

        public CategoriaAppService(ICategoriaService modelService)
        {
            _modelService = modelService;
        }

        public ValidationAppResult Add(CategoriaViewModel modelViewModel)
        {
            var model = Mapper.Map<CategoriaViewModel, Categoria>(modelViewModel);

            BeginTransaction();

            var result = _modelService.AdicionarCategoria(model);
            if (!result.IsValid)
                return DomainToApplicationResult(result);

            Commit();

            return DomainToApplicationResult(result);
        }

        public CategoriaViewModel GetById(Guid id)
        {
            return Mapper.Map<Categoria, CategoriaViewModel>(_modelService.GetById(id));
        }

        public CategoriaViewModel GetByIdTipoInteiro(int id)
        {
            return Mapper.Map<Categoria, CategoriaViewModel>(_modelService.GetByIdTipoInteiro(id));
        }

        public IEnumerable<CategoriaViewModel> GetAll()
        {
            return Mapper.Map<IEnumerable<Categoria>, IEnumerable<CategoriaViewModel>>(_modelService.GetAll());
        }

        public void Update(CategoriaViewModel modelViewModel)
        {
            var model = Mapper.Map<CategoriaViewModel, Categoria>(modelViewModel);

            BeginTransaction();
            _modelService.Update(model);
            Commit();
        }

        public void Remove(CategoriaViewModel modelViewModel)
        {
            var model = Mapper.Map<CategoriaViewModel, Categoria>(modelViewModel);

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
