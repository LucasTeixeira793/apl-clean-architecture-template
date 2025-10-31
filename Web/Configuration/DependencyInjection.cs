using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Domain.Interfaces;
using CleanArchitecture.Infrastructure.Repository;
using CleanArchitecture.Infrastructure.Services.UselessFactsApi;

namespace Web.Configuration
{
    public static class DependencyInjection
    {
        public static void AddDependencyInjection(this IServiceCollection services)
        {
            #region Services
            services.AddScoped<IJwtTokenGenerator, JwtTokenConfig>();
            services.AddScoped<IUselessFactsApiService, UselessFactsApiService>();
            #endregion

            #region Repositories
            services.AddScoped<IBlogRepository, BlogRepository>();

            #endregion
        }
    }
}
