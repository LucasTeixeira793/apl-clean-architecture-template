using CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;

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
