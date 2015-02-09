using IAPromocoes.Domain.Entities;
using System.Collections.Generic;

namespace IAPromocoes.Domain.Interfaces.Repository
{
    public interface IProdutoRepository : IRepositoryBase<Produto>
    {
        IEnumerable<Produto> BuscarPorDescricao(string descricao);
    }
}
