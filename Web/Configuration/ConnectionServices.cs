using CleanArchitecture.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Web.Configuration
{
    public static class ConnectionServices
    {
        public static void AddConectionServices(this IServiceCollection services, IConfiguration configuration)
        {
            #region [ POSTGRESQL ]
            services.AddEntityFrameworkNpgsql().AddDbContext<BlogDbContext>(option =>
                option.UseNpgsql(configuration.GetConnectionString("PostgresTeste"))
            );
            #endregion
        }
    }
}
