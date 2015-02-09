using System;
using System.Collections.Generic;
using IAPromocoes.Domain.Entities;

namespace IAPromocoes.Domain.Interfaces.Repository.ReadOnly
{
    public interface IClienteReadOnlyRepository
    {
        Cliente GetById(Guid id);
        IEnumerable<Cliente> GetAll(); 
    }
}
