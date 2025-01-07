using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace DotNetBatch14SNH.ConsoleApp1.AdoDotNetExamples
{
    public class AdoDotNetExample
    {
        private readonly SqlConnectionStringBuilder _sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
        {
            DataSource = ".",
            InitialCatalog = "Transferdb",
            UserID = "sa",
            Password = "12345",
            TrustServerCertificate = true
        };


        public void Read()
        {
            SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            connection.Open();
            SqlCommand cmd = new SqlCommand("select * from Tbl_Blog", connection);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            connection.Close();

            foreach(DataRow row in dt.Rows){
                Console.WriteLine(row["BlogId"]);
                Console.WriteLine(row["BlogTitle"]);
                Console.WriteLine(row["BlogAuthor"]);
                Console.WriteLine(row["BlogContent"]);

            }

        }

        public void Edit(string id)
        {
            SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            connection.Open();
            
            SqlCommand cmd = new SqlCommand($"Select * from Tbl_Blog where BlogId = '{id}'", connection);

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            connection.Close();

            if(dt.Rows.Count == 0)
                {
                    Console.WriteLine("No data found");
                    return;
                }
            DataRow row = dt.Rows[0];
            Console.WriteLine(row["BlogId"]);
            Console.WriteLine(row["BlogTitle"]);
            Console.WriteLine(row["BlogAuthor"]);
            Console.WriteLine(row["BlogContent"]);

        }

        public void Create(string title,string author,string content)
        {

            string query = $@"INSERT INTO [dbo].[Tbl_Blog]
           ([BlogTitle]
           ,[BlogAuthor]
           ,[BlogContent])
     VALUES
           ('{title}','{author}','{content}')";

            SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            connection.Open();

            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);

            int result = cmd.ExecuteNonQuery();
            connection.Close();
            string message = result > 0 ? "saving Successful." : "Saving Failed.";
            Console.WriteLine(message);

        }

        public void Update(string id,string title,string author,string content)
        {
            string query = $@"UPDATE Tbl_Blog
SET
    BlogTitle = '{title}',
    BlogAuthor = '{author}',
    BlogContent = '{content}'
WHERE
    BlogId = '{id}'";

            SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            connection.Open();
            SqlCommand cmd = new SqlCommand(query, connection);
            int result = cmd.ExecuteNonQuery();
            connection.Close();
            string message = result > 0 ? "Updating Successfully." : "Updating Failed.";
            Console.WriteLine(message);

        }

        public void Delete(string id)
        {
            SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            connection.Open();
            SqlCommand cmd = new SqlCommand($@"DELETE FROM Tbl_Blog WHERE blogId = '{id}'", connection);
            int result = cmd.ExecuteNonQuery();

            connection.Close();
            string message = result > 0 ? "Delete successful." : "Delete Failed.";
            Console.WriteLine(message);
        }


        
    }
}
