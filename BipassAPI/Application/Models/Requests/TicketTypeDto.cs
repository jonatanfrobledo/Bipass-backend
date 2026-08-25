using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Requests
{
    public class TicketTypeDto
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } // Ej: "General", "VIP", "Streaming"
        public Decimal Price { get; set; }
        public int QuantityAvailable { get; set; }

    }
}
