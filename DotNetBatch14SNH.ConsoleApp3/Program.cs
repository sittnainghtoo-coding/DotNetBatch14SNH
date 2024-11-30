// See https://aka.ms/new-console-template for more information
using System.Data;
using DotNetBatch14SNH.ConsoleApp3.AdoDotNetExamples;
using DotNetBatch14SNH.ConsoleApp3.DapperExamples;
using DotNetBatch14SNH.ConsoleApp3.EFCoreExamples;
using Microsoft.Data.SqlClient;

Console.WriteLine("Hello, World!");

// N Layer Architecture


// ADO.NET
// Dapper (ORM)
// EFCore (ORM)

//SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
//{
//    DataSource = ".",
//    InitialCatalog = "TestDb",
//    UserID = "sa",
//    Password = "sasa@123"
//};
//SqlConnection connection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
//connection.Open();

//SqlCommand cmd = new SqlCommand("select * from tbl_blog", connection);
//SqlDataAdapter adapter = new SqlDataAdapter(cmd);
//DataTable dt = new DataTable();
//adapter.Fill(dt);

//connection.Close();

//AdoDotNetExample adoDotNetExample = new AdoDotNetExample();
//adoDotNetExample.Read();
//adoDotNetExample.Edit("0930A539-4BF4-4914-A558-EDA61FC2BCA1");
//adoDotNetExample.Edit("0930A539-4BF4-4914-A558-EDA61FC2BCA2");
//adoDotNetExample.Create("test1", "test2", "test3");

//DapperExample dapperExample = new DapperExample();
//dapperExample.Read();
//dapperExample.Create("test1 2", "test2 3", "test3 4");

EFCoreExample eFCoreExample = new EFCoreExample();
eFCoreExample.Read();


