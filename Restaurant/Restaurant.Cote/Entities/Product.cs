using System;
using Restaurant.Core.Entities.Base;

namespace Restaurant.Core.Entities;
public class Product : BaseEntity 
{
	public string Title { get; set; }
	public string Description { get; set; }
	public decimal Price { get; set; }
	public int CategoryId { get; set; }
	public string CoverImage { get; set; }
	public Category Category { get; set; }
	public ICollection<ProductImage> OtherImages { get; set; }

}

