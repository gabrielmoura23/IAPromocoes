﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.Practices.ServiceLocation;
using IAPromocoes.Domain.Interfaces.Repository;
using IAPromocoes.Infra.Data.Context;
using IAPromocoes.Infra.Data.Interfaces;

namespace IAPromocoes.Infra.Data.Repositories
{
    public class RepositoryBase<TEntity, TContext> : IRepositoryBase<TEntity>
        where TEntity : class
        where TContext : IDbContext, new()
    {
        private readonly ContextManager<TContext> _contextManager = ServiceLocator.Current.GetInstance<IContextManager<TContext>>() as ContextManager<TContext>;

        protected IDbSet<TEntity> DbSet;
        protected readonly IDbContext Context;

        public RepositoryBase()
        {
            Context = _contextManager.GetContext();
            DbSet = Context.Set<TEntity>();
        }

        public virtual void Add(TEntity obj)
        {
            DbSet.Add(obj);
        }

        public virtual TEntity GetById(Guid id)
        {
            //return DbSet.Find(id);

            var entry = DbSet.Find(id);
            Context.Entry(entry).State = EntityState.Detached;
            return entry;
        }

        public virtual TEntity GetByIdTipoInteiro(int id)
        {
            //return DbSet.Find(id);
            var entry = DbSet.Find(id);
            Context.Entry(entry).State = EntityState.Detached;
            return entry;
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return DbSet.ToList();
        }

        public virtual IEnumerable<TEntity> GetAllReadOnly()
        {
            return DbSet.AsNoTracking();
        }

        public virtual void Update(TEntity obj)
        {
            var entry = Context.Entry(obj);
            if (entry.State == EntityState.Detached)
                DbSet.Attach(obj);
            entry.State = EntityState.Modified;
        }

        public virtual void Remove(TEntity obj)
        {
            var entry = Context.Entry(obj);
            if (entry.State == EntityState.Detached)
                DbSet.Attach(obj);
            DbSet.Remove(obj);
        }

        public virtual IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.Where(predicate);
        }


        public virtual TEntity FindWithIncludes(Expression<Func<TEntity, bool>> predicate, string[] includes = null)
        {
            return DbSet.FirstOrDefault<TEntity>(predicate);
            
            //código abaixo está dando erro
            //HANDLE INCLUDES FOR ASSOCIATED OBJECTS IF APPLICABLE
            if (includes != null && includes.Count() > 0)
            {
                var query = DbSet.Include(includes.First());
                foreach (var include in includes.Skip(1))
                    query = query.Include(include);
                return query.FirstOrDefault<TEntity>(predicate);
            }

            
        }

        public void Dispose()
        {
            Context.Dispose();
            GC.SuppressFinalize(this);
        }

    }
}
