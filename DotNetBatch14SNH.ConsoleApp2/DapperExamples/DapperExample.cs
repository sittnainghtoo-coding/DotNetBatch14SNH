using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using DotNetBatch14SNH.ConsoleApp2.Dtos;
using Microsoft.Data.SqlClient;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace DotNetBatch14SNH.ConsoleApp2.DapperExamples;

public class DapperExample
{
    private readonly string _connectionString = AppSettings.SqlConnectionStringBuilder.ConnectionString;

    public void Read()
    {
        using IDbConnection connection = new SqlConnection(_connectionString);

        List<BlogDto> lst = connection
             .Query<BlogDto>("select * from Tbl_Blog")
             .ToList();

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

        var item = connection
             .Query<BlogDto>($"select * from tbl_blog where BlogId = '{id}'")
             .FirstOrDefault();

        //if(item == null)
        if (item is null)
        {
            Console.WriteLine("No data found.");
            return;
        }

        Console.WriteLine(item.BlogId);
        Console.WriteLine(item.BlogTitle);
        Console.WriteLine(item.BlogAuthor);
        Console.WriteLine(item.BlogContent);
    }

    public void Create(string title, string author, string content)
    {
        string query = $@"INSERT INTO [dbo].[Tbl_Blog]
           ([BlogTitle]
           ,[BlogAuthor]
           ,[BlogContent])
     VALUES
           ('{title}'
           ,'{author}'
           ,'{content}')";

        using IDbConnection connection = new SqlConnection(_connectionString);
        var result = connection.Execute(query);

        string message = result > 0 ? "Saving Successful." : "Saving Failed.";
        Console.WriteLine(message);
    }

    public void Update(string id, string title,string author,string content)
    {
        string query = $@"UPDATE [dbo].[Tbl_Blog]
                            SET [BlogTitle] = '{title}',[BlogAuthor] = '{author}', [BlogContent] = '{content}'  WHERE BLogid = '{id}'";
        using IDbConnection connection = new SqlConnection(_connectionString);
        var result = connection.Execute(query);
        string message = result > 0 ? "UPdate success" : "Update fail";
        Console.WriteLine(message);

    }

    public void Delete(string id)
    {
        using IDbConnection connnection = new SqlConnection(_connectionString);
        var result = connnection.Execute($"Delete from [dbo].[Tbl_Blog] where BLogid='{id}'");
        string message = result > 0 ? "Delete Success" : "Delete Fail";
        Console.WriteLine(message);
    }
}
