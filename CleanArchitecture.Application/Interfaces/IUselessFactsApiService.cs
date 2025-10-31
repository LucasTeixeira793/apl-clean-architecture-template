using CleanArchitecture.Domain.Entities;
using Refit;

namespace CleanArchitecture.Application.Interfaces;

public interface IUselessFactsApiService
{
    Task<ApiResponse<UselessFact>> GetRandom();
}
