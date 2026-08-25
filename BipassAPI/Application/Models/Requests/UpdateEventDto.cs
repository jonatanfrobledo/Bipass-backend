using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
