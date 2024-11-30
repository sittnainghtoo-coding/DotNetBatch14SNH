using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace DotNetBatch14SNH.ConsoleApp2
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

