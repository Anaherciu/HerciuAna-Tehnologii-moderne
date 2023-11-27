namespace Rezervari.Models
{
    public class TicketModel
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public MovieModel Movie { get; set; } = null!;
        public double Price { get; set; }
        public DateTime DateTime { get; set; }
    }
}
