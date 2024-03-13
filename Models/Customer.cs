using System.ComponentModel.DataAnnotations;

namespace MVCTestApp.Models
{
    public class Customer
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string City { get; set; }
        public string Gender { get; set; }
    }
}
