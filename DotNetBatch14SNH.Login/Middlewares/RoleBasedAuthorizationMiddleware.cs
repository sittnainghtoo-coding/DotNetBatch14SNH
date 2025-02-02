using Dapper;
using DotNetBatch14SNH.Login.AppDbContextModels;
using DotNetBatch14SNH.Login.Fearures.Login;
using DotNetBatch14SNH.RBAC;
using Microsoft.Data.SqlClient;
using System.Data;

namespace DotNetBatch14SNH.Login.Middlewares
{
    public class RoleBasedAuthorizationMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly AppDbContext _db;
        private readonly IConfiguration _configuration;

        private readonly string[] allowList = new string[] { "/api/login", "/api/register" };

        public RoleBasedAuthorizationMiddleware(RequestDelegate next, AppDbContext db, IConfiguration configuration)
        {
            _next = next;
            _db = db;
            _configuration = configuration;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            string endpoint = context.Request.Path.ToString().ToLower();
            foreach (var item in allowList)
            {
                if (endpoint == item)
                {
                    goto Result;
                }
            }

            var token = context.Request.Headers["token"].ToString();
            if (token == "")
            {
                await context.Response.WriteAsync("Unauthorized");
                return;
            }

            var tokenModel = token.ToDecrypt().ToObject<TokenModel>();

            if (tokenModel.ExpireTime < DateTime.Now)
            {
                await context.Response.WriteAsync("session expired.");
                return;
            }

            var permission = await GetPermission(tokenModel.RoleId, endpoint);

            if (permission is null)
            {
                await context.Response.WriteAsync("Unauthorized");
                return;
            }

        Result:
            await _next(context);
        }

        private async Task<PermissionModel> GetPermission(string roleId, string endpoint)
        {
            string connectionString = _configuration.GetConnectionString("DbConnection")!;
            using IDbConnection connection = new SqlConnection(connectionString);


            string query = $@"select P.id as PermissionId, F.name as FeatureName, F.endpoint as FeatureEndpoint, R.name as RoleName, R.code as RoleCode
from ((Permissions as P 
inner join Features as F on P.feature_id = F.id) 
inner join Roles as R on P.role_id = R.id) 
where R.id = @RoleId and F.endpoint = @Endpoint";

            var permissionModel = await connection.QueryFirstOrDefaultAsync<PermissionModel>(query, new { RoleId = roleId, Endpoint = endpoint });

            return permissionModel!;
        }
    }
}
