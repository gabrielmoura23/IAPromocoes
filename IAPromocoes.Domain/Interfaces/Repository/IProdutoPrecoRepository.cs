﻿using IAPromocoes.Domain.Entities;
using System;
using System.Collections.Generic;

namespace IAPromocoes.Domain.Interfaces.Repository
{
    public interface IProdutoPrecoRepository : IRepositoryBase<ProdutoPreco>
    {
        IEnumerable<ProdutoPreco> BuscarPrecosPorIdProduto(Guid idProduto);
    }
}
