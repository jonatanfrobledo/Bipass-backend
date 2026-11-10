using System.ComponentModel.DataAnnotations;

namespace Application.Models.Requests
{
    public class OrderItemDto
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        [Required]
        public string TicketTypeName { get; set; }
    }
}
