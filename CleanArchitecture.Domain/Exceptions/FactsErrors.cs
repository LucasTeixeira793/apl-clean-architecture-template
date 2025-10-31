using CleanArchitecture.Domain.Abstractions;
using CleanArchitecture.Domain.Exceptions.Base;

namespace CleanArchitecture.Domain.Exceptions
{
    public static class FactsErrors
    {
        public static readonly Error ErroInesperado = new(ErrorCodes.ErroInesperado, "Ocorreu um erro inesperado");
    }
}
