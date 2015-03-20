using System;
using System.Collections.Generic;
using IAPromocoes.Application.Validation;
using IAPromocoes.Application.ViewModels;

namespace IAPromocoes.Application.Interfaces
{
    public interface ICidadeAppService : IDisposable
    {
        CidadeViewModel GetById(Guid id);
        IEnumerable<CidadeViewModel> GetAll();
    }
}
