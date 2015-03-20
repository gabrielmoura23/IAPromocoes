using IAPromocoes.Domain.Entities;
using IAPromocoes.Domain.Interfaces.Repository.ReadOnly;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;

namespace IAPromocoes.Infra.Data.Repositories.ReadOnly
{
    public class CidadeReadOnlyRepository : RepositoryBaseReadOnly, ICidadeReadOnlyRepository
    {
        public Cidade GetById(Guid id)
        {
            using (IDbConnection cn = Connection)
            {
                cn.Open();

                var sql = @"Select * From Tab_Cidade c " +
                          "WHERE c.IdCidade = '" + id + "'";

                var retorno = cn.Query<Cidade>(sql);
                return retorno.FirstOrDefault();
            }
        }


        public IEnumerable<Cidade> GetAll()
        {
            using (IDbConnection cn = Connection)
            {
                cn.Open();

                var sql = @"Select * From Tab_Cidade c ";
                var retorno = cn.Query<Cidade>(sql);

                return retorno;
            }
        }
    }
}
