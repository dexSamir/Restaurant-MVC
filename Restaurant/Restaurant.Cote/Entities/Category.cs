using System;
using Restaurant.Core.Entities.Base;

namespace Restaurant.Core.Entities;
public class Category : BaseEntity 
{
	public string Name { get; set; }
	public ICollection<Product> Products { get; set; }
}

