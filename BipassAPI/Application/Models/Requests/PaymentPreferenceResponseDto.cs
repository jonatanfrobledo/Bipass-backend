using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Requests
{
    public class PaymentPreferenceResponseDto
    {
        public int OrderId { get; set; }
        public string PreferenceId { get; set; }
        public string InitPoint { get; set; } // URL de checkout sandbox / producción
    }
}
