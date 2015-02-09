using IAPromocoes.Domain.ValueObjects;

namespace IAPromocoes.Domain.Interfaces.Validation
{
    public interface ISelfValidator
    {
        ValidationResult ResultadoValidacao { get; }
        bool IsValid(); 
    }
}