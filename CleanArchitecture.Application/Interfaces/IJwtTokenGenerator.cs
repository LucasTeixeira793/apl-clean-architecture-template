using CleanArchitecture.Application.UseCases.Login.Dto;

namespace CleanArchitecture.Application.Interfaces
{
    public interface IJwtTokenGenerator
    {
        public LoginUserResponse GenerateToken(string userId, string email, List<string> roles);
    }
}
