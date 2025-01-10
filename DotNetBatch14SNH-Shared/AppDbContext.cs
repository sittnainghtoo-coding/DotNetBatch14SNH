using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace DotNetBatch14SNH_Shared;

public class AppDbContext : DbContext
{
    private readonly SqlConnectionStringBuilder _sqlConnectionStringBuilder;

    public AppDbContext()
    {
        _sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
        {
            DataSource = ".",
            InitialCatalog = "TransferDb",
            UserID = "sa",
            Password = "12345",
            TrustServerCertificate = true
        };
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(_sqlConnectionStringBuilder.ConnectionString);
        }
        base.OnConfiguring(optionsBuilder);
    }

    public DbSet<BlogModel> Blogs { get; set; }
}
