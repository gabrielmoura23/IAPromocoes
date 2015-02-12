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
    public class ProdutoImagemAppService : AppServiceBase<IAPromocoesContext>, IProdutoImagemAppService
    {
        private readonly IProdutoImagemService _modelService;

        public ProdutoImagemAppService(IProdutoImagemService modelService)
        {
            _modelService = modelService;
        }

        public ValidationAppResult Add(ProdutoImagemViewModel modelViewModel)
        {
            var model = Mapper.Map<ProdutoImagemViewModel, ProdutoImagem>(modelViewModel);

            BeginTransaction();

            var result = _modelService.AdicionarProdutoImagem(model);
            if (!result.IsValid)
                return DomainToApplicationResult(result);

            Commit();

            return DomainToApplicationResult(result);
        }

        public ProdutoImagemViewModel GetById(Guid id)
        {
            return Mapper.Map<ProdutoImagem, ProdutoImagemViewModel>(_modelService.GetById(id));
        }

        public ProdutoImagemViewModel GetByIdTipoInteiro(int id)
        {
            return Mapper.Map<ProdutoImagem, ProdutoImagemViewModel>(_modelService.GetByIdTipoInteiro(id));
        }

        public IEnumerable<ProdutoImagemViewModel> GetAll()
        {
            return Mapper.Map<IEnumerable<ProdutoImagem>, IEnumerable<ProdutoImagemViewModel>>(_modelService.GetAll());
        }

        public void Update(ProdutoImagemViewModel modelViewModel)
        {
            var model = Mapper.Map<ProdutoImagemViewModel, ProdutoImagem>(modelViewModel);

            BeginTransaction();
            _modelService.Update(model);
            Commit();
        }

        public void Remove(ProdutoImagemViewModel modelViewModel)
        {
            var model = Mapper.Map<ProdutoImagemViewModel, ProdutoImagem>(modelViewModel);

            BeginTransaction();
            _modelService.Remove(model);
            Commit();
        }

        public void Dispose()
        {
            _modelService.Dispose();
        }


        public IEnumerable<ProdutoImagemViewModel> BuscarImagensPorIdProduto(Guid idProduto)
        {
            return Mapper.Map<IEnumerable<ProdutoImagem>, IEnumerable<ProdutoImagemViewModel>>(_modelService.BuscarImagensPorIdProduto(idProduto));
        }
    }
}
