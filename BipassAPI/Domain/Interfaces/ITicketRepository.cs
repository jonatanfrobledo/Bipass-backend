using Domain.Entities;

namespace Domain.Interfaces
{
    public interface ITicketTypeRepository
    {
        public Task<List<TicketType>> GetTicketTypesByEvent(int eventId);

        public Task UpdateQuantity(int ticketTypeId, int quantity);

        public Task<TicketType?> GetTicketTypeById(int id);
    }
}
