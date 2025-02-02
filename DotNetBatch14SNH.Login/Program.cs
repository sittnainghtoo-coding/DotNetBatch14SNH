using DotNetBatch14SNH.Login.AppDbContextModels;
using DotNetBatch14SNH.Login.Fearures.CategoryList;
using DotNetBatch14SNH.Login.Fearures.Login;
using DotNetBatch14SNH.Login.Fearures.ProductList;
using DotNetBatch14SNH.Login.Fearures.Register;
using DotNetBatch14SNH.Login.Middlewares;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
    options.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection"));
}, ServiceLifetime.Transient, ServiceLifetime.Transient);

builder.Services.AddScoped<RegisterService>();
builder.Services.AddScoped<LoginService>();
builder.Services.AddScoped<ProductListService>();
builder.Services.AddScoped<CategoryListService>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseMiddleware<RoleBasedAuthorizationMiddleware>();


app.UseAuthorization();

app.MapControllers();

app.Run();
