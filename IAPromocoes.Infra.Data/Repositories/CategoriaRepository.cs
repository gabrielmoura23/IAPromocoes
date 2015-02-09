using IAPromocoes.Domain.Entities;
using IAPromocoes.Domain.Interfaces.Repository;
using IAPromocoes.Infra.Data.Context;
using System.Collections.Generic;

namespace IAPromocoes.Infra.Data.Repositories
{
    public class CategoriaRepository : RepositoryBase<Categoria, IAPromocoesContext>, ICategoriaRepository
    {
        
    }
}
