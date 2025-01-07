using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetBatch14SNH.ConsoleApp1.EFCoreExamples
{
    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(AppSettings.SqlConnectionStringBuilder.ConnectionString);
                optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);

        }

        public DbSet<TblBlog> Blogs { get; set; }



    }

    [Table("Tbl_Blog")]

    public class TblBlog
    {
        [Key]
        [Column("BlogId")]
        public string id {  get; set; }

        [Column("BlogTitle")]
        public string title { get; set; }

        [Column("BlogAuthor")]
        public string author {  get; set; }

        [Column("BlogContent")]

        public string content {  get; set; }


    }
}
