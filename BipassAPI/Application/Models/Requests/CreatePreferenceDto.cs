using System.ComponentModel.DataAnnotations;

namespace Application.Models.Requests
{
    public class CreatePreferenceDto
    {
        public int UserId { get; set; }
        public decimal TotalAmount { get; set; }

        [Required]
        public List<CheckoutItemDto> Items { get; set; }
    }
}