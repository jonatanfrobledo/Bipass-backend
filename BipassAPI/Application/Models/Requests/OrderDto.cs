using System.ComponentModel.DataAnnotations;
namespace Application.Models.Requests
{
    public class OrderDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        [Required]
        public  string Status { get; set; }
        [Required]
        public decimal TotalAmount { get; set; }
        public DateTime OrderDate { get; set; }
        public List<OrderItemDto> OrderItems { get; set; } 
    }
}
