using IAPromocoes.Domain.Entities;
using IAPromocoes.Domain.Specification;
using IAPromocoes.Domain.Validation.Base;

namespace IAPromocoes.Domain.Validation
{
    public class ProdutoEstaAptoParaCadastroNoSistema : FiscalBase<Produto>
    {
        public ProdutoEstaAptoParaCadastroNoSistema()
        {
        }
    }
}
