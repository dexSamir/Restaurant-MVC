using System;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Restaurant.BL.Services.Interfaces;
using Restaurant.BL.VM.Category;
using Restaurant.Core.Entities;
using Restaurant.Core.Repositories;

namespace Restaurant.BL.Services.Implements;
public class CategoryService : ICategoryService
{
    readonly ICategoryRepository _repo;
    public CategoryService(ICategoryRepository repo)
    {
        _repo = repo;
    }

    public async Task<int> CreateAsync(CategoryCreateVM vm)
    {
        Category category = new Category
        {
            Name = vm.Name,
        };
        await _repo.AddAsync(category);
        await _repo.SaveAsync();
        return category.Id; 
    }

    public async Task<IEnumerable<CategoryGetVM>> GetAllAsync()
    {
        return await _repo.GetAll().Select(x=> new CategoryGetVM
        {
            Name = x.Name
        }).ToListAsync(); 
    }

    public Task<Category> UpateAsync(CategoryUpdateVM vm)
    {
        throw new NotImplementedException();
    }
}

