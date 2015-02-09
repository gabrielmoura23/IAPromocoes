using System;
using System.Collections.Generic;
using IAPromocoes.Domain.Entities;

namespace IAPromocoes.Domain.Interfaces.Repository.ReadOnly
{
    public interface IFormaDePagamentoReadOnlyRepository
    {
        FormaDePagamento GetById(Guid id);
        IEnumerable<FormaDePagamento> GetAll(); 
    }
}
