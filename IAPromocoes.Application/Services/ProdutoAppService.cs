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
    public class ProdutoAppService : AppServiceBase<IAPromocoesContext>, IProdutoAppService
    {
        private readonly IProdutoService _modelService;

        public ProdutoAppService(IProdutoService modelService)
        {
            _modelService = modelService;
        }

        public ValidationAppResult Add(ProdutoViewModel modelViewModel)
        {
            var model = Mapper.Map<ProdutoViewModel, Produto>(modelViewModel);

            BeginTransaction();

            var result = _modelService.AdicionarProduto(model);
            if (!result.IsValid)
                return DomainToApplicationResult(result);

            Commit();

            return DomainToApplicationResult(result);
        }

        public ProdutoViewModel GetById(Guid id)
        {
            return Mapper.Map<Produto, ProdutoViewModel>(_modelService.GetById(id));
        }

        public ProdutoViewModel GetByIdTipoInteiro(int id)
        {
            return Mapper.Map<Produto, ProdutoViewModel>(_modelService.GetByIdTipoInteiro(id));
        }

        public IEnumerable<ProdutoViewModel> GetAll()
        {
            return Mapper.Map<IEnumerable<Produto>, IEnumerable<ProdutoViewModel>>(_modelService.GetAll());
        }

        public IEnumerable<ProdutoViewModel> BuscarPorDescricao(string descricao)
        {
            return Mapper.Map<IEnumerable<Produto>, IEnumerable<ProdutoViewModel>>(_modelService.BuscarPorDescricao(descricao));
        }

        public void Update(ProdutoViewModel modelViewModel)
        {
            var model = Mapper.Map<ProdutoViewModel, Produto>(modelViewModel);

            BeginTransaction();
            _modelService.Update(model);
            Commit();
        }

        public void Remove(ProdutoViewModel modelViewModel)
        {
            var model = Mapper.Map<ProdutoViewModel, Produto>(modelViewModel);

            BeginTransaction();
            _modelService.Remove(model);
            Commit();
        }

        public ValidationAppResult CancelarProduto(ProdutoViewModel modelViewModel, Guid IdUsuarioAlteracao)
        {
            var model = Mapper.Map<ProdutoViewModel, Produto>(modelViewModel);

            BeginTransaction();

            var result = _modelService.CancelarProduto(model, IdUsuarioAlteracao);
            if (!result.IsValid)
                return DomainToApplicationResult(result);

            Commit();

            return DomainToApplicationResult(result);
        }

        public void Dispose()
        {
            _modelService.Dispose();
        }
    }
}
