using Dapper;
using DotNetBatch14SNH.ConsoleApp1.Dtos;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetBatch14SNH.ConsoleApp1.DapperExamples
{
    public class DapperExample
    {
        private readonly string _connectionString = AppSettings.SqlConnectionStringBuilder.ConnectionString;

        public void Read()
        {
            using IDbConnection connection = new SqlConnection(_connectionString);
            List<BlogDto> lst = connection.Query<BlogDto>("select * from Tbl_Blog").ToList();
            foreach (BlogDto item in lst)
            {
                Console.WriteLine(item.BlogId);
                Console.WriteLine(item.BlogTitle);
                Console.WriteLine(item.BlogAuthor);
                Console.WriteLine(item.BlogContent);

            }
        }

        public void Edit(string id)
        {
            using IDbConnection connection = new SqlConnection(_connectionString);
            var item = connection.Query<BlogDto>($"select * from Tbl_Blog where BlogId = '{id}'").FirstOrDefault();

            if(item is null)
            {
                Console.WriteLine("No Item Found");
                return;
            }

            Console.WriteLine(item.BlogId);
            Console.WriteLine(item.BlogTitle);
            Console.WriteLine(item.BlogAuthor);
            Console.WriteLine(item.BlogContent);

        }

        public void Create(string title,string author,string content) { 

            string query = $@"INSERT INTO Tbl_Blog (BlogTitle, BlogAuthor,BlogContent)
VALUES ('{title}', '{author}', '{content}')";

            using IDbConnection connection = new SqlConnection(_connectionString);
            var result = connection.Execute(query);
            string message = result > 0 ? "Create Successful." : "Create Failed.";
            Console.WriteLine(message);
        }

        public void Update(string id,string title ,string author,string content)
        {
            string query = $@"UPDATE Tbl_Blog
SET 
    BlogTitle = '{title}',
    BlogAuthor = '{author}',
    BlogContent = '{content}'
WHERE 
    BlogId = '{id}' ";
            using IDbConnection connection = new SqlConnection(_connectionString);
            var result = connection.Execute(query);
            string message = result > 0 ? "Update Successfully" : "Update Failed";
            Console.WriteLine(message);
        }

        public void Delete(string id)
        {
            string query = $@"Delete from [dbo].[Tbl_Blog] where BLogid='{id}'";
            using IDbConnection connection = new SqlConnection(_connectionString) ;
            var result = connection.Execute(query);
            string message = result > 0 ? "Delete Successfully" : "Delete Failed";
            Console.WriteLine(message);
        }
    }
}
