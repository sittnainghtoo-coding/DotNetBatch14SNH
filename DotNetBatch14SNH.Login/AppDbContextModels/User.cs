﻿namespace DotNetBatch14SNH.Login.AppDbContextModels
{
    public class User
    {
        public string Id { get; set; } = null!;

        public string Name { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Password { get; set; } = null!;

        public string RoleId { get; set; } = null!;
    }
}
