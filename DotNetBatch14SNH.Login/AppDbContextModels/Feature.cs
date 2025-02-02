using System;
using System.Collections.Generic;

namespace DotNetBatch14SNH.Login.AppDbContextModels;

public partial class Feature
{
    public string FeatureId { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string EndPoint { get; set; } = null!;
}
