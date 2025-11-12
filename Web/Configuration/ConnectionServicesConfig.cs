using CleanArchitecture.Application;
using CleanArchitecture.Infrastructure.Data;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Web.Configuration
{
    public static class ConnectionServicesConfig
    {
        public static void AddConectionServices(this IServiceCollection services, IConfiguration configuration)
        {
            #region [ POSTGRESQL ]
            services.AddEntityFrameworkNpgsql().AddDbContext<TesteDbContext>(option =>
                option.UseNpgsql(configuration.GetConnectionString("PostgresTeste"))
            );
            #endregion

            #region [ FLUENT VALIDATION ]
            services.AddValidatorsFromAssembly(typeof(AssemblyReference).Assembly, includeInternalTypes: true);
            #endregion
        }
    }
}
