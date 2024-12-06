namespace DotNetBatch14SNH.RestApi.Features.Blog
{
    public class BlogModel
    {
        public string? BLogId {  get; set; }
        public string? BlogTitle { get; set; }
        public string? BlogAuthor { get; set; }
        public string? BlogContent { get; set; }

    }
    public class BlogResponseModel
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }
}
