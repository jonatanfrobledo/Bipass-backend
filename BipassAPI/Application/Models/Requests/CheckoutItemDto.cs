namespace Application.Models.Requests
{
    public class CheckoutItemDto
    {
        public int TicketTypeId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public string TicketTypeName { get; set; }
    }
}