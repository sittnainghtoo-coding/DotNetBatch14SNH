﻿using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MiniPosSystemSNH.RestApi.Features.POS;
using MIniPosSystemSNH.RestApi.Features.POS;
using System.Collections.Generic;

namespace MiniPosSystemSNH.RestApi.Features.POS;

public class AppDbContext : DbContext
{
    private readonly SqlConnectionStringBuilder _conntectionBuilder = new SqlConnectionStringBuilder()
    {
        DataSource = ".",
        InitialCatalog = "mini_pos_db",
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
    public DbSet<ProductModel>? Product { get; set; }
    public DbSet<SaleModel>? Sale { get; set; }
    public DbSet<CategoryModel>? Category { get; set; }

    public DbSet<SaleDetailsModel>? SaleDetails { get; set; }
    public object Blogs { get; set; }
}
