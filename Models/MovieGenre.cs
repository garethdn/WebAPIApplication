namespace WebAPIApplication.Models
{
    public class MovieGenre
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public int GenreId { get; set; }
        public Genre Genre { get; set; }
    }
}