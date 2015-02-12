using IAPromocoes.Domain.Entities;
using IAPromocoes.Domain.Interfaces.Repository.ReadOnly;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;

namespace IAPromocoes.Infra.Data.Repositories.ReadOnly
{
    public class ProdutoPrecoReadOnlyRepository : RepositoryBaseReadOnly, IProdutoPrecoReadOnlyRepository
    {
        public ProdutoPreco GetById(Guid id)
        {
            using (IDbConnection cn = Connection)
            {
                cn.Open();

                var sql = @"Select * From Tab_ProdutoPreco c " +
                          "WHERE c.IdProdutoPreco ='" + id + "'";

                var retorno = cn.Query<ProdutoPreco>(sql);
                return retorno.FirstOrDefault();
            }
        }


        public IEnumerable<ProdutoPreco> GetAll()
        {
            using (IDbConnection cn = Connection)
            {
                cn.Open();

                var sql = @"Select * From Tab_ProdutoPreco c ";
                var retorno = cn.Query<ProdutoPreco>(sql);

                return retorno;
            }
        }
    }
}
