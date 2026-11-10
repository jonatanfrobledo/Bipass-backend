using System.ComponentModel.DataAnnotations;

namespace Application.Models.Requests
{
    public class CreateVenueDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }

        public int Capacity { get; set; }
    }
}
