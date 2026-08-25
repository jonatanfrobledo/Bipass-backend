using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IEventRepository
    {
        // Obtiene la lista completa de eventos.
        public Task<List<Event>> GetEvents();

        // Agrega un nuevo evento.
        public Task AddEvent(Event newEvent);

        // Actualiza un evento existente.
        public Task UpdateEvent(Event updatedEvent);

        // Elimina un evento por su ID.
        public Task DeleteEvent(int id);

        // Obtiene un evento específico por su ID.
        public Task<Event?> GetEventById(int id);
    }
}
