using System;
using System.Linq.Expressions;
using Restaurant.Core.Entities;
using Restaurant.Core.Entities.Base;

namespace Restaurant.Core.Repositories;
public interface IGenericRepository<T> where T :BaseEntity, new() 
{
	IQueryable<T> GetAll(params string[] includes);
	Task<T?> GetByIdAsync(int id);
	IQueryable<T> GetWhere(Expression<Func<T, bool>> expression);
	Task<bool> IsExistAsync(int id);
	Task<bool> IsExistAsync(Expression<Func<T, bool>> expression);
	Task AddAsync(T entity);
	Task AddRangeAsync(params T[] entities);
	void Remove(T entity);
	Task<bool> RemoveAsync(int id);
	Task<int> SaveAsync();
	string GetCurrentUserId();
	Task<User?> GetCurrentUserAsync(); 
}

