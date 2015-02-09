using System;
using System.Collections.Generic;
using IAPromocoes.Application.Validation;
using IAPromocoes.Application.ViewModels;

namespace IAPromocoes.Application.Interfaces
{
    public interface IProdutoAppService : IDisposable
    {
        ValidationAppResult Add(ProdutoViewModel modelViewModel);
        ProdutoViewModel GetById(Guid id);
        ProdutoViewModel GetByIdTipoInteiro(int id);
        IEnumerable<ProdutoViewModel> GetAll();
        void Update(ProdutoViewModel modelViewModel);
        void Remove(ProdutoViewModel modelViewModel);
        IEnumerable<ProdutoViewModel> BuscarPorDescricao(string descricao);
        ValidationAppResult CancelarProduto(ProdutoViewModel modelViewModel, Guid IdUsuarioAlteracao);
    }
}
