using System.Collections.Generic;
using IAPromocoes.Domain.Entities;
using IAPromocoes.Domain.ValueObjects;
using System;

namespace IAPromocoes.Domain.Interfaces.Services
{
    public interface IClienteService : IServiceBase<Cliente>
    {
        ValidationResult AdicionarCliente(Cliente model);
        IEnumerable<Cliente> BuscarPorNome(string nome);
    }
}
