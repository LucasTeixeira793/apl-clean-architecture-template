using CleanArchitecture.Domain.Abstractions;
using CleanArchitecture.Domain.Exceptions.Base;

namespace CleanArchitecture.Domain.Exceptions;

public static class ErrorsDomain
{
    public static readonly List<Error> BlogNaoEncontrado = [ErrorCodes.NaoEncontrado];
    public static readonly List<Error> ErroInesperado = [ErrorCodes.ErroInesperado];
    public static readonly List<Error> UsuarioOuSenhaInvalidos = [ErrorCodes.NaoAutorizado];
}
