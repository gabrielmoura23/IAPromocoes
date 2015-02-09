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
    public class PedidoAppService : AppServiceBase<IAPromocoesContext>, IPedidoAppService
    {
        private readonly IPedidoService _modelService;

        public PedidoAppService(IPedidoService modelService)
        {
            _modelService = modelService;
        }

        public ValidationAppResult Add(PedidoViewModel modelViewModel)
        {
            var model = Mapper.Map<PedidoViewModel, Pedido>(modelViewModel);

            BeginTransaction();

            var result = _modelService.AdicionarPedido(model);
            if (!result.IsValid)
                return DomainToApplicationResult(result);

            Commit();

            return DomainToApplicationResult(result);
        }

        public PedidoViewModel GetById(Guid id)
        {
            return Mapper.Map<Pedido, PedidoViewModel>(_modelService.GetById(id));
        }

        public PedidoViewModel GetByIdTipoInteiro(int id)
        {
            return Mapper.Map<Pedido, PedidoViewModel>(_modelService.GetByIdTipoInteiro(id));
        }

        public IEnumerable<PedidoViewModel> GetAll()
        {
            return Mapper.Map<IEnumerable<Pedido>, IEnumerable<PedidoViewModel>>(_modelService.GetAll());
        }

        public IEnumerable<PedidoViewModel> BuscarPedidosPorIdCliente(Guid idCliente)
        {
            return Mapper.Map<IEnumerable<Pedido>, IEnumerable<PedidoViewModel>>(_modelService.BuscarPedidosPorIdCliente(idCliente));
        }

        public void Update(PedidoViewModel modelViewModel)
        {
            var model = Mapper.Map<PedidoViewModel, Pedido>(modelViewModel);

            BeginTransaction();
            _modelService.Update(model);
            Commit();
        }

        public void Remove(PedidoViewModel modelViewModel)
        {
            var model = Mapper.Map<PedidoViewModel, Pedido>(modelViewModel);

            BeginTransaction();
            _modelService.Remove(model);
            Commit();
        }

        public ValidationAppResult CancelarPedido(PedidoViewModel modelViewModel, Guid IdUsuarioAlteracao)
        {
            var model = Mapper.Map<PedidoViewModel, Pedido>(modelViewModel);

            BeginTransaction();

            var result = _modelService.CancelarPedido(model, IdUsuarioAlteracao);
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

        public ValidationAppResult FinalizarPedido(PedidoViewModel modelViewModel)
        {
            throw new NotImplementedException();
        }
    }
}
