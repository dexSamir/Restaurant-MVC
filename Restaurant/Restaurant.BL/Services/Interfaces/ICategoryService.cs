using System;
using Restaurant.BL.VM.Category;
using Restaurant.Core.Entities;

namespace Restaurant.BL.Services.Interfaces;
public interface ICategoryService 
{
	Task<IEnumerable<CategoryGetVM>> GetAllAsync();
	Task<int> CreateAsync(CategoryCreateVM vm);
	Task<Category> UpateAsync(CategoryUpdateVM vm); 
}

