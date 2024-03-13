using System.ComponentModel.DataAnnotations;

namespace MVCTestApp.Models
{
    public class Movie
    {
        [Range(1, 100)]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Director { get; set; }

      
    }
}
