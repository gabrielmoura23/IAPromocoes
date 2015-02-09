using System;
using System.Collections.Generic;
using IAPromocoes.Application.Validation;
using IAPromocoes.Application.ViewModels;

namespace IAPromocoes.Application.Interfaces
{
    public interface ICategoriaAppService : IDisposable
    {
        ValidationAppResult Add(CategoriaViewModel modelViewModel);
        CategoriaViewModel GetById(Guid id);
        CategoriaViewModel GetByIdTipoInteiro(int id);
        IEnumerable<CategoriaViewModel> GetAll();
        void Update(CategoriaViewModel modelViewModel);
        void Remove(CategoriaViewModel modelViewModel);
    }
}
