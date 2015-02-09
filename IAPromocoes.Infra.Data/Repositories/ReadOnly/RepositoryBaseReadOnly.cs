using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace IAPromocoes.Infra.Data.Repositories.ReadOnly
{
    public class RepositoryBaseReadOnly
    {
        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(ConfigurationManager.ConnectionStrings["IAPromocoesContext"].ConnectionString);
            }
        }
    }
}
