using System;
using IAPromocoes.Domain.Entities;
using IAPromocoes.Domain.Interfaces.Specification;

namespace IAPromocoes.Domain.Specification
{
    class ProdutoEstaCadastradoMaisDeCincoAnos : ISpecification<Produto>
    {
        public bool IsSatisfiedBy(Produto model)
        {
            return DateTime.Now.Year - model.DtCadastro.Year >= 5;
        }
    }
}
