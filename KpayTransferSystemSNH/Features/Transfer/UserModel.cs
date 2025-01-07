﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KpayTransferSystemSNH.RestApi.Features.Transfer;

[Table("tbl_user")]
public class UserModel
{
    [Key]
    public string? UserId { get; set; } = Guid.NewGuid().ToString();
    public string? UserName { get; set; }
    public string? MobileNumber { get; set; }
    public decimal? Balance { get; set; } = 10000;
    public string? Password { get; set; }
}

public class UserRequestModel
{
    public string? UserName { get; set; }
    public string? MobileNumber { get; set; }
    public string? Password { get; set; }
}

public class UserDepositModel
{
    public string? MobileNumber { get; set; }
    public decimal? Balance { get; set; }
}

public class UserWithdrawModel
{
    public string? MobileNumber { get; set; }
    public decimal? Balance { get; set; }
}

public class UserResponseModel
{
    public bool IsSuccess { get; set; }
    public string? Message { get; set; }
}
