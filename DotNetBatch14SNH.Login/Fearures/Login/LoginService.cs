using DotNetBatch14SNH.Login.AppDbContextModels;
using DotNetBatch14SNH.RBAC;
using Microsoft.EntityFrameworkCore;

namespace DotNetBatch14SNH.Login.Fearures.Login
{
    public class LoginService
    {
        private readonly AppDbContext _db;

        public LoginService(AppDbContext db)
        {
            _db = db;
        }
        public async Task<LoginResponseModel> Execute(LoginRequestModel requestModel)
        {
            LoginResponseModel response = new();

            try
            {
                var user = await _db.Users
                .FirstOrDefaultAsync(x => x.Email == requestModel.Email);
                if (user is null)
                {
                    response.Success = false;
                    response.Message = "Email or Password is wrong.";
                    return response;
                }

                string trimmedUsername = user.Name.Trim();

                string combined = requestModel.Password + trimmedUsername;

                string hashPassword = DevCode.HashPassword(combined);

                if (hashPassword != user.Password)
                {
                    response.Success = false;
                    response.Message = "Email or Password is wrong.";
                    return response;
                }

                LoginTokenModel tokenModel = new()
                {
                    UserId = user.Id,
                    Email = user.Email,
                    Name = user.Name,
                    RoleId = user.RoleId,
                    ExpireTime = DateTime.Now.AddMinutes(5),
                };

                var token = tokenModel.ToJson().ToEncrypt();

                response.Success = true;
                response.Message = "Login successful.";
                response.Token = token;
                return response;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.ToString();
                return response;
            }
        }
    }
}
