using Microsoft.Data.SqlClient;
using System.Data;

SqlConnectionStringBuilder connectionStringBuilder = new SqlConnectionStringBuilder();
connectionStringBuilder.DataSource = "."; //servername
connectionStringBuilder.InitialCatalog = "Transferdb"; //databasename
connectionStringBuilder.UserID = "sa"; //name
connectionStringBuilder.Password = "12345"; //password
connectionStringBuilder.TrustServerCertificate = true;


SqlConnection connection = new SqlConnection(connectionStringBuilder.ConnectionString);

connection.Open();

string query = "select * from tbl_blog";
SqlCommand cmd = new SqlCommand(query, connection);
SqlDataAdapter adapter = new SqlDataAdapter(cmd);
DataTable dt = new DataTable();
adapter.Fill(dt);


connection.Close();

//DataTable
//DataRow
//DataColumn

foreach(DataRow dr in dt.Rows)
{
    Console.WriteLine(dr["BlogId"]);
    Console.WriteLine(dr["BlogTitle"]);
    Console.WriteLine(dr["BlogAuthor"]);
    Console.WriteLine(dr["BlogContent"]);

}






Console.ReadLine();



//----------------



//Blog
//Id
//Title
//Author
//Content


//MSSQL


