using System;
using System.Collections.Generic;
using IAPromocoes.Domain.Entities;

namespace IAPromocoes.Domain.Interfaces.Repository.ReadOnly
{
    public interface IProdutoPrecoReadOnlyRepository
    {
        ProdutoPreco GetById(Guid id);
        IEnumerable<ProdutoPreco> GetAll(); 
    }
}
