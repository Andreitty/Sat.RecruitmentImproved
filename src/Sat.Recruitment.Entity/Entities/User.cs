using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Sat.Recruitment.Entity.Bases;

namespace Sat.Recruitment.Entity.Entities
{
	[Index(nameof(Email), IsUnique = true)]
	[Index(nameof(Phone), IsUnique = true)]
	public class User : BaseEntity<int>
	{
		[Required]
		[StringLength(30, MinimumLength = 6)]
		public string Address { get; set; } = string.Empty;
		[Required]
		[EmailAddress]
		public string Email { get; set; } = string.Empty;
		public decimal Balance { get; set; }
		[Required]
		[StringLength(20, MinimumLength = 3)]
		public string Name { get; set; } = string.Empty;
		[Required]
		[Phone]
		public string Phone { get; set; } = string.Empty;
		[Required]
		public string UserType { get; set; } = string.Empty;
	}
}
