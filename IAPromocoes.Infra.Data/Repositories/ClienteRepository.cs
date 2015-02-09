using IAPromocoes.Domain.Entities;
using IAPromocoes.Domain.Interfaces.Repository;
using IAPromocoes.Infra.Data.Context;
using System.Collections.Generic;

namespace IAPromocoes.Infra.Data.Repositories
{
    public class ClienteRepository : RepositoryBase<Cliente, IAPromocoesContext>, IClienteRepository
    {
        public IEnumerable<Cliente> BuscarPorNome(string nome)
        {
            return base.Find(c => c.Nome == nome);
        }
    }
}
