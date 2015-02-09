using IAPromocoes.Domain.Entities;
using System;
using System.Collections.Generic;

namespace IAPromocoes.Domain.Interfaces.Repository
{
    public interface IClienteRepository : IRepositoryBase<Cliente>
    {
        IEnumerable<Cliente> BuscarPorNome(string nome);
    }
}
