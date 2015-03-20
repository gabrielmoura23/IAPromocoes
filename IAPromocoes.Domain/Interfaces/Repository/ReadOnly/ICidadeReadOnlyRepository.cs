using System;
using System.Collections.Generic;
using IAPromocoes.Domain.Entities;

namespace IAPromocoes.Domain.Interfaces.Repository.ReadOnly
{
    public interface ICidadeReadOnlyRepository
    {
        Cidade GetById(Guid id);
        IEnumerable<Cidade> GetAll(); 
    }
}
