using IAPromocoes.Domain.Entities;
using IAPromocoes.Domain.Interfaces.Repository.ReadOnly;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;

namespace IAPromocoes.Infra.Data.Repositories.ReadOnly
{
    public class ProdutoImagemReadOnlyRepository : RepositoryBaseReadOnly, IProdutoImagemReadOnlyRepository
    {
        public ProdutoImagem GetById(Guid id)
        {
            using (IDbConnection cn = Connection)
            {
                cn.Open();

                var sql = @"Select * From Tab_ProdutoImagem c " +
                          "WHERE c.IdProdutoImagem ='" + id + "'";

                var retorno = cn.Query<ProdutoImagem>(sql);
                return retorno.FirstOrDefault();
            }
        }


        public IEnumerable<ProdutoImagem> GetAll()
        {
            using (IDbConnection cn = Connection)
            {
                cn.Open();

                var sql = @"Select * From Tab_ProdutoImagem c ";
                var retorno = cn.Query<ProdutoImagem>(sql);

                return retorno;
            }
        }
    }
}
