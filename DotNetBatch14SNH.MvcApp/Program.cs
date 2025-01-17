using DotNetBatch14SNH_Shared;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection"));
}, ServiceLifetime.Transient, ServiceLifetime.Transient);

//string connectionString = builder.Configuration.GetConnectionString("DbConnection"); 
//builder.Services.AddScoped(n => new BlogDapperService(connectionString));
//builder.Services.AddScoped<BlogEFCoreService>();
//builder.Services.AddScoped(n=>new BlogService(connectionString));

//builder.Services.AddScoped<IBlogService, BlogDapperService>();
//builder.Services.AddScoped<IBlogService, BlogEFCoreService>();
builder.Services.AddControllersWithViews().AddJsonOptions(opt =>
{
	opt.JsonSerializerOptions.PropertyNamingPolicy = null;
});
// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

//https://localhost:300/Home/Index?/1

//method(string BlogId)

app.Run();
