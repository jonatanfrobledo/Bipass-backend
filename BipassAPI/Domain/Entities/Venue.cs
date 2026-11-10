using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Venue
    {
        public int Id { get; set; }
        [Required]
        [StringLength(200)]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public int Capacity { get; set; }
        public ICollection<Event> Events { get; set; } 

    }
}
