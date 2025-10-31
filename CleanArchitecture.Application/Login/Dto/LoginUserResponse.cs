namespace CleanArchitecture.Application.Login.Dto;

public class LoginUserResponse
{
    public string Token { get; set; }
    public DateTime ExpiresAt { get; set; }
}
