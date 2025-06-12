using CleanArchitecture.Domain.Abstractions;
using CleanArchitecture.Domain.Exceptions.Base;

namespace CleanArchitecture.Domain.Exceptions
{
    public static class BlogErrors
    {
        public static readonly Error BlogNaoEncontrado = new(ErrorCodes.NaoEncontrado, "Blog não encontrado");
    }
}
