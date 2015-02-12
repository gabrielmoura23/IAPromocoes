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
    public class ProdutoPrecoAppService : AppServiceBase<IAPromocoesContext>, IProdutoPrecoAppService
    {
        private readonly IProdutoPrecoService _modelService;

        public ProdutoPrecoAppService(IProdutoPrecoService modelService)
        {
            _modelService = modelService;
        }

        public ValidationAppResult Add(ProdutoPrecoViewModel modelViewModel)
        {
            var model = Mapper.Map<ProdutoPrecoViewModel, ProdutoPreco>(modelViewModel);

            BeginTransaction();

            var result = _modelService.AdicionarProdutoPreco(model);
            if (!result.IsValid)
                return DomainToApplicationResult(result);

            Commit();

            return DomainToApplicationResult(result);
        }

        public ProdutoPrecoViewModel GetById(Guid id)
        {
            return Mapper.Map<ProdutoPreco, ProdutoPrecoViewModel>(_modelService.GetById(id));
        }

        public ProdutoPrecoViewModel GetByIdTipoInteiro(int id)
        {
            return Mapper.Map<ProdutoPreco, ProdutoPrecoViewModel>(_modelService.GetByIdTipoInteiro(id));
        }

        public IEnumerable<ProdutoPrecoViewModel> GetAll()
        {
            return Mapper.Map<IEnumerable<ProdutoPreco>, IEnumerable<ProdutoPrecoViewModel>>(_modelService.GetAll());
        }

        public void Update(ProdutoPrecoViewModel modelViewModel)
        {
            var model = Mapper.Map<ProdutoPrecoViewModel, ProdutoPreco>(modelViewModel);

            BeginTransaction();
            _modelService.Update(model);
            Commit();
        }

        public void Remove(ProdutoPrecoViewModel modelViewModel)
        {
            var model = Mapper.Map<ProdutoPrecoViewModel, ProdutoPreco>(modelViewModel);

            BeginTransaction();
            _modelService.Remove(model);
            Commit();
        }

        public void Dispose()
        {
            _modelService.Dispose();
        }


        public IEnumerable<ProdutoPrecoViewModel> BuscarPrecosPorIdProduto(Guid idProduto)
        {
            return Mapper.Map<IEnumerable<ProdutoPreco>, IEnumerable<ProdutoPrecoViewModel>>(_modelService.BuscarPrecosPorIdProduto(idProduto));
        }
    }
}
