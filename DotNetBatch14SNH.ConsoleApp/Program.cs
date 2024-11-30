using Microsoft.Data.SqlClient;
using System.Data;

//SqlConnectionStringBuilder connectionStringBuilder = new SqlConnectionStringBuilder();
//connectionStringBuilder.DataSource = "."; //servername
//connectionStringBuilder.InitialCatalog = "Transferdb"; //databasename
//connectionStringBuilder.UserID = "sa"; //name
//connectionStringBuilder.Password = "12345"; //password
//connectionStringBuilder.TrustServerCertificate = true;


//SqlConnection connection = new SqlConnection(connectionStringBuilder.ConnectionString);

//connection.Open();

//string query = "select * from Tbl_Blog";
//SqlCommand cmd = new SqlCommand(query, connection);
//SqlDataAdapter adapter = new SqlDataAdapter(cmd);
//DataTable dt = new DataTable();
//adapter.Fill(dt);


//connection.Close();

////DataTable
////DataRow
////DataColumn

//foreach(DataRow dr in dt.Rows)
//{
//    Console.WriteLine(dr["BlogId"]);
//    Console.WriteLine(dr["BlogTitle"]);
//    Console.WriteLine(dr["BlogAuthor"]);
//    Console.WriteLine(dr["BlogContent"]);

//}






//Console.ReadLine();



//----------------



//Blog
//Id
//Title
//Author
//Content


//MSSQL


//testing db--------------

// See https://aka.ms/new-console-template for more information
using System.Data;
//using DotNetBatch14SNH.ConsoleApp.AdoDotNetExamples;
using DotNetBatch14SNH.ConsoleApp.DapperExamples;
//using DotNetBatch14SNH.ConsoleApp.EFCoreExamples;
//using Microsoft.Data.SqlClient;
//using DotNetBatch14SNH.ConsoleApp.EFCoreExamples;

//Console.WriteLine("Hello, World!");

// N Layer Architecture


// ADO.NET
// Dapper (ORM)
// EFCore (ORM)



//AdoDotNetExample adoDotNetExample = new AdoDotNetExample();
//adoDotNetExample.Read();
//adoDotNetExample.Edit("0930A539-4BF4-4914-A558-EDA61FC2BCA1");
//adoDotNetExample.Edit("0930A539-4BF4-4914-A558-EDA61FC2BCA2");
//adoDotNetExample.Create("test1", "test2", "test3");

DapperExample dapperExample = new DapperExample();
dapperExample.Read();
//dapperExample.Create("test1 2", "test2 3", "test3 4");

//EFCoreExample eFCoreExample = new EFCoreExample();
//eFCoreExample.Read();





