using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Interfaces;
using CleanArchitecture.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CleanArchitecture.Infrastructure.Repository;

public class BlogRepository(BlogDbContext _dbContext) : IBlogRepository
{
    public async Task<Blog> CreateAsync(Blog blog)
    {
        await _dbContext.Blog.AddAsync(blog);
        await _dbContext.SaveChangesAsync();
        return blog;
    }

    public async Task<int> DeleteAsync(int id)
        => await _dbContext.Blog.Where(e => e.Id == id).ExecuteDeleteAsync();

    public async Task<List<Blog>> GetAllAsync()
        => await _dbContext.Blog.ToListAsync();

    public async Task<Blog> GetSingleByExpressionAsync(Expression<Func<Blog, bool>> expression)
        => await _dbContext.Blog.Where(expression).FirstOrDefaultAsync();

    public async Task<int> UpdateAsync(Blog blog, int id)
        => await _dbContext.Blog
                 .Where(e => e.Id == id)
                 .ExecuteUpdateAsync(setter => setter
                    .SetProperty(m => m.Name, blog.Name)
                    .SetProperty(m => m.Author, blog.Author)
                    .SetProperty(m => m.Description, blog.Description)
                    .SetProperty(m => m.ImageUrl, blog.ImageUrl)
                 );
}
