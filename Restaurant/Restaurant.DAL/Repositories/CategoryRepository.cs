using System;
using Microsoft.AspNetCore.Http;
using Restaurant.Core.Entities;
using Restaurant.Core.Repositories;
using Restaurant.DAL.Context;

namespace Restaurant.DAL.Repositories;
public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
{
    public CategoryRepository(AppDbContext context, IHttpContextAccessor http) : base(context, http)
    {
    }
}

