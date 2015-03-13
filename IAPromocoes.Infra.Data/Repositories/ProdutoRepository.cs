using IAPromocoes.Domain.Entities;
using IAPromocoes.Domain.Interfaces.Repository;
using IAPromocoes.Infra.Data.Context;
using System.Collections.Generic;


namespace IAPromocoes.Infra.Data.Repositories
{
    public class ProdutoRepository : RepositoryBase<Produto, IAPromocoesContext>, IProdutoRepository
    {
        public IEnumerable<Produto> BuscarPorDescricao(string descricao)
        {
            return base.Find(c => c.Descricao == descricao);
        }
    }
}
