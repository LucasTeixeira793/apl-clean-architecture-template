namespace CleanArchitecture.Application.UseCases.Login.Dto;

public class LoginUserResponse
{
    public string Token { get; set; }
    public DateTime ExpiresAt { get; set; }
}
