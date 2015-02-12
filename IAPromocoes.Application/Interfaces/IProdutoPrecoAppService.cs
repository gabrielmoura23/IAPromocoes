using System;
using System.Collections.Generic;
using IAPromocoes.Application.Validation;
using IAPromocoes.Application.ViewModels;

namespace IAPromocoes.Application.Interfaces
{
    public interface IProdutoPrecoAppService : IDisposable
    {
        ValidationAppResult Add(ProdutoPrecoViewModel modelViewModel);
        ProdutoPrecoViewModel GetById(Guid id);
        ProdutoPrecoViewModel GetByIdTipoInteiro(int id);
        IEnumerable<ProdutoPrecoViewModel> GetAll();
        void Update(ProdutoPrecoViewModel modelViewModel);
        void Remove(ProdutoPrecoViewModel modelViewModel);
        IEnumerable<ProdutoPrecoViewModel> BuscarPrecosPorIdProduto(Guid idProduto);
    }
}
