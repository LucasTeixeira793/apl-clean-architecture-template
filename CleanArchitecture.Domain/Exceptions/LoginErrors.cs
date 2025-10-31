using CleanArchitecture.Domain.Abstractions;
using CleanArchitecture.Domain.Exceptions.Base;

namespace CleanArchitecture.Domain.Exceptions
{
    public static class LoginErrors
    {
        public static readonly Error NaoAutenticado = new(ErrorCodes.NaoAutorizado, "Usuário não autorizado");
    }
}
