using System.ComponentModel.DataAnnotations;

namespace Application.Models.Requests
{
    public class CreateTicketTypeDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public decimal Price { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int QuantityAvailable { get; set; }
    }
}
