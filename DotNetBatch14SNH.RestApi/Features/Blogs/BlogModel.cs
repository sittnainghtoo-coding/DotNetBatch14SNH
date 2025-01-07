namespace DotNetBatch14SNH.RestApi.Features.Blogs
{
    public class BlogModel
    {
        public string? BlogId { get; set; }

        public string? BlogTitle { get; set; }

        public string? BlogAuthor { get; set; }
        public string? BlogContent { get; set; }
    }

    public class BlogResponseModel
    {
        public bool IsSuccess { get; set; }
        public string? Message { get; set; }
    }
}
