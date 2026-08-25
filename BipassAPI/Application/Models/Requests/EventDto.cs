using Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Requests
{
    public class EventDto
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string? Description { get; set; }
        public DateTime Date { get; set; }
        public string VenueName { get; set; }
        public bool IsStreaming { get; set; }
        [Required]
        public List<TicketTypeDto> TicketTypes { get; set; }  
    }
}
