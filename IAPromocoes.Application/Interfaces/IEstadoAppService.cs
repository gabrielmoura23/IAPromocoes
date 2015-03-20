using System;
using System.Collections.Generic;
using IAPromocoes.Application.Validation;
using IAPromocoes.Application.ViewModels;

namespace IAPromocoes.Application.Interfaces
{
    public interface IEstadoAppService : IDisposable
    {
        EstadoViewModel GetByIdTipoString(string id);
        IEnumerable<EstadoViewModel> GetAll();
    }
}
