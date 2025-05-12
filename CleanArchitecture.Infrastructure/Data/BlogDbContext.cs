using CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Infrastructure.Data
{
    public class BlogDbContext(DbContextOptions<BlogDbContext> dbContextOptions) : DbContext(dbContextOptions)
    {
        public DbSet<Blog> Blog { get; set; }

        #region Configuration
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseNpgsql(_configuration.GetConnectionString("PostgresTeste"));
        //}
        #endregion
    }
}
