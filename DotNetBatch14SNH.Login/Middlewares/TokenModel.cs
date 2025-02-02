namespace DotNetBatch14SNH.Login.Middlewares
{
    public class TokenModel
    {

        public string UserId { get; set; } = null!;

        public string Name { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string RoleId { get; set; } = null!;
        public DateTime ExpireTime { get; set; }
    }
}
