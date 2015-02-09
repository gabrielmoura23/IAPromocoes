using System;
using System.Collections.Generic;

namespace IAPromocoes.Domain.Interfaces.Services
{
    public interface IServiceBase<TEntity> where TEntity : class 
    {
        void Add(TEntity obj);
        TEntity GetById(Guid id);
        TEntity GetByIdTipoInteiro(int id);
        IEnumerable<TEntity> GetAll();
        void Update(TEntity obj);
        void Remove(TEntity obj);
        void Dispose();
    }
}
