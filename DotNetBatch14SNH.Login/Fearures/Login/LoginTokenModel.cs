namespace DotNetBatch14SNH.Login.Fearures.Login
{
    public class LoginTokenModel
    {
        public string UserId { get; set; } = null!;

        public string Name { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string RoleCode { get; set; } = null!;
        public DateTime ExpireTime { get; set; }
    }
}
