using IAPromocoes.Domain.Entities;
using IAPromocoes.Domain.Interfaces.Repository.ReadOnly;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;

namespace IAPromocoes.Infra.Data.Repositories.ReadOnly
{
    public class FormaDePagamentoReadOnlyRepository : RepositoryBaseReadOnly, IFormaDePagamentoReadOnlyRepository
    {
        public FormaDePagamento GetById(Guid id)
        {
            using (IDbConnection cn = Connection)
            {
                cn.Open();

                var sql = @"Select * From Tab_FormaDePagamento c " +
                          "WHERE c.IdFormaDePagamento ='" + id + "'";

                var retorno = cn.Query<FormaDePagamento>(sql);
                return retorno.FirstOrDefault();
            }
        }


        public IEnumerable<FormaDePagamento> GetAll()
        {
            using (IDbConnection cn = Connection)
            {
                cn.Open();

                var sql = @"Select * From Tab_FormaDePagamento c ";
                var retorno = cn.Query<FormaDePagamento>(sql);

                return retorno;
            }
        }
    }
}
