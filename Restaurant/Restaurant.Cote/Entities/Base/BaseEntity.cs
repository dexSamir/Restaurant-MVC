﻿using System;
namespace Restaurant.Core.Entities.Base;
public class BaseEntity
{
	public int Id { get; set; }
	public DateTime CreatedTime { get; set; }
	public DateTime? UpdatedTime { get; set; }
	public bool IsDeleted { get; set; }
}

