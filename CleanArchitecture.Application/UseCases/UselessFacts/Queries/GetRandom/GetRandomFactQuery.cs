using CleanArchitecture.Domain.Abstractions;
using CleanArchitecture.Domain.Entities;
using MediatR;

namespace CleanArchitecture.Application.UseCases.UselessFacts.Queries.Random;

public record GetRandomFactQuery : IRequest<Result<UselessFact>>;

