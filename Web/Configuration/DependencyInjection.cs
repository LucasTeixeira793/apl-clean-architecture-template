using CleanArchitecture.Application.Login.UseCases.Commands.LoginUser;
using CleanArchitecture.Domain.Interfaces;
using CleanArchitecture.Infrastructure.Repository;

namespace Web.Configuration
{
    public static class DependencyInjection
    {
        public static void AddDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();

            #region Repositories
            services.AddScoped<IBlogRepository, BlogRepository>();

            #endregion
        }
    }
}
