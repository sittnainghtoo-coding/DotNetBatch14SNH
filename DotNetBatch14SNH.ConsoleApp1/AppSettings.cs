using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetBatch14SNH.ConsoleApp1
{
    public static class AppSettings
    {

        public static SqlConnectionStringBuilder SqlConnectionStringBuilder { get; } = new SqlConnectionStringBuilder()
        {
            DataSource = ".",
            InitialCatalog = "Transferdb",
            UserID = "sa",
            Password = "12345",
            TrustServerCertificate = true
        };
    }
}
