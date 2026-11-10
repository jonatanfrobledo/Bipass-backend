using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Repository
{
    public class TicketTypeRepository : ITicketTypeRepository
    {
        private readonly BipassDbContext _dbContext;

        public TicketTypeRepository(BipassDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<TicketType>> GetTicketTypesByEvent(int eventId)
        {
            return await _dbContext.TicketTypes.Where(tt => tt.EventId == eventId).ToListAsync();
        }

        public async Task UpdateQuantity(int ticketTypeId, int quantity)
        {
            var ticketType = await _dbContext.TicketTypes.FindAsync(ticketTypeId);
            if (ticketType != null)
            {
                ticketType.QuantityAvailable = quantity;
                _dbContext.TicketTypes.Update(ticketType);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<TicketType?> GetTicketTypeById(int id)
        {
            return await _dbContext.TicketTypes.FindAsync(id);
        }
    }
}
