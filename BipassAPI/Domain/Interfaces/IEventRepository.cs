using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IEventRepository
    {
        Task<List<Event>> GetEvents();

        Task<List<Event>> GetEventsByOrganizerId(int organizerId);

        Task AddEvent(Event newEvent);

        Task UpdateEvent(Event updatedEvent);

        Task DeleteEvent(int id);

        Task<Event?> GetEventById(int id);
    }
}