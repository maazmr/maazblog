using mynewblogapi.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public class BlogProvider
{
    private readonly BlogRepository _blogRepository;

    public BlogProvider(BlogRepository blogRepository)
    {
        _blogRepository = blogRepository;
    }

    public async Task<IEnumerable<Blog>> GetAllBlogsAsync() => await _blogRepository.GetAllBlogsAsync();

    public async Task<int> CreateBlogAsync(Blog blog)
    {
        return await _blogRepository.CreateBlogAsync(blog);
    }

    public async Task<bool> UpdateBlogAsync(Blog blog)
    {
        return await _blogRepository.UpdateBlogAsync(blog);
    }

    public async Task<bool> DeleteBlogAsync(int blogId)
    {
        return await _blogRepository.DeleteBlogAsync(blogId);
    }

}


