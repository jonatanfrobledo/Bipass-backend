using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Requests
{
    public class CreateVenueDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }

        public int Capacity { get; set; }
    }
}
