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
    public class ItemPedidoAppService : AppServiceBase<IAPromocoesContext>, IItemPedidoAppService
    {
        private readonly IItemPedidoService _modelService;

        public ItemPedidoAppService(IItemPedidoService modelService)
        {
            _modelService = modelService;
        }

        public ValidationAppResult Add(ItemPedidoViewModel modelViewModel)
        {
            var model = Mapper.Map<ItemPedidoViewModel, ItemPedido>(modelViewModel);

            BeginTransaction();

            var result = _modelService.AdicionarItemPedido(model);
            if (!result.IsValid)
                return DomainToApplicationResult(result);

            Commit();

            return DomainToApplicationResult(result);
        }

        public ItemPedidoViewModel GetById(Guid id)
        {
            return Mapper.Map<ItemPedido, ItemPedidoViewModel>(_modelService.GetById(id));
        }

        public ItemPedidoViewModel GetByIdTipoInteiro(int id)
        {
            return Mapper.Map<ItemPedido, ItemPedidoViewModel>(_modelService.GetByIdTipoInteiro(id));
        }

        public IEnumerable<ItemPedidoViewModel> GetAll()
        {
            return Mapper.Map<IEnumerable<ItemPedido>, IEnumerable<ItemPedidoViewModel>>(_modelService.GetAll());
        }

        public void Update(ItemPedidoViewModel modelViewModel)
        {
            var model = Mapper.Map<ItemPedidoViewModel, ItemPedido>(modelViewModel);

            BeginTransaction();
            _modelService.Update(model);
            Commit();
        }

        public void Remove(ItemPedidoViewModel modelViewModel)
        {
            var model = Mapper.Map<ItemPedidoViewModel, ItemPedido>(modelViewModel);

            BeginTransaction();
            _modelService.Remove(model);
            Commit();
        }

        public ValidationAppResult CancelarItemPedido(ItemPedidoViewModel modelViewModel, Guid IdUsuarioAlteracao)
        {
            var model = Mapper.Map<ItemPedidoViewModel, ItemPedido>(modelViewModel);

            BeginTransaction();

            var result = _modelService.CancelarItemPedido(model, IdUsuarioAlteracao);
            if (!result.IsValid)
                return DomainToApplicationResult(result);

            Commit();

            return DomainToApplicationResult(result);
        }

        public void Dispose()
        {
            _modelService.Dispose();
        }


        public ValidationAppResult AdicionarProdutoNoCarrinho(Guid idProduto)
        {
            throw new NotImplementedException();
        }

        public ValidationAppResult RemoverProdutoDoCarrinho(Guid idProduto)
        {
            throw new NotImplementedException();
        }

        public ValidationAppResult FinalizarItemPedido(ItemPedidoViewModel modelViewModel)
        {
            throw new NotImplementedException();
        }


        public ValidationAppResult AdicionarItemPedido(ItemPedidoViewModel modelViewModel)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ItemPedidoViewModel> BuscarItensPorIdPedido(Guid idPedido)
        {
            return Mapper.Map <IEnumerable<ItemPedido>, IEnumerable<ItemPedidoViewModel>>(_modelService.BuscarItensPorIdPedido(idPedido));
        }
    }
}
