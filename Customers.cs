namespace RentalVideoWebAPI.Models
{
    public class Customers
    {
        public Guid CustomerId { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
    }
}
