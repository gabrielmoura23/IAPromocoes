using IAPromocoes.Domain.Entities;
using IAPromocoes.Domain.Interfaces.Repository.ReadOnly;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;

namespace IAPromocoes.Infra.Data.Repositories.ReadOnly
{
    public class CategoriaReadOnlyRepository : RepositoryBaseReadOnly, ICategoriaReadOnlyRepository
    {
        public Categoria GetById(Guid id)
        {
            using (IDbConnection cn = Connection)
            {
                cn.Open();

                var sql = @"Select * From Tab_Categoria c " +
                          "WHERE c.IdCategoria ='" + id + "'";

                var retorno = cn.Query<Categoria>(sql);
                return retorno.FirstOrDefault();
            }
        }


        public IEnumerable<Categoria> GetAll()
        {
            using (IDbConnection cn = Connection)
            {
                cn.Open();

                var sql = @"Select * From Tab_Categoria c ";
                var retorno = cn.Query<Categoria>(sql);

                return retorno;
            }
        }
    }
}
