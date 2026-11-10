using Application.Models.Requests;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services
{
    public class EventService
    {
        private readonly IEventRepository _eventRepository;

        public EventService(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public async Task<List<EventDto>> GetEventsAsync()
        {
            var events = await _eventRepository.GetEvents();

            return events
                .Where(e => e.IsActive)
                .Select(e => new EventDto
                {
                    Id = e.Id,
                    Name = e.Name,
                    Description = e.Description,
                    Date = e.Date,
                    ImageUrl = e.ImageUrl,
                    VenueName = e.Venue?.Name ?? "N/A",
                    IsStreaming = e.IsStreaming,

                    TicketTypes = e.TicketTypes.Select(tt => new TicketTypeDto
                    {
                        Id = tt.Id,
                        Name = tt.Name,
                        Price = tt.Price,
                        QuantityAvailable = tt.QuantityAvailable
                    }).ToList()
                }).ToList();
        }

        public async Task<List<EventDto>> GetEventsByOrganizerIdAsync(int organizerId)
        {
            var events = await _eventRepository.GetEventsByOrganizerId(organizerId);

            return events
                .Where(e => e.IsActive)
                .Select(e => new EventDto
                {
                    Id = e.Id,
                    Name = e.Name,
                    Description = e.Description,
                    Date = e.Date,
                    ImageUrl = e.ImageUrl,
                    VenueName = e.Venue?.Name ?? "N/A",
                    IsStreaming = e.IsStreaming,

                    TicketTypes = e.TicketTypes.Select(tt => new TicketTypeDto
                    {
                        Id = tt.Id,
                        Name = tt.Name,
                        Price = tt.Price,
                        QuantityAvailable = tt.QuantityAvailable
                    }).ToList()
                }).ToList();
        }
        public async Task<EventDto?> GetEventByIdAsync(int id)
        {
            var eventItem = await _eventRepository.GetEventById(id);

            if (eventItem == null || !eventItem.IsActive)
                return null;

            return new EventDto
            {
                Id = eventItem.Id,
                Name = eventItem.Name,
                Description = eventItem.Description,
                Date = eventItem.Date,
                ImageUrl = eventItem.ImageUrl,
                VenueName = eventItem.Venue?.Name ?? "N/A",
                IsStreaming = eventItem.IsStreaming,

                TicketTypes = eventItem.TicketTypes.Select(tt => new TicketTypeDto
                {
                    Id = tt.Id,
                    Name = tt.Name,
                    Price = tt.Price,
                    QuantityAvailable = tt.QuantityAvailable
                }).ToList()
            };
        }


        public async Task<int> AddEventAsync(CreateEventDto dto, int organizerId)
        {
            var newEvent = new Event
            {
                Name = dto.Name,
                Description = dto.Description,
                Date = dto.Date,
                ImageUrl = dto.ImageUrl,
                IsStreaming = dto.IsStreaming,
                StreamingUrl = dto.StreamingUrl,
                OrganizerId = organizerId,
                IsActive = true,

                Venue = new Venue
                {
                    Name = dto.Venue.Name,
                    Address = dto.Venue.Address,
                    Capacity = dto.Venue.Capacity
                },

                TicketTypes = dto.TicketTypes.Select(t => new TicketType
                {
                    Name = t.Name,
                    Price = t.Price,
                    QuantityAvailable = t.QuantityAvailable
                }).ToList()
            };

            await _eventRepository.AddEvent(newEvent);

            return newEvent.Id;
        }

        public async Task UpdateEventAsync(
            int id,
            UpdateEventDto dto,
            int currentUserId,
            string? userRole)
        {
            var existingEvent = await _eventRepository.GetEventById(id);

            if (existingEvent == null || !existingEvent.IsActive)
                throw new KeyNotFoundException($"No se encontró el evento con ID {id}.");

            if (userRole != "SuperAdmin" &&
                existingEvent.OrganizerId != currentUserId)
            {
                throw new UnauthorizedAccessException("No tienes permisos para modificar este evento.");
            }

            existingEvent.Name = dto.Name;
            existingEvent.Description = dto.Description;
            existingEvent.Date = dto.Date;
            existingEvent.ImageUrl = dto.ImageUrl;
            existingEvent.IsStreaming = dto.IsStreaming;
            existingEvent.StreamingUrl = dto.StreamingUrl;

            if (existingEvent.Venue != null && dto.Venue != null)
            {
                existingEvent.Venue.Name = dto.Venue.Name;
                existingEvent.Venue.Address = dto.Venue.Address;
                existingEvent.Venue.Capacity = dto.Venue.Capacity;
            }

            await _eventRepository.UpdateEvent(existingEvent);
        }

        public async Task DeleteEventAsync(
            int id,
            int currentUserId,
            string? userRole)
        {
            var existingEvent = await _eventRepository.GetEventById(id);

            if (existingEvent == null || !existingEvent.IsActive)
                throw new KeyNotFoundException($"No se encontró el evento con ID {id}.");

            if (userRole != "SuperAdmin" &&
                existingEvent.OrganizerId != currentUserId)
            {
                throw new UnauthorizedAccessException("No tienes permisos para eliminar este evento.");
            }

            existingEvent.IsActive = false;

            await _eventRepository.UpdateEvent(existingEvent);
        }
        public async Task<List<TicketTypeDto>> GetTicketTypesByEventIdAsync(int eventId)
        {
            var eventItem = await _eventRepository.GetEventById(eventId);

            if (eventItem == null || !eventItem.IsActive || eventItem.TicketTypes == null)
                return new List<TicketTypeDto>();

            return eventItem.TicketTypes.Select(tt => new TicketTypeDto
            {
                Id = tt.Id,
                Name = tt.Name,
                Price = tt.Price,
                QuantityAvailable = tt.QuantityAvailable
            }).ToList();
        }
    }
}