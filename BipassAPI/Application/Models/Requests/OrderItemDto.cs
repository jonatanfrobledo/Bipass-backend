using System.ComponentModel.DataAnnotations;

namespace Application.Models.Requests
{
    public class OrderItemDto
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public string Name { get; set; } = string.Empty;
        public string TicketTypeName { get; set; } = string.Empty;
        public string EventTitle { get; set; } = string.Empty;
        public string EventLocation { get; set; } = string.Empty;
        public string EventDate { get; set; } = string.Empty;
    }
}
