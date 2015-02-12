using IAPromocoes.Domain.Entities;
using IAPromocoes.Domain.Interfaces.Repository;
using IAPromocoes.Infra.Data.Context;
using System;
using System.Collections.Generic;

namespace IAPromocoes.Infra.Data.Repositories
{
    public class ProdutoImagemRepository : RepositoryBase<ProdutoImagem, IAPromocoesContext>, IProdutoImagemRepository
    {
        public IEnumerable<ProdutoImagem> BuscarImagensPorIdProduto(Guid idProduto)
        {
            return base.Find(c => c.IdProduto == idProduto);
        }
    }
}
