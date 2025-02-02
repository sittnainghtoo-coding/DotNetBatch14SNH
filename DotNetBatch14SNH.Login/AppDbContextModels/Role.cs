using System;
using System.Collections.Generic;

namespace DotNetBatch14SNH.Login.AppDbContextModels;

public partial class Role
{
    public string RoleId { get; set; } = null!;

    public string RoleCode { get; set; } = null!;

    public string RoleName { get; set; } = null!;
}
