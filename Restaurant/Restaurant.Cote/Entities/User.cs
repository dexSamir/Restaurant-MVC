using System;
using Microsoft.AspNetCore.Identity;

namespace Restaurant.Core.Entities;
public class User : IdentityUser
{
	public string Name { get; set; }
	public string Surname { get; set; }
	public string ProfileImageUrl { get; set; }
}

