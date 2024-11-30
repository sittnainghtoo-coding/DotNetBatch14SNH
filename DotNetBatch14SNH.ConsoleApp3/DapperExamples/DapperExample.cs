using Dapper;
using DotNetBatch14SNH.ConsoleApp3.Dtos;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetBatch14SNH.ConsoleApp3.DapperExamples
{
    public class DapperExample
    {
        private readonly string _connectionString = AppSettings.SqlConnectionStringBuilder.ConnectionString;

        public void Read()
        {
            using IDbConnection connection = new SqlConnection(_connectionString);

            List<BlogDto> lst = connection
             .Query<BlogDto>("select * from tbl_blog")
             .ToList();


            foreach (BlogDto item in lst)
            {
                Console.WriteLine(item.BlogId);
                Console.WriteLine(item.BlogTitle);
                Console.WriteLine(item.BlogAuthor);
                Console.WriteLine(item.BlogContent);
            }
        }
    }
}
