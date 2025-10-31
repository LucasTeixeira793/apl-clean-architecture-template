using CleanArchitecture.Domain.Abstractions;
using CleanArchitecture.Domain.Entities;
using MediatR;

namespace CleanArchitecture.Application.UselessFacts.Queries.Random;

public record GetRandomFactQuery : IRequest<Result<UselessFact>>;

