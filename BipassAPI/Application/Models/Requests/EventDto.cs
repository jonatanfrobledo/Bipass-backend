using System.ComponentModel.DataAnnotations;

namespace Application.Models.Requests
{
    public class EventDto
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }

        public DateTime Date { get; set; }
        public string VenueName { get; set; }
        public bool IsStreaming { get; set; }
        [Required]
        public List<TicketTypeDto> TicketTypes { get; set; }  

    }
}
