using IAPromocoes.Domain.Entities;
using System;
using System.Collections.Generic;

namespace IAPromocoes.Domain.Interfaces.Repository
{
    public interface IProdutoImagemRepository : IRepositoryBase<ProdutoImagem>
    {
        IEnumerable<ProdutoImagem> BuscarImagensPorIdProduto(Guid idProduto);
    }
}
