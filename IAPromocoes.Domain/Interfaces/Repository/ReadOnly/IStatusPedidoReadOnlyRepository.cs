using System;
using System.Collections.Generic;
using IAPromocoes.Domain.Entities;

namespace IAPromocoes.Domain.Interfaces.Repository.ReadOnly
{
    public interface IStatusPedidoReadOnlyRepository
    {
        StatusPedido GetById(Guid id);
        IEnumerable<StatusPedido> GetAll(); 
    }
}
