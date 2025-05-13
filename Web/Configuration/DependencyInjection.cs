using CleanArchitecture.Domain.Interfaces;
using CleanArchitecture.Infrastructure.Repository;

namespace CleanArchitecture.API.Configuration
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
