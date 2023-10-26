using Dapper;
using Microsoft.Data.SqlClient;
using mynewblogapi.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

public class BlogRepository
{
    private readonly string _connectionString;

    public BlogRepository(string connectionString)
    {
        _connectionString = connectionString;
    }

    public async Task<IEnumerable<Blog>> GetAllBlogsAsync()
    {
        using IDbConnection db = new SqlConnection(_connectionString);
        const string query = "SELECT * FROM Blogs";
        var blogs = await db.QueryAsync<Blog>(query);
        return blogs;
    }

    public async Task<Blog> GetBlogByIdAsync(int blogId)
    {
        using IDbConnection db = new SqlConnection(_connectionString);
        const string query = "SELECT * FROM Blogs WHERE Id = @Id";
        var blog = await db.QueryFirstOrDefaultAsync<Blog>(query, new { Id = blogId });
        return blog;
    }

    // Add methods for creating, updating, and deleting blogs as needed
    public async Task<int> CreateBlogAsync(Blog blog)
    {
        using IDbConnection db = new SqlConnection(_connectionString);
        const string query = "INSERT INTO Blogs (Title, Content) VALUES (@Title, @Content); SELECT SCOPE_IDENTITY()";
        var newBlogId = await db.ExecuteScalarAsync<int>(query, blog);
        return newBlogId;
    }

    public async Task<bool> UpdateBlogAsync(Blog blog)
    {
        using IDbConnection db = new SqlConnection(_connectionString);
        const string query = "UPDATE Blogs SET Title = @Title, Content = @Content WHERE Id = @Id";
        var rowsAffected = await db.ExecuteAsync(query, blog);
        return rowsAffected > 0;
    }

    public async Task<bool> DeleteBlogAsync(int blogId)
    {
        using IDbConnection db = new SqlConnection(_connectionString);
        const string query = "DELETE FROM Blogs WHERE Id = @Id";
        var rowsAffected = await db.ExecuteAsync(query, new { Id = blogId });
        return rowsAffected > 0;
    }
}
