using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Event
    {
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Name { get; set; }
        public string Description { get; set; }

        [Required]
        public DateTime Date { get; set; }

        public string? ImageUrl { get; set; }

        public bool IsStreaming { get; set; }
        public string? StreamingUrl { get; set; }

        // Clave Foránea a Venue
        public int VenueId { get; set; }
        [ForeignKey("VenueId")]
        public Venue? Venue { get; set; }

        public ICollection<TicketType> TicketTypes { get; set; } = new List<TicketType>();
    }
}