using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Domain.Abstractions;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Exceptions;
using MediatR;
using System.Net;

namespace CleanArchitecture.Application.UseCases.UselessFacts.Queries.Random;

public class GetRandomFactHandler(IUselessFactsApiService _api) : IRequestHandler<GetRandomFactQuery, Result<UselessFact>>
{
    public async Task<Result<UselessFact>> Handle(GetRandomFactQuery request, CancellationToken cancellationToken)
    {
        var response = await _api.GetRandom();
        if (response is { StatusCode: HttpStatusCode.OK })
        {
            Console.WriteLine($"New Fact: {response.Content.Text}");
        }
        else
        {
            return ErrorsDomain.ErroInesperado;
        }
        return response.Content;
    }
}
