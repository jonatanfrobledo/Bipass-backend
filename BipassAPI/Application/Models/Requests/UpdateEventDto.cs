using System.ComponentModel.DataAnnotations;

namespace Application.Models.Requests
{
    public class UpdateEventDto
    {
        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        public DateTime Date { get; set; }

        public bool IsStreaming { get; set; }

        public string StreamingUrl { get; set; }

        public string ImageUrl { get; set; }

        [Required]
        public CreateVenueDto Venue { get; set; }
    }
}
