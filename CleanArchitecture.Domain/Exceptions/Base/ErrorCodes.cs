using CleanArchitecture.Domain.Abstractions;

namespace CleanArchitecture.Domain.Exceptions.Base;

public static class ErrorCodes
{
    public static readonly Error NaoEncontrado = new ("NE", "Blog não encontrado");
    public static readonly Error ErroInesperado = new ("IN", "Ocorreu um erro inesperado");
    public static readonly Error NaoAutorizado = new ("NA", "Usuário não autenticado");

    public static readonly Error CampoObrigatorio = new ("CO", "Campo obrigatório não preenchido");
    public static readonly Error CampoInvalido = new ("CI", "Campo preenchido de forma incorreta");

}
