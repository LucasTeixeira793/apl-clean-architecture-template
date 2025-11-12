using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Interfaces;
using CleanArchitecture.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infrastructure.Repository;

public class UserRepository(TesteDbContext _dbContext) : IUserRepository
{
    public async Task<User> GetUserByEmail(string email)
        => await _dbContext.Users
            .Where(u => u.Email == email)
            .Select(u => u)
            .FirstOrDefaultAsync();

    public async Task<List<Role>> GetUserRoles(long idUser)
        => await _dbContext.Roles
            .Join(_dbContext.UserRoles,
                  r => r.Id,
                  ur => ur.RoleId,
                  (r, ur) => new { Role = r, UserRole = ur })
            .Where(joined => joined.UserRole.UserId == idUser)
            .Select(joined => joined.Role)
            .ToListAsync();

}
