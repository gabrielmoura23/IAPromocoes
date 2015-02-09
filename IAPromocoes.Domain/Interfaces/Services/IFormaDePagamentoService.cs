using System.Collections.Generic;
using IAPromocoes.Domain.Entities;
using IAPromocoes.Domain.ValueObjects;
using System;

namespace IAPromocoes.Domain.Interfaces.Services
{
    public interface IFormaDePagamentoService : IServiceBase<FormaDePagamento>
    {
        ValidationResult AdicionarFormaDePagamento(FormaDePagamento model);
    }
}
