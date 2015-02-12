using System.Collections.Generic;
using IAPromocoes.Domain.Entities;
using IAPromocoes.Domain.ValueObjects;
using System;

namespace IAPromocoes.Domain.Interfaces.Services
{
    public interface IProdutoImagemService : IServiceBase<ProdutoImagem>
    {
        ValidationResult AdicionarProdutoImagem(ProdutoImagem model);
        IEnumerable<ProdutoImagem> BuscarImagensPorIdProduto(Guid idProduto);
    }
}
