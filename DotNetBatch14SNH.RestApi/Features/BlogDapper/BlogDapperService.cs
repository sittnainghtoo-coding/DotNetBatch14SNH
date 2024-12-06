using Microsoft.Data.SqlClient;
using System.Data;

namespace DotNetBatch14SNH.RestApi.Features.BlogDapper
{
    public class BlogDapperService
    {
        SqlConnectionStringBuilder _sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
        {
            DataSource = ".",
            InitialCatalog = "Transferdb",
            UserID = "sa",
            Password = "12345",
            TrustServerCertificate = true
        };

        public List<BLogDapperModel> GetBlogs()
        {
            using IDbConnection connection  = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString
                )
        }
    }
}
