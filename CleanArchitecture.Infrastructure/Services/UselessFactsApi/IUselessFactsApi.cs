using CleanArchitecture.Domain.Entities;
using Refit;

namespace CleanArchitecture.Infrastructure.Services.UselessFactsApi;

public interface IUselessFactsApi
{
    [Get("/api/v2/facts/random")]
    Task<ApiResponse<UselessFact>> GetRandom();
}
