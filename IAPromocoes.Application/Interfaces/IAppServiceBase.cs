using IAPromocoes.Infra.Data.Interfaces;

namespace IAPromocoes.Application.Interfaces
{
    public interface IAppServiceBase<TContext> where TContext : IDbContext
    {
        void BeginTransaction();
        void Commit();
    }
}