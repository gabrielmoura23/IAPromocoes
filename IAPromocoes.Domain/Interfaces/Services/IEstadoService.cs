using System.Collections.Generic;
using IAPromocoes.Domain.Entities;
using IAPromocoes.Domain.ValueObjects;
using System;

namespace IAPromocoes.Domain.Interfaces.Services
{
    public interface IEstadoService : IServiceBase<Estado>
    {
        Estado GetByIdTipoString(string id);
    }
}
