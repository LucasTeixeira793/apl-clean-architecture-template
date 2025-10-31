using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.Application;
public static class AssemblyReference
{
    public static void AddApplication(this IServiceCollection service)
    {
        service.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(typeof(AssemblyReference).Assembly);
        });
    }
}
