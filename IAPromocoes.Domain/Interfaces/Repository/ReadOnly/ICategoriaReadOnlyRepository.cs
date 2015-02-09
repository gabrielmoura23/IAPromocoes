using System;
using System.Collections.Generic;
using IAPromocoes.Domain.Entities;

namespace IAPromocoes.Domain.Interfaces.Repository.ReadOnly
{
    public interface ICategoriaReadOnlyRepository
    {
        Categoria GetById(Guid id);
        IEnumerable<Categoria> GetAll(); 
    }
}
