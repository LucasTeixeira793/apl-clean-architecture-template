using CleanArchitecture.Domain.Entities;
using System.Linq.Expressions;

namespace CleanArchitecture.Domain.Interfaces;

public interface IBlogRepository
{
    Task<List<Blog>> GetAllAsync();
    Task<Blog> GetSingleByExpressionAsync(Expression<Func<Blog, bool>> expression);
    Task<Blog> CreateAsync(Blog blog);
    Task<int> UpdateAsync(Blog blog, int id);
    Task<int> DeleteAsync(int id);
}
