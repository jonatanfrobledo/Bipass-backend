using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Repository
{
    public class EventRepository : IEventRepository
    {
        private readonly BipassDbContext _dbContext;
        public EventRepository(BipassDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<Event>> GetEvents()
        {
            return await _dbContext.Events
                .Include(e => e.Venue)
                .Include(e => e.TicketTypes)
                .ToListAsync();
        }
        public async Task<Event?> GetEventById(int id)
        {
            return await _dbContext.Events
                .Include(e => e.Venue)
                .Include(e => e.TicketTypes)
                .Where(e=> e.IsActive)
                .FirstOrDefaultAsync(e => e.Id == id);
        }
        public async Task AddEvent(Event newEvent)
        {
            _dbContext.Events.Add(newEvent);
            await _dbContext.SaveChangesAsync();
        }
        public async Task UpdateEvent(Event updatedEvent)
        {
            _dbContext.Events.Update(updatedEvent);
            await _dbContext.SaveChangesAsync();
        }
        public async Task<List<Event>> GetEventsByOrganizerId(int organizerId)
        {
            return await _dbContext.Events
                .Include(e => e.Venue)
                .Include(e => e.TicketTypes)
                .Where(e => e.OrganizerId == organizerId)
                .ToListAsync();
        }
        public async Task DeleteEvent(int id)
        {
            var eventToDelete = await _dbContext.Events.FindAsync(id);
            if (eventToDelete != null)
            {
                _dbContext.Events.Remove(eventToDelete);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
