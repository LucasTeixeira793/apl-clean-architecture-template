using CleanArchitecture.Infrastructure.Services.UselessFactsApi;
using Polly;
using Polly.Extensions.Http;
using Refit;

namespace Web.Configuration;

public static class ExternalServicesConfig
{
    public static void AddExternalServices(this IServiceCollection services, IConfiguration configuration)
    {
        services
            .AddRefitClient<IUselessFactsApi>()
            .ConfigureHttpClient((sp, client) =>
            {
                var config = sp.GetRequiredService<IConfiguration>();
                var baseUrl = config["ServicesSettings:UselessFactsApi:BaseUrl"];
                client.BaseAddress = new Uri(baseUrl!);
                client.Timeout = TimeSpan.FromSeconds(10);
            })
            .AddPolicyHandler(GetRetryPolicy())
            .AddPolicyHandler(GetCircuitBreakerPolicy());
    }

    private static IAsyncPolicy<HttpResponseMessage> GetRetryPolicy() =>
        HttpPolicyExtensions
            .HandleTransientHttpError()
            .WaitAndRetryAsync(3, retry => TimeSpan.FromSeconds(Math.Pow(2, retry)));

    private static IAsyncPolicy<HttpResponseMessage> GetCircuitBreakerPolicy() =>
        HttpPolicyExtensions
            .HandleTransientHttpError()
            .CircuitBreakerAsync(5, TimeSpan.FromSeconds(30));
}

