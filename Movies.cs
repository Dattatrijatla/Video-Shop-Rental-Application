namespace RentalVideoWebAPI.Models
{
    public class Movies
    {
        public Guid MovieId { get; set; }
        public string MovieTitle { get; set; }
        public string Director { get; set; }
        public DateTime Year { get; set; }
        public string Genre { get; set; }
        public string Language { get; set; }
    }
}
