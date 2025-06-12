using CleanArchitecture.Domain.Interfaces;
using CleanArchitecture.Infrastructure.Repository;

namespace Web.Configuration
{
    public static class DependencyInjection
    {
        public static void AddDependencyInjection(this IServiceCollection services)
        {            
            #region Repositories
            services.AddScoped<IBlogRepository, BlogRepository>();

            #endregion
        }
    }
}
