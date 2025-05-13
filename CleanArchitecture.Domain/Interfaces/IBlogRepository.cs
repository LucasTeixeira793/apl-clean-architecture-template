using CleanArchitecture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Interfaces;

public interface IBlogRepository
{
    Task<List<Blog>> GetAllAsync();
    Task<List<Blog>> GetByExpressionAsync(Expression<Func<Blog, bool>> expression);
    Task<Blog> CreateAsync(Blog blog);
    Task<int> UpdateAsync(Blog blog, int id);
    Task<int> DeleteAsync(int id);
}
