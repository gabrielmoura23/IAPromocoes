using System.Collections.Generic;
using IAPromocoes.Domain.Entities;
using IAPromocoes.Domain.ValueObjects;
using System;

namespace IAPromocoes.Domain.Interfaces.Services
{
    public interface IProdutoPrecoService : IServiceBase<ProdutoPreco>
    {
        ValidationResult AdicionarProdutoPreco(ProdutoPreco model);
        IEnumerable<ProdutoPreco> BuscarPrecosPorIdProduto(Guid idProduto);
    }
}
