using System;
using System.Collections.Generic;
using IAPromocoes.Domain.Entities;

namespace IAPromocoes.Domain.Interfaces.Repository.ReadOnly
{
    public interface IProdutoImagemReadOnlyRepository
    {
        ProdutoImagem GetById(Guid id);
        IEnumerable<ProdutoImagem> GetAll(); 
    }
}
