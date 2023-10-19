namespace Demo.web.Models.Domain
{
	public class ApplicationUser
	{
		public int Id { get; set; }
		public required string UserName { get; set; }
		public required string Email { get; set; }

		public string Password { get; set; }
	}
}
