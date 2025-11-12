using CleanArchitecture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Interfaces;

public interface IUserRepository
{
    Task<User> GetUserByEmail(string email);
    Task<List<Role>> GetUserRoles(long idUser);
}
