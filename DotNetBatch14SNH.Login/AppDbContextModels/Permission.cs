using System;
using System.Collections.Generic;

namespace DotNetBatch14SNH.Login.AppDbContextModels;

public partial class Permission
{
    public string UserPermissionId { get; set; } = null!;

    public string RoleId { get; set; } = null!;

    public string FeatureId { get; set; } = null!;
}
