using System;
using System.Linq.Expressions;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Restaurant.Core.Entities;
using Restaurant.Core.Entities.Base;
using Restaurant.Core.Repositories;
using Restaurant.DAL.Context;

namespace Restaurant.DAL.Repositories;
public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity , new()
{
    readonly AppDbContext _context;
    readonly IHttpContextAccessor _http; 
    protected DbSet<T> Table => _context.Set<T>();
    
    public GenericRepository(AppDbContext context, IHttpContextAccessor http)
    {
        _http = http; 
        _context = context; 
    }

    public async Task AddAsync(T entity)
        => await Table.AddAsync(entity);

    public async Task AddRangeAsync(params T[] entities)
        => await Table.AddRangeAsync(entities);

    public IQueryable<T> GetAll(params string[] includes)
    {
        var query = Table.AsQueryable();
        foreach (var include in includes)
            query = query.Include(include);
        return query; 
    }

    public async Task<T?> GetByIdAsync(int id)
        => await Table.FindAsync(id); 

    public async Task<User?> GetCurrentUserAsync()
    {
        string UserId = GetCurrentUserId();
        if (string.IsNullOrWhiteSpace(UserId))
            return null;
        return await _context.Users.FindAsync(UserId); 
    }

    public string GetCurrentUserId()
        => _http.HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value;

    public IQueryable<T> GetWhere(Expression<Func<T, bool>> expression)
        => Table.Where(expression).AsQueryable();

    public async Task<bool> IsExistAsync(int id)
        => await Table.AnyAsync(x => x.Id == id);

    public async Task<bool> IsExistAsync(Expression<Func<T, bool>> expression)
        => await Table.AnyAsync(expression);

    public void Remove(T entity)
        => Table.Remove(entity);

    public async Task<bool> RemoveAsync(int id)
    {
        int result = await Table.Where(x => x.Id == id).ExecuteDeleteAsync(); 
        return result > 0; 
    }
    public Task<int> SaveAsync()
        => _context.SaveChangesAsync(); 
}

