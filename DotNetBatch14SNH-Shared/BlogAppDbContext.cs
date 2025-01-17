using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetBatch14SNH_Shared
{
    public class BlogAppDbContext : DbContext
    {
        public BlogAppDbContext(DbContextOptions<BlogAppDbContext> options) : base(options)
        {
        }
    }
}
