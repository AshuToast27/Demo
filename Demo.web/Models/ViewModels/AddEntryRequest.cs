namespace Demo.web.Models.ViewModels
{
    public class AddEntryRequest
    {

        public int Id { get; set; }
        public required string Fname { get; set; }
        public required string Lname { get; set; }
        public DateTime Dob { get; set; }
        public required string City { get; set; }
        public required string Address { get; set; }
        public string FullName { 
            get { return Fname+ " "+Lname; }
                }
    }
}
