using Microsoft.EntityFrameworkCore;

namespace DotNetBatch14SNH.Login.AppDbContextModels
{
    public partial class AppDbContext : DbContext
    {
        public AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Feature> Features { get; set; }

        public virtual DbSet<Permission> Permissions { get; set; }

        public virtual DbSet<Role> Roles { get; set; }

        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Feature>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(newid())")
                    .HasColumnName("id");
                entity.Property(e => e.Endpoint)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("endpoint");
                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Permission>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .HasColumnName("id");
                entity.Property(e => e.FeatureId)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .HasColumnName("feature_id");
                entity.Property(e => e.RoleId)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .HasColumnName("role_id");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(newid())")
                    .HasColumnName("id");
                entity.Property(e => e.Code)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("code");
                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(newid())")
                    .HasColumnName("id");
                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("email");
                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("name");
                entity.Property(e => e.Password)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("password");
                entity.Property(e => e.RoleId)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .HasColumnName("role_id");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }

}
