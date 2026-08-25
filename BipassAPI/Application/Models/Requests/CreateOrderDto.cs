using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Requests
{
    public class CreateOrderDto
    {
        public int UserId { get; set; }
        [Required]
        public List<CreateOrderItemDto> Items { get; set; }
    }
    public class CreateOrderItemDto
    {
        public int TicketTypeId { get; set; }
        public int Quantity { get; set; }
    }
}
