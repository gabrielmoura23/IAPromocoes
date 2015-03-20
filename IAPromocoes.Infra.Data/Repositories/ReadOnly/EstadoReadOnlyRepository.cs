using IAPromocoes.Domain.Entities;
using IAPromocoes.Domain.Interfaces.Repository.ReadOnly;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;

namespace IAPromocoes.Infra.Data.Repositories.ReadOnly
{
    public class EstadoReadOnlyRepository : RepositoryBaseReadOnly, IEstadoReadOnlyRepository
    {
        public Estado GetByIdTipoString(string id)
        {
            using (IDbConnection cn = Connection)
            {
                cn.Open();

                var sql = @"Select * From Tab_Estado c " +
                          "WHERE c.IdEstado = '" + id + "'";

                var retorno = cn.Query<Estado>(sql);
                return retorno.FirstOrDefault();
            }
        }


        public IEnumerable<Estado> GetAll()
        {
            using (IDbConnection cn = Connection)
            {
                cn.Open();

                var sql = @"Select * From Tab_Estado c ";
                var retorno = cn.Query<Estado>(sql);

                return retorno;
            }
        }
    }
}
