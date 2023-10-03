namespace RentalVideoWebAPI.Models
{
    public class AddRentalRequest
    {
        public Guid RentalId { get; set; }
        public Guid CustomerId { get; set; }
        public Guid MovieId { get; set; }
        public DateTime RentalDate { get; set; }
        public DateTime ReturnDate { get; set; }
    }
}
