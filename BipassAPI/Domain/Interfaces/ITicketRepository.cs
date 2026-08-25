using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface ITicketTypeRepository
    {
        // Obtiene todos los tipos de entrada para un evento.
        public Task<List<TicketType>> GetTicketTypesByEvent(int eventId);

        // Actualiza la cantidad disponible de un tipo de entrada.
        public Task UpdateQuantity(int ticketTypeId, int quantity);

        // Obtiene un tipo de entrada por su ID.
        public Task<TicketType?> GetTicketTypeById(int id);
    }
}
