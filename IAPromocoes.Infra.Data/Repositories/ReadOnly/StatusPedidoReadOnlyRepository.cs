using IAPromocoes.Domain.Entities;
using IAPromocoes.Domain.Interfaces.Repository.ReadOnly;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;

namespace IAPromocoes.Infra.Data.Repositories.ReadOnly
{
    public class StatusPedidoReadOnlyRepository : RepositoryBaseReadOnly, IStatusPedidoReadOnlyRepository
    {
        public StatusPedido GetById(Guid id)
        {
            using (IDbConnection cn = Connection)
            {
                cn.Open();

                var sql = @"Select * From Tab_StatusPedido c " +
                          "WHERE c.IdStatusPedido ='" + id + "'";

                var retorno = cn.Query<StatusPedido>(sql);
                return retorno.FirstOrDefault();
            }
        }


        public IEnumerable<StatusPedido> GetAll()
        {
            using (IDbConnection cn = Connection)
            {
                cn.Open();

                var sql = @"Select * From Tab_StatusPedido c ";
                var retorno = cn.Query<StatusPedido>(sql);

                return retorno;
            }
        }
    }
}
