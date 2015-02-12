using System;
using System.Collections.Generic;
using IAPromocoes.Application.Validation;
using IAPromocoes.Application.ViewModels;

namespace IAPromocoes.Application.Interfaces
{
    public interface IProdutoImagemAppService : IDisposable
    {
        ValidationAppResult Add(ProdutoImagemViewModel modelViewModel);
        ProdutoImagemViewModel GetById(Guid id);
        ProdutoImagemViewModel GetByIdTipoInteiro(int id);
        IEnumerable<ProdutoImagemViewModel> GetAll();
        void Update(ProdutoImagemViewModel modelViewModel);
        void Remove(ProdutoImagemViewModel modelViewModel);
        IEnumerable<ProdutoImagemViewModel> BuscarImagensPorIdProduto(Guid idProduto);
    }
}
