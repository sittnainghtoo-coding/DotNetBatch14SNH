using KpayTransferSystemSNH.RestApi.Features.Transfer;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace KpayTransferSystemSNH.RestApi.Features.Transfer;

public class AppDbContext : DbContext
{
    private readonly SqlConnectionStringBuilder _conntectionBuilder = new SqlConnectionStringBuilder()
    {
        DataSource = ".",
        InitialCatalog = "kpay_transfer_db",
        UserID = "sa",
        Password = "12345",
        TrustServerCertificate = true,
    };

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(_conntectionBuilder.ConnectionString);
        }
    }
    public DbSet<TransferModel>? TransfersHistory { get; set; }
    public DbSet<UserModel>? Users { get; set; }
}
