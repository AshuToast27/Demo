namespace Demo.web.Models.Domain
{
    public class User
    {
        public int Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required DateTime DateOfBirth { get; set; }
        public required string City { get; set; }
        public required string Address { get; set; } 

    }
}
