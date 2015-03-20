using System;
using System.Collections.Generic;
using IAPromocoes.Domain.Entities;

namespace IAPromocoes.Domain.Interfaces.Repository.ReadOnly
{
    public interface IEstadoReadOnlyRepository
    {
        Estado GetByIdTipoString(string id);
        IEnumerable<Estado> GetAll(); 
    }
}
