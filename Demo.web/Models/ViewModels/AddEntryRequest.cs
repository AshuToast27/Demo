using Demo.web.Controllers;
using System.ComponentModel.DataAnnotations;


namespace Demo.web.Models.ViewModels
{
	public class AddEntryRequest
	{
		[Key]
		public int Id { get; set; }
		public required string Fname { get; set; }
		public required string Lname { get; set; }
		public DateTime Dob { get; set; }
		public required string City { get; set; }
		public required string Address { get; set; }
		public required string Mail { get; set; }
		public required string Password { get; set; }
		public IFormFile Photo { get; set; }
		public string FullName { 
			get { return Fname+ " "+Lname; }
				}
	}
}
