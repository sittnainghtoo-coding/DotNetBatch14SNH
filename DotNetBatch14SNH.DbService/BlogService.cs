using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Globalization;

namespace DotNetBatch14SNH_Shared;

public class BlogService : IBlogService
{

    private readonly SqlConnectionStringBuilder _sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
    {
        DataSource = ".",
        InitialCatalog = "Transferdb",
        UserID = "sa",
        Password = "12345",
        TrustServerCertificate = true

    };

    public BlogService(String connectionString) 
    {
        _sqlConnectionStringBuilder = new SqlConnectionStringBuilder(connectionString);
    }

    public BlogService(IConfiguration configuration)
    {
        _sqlConnectionStringBuilder = new SqlConnectionStringBuilder(configuration.GetConnectionString("DbConnection"));
    }
    public List<BlogModel> GetBlogs()
    {
        SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
        connection.Open();
        SqlCommand cmd = new SqlCommand("Select * from Tbl_Blog", connection);
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        adapter.Fill(dt);


        connection.Close();
        List<BlogModel> lst = new List<BlogModel>();
        foreach (DataRow row in dt.Rows)
        {
            //Console.WriteLine(row["BlogId"]);
            //Console.WriteLine(row["BlogTitle"]);
            //Console.WriteLine(row["BlogAuthor"]);
            //Console.WriteLine(row["BlogContent"]);

            BlogModel item = new BlogModel();
            item.BlogId = row["BlogId"].ToString()!;
            item.BlogTitle = row["BlogTitle"].ToString()!;
            item.BlogAuthor = row["BlogAuthor"].ToString()!;
            item.BlogContent = row["BlogContent"].ToString()!;

            lst.Add(item);

        }
        return lst;

    }

    public BlogModel GetBlog(string id)
    {
        SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
        connection.Open();
        SqlCommand cmd = new SqlCommand("Select * from Tbl_BLog where BlogId = @BlogId;", connection);
        cmd.Parameters.AddWithValue("@BlogId", id);
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        adapter.Fill(dt);


        connection.Close();
        if (dt.Rows.Count == 0) return null;
        DataRow row = dt.Rows[0];

        BlogModel item = new BlogModel();
        item.BlogId = row["BlogId"].ToString()!;
        item.BlogTitle = row["BlogTitle"].ToString()!;
        item.BlogAuthor = row["BlogAuthor"].ToString()!;
        item.BlogContent = row["BlogContent"].ToString()!;

        return item;
    }

    public BlogResponseModel CreateBlog(BlogModel requestModel)
    {

        string query = $@"INSERT INTO [dbo].[Tbl_Blog]
           ([BlogTitle]
           ,[BlogAuthor]
           ,[BlogContent])
     VALUES
           (@BlogTitle,@BlogAuthor,@BLogContent)";

        SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
        connection.Open();

        SqlCommand cmd = new SqlCommand(query, connection);
        cmd.Parameters.AddWithValue("@BlogTitle", requestModel.BlogTitle);
        cmd.Parameters.AddWithValue("@BlogAuthor", requestModel.BlogAuthor);
        cmd.Parameters.AddWithValue("@BlogContent", requestModel.BlogContent);

        SqlDataAdapter adapter = new SqlDataAdapter(cmd);

        int result = cmd.ExecuteNonQuery();
        connection.Close();
        string message = result > 0 ? "saving Successful." : "Saving Failed.";
        BlogResponseModel model = new BlogResponseModel();
        model.IsSuccess = result > 0;
        model.Message = message;
        // void only return one value so we have to return object model 

        return model;

    }

    public BlogResponseModel UpdateBlog(BlogModel requestModel)
    {

        var item = GetBlog(requestModel.BlogId!);
        if (item is null)
        {
            return new BlogResponseModel
            {
                IsSuccess = false,
                Message = "No data found."
            };
        }
        //if (string.IsNullOrEmpty(requestModel.BlogTitle))
        //{
        //    requestModel.BlogTitle = item.BlogTitle;
        //}
        //if (string.IsNullOrEmpty(requestModel.BlogAuthor))
        //{
        //    requestModel.BlogAuthor = item.BlogAuthor;
        //}
        //if (string.IsNullOrEmpty(requestModel.BlogContent))
        //{
        //    requestModel.BlogContent = item.BlogContent;
        //}

        string conditions = string.Empty;

        if (!string.IsNullOrEmpty(requestModel.BlogTitle))
        {
            conditions += " [BlogTitle] = @BlogTitle, ";
        }
        if (!string.IsNullOrEmpty(requestModel.BlogAuthor))
        {

            conditions += " [BlogAuthor] = @BlogAuthor, ";
        }
        if (!string.IsNullOrEmpty(requestModel.BlogContent))
        {
            conditions += " [BlogContent] = @BlogContent, ";
        }

        if (conditions.Length == 0)
        {
            throw new Exception("Invalid Parameters.");
        }

        conditions = conditions.Substring(0, conditions.Length - 2);



        string query = $@"UPDATE [dbo].[Tbl_Blog]
SET
    {conditions}
WHERE
    BlogId = @BlogId";

        SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
        connection.Open();

        SqlCommand cmd = new SqlCommand(query, connection);
        cmd.Parameters.AddWithValue("@BlogId", requestModel.BlogId);
        cmd.Parameters.AddWithValue("@BlogTitle", requestModel.BlogTitle);
        cmd.Parameters.AddWithValue("@BlogAuthor", requestModel.BlogAuthor);
        cmd.Parameters.AddWithValue("@BlogContent", requestModel.BlogContent);

        SqlDataAdapter adapter = new SqlDataAdapter(cmd);

        int result = cmd.ExecuteNonQuery();
        connection.Close();
        string message = result > 0 ? "Update Successful." : "Update Failed.";
        BlogResponseModel model = new BlogResponseModel();
        model.IsSuccess = result > 0;
        model.Message = message;
        // void only return one value so we have to return object model 

        return model;

    }

    public BlogResponseModel UpsertBlog(BlogModel requestModel)
    {
        BlogResponseModel model = new BlogResponseModel();

        var item = GetBlog(requestModel.BlogId!);

        if (item is not null)
        {
            string query = @"UPDATE [dbo].[Tbl_Blog]
SET
    [BlogTitle] = @BlogTitle,
    [BlogAuthor] = @BlogAuthor,
    [BlogContent] = @BlogContent
WHERE
    BlogId = @BlogId";

            SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            connection.Open();
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@BlogId", requestModel.BlogId);
            cmd.Parameters.AddWithValue("@BlogTitle", requestModel.BlogTitle);
            cmd.Parameters.AddWithValue("@BlogAuthor", requestModel.BlogAuthor);
            cmd.Parameters.AddWithValue("@BlogContent", requestModel.BlogContent);
            int result = cmd.ExecuteNonQuery();

            connection.Close();
            string message = result > 0 ? "Updating Successful" : "Updating Failed";
            model.IsSuccess = result > 0;
            model.Message = message;

        }


        else if (item is null)
        {

            model = CreateBlog(requestModel);
        }
        return model;

    }



    public BlogResponseModel DeleteBlog(string id)
    {
        SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
        connection.Open();
        SqlCommand cmd = new SqlCommand("Delete From [dbo].[Tbl_Blog] where BlogId = @BlogId", connection);
        cmd.Parameters.AddWithValue("@BlogId", id);
        int result = cmd.ExecuteNonQuery();

        connection.Close();
        string message = result > 0 ? "Delete Successful" : "Delete Failed";
        BlogResponseModel model = new BlogResponseModel();
        model.IsSuccess = result > 0;
        model.Message = message;
        return model;




    }

   
}
