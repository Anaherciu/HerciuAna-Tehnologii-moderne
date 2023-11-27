namespace Rezervari.Models
{
    public class MovieModel
    {
        public int Id { get; set; }
        public int MovieTypeId { get; set; }
        public MovieTypeModel MovieType { get; set; } = null!;
        public string Name { get; set; } = null!;
  
        public string? Description { get; set; }

        public int Length { get; set; }
        public int Year { get; set; }
        public string Rating { get; set; } = null!;
        public string Director { get; set; } = null!;
        
    }
}
