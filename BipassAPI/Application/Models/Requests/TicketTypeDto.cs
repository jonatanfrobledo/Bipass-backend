using System.ComponentModel.DataAnnotations;

namespace Application.Models.Requests
{
    public class TicketTypeDto
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public Decimal Price { get; set; }
        public int QuantityAvailable { get; set; }

    }
}
