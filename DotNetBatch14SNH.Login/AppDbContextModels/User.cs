using System;
using System.Collections.Generic;

namespace DotNetBatch14SNH.Login.AppDbContextModels;

public partial class User
{
    public string UserId { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string RoleCode { get; set; } = null!;

    public string Email { get; set; } = null!;
}
