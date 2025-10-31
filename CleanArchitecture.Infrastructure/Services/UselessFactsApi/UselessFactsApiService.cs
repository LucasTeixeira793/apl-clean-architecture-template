using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Domain.Entities;
using Refit;

namespace CleanArchitecture.Infrastructure.Services.UselessFactsApi
{
    public class UselessFactsApiService(IUselessFactsApi _api) : IUselessFactsApiService
    {
        public async Task<ApiResponse<UselessFact>> GetRandom()
        {
            var ret = await _api.GetRandom();
            return ret;
        }
    }
}
