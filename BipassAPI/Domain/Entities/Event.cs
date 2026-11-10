using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Event
    {
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        [Required]
        public DateTime Date { get; set; }

        public string? ImageUrl { get; set; }

        public bool IsStreaming { get; set; }
        public string? StreamingUrl { get; set; }

        public bool IsActive { get; set; } = true;
        public int? OrganizerId { get; set; }

        [ForeignKey("OrganizerId")]
        public User? Organizer { get; set; }

        public int VenueId { get; set; }
        [ForeignKey("VenueId")]
        public Venue? Venue { get; set; }

        public ICollection<TicketType> TicketTypes { get; set; } = new List<TicketType>();
    }
}