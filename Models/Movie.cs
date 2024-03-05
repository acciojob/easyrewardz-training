using System.ComponentModel.DataAnnotations;

namespace MVCTestApp.Models
{
    public class Movie
    {
        [Required]
        public string Name { get; set; }
        public string Director { get; set; }

        [Range(1,100)]
        public int Id { get; set; }
    }
}
