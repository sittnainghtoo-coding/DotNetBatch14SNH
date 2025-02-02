using DotNetBatch14SNH.Login.AppDbContextModels;
using DotNetBatch14SNH.Login.Fearures.Login;
using DotNetBatch14SNH.RBAC;
using Microsoft.EntityFrameworkCore;

namespace DotNetBatch14SNH.Login.Fearures.Register
{
    public class RegisterService
    {
        private readonly AppDbContext _db;
        public RegisterService(AppDbContext db)
        {
            _db = db;
        }

        public async Task<RegisterResponseModel> Execute(RegisterRequestModel requestModel)
        {
            RegisterResponseModel response = new();
            try
            {
                string trimmedUsername = requestModel.Username.Trim();

                string combined = requestModel.Password + trimmedUsername;

                string hashPassword = DevCode.HashPassword(combined);

                var role = await _db.Roles.FirstOrDefaultAsync(x => x.Name == requestModel.Role);
                if (role is null)
                {
                    response.Success = false;
                    response.Message = "Role does not exists.";
                    return response;
                }

                var user = await _db.Users.FirstOrDefaultAsync(x => x.Email == requestModel.Email);
                if (user is not null)
                {
                    response.Success = false;
                    response.Message = "User already exists.";
                    return response;
                }

                string userId = Guid.NewGuid().ToString();

                User newUser = new()
                {
                    Id = userId,
                    Name = requestModel.Username,
                    Email = requestModel.Email,
                    Password = hashPassword,
                    RoleId = role.Id
                };

                await _db.Users.AddAsync(newUser);
                await _db.SaveChangesAsync();

                response.Success = true;
                response.Message = "Register successful.";
                response.Data = new
                {
                    Id = userId,
                    Name = requestModel.Username,
                    Email = requestModel.Email,
                    Role = role.Name
                };
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
