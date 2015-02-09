using IAPromocoes.Domain.ValueObjects;

namespace IAPromocoes.Domain.Interfaces.Validation
{
    public interface IFiscal<in TEntity>
    {
        ValidationResult Validar(TEntity entity);
    }
}
