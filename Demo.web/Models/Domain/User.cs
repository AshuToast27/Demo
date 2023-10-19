using System.ComponentModel.DataAnnotations;
	

namespace Demo.web.Models.Domain
{
	public class User
	{
		[Key]
		public int Id { get; set; }
		public required string FirstName { get; set; }
		public required string LastName { get; set; }
		public required DateTime DateOfBirth { get; set; }
		public required string City { get; set; }
		public required string Address { get; set; }
		public required string Mail { get; set; }
		public string Photo { get; set; }

	
	}
}
