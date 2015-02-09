using IAPromocoes.Domain.Entities;
using IAPromocoes.Domain.Interfaces.Repository.ReadOnly;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;

namespace IAPromocoes.Infra.Data.Repositories.ReadOnly
{
    public class ClienteReadOnlyRepository : RepositoryBaseReadOnly, IClienteReadOnlyRepository
    {
        public Cliente GetById(Guid id)
        {
            using (IDbConnection cn = Connection)
            {
                cn.Open();

                var sql = @"Select * From Tab_Cliente c " +
                          "WHERE c.IdCliente ='" + id + "'";

                var retorno = cn.Query<Cliente>(sql);
                return retorno.FirstOrDefault();
            }
        }


        public IEnumerable<Cliente> GetAll()
        {
            using (IDbConnection cn = Connection)
            {
                cn.Open();

                var sql = @"Select * From Tab_Cliente c ";
                var retorno = cn.Query<Cliente>(sql);

                return retorno;
            }
        }
    }
}
