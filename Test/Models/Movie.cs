using System.ComponentModel.DataAnnotations;

namespace Test.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        [DataType(DataType.Date)]
        public DateTime? ReleaseYear { get; set; }
        public string? Gender { get; set; }
        [DataType(DataType.Time)]
        public TimeSpan? Duration { get; set; }

        public int DirectorId { get; set; }
        public Director? Director { get; set; }
    }
}
