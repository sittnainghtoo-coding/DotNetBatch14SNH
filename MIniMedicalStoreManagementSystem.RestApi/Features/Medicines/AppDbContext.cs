using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace MIniMedicalStoreManagementSystem.RestApi.Features.Medicines
{
    public class AppDbContext : DbContext
    {
        private readonly SqlConnectionStringBuilder _sqlConnectionStringBuilder;

        public AppDbContext()
        {
            _sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
            {
                DataSource = ".",
                InitialCatalog = "mininal_medical_store_management",
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

        public DbSet<MedicineModel> Medicine { get; set; }
    }
}
