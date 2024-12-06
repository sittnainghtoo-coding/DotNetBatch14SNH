using Microsoft.Data.SqlClient;
using System.Data;

namespace DotNetBatch14SNH.RestApi.Features.Blog
{
    public class BlogService
    {
        private readonly SqlConnectionStringBuilder _sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
        {
            DataSource = ".",
            InitialCatalog = "Transferdb",
            UserID = "sa",
            Password = "12345",
            TrustServerCertificate = true
        };
        public List<BlogModel> GetBlogs()
        {
            SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            connection.Open();

            SqlCommand cmd = new SqlCommand("select * from Transferdb", connection);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            connection.Close();

            List<BlogModel> lst = new List<BlogModel>();
            foreach (DataRow row in dt.Rows)
            {
                BlogModel item = new BlogModel();
                item.BLogId = row["BlogId"].ToString()!;
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

            SqlCommand cmd = new SqlCommand("select * from Tbl_Blog where BLogId = @BLogId;", connection);
            cmd.Parameters.AddWithValue("@BLogId", id);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            connection.Close();

            if (dt.Rows.Count == 0) return null;

            DataRow row = dt.Rows[0];

            BlogModel item = new BlogModel();
            item.BLogId = row["BlogId"].ToString()!;
            item.BlogTitle = row["BlogTitle"].ToString()!;
            item.BlogAuthor = row["BlogAuthor"].ToString()!;
            item.BlogContent = row["BlogContent"].ToString()!;

            return item;
        }
        public BlogResponseModel CreateBlog(BlogModel requestModel)
        {
            string query = $@"INSERT INTO [dbo].[Tbl_Blog]
           ([BLogTitle]
           ,[BlogAuthor]
           ,[BlogContent])
     VALUES
           (@BlogTitle
           ,@BlogAuthor
           ,@BlogContent)";

            SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            connection.Open();

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@BlogTitle", requestModel.BlogTitle);
            cmd.Parameters.AddWithValue("@BlogAuthor", requestModel.BlogAuthor);
            cmd.Parameters.AddWithValue("@BlogContent", requestModel.BlogContent);
            int result = cmd.ExecuteNonQuery();

            connection.Close();

            string message = result > 0 ? "Saving Successful." : "Saving Failed.";
            BlogResponseModel model = new BlogResponseModel();
            model.IsSuccess = result > 0;
            model.Message = message;

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

            if (string.IsNullOrEmpty(requestModel.BlogTitle))
            {
                requestModel.BlogTitle = item.BlogTitle;
            }
            if (string.IsNullOrEmpty(requestModel.BlogAuthor))
            {
                requestModel.BlogAuthor = item.BlogAuthor;
            }
            if (string.IsNullOrEmpty(requestModel.BlogContent))
            {
                requestModel.BlogContent = item.BlogContent;
            }

            string query = @"UPDATE [dbo].[Tbl_Blog]
   SET [BlogTitle] = @BlogTitle
      ,[BlogAuthor] = @BlogAuthor
      ,[BlogContent] = @BlogContent
 WHERE BlogId = @BlogId";

            SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            connection.Open();

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@BLogId", requestModel.BLogId);
            cmd.Parameters.AddWithValue("@BlogTitle", requestModel.BlogTitle);
            cmd.Parameters.AddWithValue("@BlogAuthor", requestModel.BlogAuthor);
            cmd.Parameters.AddWithValue("@BlogContent", requestModel.BlogContent);
            int result = cmd.ExecuteNonQuery();

            connection.Close();

            string message = result > 0 ? "Saving Successful." : "Saving Failed.";
            BlogResponseModel model = new BlogResponseModel();
            model.IsSuccess = result > 0;
            model.Message = message;

            return model;
        }

    }
}
