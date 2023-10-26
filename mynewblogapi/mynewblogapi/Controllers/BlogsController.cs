using Microsoft.AspNetCore.Mvc;
using mynewblogapi.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

[ApiController]
[Route("api/blogs")]
public class BlogsController : ControllerBase
{
    private readonly BlogProvider _blogProvider;

    public BlogsController(BlogProvider blogProvider)
    {
        _blogProvider = blogProvider;
    }

    [HttpGet]
    public async Task<IActionResult> GetBlogs()
    {
        var blogs = await _blogProvider.GetAllBlogsAsync();
        return Ok(blogs);
    }

    [HttpPost]
    public async Task<IActionResult> CreateBlog([FromBody] Blog blog)
    {
        var newBlogId = await _blogProvider.CreateBlogAsync(blog);
        return Ok(newBlogId);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateBlog(int id, [FromBody] Blog blog)
    {
        blog.Id = id;
        var result = await _blogProvider.UpdateBlogAsync(blog);
        if (result)
        {
            return Ok();
        }
        return NotFound();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBlog(int id)
    {
        var result = await _blogProvider.DeleteBlogAsync(id);
        if (result)
        {
            return Ok();
        }
        return NotFound();
    }
}
