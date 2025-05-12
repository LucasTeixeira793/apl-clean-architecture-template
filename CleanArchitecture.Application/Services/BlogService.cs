using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Services
{
    public class BlogService(IBlogRepository _blogRepository) : IBlogService
    {
        public async Task<Blog> CreateAsync(Blog blog)
        {
            return await _blogRepository.CreateAsync(blog);
        }

        public async Task<int> DeleteAsync(int id)
        {
            return await _blogRepository.DeleteAsync(id);
        }

        public async Task<List<Blog>> GetAllAsync()
        {
            return await _blogRepository.GetAllAsync();
        }

        public async Task<Blog> GetByIdAsync(int id)
        {
            return await _blogRepository.GetByIdAsync(id);
        }

        public async Task<int> UpdateAsync(Blog blog, int id)
        {
            return await _blogRepository.UpdateAsync(blog, id);
        }
    }
}
