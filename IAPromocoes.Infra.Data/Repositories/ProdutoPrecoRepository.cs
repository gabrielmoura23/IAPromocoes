using IAPromocoes.Domain.Entities;
using IAPromocoes.Domain.Interfaces.Repository;
using IAPromocoes.Infra.Data.Context;
using System;
using System.Collections.Generic;

namespace IAPromocoes.Infra.Data.Repositories
{
    public class ProdutoPrecoRepository : RepositoryBase<ProdutoPreco, IAPromocoesContext>, IProdutoPrecoRepository
    {
        public IEnumerable<ProdutoPreco> BuscarPrecosPorIdProduto(Guid idProduto)
        {
            return base.Find(c => c.IdProduto == idProduto);
        }
    }
}
